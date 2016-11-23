using System;
using System.Collections.Generic;
using Domain.Cache.Interfaces;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Web.Controllers
{
    [Route("api/[controller]")]
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;
        private readonly ICacheService _cacheService;

        public FacultyController(IFacultyService facultyService, ICacheService cacheService)
        {
            _facultyService = facultyService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public Result<IEnumerable<Faculty>> Get()
        {
            string key = $"{nameof(FacultyController)}-{nameof(Get)}";
            return _cacheService.GetOrStore(key, () => _facultyService.GetAll(), TimeSpan.FromHours(1));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _facultyService.Dispose();
            }
        }
    }
}