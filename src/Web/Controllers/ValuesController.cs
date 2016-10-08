using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Core.Domain.Model;

namespace Backend.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public Result<IEnumerable<string>> Get()
        {
            return Result<IEnumerable<string>>.Wrap(new[] { "value1", "value2" }.AsEnumerable());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Result<string> Get(int id)
        {
            return Result<string>.Wrap("value2");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
