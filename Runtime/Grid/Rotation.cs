/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Represents a cardinal rotation in 3D.
	/// </summary>
	[Serializable]
	public partial struct Rotation {
		/// <summary>
		/// The default rotation.
		/// </summary>
		public static readonly Rotation Identity = new Rotation(Matrix3x3Byte.Identity);
		/// <summary>
		/// The null rotation.
		/// </summary>
		public static readonly Rotation Zero = LookRotation(Vector3Int.zero);
		/// <summary>
		/// A rotation which faces left.
		/// </summary>
		public static readonly Rotation Left = LookRotation(Vector3Int.left);
		/// <summary>
		/// A rotation which faces right.
		/// </summary>
		public static readonly Rotation Right = LookRotation(Vector3Int.right);
		/// <summary>
		/// A rotation which faces down.
		/// </summary>
		public static readonly Rotation Down = LookRotation(Vector3Int.down);
		/// <summary>
		/// A rotation which faces up.
		/// </summary>
		public static readonly Rotation Up = LookRotation(Vector3Int.up);
		/// <summary>
		/// A rotation which faces back.
		/// </summary>
		public static readonly Rotation Back = LookRotation(VECTOR3INT.back);
		/// <summary>
		/// A rotation which faces forward.
		/// </summary>
		public static readonly Rotation Forward = LookRotation(VECTOR3INT.forward);

		[SerializeField]
		internal Matrix3x3Byte matrix;

		private Vector3Int Basis0 => matrix.GetColumn(0);
		private Vector3Int Basis1 => matrix.GetColumn(1);
		private Vector3Int Basis2 => matrix.GetColumn(2);

		private Rotation(Matrix3x3Byte matrix) => this.matrix = matrix;

		private Rotation(Vector3Int right, Vector3Int up, Vector3Int forward) => matrix = new Matrix3x3Byte(right.Sign(), up.Sign(), forward.Sign());

		/// <summary>
		/// Returns the inverse of <paramref name="rotation"/>.
		/// </summary>
		/// <param name="rotation">The rotation to invert.</param>
		/// <returns>The inverse of <paramref name="rotation"/>.</returns>
		public static Rotation Inverse(Rotation rotation) => new Rotation(rotation.matrix.Inverse);

		/// <summary>
		/// Creates a rotation with the specified forward.
		/// </summary>
		/// <param name="forward">The direction to look in.</param>
		/// <returns>A rotation facing the vector.</returns>
		public static Rotation LookRotation(Vector3Int forward) {
			forward = forward.Sign();
			var up = Vector3Int.up;
			var collinear = forward == up || forward == -up;
			if (collinear)
				up = VECTOR3INT.Cross(forward, Vector3Int.right);

			return LookRotation(forward, up);
		}

		/// <summary>
		/// Creates a rotation with the specified forward and upwards direction.
		/// </summary>
		/// <param name="forward">The direction to look in.</param>
		/// <returns>A rotation facing the vector.</returns>
		public static Rotation LookRotation(Vector3Int forward, Vector3Int upwards) {
			var b2 = forward.Sign();
			var b0 = VECTOR3INT.Cross(upwards, b2).Sign();
			var b1 = VECTOR3INT.Cross(b2, b0).Sign();

			return new Rotation(b0, b1, b2);
		}

		public bool Equals(object obj, RotationMode options) {
			if (!base.Equals(obj))
				return false;

			if (obj is Rotation other)
				return Equals(other, options);

			return false;
		}

		public bool Equals(Rotation value) => Equals(value, default);

		public bool Equals(Rotation value, RotationMode options) {
			switch (options) {
				case RotationMode.Direction:
					return matrix.GetColumn(2).Equals(value.matrix.GetColumn(2));
				case RotationMode.Orientation:
					return matrix.Equals(value.matrix);
			}

			return false;
		}

		#region OVERRIDE
		public override string ToString() => Basis2.ToString();

		public override bool Equals(object obj) => Equals(obj, default);

		public override int GetHashCode() => Basis2.GetHashCode();
		#endregion

		#region OPERATOR
		/// <summary>
		/// Combines the rotations.
		/// </summary>
		/// <param name="a">The first rotation.</param>
		/// <param name="b">The second rotation.</param>
		/// <returns>The combination rotation.</returns>
		public static Rotation operator |(Rotation a, Rotation b) => LookRotation(a.Basis2.Sign() + b.Basis2.Sign());

		/// <summary>
		/// Reverses the rotation.
		/// </summary>
		/// <param name="rotation">The rotation to reverse.</param>
		/// <returns>The rotation which faces opposite of <paramref name="rotation"/>.</returns>
		public static Rotation operator -(Rotation rotation) => new Rotation(-rotation.matrix);

		/// <summary>
		/// Applies one rotation to another.
		/// </summary>
		/// <param name="a">The rotation to apply.</param>
		/// <param name="b">The relative rotation.</param>
		/// <returns>A sequence of rotations.</returns>
		public static Rotation operator *(Rotation a, Rotation b) {
			var b0 = a * b.Basis0;
			var b1 = a * b.Basis1;
			var b2 = a * b.Basis2;

			return new Rotation(b0, b1, b2);
		}

		/// <summary>
		/// Applies a rotation to a vector.
		/// </summary>
		/// <param name="rotation">The rotation to apply.</param>
		/// <param name="vector">The relative point.</param>
		/// <returns>The rotated vector.</returns>
		public static Vector3Int operator *(Rotation rotation, Vector3Int vector) => rotation.matrix.MultiplyPoint(vector);

		/// <summary>
		/// Are two rotations equal to each other?
		/// </summary>
		/// <param name="a">The first rotation.</param>
		/// <param name="b">The second rotation.</param>
		/// <returns>The rotations are equal.</returns>
		/// <remarks>All 3 rotation components are compared for equality.</remarks>
		public static bool operator ==(Rotation a, Rotation b) => a.Equals(b);

		/// <summary>
		/// Are two rotations not equal to each other?
		/// </summary>
		/// <param name="a">The first rotation.</param>
		/// <param name="b">The second rotation.</param>
		/// <returns>The rotations are not equal.</returns>
		/// <remarks>All 3 rotation components are compared for equality.</remarks>
		public static bool operator !=(Rotation a, Rotation b) => !a.Equals(b);
		#endregion
	}
}
