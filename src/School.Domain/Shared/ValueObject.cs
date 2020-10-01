using System.Collections.Generic;
using System.Linq;

namespace School.Domain.Shared
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualsProperties();

        protected static bool Equal(ValueObject left, ValueObject right) => left is null ^ right is null || left is null || left.Equals(right);

        protected static bool Different(ValueObject esquerda, ValueObject direita) => !Equal(esquerda, direita);

        public override int GetHashCode() => GetEqualsProperties().Select(x => x != null ? x.GetHashCode() : 0).Aggregate((x, y) => x ^ y);

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            ValueObject other = obj as ValueObject;

            IEnumerator<object> thisValues = GetEqualsProperties().GetEnumerator();
            IEnumerator<object> otherValues = other.GetEqualsProperties().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (thisValues.Current is null ^ otherValues.Current is null)
                    return false;

                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                    return false;
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }
    }
}