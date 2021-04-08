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
    public class SavedCreditCartsController : ControllerBase
    {
        ISavedCreditCartService _savedCreditCartService;
        public SavedCreditCartsController(ISavedCreditCartService savedCreditCartService)
        {
            _savedCreditCartService = savedCreditCartService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _savedCreditCartService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyıd")]
        public IActionResult Get(int id)
        {
            var result = _savedCreditCartService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SavedCreditCart creditCart)
        {
            var result = _savedCreditCartService.Add(creditCart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SavedCreditCart creditCart)
        {
            var result = _savedCreditCartService.Delete(creditCart);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
   

    }
}
