using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominic_2005053J.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominic_2005053J.Server.Data;
using Dominic_2005053J.Server.IRepository;
using Dominic_2005053J.Shared.Domain;

namespace Dominic_2005053J.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeveritysController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public SeveritysController(ApplicationDbContext context)
        public SeveritysController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Severitys
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Severity>>> GetSeveritys()
        public async Task<IActionResult> GetSeveritys()
        {
            //return await _context.Severitys.ToListAsync();
            var severitys = await _unitOfWork.Severitys.GetAll();
            return Ok(severitys);
        }

        // GET: api/Severitys/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Severity>> GetSeverity(int id)
        public async Task<IActionResult> GetSeverity(int id)
        {
            //var severity = await _context.Severitys.FindAsync(id);
            var severity = await _unitOfWork.Severitys.Get(q => q.Id == id);

            if (severity == null)
            {
                return NotFound();
            }

            //return severity;
            return Ok(severity);
        }

        // PUT: api/Severitys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeverity(int id, Severity severity)
        {
            if (id != severity.Id)
            {
                return BadRequest();
            }

            //_context.Entry(severity).State = EntityState.Modified;
            _unitOfWork.Severitys.Update(severity);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!SeverityExists(id))
                if (!await SeverityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Severitys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Severity>> PostSeverity(Severity severity)
        {
            //_context.Severitys.Add(severity);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Severitys.Insert(severity);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetSeverity", new { id = severity.Id }, severity);
        }

        // DELETE: api/Severitys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeverity(int id)
        {
            //var severity = await _context.Severitys.FindAsync(id);
            var severity = await _unitOfWork.Severitys.Get(q => q.Id == id);
            if (severity == null)
            {
                return NotFound();
            }

            //_context.Severitys.Remove(severity);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Severitys.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool SeverityExists(int id)
        private async Task<bool> SeverityExists(int id)
        {
            //return _context.Severitys.Any(e => e.Id == id);
            var severity = await _unitOfWork.Severitys.Get(q => q.Id == id);
            return severity != null;
        }
    }
}
