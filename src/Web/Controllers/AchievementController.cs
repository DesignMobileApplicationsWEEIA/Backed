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
    public class AchievementController : Controller
    {
        private readonly IAchievementService _achievementService;
        private readonly ICacheService _cacheService;

        public AchievementController(IAchievementService achievementService, ICacheService cacheService)
        {
            _achievementService = achievementService;
            _cacheService = cacheService;
        }


        [HttpGet]
        public Result<IEnumerable<Achievement>> Get()
        {
            string key = $"{nameof(AchievementController)}-{nameof(Get)}";
            return _cacheService.GetOrStore(key, () => _achievementService.GetAll(), TimeSpan.FromHours(1));
        }
    }
}