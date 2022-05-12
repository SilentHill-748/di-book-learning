using System.Security.Principal;

namespace ClearDIExample
{
    public class SecureMessageWriter : IMessageWriter
    {
        private readonly IMessageWriter _messageWriter;
        private readonly IIdentity _identity;

        public SecureMessageWriter(IMessageWriter messageWriter, IIdentity identity)
        {
            ArgumentNullException.ThrowIfNull(messageWriter, nameof(messageWriter));
            ArgumentNullException.ThrowIfNull(identity, nameof(identity));

            _messageWriter = messageWriter;
            _identity = identity;
        }


        public void Write(string message)
        {
            if (this._identity.IsAuthenticated)
            {
                this._messageWriter.Write("Secure message: " + message);
            }
        }
    }
}
