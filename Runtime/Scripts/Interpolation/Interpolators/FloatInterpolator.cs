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

    /// <summary>
    /// Interpolates a single float.
    /// </summary>
    public class FloatInterpolator
    {
        public float Current { get; set; }
        public float Target { get; set; }
        public float MaxSpeed { get; set; } = Mathf.Infinity;
        public float SmoothTime { get; set; } = 1.0f;
        public float Velocity
        {
            get => velocity;
            set => velocity = value;
        }

        private float velocity;

        public void MoveTowards() => MoveTowards(Time.deltaTime);

        public void MoveTowards(float deltaTime) => Current = Mathf.MoveTowards(Current, Target, MaxSpeed * deltaTime);

        public void MoveTowardsAngle() => MoveTowardsAngle(Time.deltaTime);

        public void MoveTowardsAngle(float deltaTime) => Current = Mathf.MoveTowardsAngle(Current, Target, MaxSpeed * deltaTime);

        public void SmoothDamp() => SmoothDamp(Time.deltaTime);

        public void SmoothDamp(float deltaTime) => Current = Mathf.SmoothDamp(Current, Target, ref velocity, SmoothTime, MaxSpeed, deltaTime);

        public void SmoothDampAngle() => SmoothDampAngle(Time.deltaTime);

        public void SmoothDampAngle(float deltaTime) => Current = Mathf.SmoothDampAngle(Current, Target, ref velocity, SmoothTime, MaxSpeed, deltaTime);

        public static FloatInterpolator Linear(float maxAcceleration, float initialValue = 0.0f) => new FloatInterpolator { Current = initialValue, MaxSpeed = maxAcceleration };

        public static FloatInterpolator Smooth(float smoothTime, float initialValue = 0.0f) => new FloatInterpolator { Current = initialValue, SmoothTime = smoothTime };

        #region OPERATOR
        /// <summary>
        /// Casts the interpolator to the type of the internal value.
        /// </summary>
        /// <param name="interpolator">The interpolator to cast.</param>
        public static implicit operator float(FloatInterpolator interpolator) => interpolator.Current;
        #endregion
    }
}
