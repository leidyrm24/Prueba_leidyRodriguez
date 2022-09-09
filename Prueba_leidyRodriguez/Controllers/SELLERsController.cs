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
    [Route("api/SELLER")]
    [ApiController]
    public class SELLERsController : ControllerBase
    {
        private readonly DatosContext _context;

        public SELLERsController(DatosContext context)
        {
            _context = context;
        }

        #region List
        // GET: api/SELLERs
        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<IEnumerable<SELLER>>> GetSELLERS()
        {
            return await _context.SELLERS.ToListAsync();
        }
        #endregion

        #region Details
        // GET: api/SELLERs/5
        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult<SELLER>> GetSELLER(int id)
        {
            var sELLER = await _context.SELLERS.FindAsync(id);

            if (sELLER == null)
            {
                return NotFound();
            }

            return sELLER;
        }
        #endregion

        #region UpdateSeller
        // PUT: api/SELLERs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("UpdateSeller")]
        public async Task<IActionResult> PutSELLER(SELLER sELLER)
        {
            int id = sELLER.CODE;
            if (id != sELLER.CODE)
            {
                return BadRequest();
            }

            _context.Entry(sELLER).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SELLERExists(id))
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
        // POST: api/SELLERs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("CreateRecord")]
        public async Task<ActionResult<SELLER>> PostSELLER(SELLER sELLER)
        {
            try
            {
                _context.SELLERS.Add(sELLER);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSELLER", new { id = sELLER.CODE }, sELLER);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region DeleteSeller
        // DELETE: api/SELLERs/5
        [HttpPost]
        [Route("DeleteSeller")]
        public async Task<IActionResult> DeleteSELLER(SELLER sELLER)
        {
            int id = sELLER.CODE;
            var sELLERs = await _context.SELLERS.FindAsync(id);
            if (sELLERs == null)
            {
                return NotFound();
            }

            _context.SELLERS.Remove(sELLERs);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        private bool SELLERExists(int id)
        {
            return _context.SELLERS.Any(e => e.CODE == id);
        }
        

    }
}
