using System;

namespace CoreServiceCollection.Core.Services
{
    public class IdentifierService : IIdentifierServiceScoped, IIdentifierServiceTransient
    {
        public IdentifierService()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}