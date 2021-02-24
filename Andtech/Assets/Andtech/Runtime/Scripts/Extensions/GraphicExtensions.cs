using UnityEngine;
using UnityEngine.UI;

namespace Andtech {

	public static class GraphicExtensions {

		public static void SetColor(this Graphic graphic, Color color) => graphic.color = color;
	}
}
