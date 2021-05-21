using UnityEngine;

namespace Andtech
{

	public static class Vector3IntExtensions
	{

		/// <summary>
		/// Selects components from a vector.
		/// </summary>
		/// <param name="original">The original vector.</param>
		/// <param name="x">New x component value.</param>
		/// <param name="y">New y component value.</param>
		/// <param name="z">New z component value.</param>
		/// <returns>A combination of the original and new values.</returns>
		public static Vector3Int With(this Vector3Int original, int? x = null, int? y = null, int? z = null) => new Vector3Int
		{
			x = x ?? original.x,
			y = y ?? original.y,
			z = z ?? original.z
		};

		/// <summary>
		/// Returns a copy of the vector which points in the opposite direction.
		/// </summary>
		/// <param name="vector">The vector to reverse.</param>
		/// <returns>The reversed vector.</returns>
		public static Vector3Int Reverse(this Vector3Int vector)
		{
			return new Vector3Int()
			{
				x = -vector.x,
				y = -vector.y,
				z = -vector.z
			};
		}

		/// <summary>
		/// Reduces the vector to its minimum equivalent representation.
		/// </summary>
		/// <param name="vector">The vector to reduce.</param>
		/// <returns>The minimum equivalent vector.</returns>
		public static Vector3Int Reduce(this Vector3Int vector)
		{
			if (vector == Vector3Int.zero)
			{
				return Vector3Int.zero;
			}

			int gcd = MathfA.GCD(
				Mathf.Abs(vector.x),
				Mathf.Abs(vector.y),
				Mathf.Abs(vector.z)
			);
			return new Vector3Int()
			{
				x = vector.x / gcd,
				y = vector.y / gcd,
				z = vector.z / gcd
			};
		}

		/// <summary>
		/// Reduces the vector to its minimum equivalent representation.
		/// </summary>
		/// <param name="vector">The vector to reduce.</param>
		/// <param name="count">The multiplier required to reconstruct the original vector.</param>
		/// <returns>The minimum equivalent vector.</returns>
		public static Vector3Int Reduce(this Vector3Int vector, out int scale)
		{
			if (vector == Vector3Int.zero)
			{
				scale = 0;
				return Vector3Int.zero;
			}

			Vector3Int reduced = Reduce(vector);
			long sqrScale = vector.sqrMagnitude / reduced.sqrMagnitude;
			scale = Mathf.RoundToInt(Mathf.Sqrt(sqrScale));

			return reduced;
		}

		public static Vector2Int To2D(this Vector3Int vector)
		{
			return new Vector2Int()
			{
				x = vector.x,
				y = vector.y
			};
		}

		/// <summary>
		/// Returns a vector of signs of components in <paramref name="vector"/>.
		/// </summary>
		/// <param name="vector">The vector to convert.</param>
		/// <returns>The vector whose components are the signs of the components in <paramref name="vector"/>.</returns>
		public static Vector3Int Sign(this Vector3Int vector)
		{
			vector.x = Sign(vector.x);
			vector.y = Sign(vector.y);
			vector.z = Sign(vector.z);
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
