
namespace UnityEngine
{

	/// <summary>
	/// Missing vector features. Note: if/when Unity adds these to their API, simply replace "VECTOR2INT" with Vector2Int.
	/// </summary>
	public static class VECTOR2INT
	{

		/// <summary>
		/// Dot product of two vectors.
		/// </summary>
		/// <param name="lhs">Left-hand side.</param>
		/// <param name="rhs">Right-hand side.</param>
		/// <returns>The dot product.</returns>
		public static int Dot(Vector2Int lhs, Vector2Int rhs) => lhs.x * rhs.x + lhs.y * rhs.y;
	}
}