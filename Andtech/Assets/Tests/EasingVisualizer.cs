using Andtech;
using System;
using UnityEngine;


public class EasingVisualizer : MonoBehaviour
{
    public EasingCurve curve;
    [Range(2, 32)]
    public int pointCount;
    [Range(1, 5)]
    public int power;

    void OnDrawGizmos()
    {
        Func<float, float> f;
        switch (curve)
        {
            case EasingCurve.Linear:
                f = Easing.Linear;
                break;
            case EasingCurve.EaseInQuadratic:
                f = Easing.EaseInQuadratic;
                break;
            case EasingCurve.EaseOutQuadratic:
                f = Easing.EaseOutQuadratic;
                break;
            case EasingCurve.EaseInOutQuadratic:
                f = Easing.EaseInOutQuadratic;
                break;
            case EasingCurve.EaseInCubic:
                f = Easing.EaseInCubic;
                break;
            case EasingCurve.EaseOutCubic:
                f = Easing.EaseOutCubic;
                break;
            case EasingCurve.EaseInOutCubic:
                f = Easing.EaseInOutCubic;
                break;
            case EasingCurve.EaseInQuartic:
                f = Easing.EaseInQuartic;
                break;
            case EasingCurve.EaseOutQuartic:
                f = Easing.EaseOutQuartic;
                break;
            case EasingCurve.EaseInOutQuartic:
                f = Easing.EaseInOutQuartic;
                break;
            case EasingCurve.EaseInQuintic:
                f = Easing.EaseInQuintic;
                break;
            case EasingCurve.EaseOutQuintic:
                f = Easing.EaseOutQuintic;
                break;
            case EasingCurve.EaseInOutQuintic:
                f = Easing.EaseInOutQuintic;
                break;
            case EasingCurve.EaseInPow:
                f = t => Easing.EaseInPow(t, power);
                break;
            case EasingCurve.EaseOutPow:
                f = t => Easing.EaseOutPow(t, power);
                break;
            case EasingCurve.EaseInOutPow:
                f = t => Easing.EaseInOutPow(t, power);
                break;
            case EasingCurve.EaseOutInPow:
                f = t => Easing.EaseOutInPow(t, power);
                break;
            default:
                f = Easing.Linear;
                break;
        }

        var previous = Vector2.zero;
        for (int i = 0; i <= pointCount; i++)
        {
            var alpha = (float)i / pointCount;
            var x = alpha;
            var y = f(x);

            var position = new Vector2(x, y);
            Gizmos.DrawLine(previous, position);
            previous = position;
        }
    }

    public enum EasingCurve
    {
        Linear,
        EaseInQuadratic,
        EaseOutQuadratic,
        EaseInOutQuadratic,
        EaseInCubic,
        EaseOutCubic,
        EaseInOutCubic,
        EaseInQuartic,
        EaseOutQuartic,
        EaseInOutQuartic,
        EaseInQuintic,
        EaseOutQuintic,
        EaseInOutQuintic,
        EaseInPow,
        EaseOutPow,
        EaseInOutPow,
        EaseOutInPow
    }
}