using System.Collections.Generic;

namespace Andtech
{

    public static class IListExtensions
    {

        /// <summary>
        /// Swaps the element at <paramref name="indexA"/> with the element at <paramref name="indexB"/>.
        /// </summary>
        /// <typeparam name="T">The type of list elements</typeparam>
        /// <param name="list">The list to use in the swap.</param>
        /// <param name="indexA">The index of an element.</param>
        /// <param name="indexB">The index of the other element.</param>
        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }
    }
}
