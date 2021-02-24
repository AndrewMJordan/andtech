using System.Runtime.CompilerServices;
using UnityEngine;

namespace Andtech {

	public static class ColorExtensions {

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		/// <summary>
		/// Set the transparency of the current color.
		/// </summary>
		/// <param name="color">The original color value.</param>
		/// <param name="alpha">The desired alpha (transparency).</param>
		/// <returns>The color with <paramref name="alpha"/> applied.</returns>
		public static Color Alpha(this Color color, float alpha) {
			color.a = alpha;

			return color;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		/// <summary>
		/// Set the saturation of the current color.
		/// </summary>
		/// <param name="color">The original color value.</param>
		/// <param name="alpha">The desired saturation.</param>
		/// <returns>The color with <paramref name="saturation"/> applied.</returns>
		public static Color Saturate(this Color color, float saturation) {
			Color.RGBToHSV(color, out var h, out _, out var v);

			return Color.HSVToRGB(h, saturation, v);
		}
	}
}
