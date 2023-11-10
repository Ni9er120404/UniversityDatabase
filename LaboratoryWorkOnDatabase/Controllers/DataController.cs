using LaboratoryWorkOnDatabase.Data;
using LaboratoryWorkOnDatabase.Services.DataGenerator;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoryWorkOnDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController(Context context) : ControllerBase
    {
        private readonly Context _context = context;

        [HttpPost]
        public async Task<ActionResult> CreateData(int quantity)
        {
            DataGeneratorService dataGenerator = new();
            
            await dataGenerator.SaveDataInDatabase(_context, quantity);
            
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}