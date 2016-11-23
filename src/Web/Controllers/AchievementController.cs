using System.Collections.Generic;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Web.Controllers
{
    [Route("api/[controller]")]
    public class AchievementController: Controller
    {
        private readonly IAchievementService _achievementService;

        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }


        [HttpGet]
        public Result<IEnumerable<Achievement>> Get()
        {
            return _achievementService.GetAll();
        }
    }
}