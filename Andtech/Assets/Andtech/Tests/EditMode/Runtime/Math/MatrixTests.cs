using NUnit.Framework;
using UnityEngine;

namespace Andtech.Tests {

	public static class MatrixTests {

		[Test]
		public static void TestStaticMembers() {
			Assert.AreEqual(Vector3Int.right, Matrix3x3Int.Identity.GetColumn(0));
			Assert.AreEqual(Vector3Int.up, Matrix3x3Int.Identity.GetColumn(1));
			Assert.AreEqual(VECTOR3INT.forward, Matrix3x3Int.Identity.GetColumn(2));
		}

		[Test]
		public static void TestConstructors() {
			var right = Vector3Int.right;
			var up = Vector3Int.up;
			var forward = new Vector3Int(0, 0, 1);

			var matrix = new Matrix3x3Int(right, up, forward);

			Assert.AreEqual(right, matrix.GetColumn(0));
			Assert.AreEqual(up, matrix.GetColumn(1));
			Assert.AreEqual(forward, matrix.GetColumn(2));
		}

		[Test]
		public static void TestMultiplication() {
			var right = Vector3Int.right;
			var up = Vector3Int.up;
			var forward = new Vector3Int(0, 0, 1);

			var matrix = new Matrix3x3Int(-forward, up, right);

			Assert.AreEqual(right, matrix.MultiplyPoint(forward));
		}

		[Test]
		public static void TestInvertIdentity() {
			Assert.AreEqual(Matrix3x3Int.Identity, Matrix3x3Int.Identity.Inverse);
		}

		[Test]
		public static void TestInverseA() {
			var a = Make(
				0, 0, 1,
				0, 1, 0,
				-1, 0, 0
			);
			var b = Make(
				0, 0, -1,
				0, 1, 0,
				1, 0, 0
			);

			Assert.AreEqual(b, a.Inverse);
		}

		[Test]
		public static void TestInverseB() {
			var a = Make(
				1, 0, -3,
				2, -2, 1,
				0, -1, 3
			);
			var b = Make(
				-5, 3, -6,
				-6, 3, -7,
				-2, 1, -2
			);

			Assert.AreEqual(b, a.Inverse);
		}

		public static Matrix3x3Int Make(int x00, int x01, int x02, int x10, int x11, int x12, int x20, int x21, int x22) => new Matrix3x3Int(new Vector3Int(x00, x10, x20), new Vector3Int(x01, x11, x21), new Vector3Int(x02, x12, x22));
	}
}
