using Domain.Cache.Interfaces;
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
    }
}