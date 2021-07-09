using FillMeApp.Server.Model;
using FillMeApp.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FillMeApp.Server.Controllers
{
    [Route("api/party")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly FillMeAppDbContext _context;
        private readonly IFillMeAppDbService _service;
        //public PartyController(FillMeAppDbContext fillMeAppDbContext) { _context = fillMeAppDbContext; }
        public PartyController(IFillMeAppDbService iFillMeAppDbService) { _service = iFillMeAppDbService; }
        [HttpGet]
        public IActionResult GetDoctors() { return Ok(_service.GetParties()); }
    }
}
