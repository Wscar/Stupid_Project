﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SP.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;

namespace SP.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SqlMap sqlMap;
        AuthenticationOptions Options;
        public ValuesController(SqlMap _sqlMap, IOptions<AuthenticationOptions> _options)
        {
            sqlMap = _sqlMap;
            Options = _options.Value;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {    
            
            return new List<string>() { Options.SchemeMap.Count().ToString()};
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return sqlMap.GetSqlStatment("updateFormName");
        }

        // POST api/values
        [HttpPost]
      
        public void Post([FromBody]string value)
        {
            string v = value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
