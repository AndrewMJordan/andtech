/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech
{

    public class Viewport : MonoBehaviour
    {
        public Camera Camera
        {
            get => camera;
            set => camera = value;
        }
        public Vector2 Center => screenCenter;

        private readonly Vector3[] corners = new Vector3[4];

        private Matrix4x4 screenToAnchor;
        private Matrix4x4 anchorToScreen;
        private Vector2 screenCenter;
        private RectTransform RectTransform
        {
            get
            {
                if (!rectTransform)
                {
                    rectTransform = transform as RectTransform;
                }

                return rectTransform;
            }
        }

        [SerializeField]
        private Camera camera;
        private RectTransform rectTransform;
        private const float MAX_RADIUS = 0.5f;
        private static readonly Vector2 HALF = new Vector2(0.5f, 0.5f);

        public bool Contains(Vector3 point)
        {
            return camera.pixelRect.Contains(point);
        }

        public Vector3 WorldToScreenPoint(Vector3 position) => camera.WorldToScreenPoint(position);

        public Vector3 WorldToViewportPoint(Vector3 position) => camera.WorldToViewportPoint(position);

        public Vector3 GetCorrectedPosition(Vector3 screenPosition)
        {
            if (screenPosition.z < 0.0f)
            {
                var d = (Vector2)screenPosition - screenCenter;
                screenPosition = screenCenter + -d;
            }

            return screenPosition;
        }

        public Vector2 GetRadius(Vector2 screenPosition)
        {
            var anchorCoordinates = (Vector2)screenToAnchor.MultiplyPoint3x4(screenPosition);
            var radius = anchorCoordinates - HALF;

            anchorCoordinates = MaximizeRadius(radius);
            var position = anchorToScreen.MultiplyPoint3x4(anchorCoordinates);

            return position;
        }

        public bool Truncate(Vector2 screenPosition, out Vector2 position)
        {
            var anchorCoordinates = (Vector2)screenToAnchor.MultiplyPoint3x4(screenPosition);
            var radius = anchorCoordinates - HALF;

            anchorCoordinates = TruncateCircular(radius);
            position = anchorToScreen.MultiplyPoint3x4(anchorCoordinates);

            return radius.sqrMagnitude > (MAX_RADIUS * MAX_RADIUS);
        }

        #region MONOBEHAVIOUR
        protected virtual void OnRectTransformDimensionsChange()
        {
            RectTransform.GetWorldCorners(corners);
            var basis0 = corners[3] - corners[0];
            var basis1 = corners[1] - corners[0];
            var basis2 = Vector3.Cross(basis0, basis1);
            var origin = corners[0];

            screenToAnchor = MatrixUtility.GetLocalizationMatrix(basis0, basis1, basis2, origin);
            anchorToScreen = MatrixUtility.GetGlobalizationMatrix(basis0, basis1, basis2, origin);
            screenCenter = anchorToScreen.MultiplyPoint3x4(HALF);
        }
        #endregion

        #region PIPELINE
        private Vector2 TruncateCircular(Vector2 radius)
        {
            return HALF + Vector2.ClampMagnitude(radius, MAX_RADIUS);
        }

        private Vector2 TruncateRectangular(Vector2 radius)
        {
            return new Vector2
            {
                x = Mathf.Clamp01(HALF.x + radius.x),
                y = Mathf.Clamp01(HALF.y + radius.y)
            };
        }

        private Vector2 MaximizeRadius(Vector2 radius)
        {
            return HALF + radius.normalized * MAX_RADIUS;
        }
        #endregion
    }
}
