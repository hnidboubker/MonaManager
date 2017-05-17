using System;
using System.Collections.Generic;

namespace Mona.Server.Domain.Entities
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
            if (EqualityComparer<TKey>.Default.Equals(Id, default(TKey)))
            {
                return true;
            }

            //Workaround for EF Core since it sets int/long to min value when attaching to dbcontext
            if (typeof (TKey) == typeof (int))
            {
                return Convert.ToInt32(Id) <= 0;
            }

            if (typeof (TKey) == typeof (long))
            {
                return Convert.ToInt64(Id) <= 0;
            }

            return false;
        }
    }
}