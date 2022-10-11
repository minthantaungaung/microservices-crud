using CMSAPI.Manager;
using CMSAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private ICatalogService catalogService;

        public CatalogController(ICatalogService _catalogService)
        {
            catalogService = _catalogService;
        }

        [Produces("application/json")]
        [HttpGet("findall")]
        [Authorize]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(catalogService.FindAll());
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("Create")]
        [Authorize]
        public IActionResult Create([FromBody]Product product)
        {
            try
            {
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateUpdateVouncher")]
        [Authorize]    
        public IActionResult CreateUpdateVouncher([FromBody] Evouncher evouncher)
        {
            eVoucherManager vouMgr = new eVoucherManager();
            IEnumerable<Evouncher> result = vouMgr.UpSertEVoucher(evouncher);
            return Ok(result);
        }

    }
}
