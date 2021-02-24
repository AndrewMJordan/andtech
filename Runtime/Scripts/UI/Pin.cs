/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using UnityEngine;

namespace Andtech {

	public abstract class Pin : MonoBehaviour {
		public RectTransform RectTransform => (RectTransform)transform;
		public Func<Vector3> ScreenPointStrategy { get; set; }

		private bool? isVisible;

		#region MONOBEHAVIOUR
		protected virtual void LateUpdate() {
			Move();
		}
		#endregion

		#region VIRTUAL
		protected virtual void ApplyPosition(Vector3 position) {
			SetScreenPosition(position);
		}

		protected void SetScreenPosition(Vector3 position) {
			RectTransform.position = position;
		}

		protected virtual void OnEnterScreen() => RectTransform.localScale = Vector3.one;

		protected virtual void OnExitScreen() => RectTransform.localScale = Vector3.zero;
		#endregion

		#region ABSTRACT
		protected abstract bool IsPointVisible(Vector3 sp);
		#endregion

		#region PIPELINE
		private void Move() {
			var sp = ScreenPointStrategy?.Invoke() ?? Vector3.zero;
			var isVisible = IsPointVisible(sp);
			var same = isVisible == this.isVisible;
			this.isVisible = isVisible;

			if (!same) {
				if (isVisible)
					OnEnterScreen();
				else
					OnExitScreen();
			}

			if (isVisible) {
				ApplyPosition(sp);
			}
		}
		#endregion
	}
}
