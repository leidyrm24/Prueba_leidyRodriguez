using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_leidyRodriguez;
using Prueba_leidyRodriguez.Models;

namespace Prueba_leidyRodriguez.Controllers
{
    [Route("api/CITY")]
    [ApiController]
    public class CITYSController : ControllerBase
    {
        private readonly DatosContext _context;

        public CITYSController(DatosContext context)
        {
            _context = context;
        }

        #region List
        // GET: api/CITies
        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<CITY>>> GetCITYS()
        {
            return await _context.CITYS.ToListAsync();
        }
        #endregion

        #region Details
        // GET: api/CITies/5
        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<CITY>> GetCITY(int id)
        {
            var cITY = await _context.CITYS.FindAsync(id);

            if (cITY == null)
            {
                return NotFound();
            }

            return cITY;
        }

        #endregion

        #region UpdateCity
        // PUT: api/CITies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("UpdateCity")]
        public async Task<IActionResult> PutCITY(CITY cITY)
        {
            int id = cITY.CODE;

            if (id != cITY.CODE)
            {
                return BadRequest();
            }

            _context.Entry(cITY).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CITYExists(id))
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
        #endregion

        #region CreateRecord
        // POST: api/CITies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("CreateRecord")]
        public async Task<ActionResult<CITY>> PostCITY(CITY cITY)
        {
            _context.CITYS.Add(cITY);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCITY", new { id = cITY.CODE }, cITY);
        }

        #endregion

        #region DeleteCity
        // DELETE: api/CITies/5
        [HttpPost]
        [Route("DeleteCity")]
        public async Task<IActionResult> DeleteCITY(CITY cITY)
        {
            int id = cITY.CODE;

            var CITY = await _context.CITYS.FindAsync(id);
            if (CITY == null)
            {
                return NotFound();
            }

            _context.CITYS.Remove(CITY);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        private bool CITYExists(int id)
        {
            return _context.CITYS.Any(e => e.CODE == id);
        }
    }
}
