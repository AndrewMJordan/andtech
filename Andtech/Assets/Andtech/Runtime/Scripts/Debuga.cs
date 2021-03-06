﻿using UnityEngine;

namespace Andtech
{

    public static class DebugA
    {
        public static float ArrowRatio { get; set; } = 0.125f;

        public static void DrawArrow(Vector3 position, Vector3 direction) => DrawArrow(position, direction, Color.white);

        public static void DrawArrow(Vector3 position, Vector3 direction, Color color, float duration = 0.0f, bool depthTest = true, float arrowRatio = 0.125f)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            var length = direction.magnitude;
            Vector3 stick = new Vector3(0.0f, 0.0f, 1.0f);
            Vector3 left = new Vector3(-1.0f, 0.0f, -1.0f);
            Vector3 right = new Vector3(1.0f, 0.0f, -1.0f);

            stick *= length;
            left *= length * arrowRatio;
            right *= length * arrowRatio;

            Debug.DrawRay(position, rotation * stick, color, duration, depthTest);
            Debug.DrawRay(position + rotation * stick, rotation * left, color, duration, depthTest);
            Debug.DrawRay(position + rotation * stick, rotation * right, color, duration, depthTest);
        }

        public static void DrawRectangle(Vector3 center, Vector3 size) => DrawRectangle(center, size, Color.white);

        public static void DrawRectangle(Vector3 center, Vector3 size, Color color, float duration = 0.0f, bool depthTest = true)
        {
            var min = center - 0.5f * size;
            var max = center + size;

            DrawMinMaxRectangle(min, max, color, duration, depthTest);
        }

        public static void DrawMinMaxRectangle(Vector3 min, Vector3 max) => DrawMinMaxRectangle(min, max, Color.white);

        public static void DrawMinMaxRectangle(Vector3 min, Vector3 max, Color color, float duration = 0.0f, bool depthTest = true)
        {
            var size = max - min;
            var width = new Vector3(size.x, 0.0f, 0.0f);
            var height = new Vector3(0.0f, size.y, 0.0f);
            var depth = new Vector3(0.0f, 0.0f, size.z);

            Debug.DrawRay(min, width, color, duration, depthTest);
            Debug.DrawRay(min + depth, width, color, duration, depthTest);
            Debug.DrawRay(min + height, width, color, duration, depthTest);
            Debug.DrawRay(min + height + depth, width, color, duration, depthTest);
            Debug.DrawRay(min, height, color, duration, depthTest);
            Debug.DrawRay(min + width, height, color, duration, depthTest);
            Debug.DrawRay(min + depth, height, color, duration, depthTest);
            Debug.DrawRay(min + width + depth, height, color, duration, depthTest);
            Debug.DrawRay(min, depth, color, duration, depthTest);
            Debug.DrawRay(min + width, depth, color, duration, depthTest);
            Debug.DrawRay(min + height, depth, color, duration, depthTest);
            Debug.DrawRay(min + width + height, depth, color, duration, depthTest);
        }
    }
}
