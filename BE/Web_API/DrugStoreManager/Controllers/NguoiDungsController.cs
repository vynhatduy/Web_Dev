using DrugStoreManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugStoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly EntityController<NguoiDung> _controller;

        public NguoiDungsController(MyDbContext context)
        {
            _context = context;
            _controller = new EntityController<NguoiDung>(context);
        }

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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("NguoiDung=={id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var x = _controller.GetById(id);
                if (x == null)
                    return NotFound();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("properties={properties}, values= {values}")]
        public IActionResult GetByProperties(string properties, string values)
        {
            try
            {
                var x = _controller.GetByString(properties, values);
                if (x == null)
                    return NotFound();
                return Ok(x);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(NguoiDung x)
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("NguoiDung={id}")]
        public IActionResult Update(NguoiDung x)
        {
            try
            {
                var s = _controller.UpdateAllEntity(x);
                if (s.Contains("fail"))
                    return BadRequest(s);
                return Ok(s);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("NguoiDung={id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                var x = _controller.GetById(id);
                if (x == null)
                {
                    return NotFound();
                }
                string s = _controller.Delete((NguoiDung)x);
                if (s.Contains("fail"))
                    return BadRequest(s);
                return Ok(s);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
