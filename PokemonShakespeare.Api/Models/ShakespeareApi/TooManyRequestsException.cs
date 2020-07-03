using System;

namespace PokemonShakespeare.Api.Models.ShakespeareApi
{
    [Serializable]
    public class TooManyRequestsException : Exception
    {
        public TooManyRequestsException() { }
        public TooManyRequestsException(string message) : base(message) { }
        public TooManyRequestsException(string message, Exception inner) : base(message, inner) { }
        protected TooManyRequestsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
