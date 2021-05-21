using System;
using System.Collections.Generic;
using System.Linq;

namespace Andtech
{

	[Flags]
	public enum RandomizationOptions
	{
		Infinite,
		/// <summary>
		/// Elements cannot be selected more than once.
		/// </summary>
		NoReplacement,
		/// <summary>
		/// Elements cannot appear consecutively.
		/// </summary>
		NoConsecutiveValues
	}

	/// <summary>
	/// Returns a random index.
	/// </summary>
	/// <param name="count">The upper bound (exclusive) of the index range.</param>
	/// <returns>The random index.</returns>
	public delegate int RandomIndex(int count);

	public static class RandomizationExtensions
	{

		/// <summary>
		/// Retrieves an element using pure randomness.
		/// </summary>
		/// <typeparam name="T">The type of the elements.</typeparam>
		/// <param name="collection">The set of elements to randomize.</param>
		/// <returns>The randomly selected element.</returns>
		public static T GetRandom<T>(this IEnumerable<T> collection) => GetRandom(collection, UnityRandom);

		/// <summary>
		/// Retrieves an element using pure randomness.
		/// </summary>
		/// <typeparam name="T">The type of the elements.</typeparam>
		/// <param name="collection">The set of elements to randomize.</param>
		/// <param name="randomizer">The random index strategy.</param>
		/// <returns>The randomly selected element.</returns>
		public static T GetRandom<T>(this IEnumerable<T> collection, RandomIndex randomizer)
		{
			int n = collection.Count();
			int index = randomizer(n);

			return collection.ElementAt(index);
		}

		/// <summary>
		/// Yields a random sequence of elements.
		/// </summary>
		/// <typeparam name="T">The type of elements.<typeparam>
		/// <param name="collection">The set of elements to randomize.</param>
		/// <returns>The random sequence of elements.</returns>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> collection) => Randomize(collection, RandomizationOptions.NoReplacement);

		/// <summary>
		/// Yields a random sequence of elements.
		/// </summary>
		/// <typeparam name="T">The type of elements.<typeparam>
		/// <param name="collection">The set of elements to randomize.</param>
		/// <param name="options">The parameters of randomization.</param>
		/// <returns>The random sequence of elements.</returns>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> collection, RandomizationOptions options) => Randomize(collection, options, UnityRandom);

		/// <summary>
		/// Yields a random sequence of elements.
		/// </summary>
		/// <typeparam name="T">The type of elements.<typeparam>
		/// <param name="collection">The set of elements to randomize.</param>
		/// <param name="options">The parameters of randomization.</param>
		/// <param name="randomizer">The random index strategy.</param>
		/// <returns>The random sequence of elements.</returns>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> collection, RandomizationOptions options, RandomIndex randomizer) => Randomize(collection.ToList(), options, randomizer);

		/// <summary>
		/// Yields a random sequence of elements.
		/// </summary>
		/// <typeparam name="T">The type of elements.<typeparam>
		/// <param name="list">The set of elements to randomize.</param>
		/// <returns>The random sequence of elements.</returns>
		public static IEnumerable<T> Randomize<T>(this IList<T> list) => Randomize(list, RandomizationOptions.NoReplacement);

		/// <summary>
		/// Yields a random sequence of elements.
		/// </summary>
		/// <typeparam name="T">The type of elements.<typeparam>
		/// <param name="list">The set of elements to randomize.</param>
		/// <param name="options">The parameters of randomization.</param>
		/// <returns>The random sequence of elements.</returns>
		public static IEnumerable<T> Randomize<T>(this IList<T> list, RandomizationOptions options) => Randomize(list, options, UnityRandom);

		/// <summary>
		/// Yields a random sequence of elements.
		/// </summary>
		/// <typeparam name="T">The type of elements.<typeparam>
		/// <param name="list">The set of elements to randomize.</param>
		/// <param name="options">The parameters of randomization.</param>
		/// <param name="randomizer">The random index strategy.</param>
		/// <returns>The random sequence of elements.</returns>
		public static IEnumerable<T> Randomize<T>(this IList<T> list, RandomizationOptions options, RandomIndex randomizer)
		{
			int n = list.Count;
			int size = n;

			while (size > 0)
			{
				int index = randomizer(size);
				T element = list[index];

				if (options.HasFlag(RandomizationOptions.NoReplacement))
				{
					size--;
					Hide(index);
				}
				else
				{
					if (options.HasFlag(RandomizationOptions.NoConsecutiveValues))
					{
						size = n - 1;
						Hide(index);
					}
				}

				yield return element;
			}

			#region PIPELINE
			void Hide(int i) => list.Swap(i, size);
			#endregion
		}

		/// <summary>
		/// Randomly reorders elements in <paramref name="list"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements.</typeparam>
		/// <param name="list">The set of elements to randomize.</param>
		public static void Shuffle<T>(this IList<T> list) => Shuffle(list, UnityRandom);

		/// <summary>
		/// Randomly reorders elements in <paramref name="list"/>.
		/// </summary>
		/// <typeparam name="T">The type of the elements.</typeparam>
		/// <param name="list">The set of elements to randomize.</param>
		/// <param name="randomizer">The random index strategy.</param>
		public static void Shuffle<T>(this IList<T> list, RandomIndex randomizer)
		{
			int size = list.Count;

			while (size > 0)
			{
				int index = randomizer(size);
				list.Swap(index, --size);
			}
		}

		private static int UnityRandom(int max) => UnityEngine.Random.Range(0, max);
	}
}
