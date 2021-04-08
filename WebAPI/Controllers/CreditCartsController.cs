using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCartsController : ControllerBase
    {
        ICreditCartService _creditCartService;
        public CreditCartsController(ICreditCartService creditCartService)
        {
            _creditCartService = creditCartService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _creditCartService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyıd")]
        public IActionResult Get(int id)
        {
            var result = _creditCartService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(CreditCart creditCart)
        {
            var result = _creditCartService.Add(creditCart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("delete")]
        public IActionResult Delete(CreditCart creditCart)
        {
            var result = _creditCartService.Delete(creditCart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getcartbycartnumber")]
        public IActionResult GetCartByCartNumber(string cartNumber)
        {
            var result = _creditCartService.GetCrediCartByCartNumber(cartNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
