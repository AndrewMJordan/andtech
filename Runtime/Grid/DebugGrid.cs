/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech {

	public static class DebugGrid {
		public static Matrix4x4 Transformation { get; set; } = Matrix4x4.identity;
		public static float ArrowScale { get; set; } = 1.0F;

		private static readonly Vector3 Half = new Vector3(0.5F, 0.5F, 0.5F);

		public static void DrawCell(Vector3Int cell) => DrawCell(cell, Color.white);

		public static void DrawCell(Vector3Int cell, Color color, float duration = 0.0F, bool depthTest = true) {
			var width = Vector3.right;
			var height = Vector3.up;
			var depth = Vector3.forward;

			var min = cell;

			DrawRay(min, width, color, duration, depthTest);
			DrawRay(min + depth, width, color, duration, depthTest);
			DrawRay(min + height, width, color, duration, depthTest);
			DrawRay(min + height + depth, width, color, duration, depthTest);

			DrawRay(min, height, color, duration, depthTest);
			DrawRay(min + width, height, color, duration, depthTest);
			DrawRay(min + depth, height, color, duration, depthTest);
			DrawRay(min + width + depth, height, color, duration, depthTest);

			DrawRay(min, depth, color, duration, depthTest);
			DrawRay(min + width, depth, color, duration, depthTest);
			DrawRay(min + height, depth, color, duration, depthTest);
			DrawRay(min + width + height, depth, color, duration, depthTest);
		}

		public static void DrawRay(Vector3Int cell, Rotation rotation) => DrawRay(cell, rotation, Rotation.Zero);

		public static void DrawRay(Vector3Int cell, Rotation rotation, Color color) => DrawRay(cell, rotation, Rotation.Zero, color);

		public static void DrawRay(Vector3Int cell, Rotation rotation, Color color, float duration = 0.0F, bool depthTest = true) => DrawRay(cell, rotation, Rotation.Zero, color, duration, depthTest);

		public static void DrawRay(Vector3Int cell, Rotation rotation, Rotation offset, float duration = 0.0F, bool depthTest = true) => DrawRay(cell, rotation, offset, Color.white, duration, depthTest);

		public static void DrawRay(Vector3Int cell, Rotation rotation, Rotation offset, Color color, float duration = 0.0F, bool depthTest = true) {
			var stick = rotation * VECTOR3INT.forward;
			var center = cell + Half;
			var position = center + Vector3.Scale(offset * VECTOR3INT.forward, Half);

			DebugA.DrawArrow(
				Transformation.MultiplyPoint3x4(position),
				Transformation.MultiplyVector(Vector3.Scale(stick, Half) * ArrowScale),
				color,
				duration: duration,
				depthTest: depthTest
			);
		}

		private static void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest) =>
			Debug.DrawRay(
				Transformation.MultiplyPoint3x4(start),
				Transformation.MultiplyVector(dir),
				color,
				duration,
				depthTest
			);
	}
}
