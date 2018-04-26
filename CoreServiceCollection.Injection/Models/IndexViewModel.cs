using System;

namespace CoreServiceCollection.Injection.Models
{
    public class IndexViewModel
    {
        public Guid ScopedId { get; set; }
        public Guid OtherScopedId { get; set; }
        public Guid TransientId { get; set; }
        public Guid OtherTransientId { get; set; }
    }
}