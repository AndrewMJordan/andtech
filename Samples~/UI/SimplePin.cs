/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Samples
{

    public class SimplePin : Pin
    {
        public RectTransform Arrow
        {
            get => arrow;
            set => arrow = value;
        }
        public Viewport Viewport
        {
            get => viewport;
            set => viewport = value;
        }

        [SerializeField]
        private Transform source;
        [SerializeField]
        private Viewport viewport;
        [SerializeField]
        private bool truncate;
        [SerializeField]
        private RectTransform arrow;
        private bool? isTruncated;

        #region MONOBEHAVIOUR
        protected virtual void Reset()
        {
            viewport = GetComponentInParent<Viewport>();
        }

        protected virtual void Awake()
        {
            if (source && viewport)
            {
                ScreenPointStrategy = () => viewport.WorldToScreenPoint(source.position);
            }
        }
        #endregion

        #region OVERRIDE
        protected override bool IsPointVisible(Vector3 sp)
        {
            return truncate || viewport.Contains(sp);
        }

        protected override void ApplyPosition(Vector3 screenPosition)
        {
            if (truncate && viewport)
            {
                screenPosition = viewport.GetCorrectedPosition(screenPosition);

                Vector2 outputPosition;
                bool isTruncated;

                if (screenPosition.z > 0.0f)
                {
                    isTruncated = viewport.Truncate(screenPosition, out var truncatedPosition);
                    outputPosition = truncatedPosition;
                }
                else
                {
                    isTruncated = true;
                    outputPosition = viewport.GetRadius(screenPosition);
                }

                if (isTruncated)
                {
                    if (arrow)
                    {
                        var roll = Vector2.SignedAngle(Vector2.right, (Vector2)screenPosition - Viewport.Center);
                        arrow.localRotation = Quaternion.Euler(0.0f, 0.0f, roll);
                    }
                }

                var same = isTruncated == this.isTruncated;
                this.isTruncated = isTruncated;
                screenPosition = outputPosition;
                if (!same)
                {
                    if (isTruncated)
                    {
                        OnBeginTruncate();
                    }
                    else
                    {
                        OnEndTruncate();
                    }
                }
            }

            SetScreenPosition(screenPosition);
        }
        #endregion

        #region VIRTUAL
        protected virtual void OnBeginTruncate()
        {
            if (arrow)
            {
                arrow.localScale = Vector3.one;
            }
        }

        protected virtual void OnEndTruncate()
        {
            if (arrow)
            {
                arrow.localScale = Vector3.zero;
            }
        }
        #endregion
    }
}
