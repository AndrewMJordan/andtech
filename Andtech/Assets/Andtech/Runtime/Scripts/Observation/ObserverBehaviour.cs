using UnityEngine;

namespace Andtech
{

    /// <summary>
    /// Template for observing a target subject.
    /// </summary>
    /// <typeparam name="TSubsystem">The subject to target.</typeparam>
    public abstract class ObserverBehaviour<T> : MonoBehaviour, IObserver<T> where T : SubjectBehaviour<T>
    {
        public IObservable<T> Subject => subject;

        [SerializeField]
        private T subject;

        #region MONOBEHAVIOUR
        protected virtual void OnEnable() => Subject?.Register(this);

        protected virtual void OnDisable() => Subject?.Unregister(this);
        #endregion

        #region ABSTRACT
        protected abstract void OnRegister(T instance);

        protected abstract void OnUnregister(T instance);
        #endregion

        #region ABSTRACT
        void IObserver<T>.OnRegister(T instance) => OnRegister(instance);

        void IObserver<T>.OnUnregister(T instance) => OnUnregister(instance);
        #endregion
    }
}
