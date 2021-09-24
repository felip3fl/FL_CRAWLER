using Microsoft.AspNetCore.Mvc;
using Puan.Business.Interfaces.Services;
using Puan.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puan.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class PointTimeController : Controller
    {
        private readonly IPointTimeService _pointTimeService;

        public PointTimeController(IPointTimeService pointTimeService)
        {
            _pointTimeService = pointTimeService;
        }

        [HttpGet("Add")]
        public async Task<ActionResult> Add()
        {
            try
            {
                var oi = new PointTime {
                    Mark = DateTime.Now,
                    Activated = true
                };
                _pointTimeService.Add(oi);
                return Ok(true);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _pointTimeService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
