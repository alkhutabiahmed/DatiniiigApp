using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            this._context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetValues () 
        {
         var   values =await  _context.Values.ToListAsync();
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetValue (int id) 
        {
            var value = await  _context.Values.FirstOrDefaultAsync(x=>x.Id == id);
            return Ok(value);
        }
    }
}