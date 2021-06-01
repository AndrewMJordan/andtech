using System;
using System.Collections.Generic;
using System.Linq;

namespace Andtech
{

    public static class LinqExtensions
    {

        public static bool TryFirst<T>(this IEnumerable<T> enumerable, out T value)
        {
            bool contains = enumerable.Any();
            value = contains ? enumerable.First() : default;

            return contains;
        }

        public static bool TryFirst<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, out T value)
        {
            bool contains = enumerable.Any(predicate);
            value = contains ? enumerable.First(predicate) : default;

            return contains;
        }

        public static bool TryLast<T>(this IEnumerable<T> enumerable, out T value)
        {
            bool contains = enumerable.Any();
            value = contains ? enumerable.Last() : default;

            return contains;
        }

        public static bool TryLast<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, out T value)
        {
            bool contains = enumerable.Any(predicate);
            value = contains ? enumerable.Last(predicate) : default;

            return contains;
        }

        public static bool TrySingle<T>(this IEnumerable<T> enumerable, out T value)
        {
            bool contains = enumerable.Any();
            value = contains ? enumerable.Single() : default;

            return contains;
        }

        public static bool TrySingle<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, out T value)
        {
            bool contains = enumerable.Any(predicate);
            value = contains ? enumerable.Single(predicate) : default;

            return contains;
        }
    }
}
