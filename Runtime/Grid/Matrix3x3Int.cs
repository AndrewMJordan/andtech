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
	/// A standard 3x3 integer matrix.
	/// </summary>
	/// <remarks>The matrix uses row-major indexing.</remarks>
	[Serializable]
	public struct Matrix3x3Int {
		/// <summary>
		/// Access element at <paramref name="row"/> and <paramref name="column"/>.
		/// </summary>
		/// <param name="row">The row in the matrix.</param>
		/// <param name="column">The column in the matrix.</param>
		public int this[int row, int column] {
			get {
				if (row == 0)
					return ChooseFrom(ref m00, ref m01, ref m02);

				if (row == 1)
					return ChooseFrom(ref m10, ref m11, ref m12);

				return ChooseFrom(ref m20, ref m21, ref m22);

				int ChooseFrom(ref int x, ref int y, ref int z) {
					if (column == 0)
						return x;

					if (column == 1)
						return y;

					if (column == 2)
						return z;

					throw new IndexOutOfRangeException();
				}
			}
			set {
				if (row == 0)
					ChooseFrom(ref m00, ref m01, ref m02);
				else if (row == 1)
					ChooseFrom(ref m10, ref m11, ref m12);
				else
					ChooseFrom(ref m20, ref m21, ref m22);

				void ChooseFrom(ref int x, ref int y, ref int z) {
					if (column == 0)
						x = value;
					else if (column == 1)
						y = value;
					else
						z = value;
				}
			}
		}
		/// <summary>
		/// The inverse of this matrix. (Read Only)
		/// </summary>
		public Matrix3x3Int Inverse {
			get {
				// Matrix of cofactors
				var c0 = new Vector3Int(Cofactor(0, 0), Cofactor(1, 0), Cofactor(2, 0));
				var c1 = new Vector3Int(Cofactor(0, 1), Cofactor(1, 1), Cofactor(2, 1));
				var c2 = new Vector3Int(Cofactor(0, 2), Cofactor(1, 2), Cofactor(2, 2));
				var cofactors = new Matrix3x3Int(c0, c1, c2);

				// Adjugate
				var adjugate = cofactors.Transpose;

				// Multiply by (1 / determinant)
				return adjugate / Determinant;
			}
		}
		/// <summary>
		/// The determinant of the matrix. (Read Only)
		/// </summary>
		public int Determinant {
			get =>
				m00 * Cofactor(0, 0) +
				m01 * Cofactor(0, 1) +
				m02 * Cofactor(0, 2);
		}
		/// <summary>
		/// Returns the transpose of this matrix (Read Only).
		/// </summary>
		public Matrix3x3Int Transpose => new Matrix3x3Int(GetRow(0), GetRow(1), GetRow(2));

		/// <summary>
		/// Returns the identity matrix (Read Only).
		/// </summary>
		public static readonly Matrix3x3Int Identity = new Matrix3x3Int(Vector3Int.right, Vector3Int.up, VECTOR3INT.forward);

		[SerializeField]
		private int m00, m01, m02;
		[SerializeField]
		private int m10, m11, m12;
		[SerializeField]
		private int m20, m21, m22;

		public Matrix3x3Int(Vector3Int column0, Vector3Int column1, Vector3Int column2) {
			m00 = column0[0];
			m01 = column1[0];
			m02 = column2[0];
			m10 = column0[1];
			m11 = column1[1];
			m12 = column2[1];
			m20 = column0[2];
			m21 = column1[2];
			m22 = column2[2];
		}

		/// <summary>
		/// Get a column of the matrix.
		/// </summary>
		/// <param name="index">The column index to get.</param>
		/// <returns>The column in the matrix.</returns>
		public Vector3Int GetColumn(int index) => new Vector3Int(this[0, index], this[1, index], this[2, index]);

		/// <summary>
		/// Get a row of the matrix.
		/// </summary>
		/// <param name="index">The row index to get.</param>
		/// <returns>The row in the matrix.</returns>
		public Vector3Int GetRow(int index) => new Vector3Int(this[index, 0], this[index, 1], this[index, 2]);

		/// <summary>
		/// Sets a column of the matrix.
		/// </summary>
		/// <param name="index">The column index to get.</param>
		/// <param name="column">The column value.</param>
		public void SetColumn(int index, Vector3Int column) {
			this[0, index] = column[0];
			this[1, index] = column[1];
			this[2, index] = column[2];
		}

		/// <summary>
		/// Sets a row of the matrix.
		/// </summary>
		/// <param name="index">The row index to get.</param>
		/// <param name="column">The row value.</param>
		public void SetRow(int index, Vector3Int row) {
			this[index, 0] = row[0];
			this[index, 1] = row[1];
			this[index, 2] = row[2];
		}

		/// <summary>
		/// Transforms a position by this matrix.
		/// </summary>
		/// <param name="vector">The vector to transform.</param>
		/// <returns>The transformed vector.</returns>
		public Vector3Int MultiplyPoint(Vector3Int vector) {
			int x = vector.x;
			int y = vector.y;
			int z = vector.z;

			return new Vector3Int {
				x = x * m00 + y * m01 + z * m02,
				y = x * m10 + y * m11 + z * m12,
				z = x * m20 + y * m21 + z * m22,
			};
		}

		#region OVERRIDE
		public override string ToString() => string.Format("[ {0}, {1}, {2} ]", GetRow(0), GetRow(1), GetRow(2));

		public override bool Equals(object obj) {
			if (obj is Matrix3x3Int matrix) {
				if (!GetColumn(0).Equals(matrix.GetColumn(0)))
					return false;

				if (!GetColumn(1).Equals(matrix.GetColumn(1)))
					return false;

				if (!GetColumn(2).Equals(matrix.GetColumn(2)))
					return false;

				return true;
			}

			return false;
		}

		public override int GetHashCode() => new Matrix4x4((Vector3)GetColumn(0), (Vector3)GetColumn(1), (Vector3)GetColumn(2), new Vector4(0.0F, 0.0F, 0.0F, 1.0F)).GetHashCode();
		#endregion

		#region OPERATOR
		public static bool operator ==(Matrix3x3Int a, Matrix3x3Int b) => a.Equals(b);

		public static bool operator !=(Matrix3x3Int a, Matrix3x3Int b) => !a.Equals(b);

		public static Matrix3x3Int operator -(Matrix3x3Int matrix) => new Matrix3x3Int(-matrix.GetColumn(0), -matrix.GetColumn(1), -matrix.GetColumn(2));

		public static Matrix3x3Int operator *(Matrix3x3Int matrix, int scale) => new Matrix3x3Int(matrix.GetColumn(0) * scale, matrix.GetColumn(1) * scale, matrix.GetColumn(2) * scale);

		public static Matrix3x3Int operator /(Matrix3x3Int matrix, int scale) => new Matrix3x3Int(matrix.GetColumn(0) / scale, matrix.GetColumn(1) / scale, matrix.GetColumn(2) / scale);
		#endregion

		#region PIPELINE
		private int Cofactor(int i, int j) => SignedMinor(i, j);

		private int SignedMinor(int i, int j) {
			int a = GetRepeat(i + 1, j + 1);
			int b = GetRepeat(i - 1, j + 1);
			int c = GetRepeat(i + 1, j - 1);
			int d = GetRepeat(i - 1, j - 1);

			return a * d - b * c;
		}

		private int GetRepeat(int row, int column) {
			row = MathfA.Repeat(row, 3);
			column = MathfA.Repeat(column, 3);

			return this[row, column];
		}
		#endregion
	}
}
