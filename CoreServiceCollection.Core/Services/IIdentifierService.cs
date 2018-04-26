using System;

namespace CoreServiceCollection.Core.Services
{
    public interface IIdentifierService
    {
        Guid Id { get; }
    }

    public interface IIdentifierServiceTransient : IIdentifierService
    {
    }

    public interface IIdentifierServiceScoped : IIdentifierService
    {
    }
}