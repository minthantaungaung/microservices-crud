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
    public class eVoucherController : ControllerBase
    {
        [HttpPost("CreateUpdateVouncher")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateUpdateVouncher([FromBody]Evouncher evouncher)
        {
            eVoucherManager vouMgr = new eVoucherManager();
            IEnumerable<Evouncher> result = vouMgr.UpSertEVoucher(evouncher);
            return Ok(result);
        }
        [HttpPut("EditVouncher")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditVouncher(int ID)
        {
            eVoucherManager vouMgr = new eVoucherManager();
            Evouncher result = vouMgr.SetAsInactive(ID);
            return Ok(result);
        }

        // [HttpPost("CreateVouncher")]
        // //[Authorize(Roles = "Admin")]
        // public IActionResult CreateUpdateVouncher([FromBody] eVoucherViewModel evouncher)
        // {
        //     eVoucherManager vouMgr = new eVoucherManager();
        //     bool result = vouMgr.AddEmployee(evouncher);
        //     return Ok(result);
        // }
    }
}
