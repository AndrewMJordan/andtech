/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

namespace UnityEngine {

	/// <summary>
	/// Missing vector features. Note: if/when Unity adds these to their API, simply replace "VECTOR2INT" with Vector2Int.
	/// </summary>
	public static class VECTOR2INT {

		/// <summary>
		/// Dot product of two vectors.
		/// </summary>
		/// <param name="lhs">Left-hand side.</param>
		/// <param name="rhs">Right-hand side.</param>
		/// <returns>The dot product.</returns>
		public static int Dot(Vector2Int lhs, Vector2Int rhs) => lhs.x * rhs.x + lhs.y * rhs.y;
	}
}