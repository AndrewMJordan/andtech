using System;

namespace Andtech
{

    public class SingletonReferenceException : Exception
    {
        private const string DEFAULT_MESSAGE = "Singleton reference not set to an instance of an object";

        public SingletonReferenceException() : base(DEFAULT_MESSAGE) { }

        public SingletonReferenceException(Type type) : base(string.Format("{0} singleton not set to an instance of an object", type.Name)) { }
    }
}
