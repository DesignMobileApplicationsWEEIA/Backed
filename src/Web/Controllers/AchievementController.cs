using System.Collections.Generic;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Repositories.Interfaces;
using Domain.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Web.Controllers
{
    [Route("api/[controller]")]
    public class AchievementController: Controller
    {
        private readonly AchievementService _achievementService;

        public AchievementController(IUnitOfWork unitOfWork)
        {
            _achievementService = new AchievementService(unitOfWork);
        }

        [HttpGet]
        public Result<IEnumerable<Achievement>> Get()
        {
            return _achievementService.GetAll();
        }
    }
}