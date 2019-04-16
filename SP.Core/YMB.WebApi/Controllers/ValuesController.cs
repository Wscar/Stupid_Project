using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace YMB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            Dictionary<string, Dictionary<string, string>> props = new Dictionary<string, Dictionary<string, string>>();
            var claims = new Dictionary<string, string>();
            foreach (var claim in User.Claims)
            {
                claims.Add(claim.Type, claim.Value);
            }
            props.Add("Claims", claims);
            var xxx = new Dictionary<string, string>();
            foreach (var prop in (await HttpContext.AuthenticateAsync()).Properties.Items)
            {
                xxx.Add(prop.Key, prop.Value);
            }
            props.Add("prop", xxx);
            return Ok(props);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
