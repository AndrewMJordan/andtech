using NUnit.Framework;

namespace Andtech.Tests {

	internal class ControlRandom {
		private int[] order;
		private int index;

		public ControlRandom(params int[] order) {
			this.order = order;
			index = 0;
		}

		public int GetRandom(int count) {
			int element = order[index];
			index = ++index % count;

			return element;
		}
	}

	public static class RandomizationTests {
		private static readonly string[] ARRAY = new string[] { "ALPHA", "BETA", "GAMMA" };

		[Test]
		public static void TestGetRandom() {
			var randomizer = new ControlRandom(0, 1, 2);

			var array = ARRAY.Clone() as string[];
			Assert.AreEqual(array[0], array.GetRandom(randomizer.GetRandom));
		}
	}
}
