using UnityEngine;

namespace Andtech
{

    public static class Vector3Extensions
    {

        /// <summary>
        /// Converts from XZ plane (3D) to XY plane (2D).
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>The 2D vector.</returns>
        public static Vector2 FromXZ(this Vector3 vector) => new Vector3(vector.x, vector.z);

        /// <summary>
        /// Converts from XY plane (2D) to XZ plane (3D).
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        /// <returns>The 3D vector.</returns>
        public static Vector3 ToXZ(this Vector2 vector) => new Vector3(vector.x, 0.0f, vector.y);

        /// <summary>
        /// Selects components from a vector.
        /// </summary>
        /// <param name="original">The original vector.</param>
        /// <param name="x">New x component value.</param>
        /// <param name="y">New y component value.</param>
        /// <param name="z">New z component value.</param>
        /// <returns>A combination of the original and new values.</returns>
        public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null) => new Vector3
        {
            x = x ?? original.x,
            y = y ?? original.y,
            z = z ?? original.z
        };

        /// <summary>
        /// Makes this <paramref name="vector"/> have a magnitude of 1.
        /// </summary>
        /// <param name="vector">The vector to scale.</param>
        /// <param name="length">The length of the original vector.</param>
        public static void Normalize(this ref Vector3 vector, out float length)
        {
            length = vector.magnitude;
            vector /= length;
        }

        /// <summary>
        /// Returns the components rounded to the nearest integer.
        /// </summary>
        /// <param name="vector">The vector whose components should be rounded.</param>
        /// <returns>The vector with rounded components.</returns>
        public static Vector3 Round(this Vector3 vector)
        {
            return new Vector3()
            {
                x = Mathf.Round(vector.x),
                y = Mathf.Round(vector.y),
                z = Mathf.Round(vector.z)
            };
        }

        /// <summary>
        /// Returns the components rounded to the nearest integer.
        /// </summary>
        /// <param name="vector">The vector whose components should be rounded.</param>
        /// <returns>The vector with rounded components.</returns>
        public static Vector3Int RoundToInt(this Vector3 vector)
        {
            return new Vector3Int()
            {
                x = Mathf.RoundToInt(vector.x),
                y = Mathf.RoundToInt(vector.y),
                z = Mathf.RoundToInt(vector.z)
            };
        }

        /// <summary>
        /// Returns the largest integer smaller than or equal to f (for each component).
        /// </summary>
        /// <param name="vector">The vector whose components should be floored.</param>
        /// <returns>The vector with floored components.</returns>
        public static Vector3 Floor(this Vector3 vector)
        {
            return new Vector3()
            {
                x = Mathf.Floor(vector.x),
                y = Mathf.Floor(vector.y),
                z = Mathf.Floor(vector.z)
            };
        }

        /// <summary>
        /// Returns the largest integer smaller than or equal to f (for each component).
        /// </summary>
        /// <param name="vector">The vector whose components should be floored.</param>
        /// <returns>The vector with floored components.</returns>
        public static Vector3Int FloorToInt(this Vector3 vector)
        {
            return new Vector3Int()
            {
                x = Mathf.FloorToInt(vector.x),
                y = Mathf.FloorToInt(vector.y),
                z = Mathf.FloorToInt(vector.z)
            };
        }

        /// <summary>
        /// Returns the largest integer greater than or equal to f (for each component).
        /// </summary>
        /// <param name="vector">The vector whose components should be ceiled.</param>
        /// <returns>The vector with ceiled components.</returns>
        public static Vector3 Ceil(this Vector3 vector)
        {
            return new Vector3()
            {
                x = Mathf.Ceil(vector.x),
                y = Mathf.Ceil(vector.y),
                z = Mathf.Ceil(vector.z)
            };
        }

        /// <summary>
        /// Returns the largest integer greater than or equal to f (for each component).
        /// </summary>
        /// <param name="vector">The vector whose components should be ceiled.</param>
        /// <returns>The vector with ceiled components.</returns>
        public static Vector3Int CeilToInt(this Vector3 vector)
        {
            return new Vector3Int()
            {
                x = Mathf.CeilToInt(vector.x),
                y = Mathf.CeilToInt(vector.y),
                z = Mathf.CeilToInt(vector.z)
            };
        }

        /// <summary>
        /// Returns a component-wise reciprocal of <paramref name="vector"/>.
        /// </summary>
        /// <param name="vector">The vector to reciprocate.</param>
        /// <returns>The reciprocal of <paramref name="vector"/>.</returns>
        public static Vector3 Reciprocal(this Vector3 vector)
        {
            return new Vector3()
            {
                x = 1.0f / vector.x,
                y = 1.0f / vector.y,
                z = 1.0f / vector.z
            };
        }

        /// <summary>
        /// Divides the current vector component-wise by another.
        /// </summary>
        /// <param name="a">The divident vector.</param>
        /// <param name="b">The divisor vector</param>
        /// <returns>A vector of component-wise quotients.</returns>
        public static Vector3 DivideBy(this Vector3 a, Vector3 b)
        {
            return new Vector3()
            {
                x = a.x / b.x,
                y = a.y / b.y,
                z = a.z / b.z
            };
        }
    }
}
