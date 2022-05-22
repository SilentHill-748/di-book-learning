using CodeSmells.Domain.Abstractions.Services;

namespace CodeSmells.Domain.Implementations.Services
{
    public class MessageService : IMessageService
    {
        public void SendReceipt()
        {
            Console.WriteLine("This is a message service!");
        }
    }
}
