
namespace UnityEngine {

	/// <summary>
	/// Missing vector features. Note: if/when Unity adds these to their API, simply replace "VECTOR3INT" with Vector3Int.
	/// </summary>
	public static class VECTOR3INT {
		public static Vector3Int forward => new Vector3Int(0, 0, 1);
		public static Vector3Int back => new Vector3Int(0, 0, -1);

		/// <summary>
		/// Dot product of two vectors.
		/// </summary>
		/// <param name="lhs">Left-hand side.</param>
		/// <param name="rhs">Right-hand side.</param>
		/// <returns>The dot product.</returns>
		public static int Dot(Vector3Int lhs, Vector3Int rhs) => lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;

		public static Vector3Int Cross(Vector3Int a, Vector3Int b) {
			return new Vector3Int {
				x = a.y * b.z - a.z * b.y,
				y = a.z * b.x - a.x * b.z,
				z = a.x * b.y - a.y * b.x
			};
		}
	}
}