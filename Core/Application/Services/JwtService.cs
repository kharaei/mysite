using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Kharaei.Domain;
using Microsoft.Extensions.Options;
using System.Text;

namespace  Kharaei.Application;

public class JwtService : IJwtService
{
    private readonly SiteSettings _siteSetting;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public JwtService(IOptionsSnapshot<SiteSettings> settings, SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _siteSetting = settings.Value;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<string> Generate(User user)
    { 
        var secretKey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.SecretKey); // longer that 16 character
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

        var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.Encryptkey); //must be 16 character
        var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

        var claims = await _getClaimsAsync(user);

        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _siteSetting.JwtSettings.Issuer,
            Audience = _siteSetting.JwtSettings.Audience,
            IssuedAt = DateTime.Now,
            NotBefore = DateTime.Now.AddMinutes(_siteSetting.JwtSettings.NotBeforeMinutes),
            Expires = DateTime.Now.AddMinutes(_siteSetting.JwtSettings.ExpirationMinutes),
            SigningCredentials = signingCredentials,
            EncryptingCredentials = encryptingCredentials,
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(descriptor);

        var jwt = tokenHandler.WriteToken(securityToken);

        return jwt;
    } 

    private async Task<IEnumerable<Claim>> _getClaimsAsync(User user)
    {
        var result = await _signInManager.ClaimsFactory.CreateAsync(user);
          
        var list = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
        }; 
        
        var roles = _userManager.GetRolesAsync(user).Result;
        foreach (var role in roles)           
            list.Add(new Claim(ClaimTypes.Role, role));

        return list;
    }
}