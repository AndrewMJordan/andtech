/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using NUnit.Framework;
using UnityEngine;

namespace Andtech.Tests {

	public static class RotationTests {
		private static Rotation QZero = Rotation.LookRotation(0, 0, 0);
		private static Rotation QLeft = Rotation.LookRotation(-1, 0, 0);
		private static Rotation QRight = Rotation.LookRotation(1, 0, 0);
		private static Rotation QDown = Rotation.LookRotation(0, -1, 0);
		private static Rotation QUp = Rotation.LookRotation(0, 1, 0);
		private static Rotation QBack = Rotation.LookRotation(0, 0, -1);
		private static Rotation QForward = Rotation.LookRotation(0, 0, 1);

		private static Vector3Int left = new Vector3Int(-1, 0, 0);
		private static Vector3Int right = new Vector3Int(1, 0, 0);
		private static Vector3Int down = new Vector3Int(0, -1, 0);
		private static Vector3Int up = new Vector3Int(0, 1, 0);
		private static Vector3Int back = new Vector3Int(0, 0, -1);
		private static Vector3Int forward = new Vector3Int(0, 0, 1);

		[Test]
		public static void TestFactory() {
			Assert.AreEqual(Rotation.Left, Rotation.LookRotation(Vector3.left));
			Assert.AreEqual(Rotation.Right, Rotation.LookRotation(Vector3.right));
			Assert.AreEqual(Rotation.Down, Rotation.LookRotation(Vector3.down));
			Assert.AreEqual(Rotation.Up, Rotation.LookRotation(Vector3.up));
			Assert.AreEqual(Rotation.Back, Rotation.LookRotation(Vector3.back));
			Assert.AreEqual(Rotation.Forward, Rotation.LookRotation(Vector3.forward));

			Assert.AreEqual(Rotation.LookRotation(1, 0, 0), Rotation.LookRotation(0.85F, 0.0F, 0.05F));
			Assert.AreEqual(Rotation.LookRotation(1, 0, 1), Rotation.LookRotation(0.5F, 0.0F, 0.5F));
			Assert.AreEqual(Rotation.LookRotation(0, 0, 1), Rotation.LookRotation(0.05F, 0.0F, 0.85F));
		}

		[Test]
		public static void TestMultiplication() {
			Assert.AreEqual(QForward, QForward * QForward);
			Assert.AreEqual(QForward, QLeft * QRight);
			Assert.AreEqual(QLeft, QBack * QRight);
			Assert.AreEqual(QBack, QLeft * QLeft);
			Assert.AreEqual(QRight, QBack * QLeft);
			Assert.AreEqual(QForward, QBack * QBack);

			Assert.AreEqual(QForward, QLeft * QRight);
			Assert.AreEqual(QBack, QLeft * QLeft);
			Assert.AreEqual(QRight, QBack * QLeft);
		}

		[Test]
		public static void TestUnion() {
			Assert.AreEqual(Rotation.LookRotation(1, 0, -1), (QRight | QBack));
			Assert.AreEqual(Rotation.LookRotation(1, 1, -1), (QRight | QUp | QBack));
			Assert.AreEqual(Rotation.LookRotation(1, 1, 1), (QRight | QUp | QForward));

			Assert.AreEqual(Rotation.LookRotation(-1, -1, -1), (QLeft | QDown | QBack));
		}

		[Test]
		public static void TestRotation() {
			Assert.AreEqual(left, QLeft * forward);
			Assert.AreEqual(right, QRight * forward);
			Assert.AreEqual(down, QDown * forward);
			Assert.AreEqual(back, QBack * forward);
			Assert.AreEqual(right, QBack * left);

			Assert.AreEqual(new Vector3Int(-1, 1, 2), QLeft * new Vector3Int(2, 1, 1));
		}

		[Test]
		public static void TestInvertIdentity() {
			Assert.AreEqual(Rotation.Identity, Rotation.Inverse(Rotation.Identity));
		}

		[Test]
		public static void TestNeutralize() {
			Assert.AreEqual(Rotation.Identity, Rotation.Inverse(Rotation.Right) * Rotation.Right);
		}

		[Test]
		public static void TestInvert() {
			Assert.AreEqual(Rotation.Left, Rotation.Inverse(Rotation.Right));
		}

		[Test]
		public static void TestClone() {
			var rotsA = new Rotation[] { Rotation.Forward, Rotation.Forward };
			var rotsB = rotsA.Clone() as Rotation[];
			rotsB[0] = rotsB[0] * Rotation.Right;

			Assert.AreNotEqual(rotsA[0], rotsB[0]);
		}

		[Test]
		public static void TestComparisons() {
			var rotA = Rotation.LookRotation(Vector3Int.right, Vector3Int.up);
			var rotB = Rotation.LookRotation(Vector3Int.right, Vector3Int.down);

			Assert.IsTrue(rotA == rotB);
			Assert.IsTrue(rotA.Equals(rotB, RotationMode.Direction));
			Assert.IsFalse(rotA.Equals(rotB, RotationMode.Orientation));

		}
	}
}
