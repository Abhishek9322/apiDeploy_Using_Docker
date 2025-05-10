using apiDeploy_Using_Docker.Data;
using apiDeploy_Using_Docker.ModelClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiDeploy_Using_Docker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        private readonly StudentDbContext _context;
        public studentController(StudentDbContext context) 
        {
          _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<student>>> GetAll()
        {
            return await _context.students.ToListAsync();
        }
        //create 
        [HttpGet("{id}")]
        public async Task<ActionResult<student>> GetById(int id)
        {
            var product = await _context.students.FindAsync(id);
            if (product == null) return NotFound();

            return product;

        }
        //Create Api
        [HttpPost]
        public async Task<ActionResult<student>> Create(student students)
        {
            _context.students.Add(students);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = students.Id }, students);
        }


        //update Api

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, student students)
        {
            if (id !=students .Id) return BadRequest();

            _context.Entry(students).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        //Delete Api
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var students = await _context.students.FindAsync(id);
            if (students == null) return NotFound();

            _context.students.Remove(students);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
