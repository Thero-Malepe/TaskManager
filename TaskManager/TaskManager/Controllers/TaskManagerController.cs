using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetTasks()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string GetTaskById(int id)
        {
            return "value";
        }

        [HttpPost]
        public void CreateTask([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void UpdateTask(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void DeleteTask(int id)
        {
        }
    }
}
