using System;
using System.Runtime.Serialization;

namespace ProjetPourTU.Services.CustomExceptions {

    public class SameIDExistsException : Exception {
        public SameIDExistsException() {
        }

        public SameIDExistsException(string message) : base(message) {
        }

        public SameIDExistsException(string message, Exception innerException) : base(message, innerException) {
        }

        protected SameIDExistsException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}