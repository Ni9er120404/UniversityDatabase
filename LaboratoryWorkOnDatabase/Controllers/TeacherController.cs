using LaboratoryWorkOnDatabase.Models;
using LaboratoryWorkOnDatabase.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoryWorkOnDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(ITeacherService service) : ControllerBase
    {
        private readonly ITeacherService _service = service;

        [HttpPost]
        public async Task<ActionResult<Teacher>> Create(Teacher item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return await _service.Create(item);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> Delete(int id)
        {
            Teacher? item = await _service.Delete(id);

            if (item is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                return item;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> Get(int id)
        {
            var item = await _service.Get(id);

            if (item is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                return item;
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
        {
            var items = await _service.GetAll();

            if (items is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return Ok(items);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Teacher>> Update(Teacher item)
        {
            Teacher? teacher = await _service.Update(item);

            if (teacher is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return teacher;
            }
        }
    }
}