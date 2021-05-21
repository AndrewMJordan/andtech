using UnityEngine;

namespace Andtech
{

	public static class Vector2IntExtensions
	{

		/// <summary>
		/// Selects components from a vector.
		/// </summary>
		/// <param name="original">The original vector.</param>
		/// <param name="x">New x component value.</param>
		/// <param name="y">New y component value.</param>
		/// <returns>A combination of the original and new values.</returns>
		public static Vector2Int With(this Vector2Int original, int? x = null, int? y = null) => new Vector2Int
		{
			x = x ?? original.x,
			y = y ?? original.y
		};

		/// <summary>
		/// Dot product of two vectors.
		/// </summary>
		/// <param name="lhs">Left-hand side.</param>
		/// <param name="rhs">Right-hand side.</param>
		/// <returns>The dot product.</returns>
		public static int Dot(this Vector2Int lhs, Vector2Int rhs) => lhs.x * rhs.x + lhs.y * rhs.y;

		/// <summary>
		/// Reduces the vector to its minimum equivalent representation.
		/// </summary>
		/// <param name="vector">The vector to reduce.</param>
		/// <returns>The minimum equivalent vector.</returns>
		public static Vector2Int Reduce(this Vector2Int vector)
		{
			if (vector == Vector2Int.zero)
			{
				return vector;
			}

			int gcd = MathfA.GCD(
				Mathf.Abs(vector.x),
				Mathf.Abs(vector.y)
			);
			return new Vector2Int()
			{
				x = vector.x / gcd,
				y = vector.y / gcd
			};
		}

		/// <summary>
		/// Reduces the vector to its minimum equivalent representation.
		/// </summary>
		/// <param name="vector">The vector to reduce.</param>
		/// <param name="count">The multiplier required to reconstruct the original vector.</param>
		/// <returns>The minimum equivalent vector.</returns>
		public static Vector2Int Reduce(this Vector2Int vector, out int scale)
		{
			if (vector == Vector2Int.zero)
			{
				scale = 0;
				return vector;
			}

			var reduced = Reduce(vector);
			var sqrScale = vector.sqrMagnitude / reduced.sqrMagnitude;
			scale = Mathf.RoundToInt(Mathf.Sqrt(sqrScale));

			return reduced;
		}

		/// <summary>
		/// Returns a vector of signs of components in <paramref name="vector"/>.
		/// </summary>
		/// <param name="vector">The vector to convert.</param>
		/// <returns>The vector whose components are the signs of the components in <paramref name="vector"/>.</returns>
		public static Vector2Int Sign(this Vector2Int vector)
		{
			vector.x = Sign(vector.x);
			vector.y = Sign(vector.y);
			return vector;

			#region LOCAL_FUNCTIONS
			int Sign(int x)
			{
				if (x < 0)
				{
					return -1;
				}

				if (x > 0)
				{
					return 1;
				}

				return 0;
			}
			#endregion
		}
	}
}
