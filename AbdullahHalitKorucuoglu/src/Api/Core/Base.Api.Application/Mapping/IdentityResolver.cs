using AutoMapper;
using Base.Api.Application.Services;

namespace Base.Api.Application.Mapping;

public class IdentityResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, int> where TSource : class where TDestination : class
{
    private readonly IIdentityService _service;

    public IdentityResolver(IIdentityService service)
    {
        _service = service;
    }

    public int Resolve(TSource source, TDestination destination, int destMember, ResolutionContext context)
    {
        return _service.GetUserDecodeId;
    }
}