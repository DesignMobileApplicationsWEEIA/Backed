using System;
using System.Collections.Generic;
using Domain.Cache.Interfaces;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class UserAchievementController : Controller
    {
        private readonly IUserAchievementService _userAchievementService;
        private readonly ICacheService _cacheService;

        public UserAchievementController(IUserAchievementService userAchievementService, ICacheService cacheService)
        {
            _userAchievementService = userAchievementService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public Result<IEnumerable<UserAchievement>> Get()
        {
            string key = $"{nameof(UserAchievementController)}-{nameof(Get)}";
            return _cacheService.GetOrStore(key, () => _userAchievementService.GetAll(), TimeSpan.FromMinutes(1));
        }

        [HttpPost]
        public Result<bool> Post(ApiUserAchievement userAchievement)
        {
            return _userAchievementService.Add(userAchievement);
        }

        [HttpPost]
        public Result<bool> Post(PhoneData data)
        {
            return _userAchievementService.StoreAchievement(data);
        }

        [HttpPost]
        public Result<List<AchievementResult>> GetUserAchievements(string macAddress)
        {
            string cacheKey = $"{nameof(UserAchievementController)}-{nameof(GetUserAchievements)}-{macAddress}";
            return _userAchievementService.GetUserAchievements(macAddress);
        }
    }
}
