/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech {

	/// <summary>
	/// A grid which snaps positions to points.
	/// </summary>
	public class SnapGrid {
		/// <summary>
		/// The distance between snap points.
		/// </summary>
		public Vector3 Scale {
			get => scale;
			set {
				scale = value;
				MarkDirty();
			}
		}
		/// <summary>
		/// The central position where all snap points originate.
		/// </summary>
		public Vector3 Origin {
			get => origin;
			set {
				origin = value;
				MarkDirty();
			}
		}
		/// <summary>
		/// Does the instance require a rebuild?
		/// </summary>
		public bool IsDirty {
			get => isDirty;
			private set {
				isDirty = true;
			}
		}

		private Vector3 scale;
		private Vector3 origin;
		private Matrix4x4 prefix;
		private Matrix4x4 suffix;

		private bool isDirty;

		/// <summary>
		/// Constructs a snapping grid.
		/// </summary>
		/// <param name="scale">The distance between snap points.</param>
		public SnapGrid(Vector3 scale) : this(scale, Vector3.zero) { }

		/// <summary>
		/// Constructs a snapping grid.
		/// </summary>
		/// <param name="scale">The distance between snap points.</param>
		/// <param name="origin">The central position where all snap points originate.</param>
		public SnapGrid(Vector3 scale, Vector3 origin) {
			Scale = scale;
			Origin = origin;
			Rebuild();
		}

		/// <summary>
		/// Snaps the vector to the closest snap point.
		/// </summary>
		/// <param name="vector">The position (worldspace) to snap.</param>
		/// <returns>The snapped vector.</returns>
		public Vector3 Snap(Vector3 vector) {
			if (IsDirty)
				Rebuild();

			Vector3 pre = prefix.MultiplyPoint3x4(vector);
			Vector3 snapped = pre.Round();
			Vector3 post = suffix.MultiplyPoint3x4(snapped);

			return post;
		}

		/// <summary>
		/// Marks the instance for a rebuild.
		/// </summary>
		/// <returns></returns>
		public void MarkDirty() => IsDirty = true;

		/// <summary>
		/// Rebuilds the snap grid after changing parameters.
		/// </summary>
		public void Rebuild() {
			// Remove snapping offset
			Matrix4x4 prefixA = Matrix4x4.Translate(-origin);
			// Normalize coordinates
			Matrix4x4 prefixB = Matrix4x4.Scale(scale.Reciprocal());
			prefix = prefixB * prefixA;

			// Denormalize coordinates
			Matrix4x4 suffixA = Matrix4x4.Scale(scale);
			// Reapply snapping offset
			Matrix4x4 suffixB = Matrix4x4.Translate(origin);
			suffix = suffixB * suffixA;

			isDirty = false;
		}
	}
}
