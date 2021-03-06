﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OplogDataChartBackend.Entities;
using OplogDataChartBackend.Services;
using System.Collections.Generic;

namespace OplogDataChartBackend.Controllers
{



    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly IConfiguration configuration;
        private readonly ValuesServices _valuesServices;


        public ValuesController(IConfiguration config, ValuesServices valuesServices)
        {
            this.configuration = config;
            _valuesServices = valuesServices;

        }

        // GET api/values
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Ogan", "Dragonetti" };
        }

        [Authorize]
        [HttpPost]
        public JsonResult Post([FromBody]Data value)
        {
            return Json(_valuesServices.ReturnValues(value));
        }
    }
}
