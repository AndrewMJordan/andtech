/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech
{

	public static class MatrixUtility
	{

		/// <summary>
		/// Returns a matrix which transforms from relative to world coordinates.
		/// </summary>
		/// <param name="basis0">The system's "X axis".</param>
		/// <param name="basis1">The system's "Y axis".</param>
		/// <param name="basis1">The system's "Z axis".</param>
		/// <returns>The transformation matrix.</returns>
		public static Matrix4x4 GetGlobalizationMatrix(Vector3 basis0, Vector3 basis1, Vector3 basis2) => GetGlobalizationMatrix(basis0, basis1, basis2, Vector3.zero);

		/// <summary>
		/// Returns a matrix which transforms from relative to world coordinates.
		/// </summary>
		/// <param name="basis0">The system's "X axis".</param>
		/// <param name="basis1">The system's "Y axis".</param>
		/// <param name="basis1">The system's "Z axis".</param>
		/// <param name="position">The system's origin (world space).</param>
		/// <returns>The transformation matrix.</returns>
		public static Matrix4x4 GetGlobalizationMatrix(Vector3 basis0, Vector3 basis1, Vector3 basis2, Vector3 position)
		{
			Matrix4x4 translation = Matrix4x4.Translate(position);
			Matrix4x4 b = new Matrix4x4(basis0, basis1, basis2, new Vector4(0.0F, 0.0F, 0.0F, 1.0F));
			return translation * b;
		}

		/// <summary>
		/// Returns a matrix which transforms from world to relative coordinates.
		/// </summary>
		/// <param name="basis0">The system's "X axis".</param>
		/// <param name="basis1">The system's "Y axis".</param>
		/// <param name="basis1">The system's "Z axis".</param>
		/// <returns>The transformation matrix.</returns>
		public static Matrix4x4 GetLocalizationMatrix(Vector3 basis0, Vector3 basis1, Vector3 basis2) => GetLocalizationMatrix(basis0, basis1, basis2, Vector3.zero);

		/// <summary>
		/// Returns a matrix which transforms from world to relative coordinates.
		/// </summary>
		/// <param name="position">The system's origin (world space).</param>
		/// <param name="basis0">The system's "X axis".</param>
		/// <param name="basis1">The system's "Y axis".</param>
		/// <param name="basis1">The system's "Z axis".</param>
		/// <returns>The transformation matrix.</returns>
		public static Matrix4x4 GetLocalizationMatrix(Vector3 basis0, Vector3 basis1, Vector3 basis2, Vector3 position) => GetGlobalizationMatrix(basis0, basis1, basis2, position).inverse;
	}
}
