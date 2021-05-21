using UnityEngine;

namespace Andtech
{

	/// <summary>
	/// Describes a region in 2D space.
	/// </summary>
	public struct Region
	{
		public readonly Matrix4x4 transformation;

		public Region(Vector2 origin, Vector2 basis0, Vector2 basis1)
		{
			transformation = MatrixUtility.GetLocalizationMatrix(origin, basis0, basis1);
		}

		/// <summary>
		/// Tests whether the point overlaps the region (triangular).
		/// </summary>
		/// <param name="point">The position of the point.</param>
		/// <returns>The point overlaps the region (triangular).</returns>
		public bool OverlapsTriangular(Vector2 point)
		{
			// Transform to "B coordinates"
			Vector2 bCoordinates = transformation.MultiplyPoint3x4(point);

			// Examine the "B coordinates" to determine overlap
			bool overlapping =
				(bCoordinates.x >= 0.0F && bCoordinates.y >= 0.0F) &&
				(bCoordinates.y <= 1.0F - bCoordinates.x);

			return overlapping;
		}

		/// <summary>
		/// Tests whether the point overlaps the region (rectangular).
		/// </summary>
		/// <param name="point">The position of the point.</param>
		/// <returns>The point overlaps the region (rectangular).</returns>
		public bool OverlapsRectangular(Vector2 point)
		{
			// Transform to "B coordinates"
			Vector2 bCoordinates = transformation.MultiplyPoint3x4(point);

			// Examine the "B coordinates" to determine overlap
			bool overlapping =
				(bCoordinates.x >= 0.0F && bCoordinates.x <= 1.0F) &&
				(bCoordinates.y >= 0.0F && bCoordinates.y <= 1.0F);

			return overlapping;
		}
	}
}
