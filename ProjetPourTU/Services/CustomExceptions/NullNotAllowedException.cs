using System;
using System.Runtime.Serialization;

namespace ProjetPourTU.Services.CustomExceptions {
    
    public class NullNotAllowedException : Exception {
        public NullNotAllowedException() {
        }

        public NullNotAllowedException(string message) : base(message) {
        }

        public NullNotAllowedException(string message, Exception innerException) : base(message, innerException) {
        }

        protected NullNotAllowedException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}