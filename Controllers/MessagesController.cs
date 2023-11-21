using API_Mes.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Mes.Controllers
{
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private static List<Message> messages = new List<Message>
        {
            new Message { Id = 1, Sender = "User1", Text = "Hello, World!" },
            new Message { Id = 2, Sender = "User2", Text = "Hi there!" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get()
        {
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public ActionResult<Message> GetById(int id)
        {
            var message = messages.FirstOrDefault(m => m.Id == id);
            if (message == null)
                return NotFound();

            return Ok(message);
        }

        [HttpPost]
        public ActionResult<Message> Create(Message message)
        {
            message.Id = messages.Count + 1;
            messages.Add(message);

            return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Message updatedMessage)
        {
            var existingMessage = messages.FirstOrDefault(m => m.Id == id);
            if (existingMessage == null)
                return NotFound();

            existingMessage.Sender = updatedMessage.Sender;
            existingMessage.Text = updatedMessage.Text;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var message = messages.FirstOrDefault(m => m.Id == id);
            if (message == null)
                return NotFound();

            messages.Remove(message);

            return NoContent();
        }
    }

}
