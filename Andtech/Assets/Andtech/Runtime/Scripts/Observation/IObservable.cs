
namespace Andtech {

	public interface IObservable<T> {

		void Register(IObserver<T> observer);

		void Unregister(IObserver<T> observer);
	}
}
