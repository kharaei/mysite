using AutoMapper;

namespace Kharaei.Infra;

public interface IHaveCustomMapping
{
    void CreateMappings(Profile profile);
}