using System.Collections.Generic;

namespace Mona.Web.Infrastructure
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
        bool IsTransient();
    }

    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
        public bool IsTransient()
        {
            return EqualityComparer<TKey>.Default.Equals(Id, default(TKey));
        }
    }
}