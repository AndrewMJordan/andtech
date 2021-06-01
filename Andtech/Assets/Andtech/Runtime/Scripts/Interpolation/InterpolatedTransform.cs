using System.Collections;
using UnityEngine;

namespace Andtech
{

    internal static class TransformExtensions
    {

        public static void Apply(this Transform transform, TransformState state)
        {
            transform.position = state.Position;
            transform.rotation = state.Rotation;
            transform.localScale = state.Scale;
        }
    }

    internal struct TransformState
    {
        public Vector3 Position { get; set; }
        public Quaternion Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public TransformState(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }

        public static TransformState FromTransform(Transform transform)
        {
            return new TransformState
            {
                Position = transform.position,
                Rotation = transform.rotation,
                Scale = transform.localScale
            };
        }

        public static TransformState Lerp(TransformState a, TransformState b, float t)
        {
            return new TransformState
            {
                Position = Vector3.Lerp(a.Position, b.Position, t),
                Rotation = Quaternion.Slerp(a.Rotation, b.Rotation, t),
                Scale = Vector3.Lerp(a.Scale, b.Scale, t)
            };
        }
    }

    [DefaultExecutionOrder(-700)]
    public class InterpolatedTransform : MonoBehaviour
    {
        private readonly TransformState[] stateBuffer = new TransformState[2];

        private int RecentStateIndex { get; set; } = 0;
        private int PreviousStateIndex => RecentStateIndex == 0 ? 1 : 0;
        private TransformState RecentState
        {
            get => stateBuffer[RecentStateIndex];
            set
            {
                RecentStateIndex = PreviousStateIndex;
                stateBuffer[RecentStateIndex] = value;
            }
        }
        private TransformState PreviousState
        {
            get => stateBuffer[PreviousStateIndex];
            set => stateBuffer[PreviousStateIndex] = value;
        }

        private Transform Source;
        private Transform Target;

        public void ForgetPreviousState()
        {
            var state = TransformState.FromTransform(Source);
            stateBuffer[0] = state;
            stateBuffer[1] = state;
            RecentStateIndex = 0;
        }

        #region MONOBEHAVIOUR
        protected virtual void Awake()
        {
            Source = transform;
            Target = transform;
        }

        protected virtual void OnEnable()
        {
            ForgetPreviousState();

            StartCoroutine(LateFixedUpdating());
        }

        protected virtual void OnDisable()
        {
            StopAllCoroutines();
        }

        protected virtual void FixedUpdate()
        {
            RestoreState();
        }

        protected virtual void Update()
        {
            var state = TransformState.Lerp(PreviousState, RecentState, FrameInterpolation.InterpolationFactor);
            Target.Apply(state);
        }
        #endregion

        #region COROUTINE
        private IEnumerator LateFixedUpdating()
        {
            while (enabled)
            {
                yield return Yielders.WaitForPostFixedUpdate;

                RememberState();
            }
        }
        #endregion

        #region PIPELINE
        private void RestoreState()
        {
            Target.Apply(RecentState);
        }

        private void RememberState()
        {
            RecentState = TransformState.FromTransform(Source);
        }
        #endregion
    }
}
