using NUnit.Framework;
using System.Linq;

namespace Andtech.Tests {

	public static class DirectionTests {

		[Test]
		public static void Encode() {
			Assert.AreEqual(Direction.Left, Rotation.Encode(Rotation.Left));
			Assert.AreEqual(Direction.Right, Rotation.Encode(Rotation.Right));
			Assert.AreEqual(Direction.Down, Rotation.Encode(Rotation.Down));
			Assert.AreEqual(Direction.Up, Rotation.Encode(Rotation.Up));
			Assert.AreEqual(Direction.Back, Rotation.Encode(Rotation.Back));
			Assert.AreEqual(Direction.Forward, Rotation.Encode(Rotation.Forward));

			Assert.AreEqual(Direction.Back, Rotation.Encode(-Rotation.Forward));
		}

		[Test]
		public static void Decode() {
			Assert.AreEqual(Rotation.Right, Rotation.Decode(Direction.Right));
			Assert.AreEqual(Rotation.Right | Rotation.Forward, Rotation.Decode(Direction.Right) | Rotation.Decode(Direction.Forward));
		}

		[Test]
		public static void DecodeMany() {
			Direction direction = Direction.Right | Direction.Up;
			var rotations = Rotation.DecodeMany(direction).ToList();

			var hasRight = rotations.Contains(Rotation.Right);
			var hasUp = rotations.Contains(Rotation.Up);

			Assert.IsTrue(hasRight && hasUp);
		}
	}
}
