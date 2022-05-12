namespace ClearDIExample
{
    public class Salutation
    {
        private readonly IMessageWriter _messageWriter;


        public Salutation(IMessageWriter messageWriter)
        {
            ArgumentNullException.ThrowIfNull(messageWriter, nameof(messageWriter));

            _messageWriter = messageWriter;
        }


        public void Exclaim()
        {
            this._messageWriter.Write("Hello DI!");
        }
    }
}
