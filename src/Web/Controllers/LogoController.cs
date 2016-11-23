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
    public class LogoController : Controller
    {
        private readonly ILogoService _logoService;
        private readonly ICacheService _cacheService;

        public LogoController(ILogoService logoService, ICacheService cacheService)
        {
            _logoService = logoService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public Result<IEnumerable<Logo>> Get()
        {
            string key = $"{nameof(LogoController)}-{nameof(Get)}";
            return _cacheService.GetOrStore(key, () => _logoService.GetAll(), TimeSpan.FromHours(1));
        }
    }
}