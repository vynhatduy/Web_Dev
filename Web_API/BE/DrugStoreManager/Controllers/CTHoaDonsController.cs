using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DrugStoreManager.Models;

namespace DrugStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTHoaDonsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly EntityController<CTHoaDon> _controller;

        public CTHoaDonsController(MyDbContext context)
        {
            _context = context;
            _controller = new EntityController<CTHoaDon>(context);
        }

        /*       // GET: api/CTHoaDons
               [HttpGet]
               public async Task<ActionResult<IEnumerable<CTHoaDon>>> GetCTHoaDons()
               {
                 if (_context.CTHoaDons == null)
                 {
                     return NotFound();
                 }
                   return await _context.CTHoaDons.ToListAsync();
               }

               // GET: api/CTHoaDons/5
               [HttpGet("{id}")]
               public async Task<ActionResult<CTHoaDon>> GetCTHoaDon(int id)
               {
                 if (_context.CTHoaDons == null)
                 {
                     return NotFound();
                 }
                   var CTHoaDon = await _context.CTHoaDons.FindAsync(id);

                   if (CTHoaDon == null)
                   {
                       return NotFound();
                   }

                   return CTHoaDon;
               }

               // PUT: api/CTHoaDons/5
               // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
               [HttpPut("{id}")]
               public async Task<IActionResult> PutCTHoaDon(int id, CTHoaDon CTHoaDon)
               {
                   if (id != CTHoaDon.HoaDonId)
                   {
                       return BadRequest();
                   }

                   _context.Entry(CTHoaDon).State = EntityState.Modified;

                   try
                   {
                       await _context.SaveChangesAsync();
                   }
                   catch (DbUpdateConcurrencyException)
                   {
                       if (!CTHoaDonExists(id))
                       {
                           return NotFound();
                       }
                       else
                       {
                           throw;
                       }
                   }

                   return NotFound();
               }

               // POST: api/CTHoaDons
               // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
               [HttpPost]
               public async Task<ActionResult<CTHoaDon>> PostCTHoaDon(CTHoaDon CTHoaDon)
               {
                 if (_context.CTHoaDons == null)
                 {
                     return Problem("Entity set 'MyDbContext.CTHoaDons'  is null.");
                 }
                   _context.CTHoaDons.Add(CTHoaDon);
                   try
                   {
                       await _context.SaveChangesAsync();
                   }
                   catch (DbUpdateException)
                   {
                       if (CTHoaDonExists(CTHoaDon.HoaDonId))
                       {
                           return Conflict();
                       }
                       else
                       {
                           throw;
                       }
                   }

                   return CreatedAtAction("GetCTHoaDon", new { id = CTHoaDon.HoaDonId }, CTHoaDon);
               }

               // DELETE: api/CTHoaDons/5
               [HttpDelete("{id}")]
               public async Task<IActionResult> DeleteCTHoaDon(int id)
               {
                   if (_context.CTHoaDons == null)
                   {
                       return NotFound();
                   }
                   var CTHoaDon = await _context.CTHoaDons.FindAsync(id);
                   if (CTHoaDon == null)
                   {
                       return NotFound();
                   }

                   _context.CTHoaDons.Remove(CTHoaDon);
                   await _context.SaveChangesAsync();

                   return NotFound();
               }

               private bool CTHoaDonExists(int id)
               {
                   return (_context.CTHoaDons?.Any(e => e.HoaDonId == id)).GetValueOrDefault();
               }
        */

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var x = _controller.GetAll();
                if (x == null)
                    return NotFound();
                return Ok(x);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("CTHoaDon=={id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var x=_controller.GetById(id);
                if (x! is CTHoaDon)
                    return BadRequest();
                if (x == null)
                    return NotFound();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("CTHoaDon")]
        public IActionResult GetByProperties(string properties,string s)
        {
            try
            {
                var x=_controller.GetByString(properties, s);
                if (x == null)
                    return NotFound();
                return Ok(x);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(CTHoaDon x)
        {
            try
            {
                string s = _controller.Create(x);
                if (s.Contains("fail"))
                {
                    return BadRequest(x);
                }
                return Ok(s);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("CTHoaDon={id}")]
        public IActionResult Update(CTHoaDon x)
        {
            try
            {
                var s = _controller.UpdateAllEntity(x);
                if (s.Contains("fail"))
                    return BadRequest(s);
                return Ok(s);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("CTHoaDon={id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                var x = _controller.GetById(id);
                if (x == null)
                {
                    return NotFound();
                }
                string s = _controller.Delete((CTHoaDon)x);
                if (s.Contains("fail"))
                    return BadRequest(s);
                return Ok(s);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
