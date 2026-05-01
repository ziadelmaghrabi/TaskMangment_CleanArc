using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Interfaces;
using TaskMange.Core.Entiteis;

namespace TaskMange.Api.Controllers
{
    [Route("api/[controller]")]      //attribute routing

    [ApiController]
    public class TaskController : ControllerBase

    {
        

        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        //path : api/Department   http verp--> get

        [HttpGet]
        public async Task<IActionResult> GetAll(bool? isCompleted, bool sortByDueDate = false)
        {
            var tasks = await _service.GetAllAsync(isCompleted, sortByDueDate);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            await _service.AddAsync(task);
            return Ok(task);
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskItem task)
        {
            await _service.UpdateAsync(task);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

    }

    }

