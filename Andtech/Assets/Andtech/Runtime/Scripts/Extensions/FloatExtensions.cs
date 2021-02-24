using UnityEngine;

namespace Andtech {

	public static class FloatExtensions {

		public static void Snap(this ref float number, int divisions) {
			if (divisions < 1)
				return;

			number = Mathf.Round(number * divisions) / divisions;
		}
	}
}
