using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Domain.Cache.Interfaces;
using Domain.Model.Api;

namespace Backend.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ICacheService _cacheService;

        public ValuesController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

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
            string key = $"{nameof(ValuesController)}-{nameof(Get)}-{id}";

            return _cacheService.GetOrStore(key, () => Result<string>.Wrap($"value2-{id}-{DateTime.Now}"),TimeSpan.FromMinutes(5));
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
