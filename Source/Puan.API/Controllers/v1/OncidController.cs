using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Puan.Business.Interfaces.Services;

namespace Puan.API.Controllers.v1
{
    [ApiController]
    [Route("[controller]")]
    public class OncidController : Controller
    {
        private readonly IOncidService _oncidService;

        public OncidController(IOncidService oncidService)
        {
            _oncidService = oncidService;
        }

        [HttpGet]
        public async Task<String> GetMarcPoint()
        {
            try
            {
                _oncidService.MarkPoint();
                return null;
            }
            catch (Exception)
            {
                return null;   
            }
        }
    }
}
