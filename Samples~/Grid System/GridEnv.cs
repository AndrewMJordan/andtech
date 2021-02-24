/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech {

	public class GridEnv : SubsystemBehaviour<GridEnv> {
		/// <summary>
		/// The (real) size of 1 cell.
		/// </summary>
		public Vector3 CellScale => basisTransform.localScale;
		public Vector3 HalfCellScale => CellScale * 0.5F;
		public Basis Basis => basis;
		public Quaternion Rotation => basisTransform.rotation;
		public Matrix4x4 Matrix => basisTransform.localToWorldMatrix;

		[SerializeField]
		private Transform basisTransform;
		private Basis basis;

		/// <summary>
		/// Converts a grid position to world coordinates.
		/// </summary>
		/// <param name="cell">The cell coordinates.</param>
		/// <returns>The world coordinates.</returns>
		public Vector3 TransformPoint(Vector3 cell) => basisTransform.TransformPoint(cell);

		/// <summary>
		/// Converts a grid position to world coordinates with an offest.
		/// </summary>
		/// <param name="cell">The cell coordinates.</param>
		/// <param name="offset">The offset within the cell.</param>
		/// <returns>The world coordinates.</returns>
		public Vector3 TransformPoint(Vector3 cell, Rotation offset) {
			var cellOffset = ((Vector3)(offset * VECTOR3INT.forward)) * 0.5F;
			return TransformPoint(cell + 0.5F * Vector3.one + cellOffset);
		}

		/// <summary>
		/// Converts a grid direction to world space.
		/// </summary>
		/// <param name="vector">The direction (grid space).</param>
		/// <returns>The direction (world space)</returns>
		public Vector3 TransformVector(Vector3 vector) => basisTransform.TransformVector(vector);

		/// <summary>
		/// Converts a world space position to grid coordinates. 
		/// </summary>
		/// <param name="position">The world space coordinates.</param>
		/// <returns>The cell coordinates.</returns>
		public Vector3 InverseTransformPoint(Vector3 position) => basisTransform.InverseTransformPoint(position);

		public Quaternion Rotate(Quaternion rotation) => basisTransform.rotation * rotation;

		public Vector3 Rotate(Vector3 vector) => basisTransform.rotation * vector;

		#region MONOBEHAVIOUR
		protected virtual void Awake() {
			SetupBasis();
			DebugGrid.Transformation = Matrix;

			void SetupBasis() {
				Vector3 b0 = basisTransform.right;
				Vector3 b1 = basisTransform.up;
				Vector3 b2 = basisTransform.forward;

				b0 = b0 * basisTransform.localScale.x;
				b1 = b1 * basisTransform.localScale.y;
				b2 = b2 * basisTransform.localScale.z;

				Quaternion rotation = basisTransform.rotation;
				b0 = rotation * b0;
				b1 = rotation * b1;
				b2 = rotation * b2;

				basis = new Basis(b0, b1, b2, basisTransform.position);
			}
		}
		#endregion
	}
}
