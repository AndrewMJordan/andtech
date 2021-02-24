/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Text;
using UnityEngine;

namespace Andtech {

	public static class StringExtensions {

		/// <summary>
		/// Wraps the text in html color tags.
		/// </summary>
		/// <param name="text">The text to wrap.</param>
		/// <param name="color">The color to use.</param>
		/// <returns>The wrapped string.</returns>
		public static string Color(this string text, Color color) => text.Color(ColorUtility.ToHtmlStringRGBA(color));

		/// <summary>
		/// Wraps the text in html color tags.
		/// </summary>
		/// <param name="text">The text to wrap.</param>
		/// <param name="htmlColor">The color to use.</param>
		/// <returns>The wrapped string.</returns>
		public static string Color(this string text, string htmlColor) => string.Format("<color=#{1}>{0}</color>", text, htmlColor.Replace("#", string.Empty));

		/// <summary>
		/// Wraps the text in html color tags.
		/// </summary>
		/// <param name="text">The text to wrap.</param>
		/// <param name="colorStart">The start color to use.</param>
		/// <param name="colorEnd">The end color to use.</param>
		/// <returns>The wrapped string.</returns>
		public static string Color(this string text, Color colorStart, Color colorEnd) {
			int n = text.Length;
			var builder = new StringBuilder(n);

			for (int i = 0; i < n; i++) {
				var letter = text[i];
				var alpha = (float)i / (n - 1);
				var color = UnityEngine.Color.Lerp(colorStart, colorEnd, alpha);
				var html = Color(letter.ToString(), color);
				builder.Append(html);
			}

			return builder.ToString();
		}
	}
}
