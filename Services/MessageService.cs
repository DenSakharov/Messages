using API_Mes.Models;

namespace API_Mes.Services
{
    public class MessageService
    {
        private List<Message> _messages = new List<Message>();

        public IEnumerable<Message> GetMessages() => _messages;

        public void SendMessage(Message message)
        {
            message.Id = _messages.Count + 1;
            _messages.Add(message);
        }
    }
}
