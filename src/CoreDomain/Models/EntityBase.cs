using CoreDomain.Interfaces;
using System;
using System.Collections.Generic;

namespace CoreDomain
{
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        protected EntityBase() { }

        protected EntityBase(TKey id) => Id = id;

        public TKey Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var entity = obj as EntityBase<TKey>;

            return entity != null &&
                   GetType() == entity.GetType() &&
                   EqualityComparer<TKey>.Default.Equals(Id, entity.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }

        public static bool operator ==(EntityBase<TKey> entity1, EntityBase<TKey> entity2)
        {
            return EqualityComparer<EntityBase<TKey>>.Default.Equals(entity1, entity2);
        }

        public static bool operator !=(EntityBase<TKey> entity1, EntityBase<TKey> entity2)
        {
            return !(entity1 == entity2);
        }
    }
}
