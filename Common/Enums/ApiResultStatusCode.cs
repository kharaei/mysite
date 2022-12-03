using System.ComponentModel.DataAnnotations;

namespace Kharaei.Common;

 public enum ApiResultStatusCode
    {
        [Display(Name = "LogicError")]
        LogicError = 100,

        [Display(Name = "Done")]
        Success = 200,

        [Display(Name = "BadRequest")]
        BadRequest = 400,

        [Display(Name = "Unauthorized")]
        UnAuthorized = 401,

        [Display(Name = "Forbidden")]
        Forbidden = 403, 

        [Display(Name = "NotFound")]
        NotFound = 404,

        [Display(Name = "ServerError")]
        ServerError = 500
    }