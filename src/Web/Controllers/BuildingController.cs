using System;
using Domain.Cache.Interfaces;
using Domain.Model.Api;
using Domain.Model.Database;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Web.Controllers
{
    [Route("api/[controller]")]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _buildingService;
        private readonly ICacheService _cacheService;

        public BuildingController(IBuildingService buildingService, ICacheService cacheService)
        {
            _buildingService = buildingService;
            _cacheService = cacheService;
        }

        [HttpPost("search")]
        public Result<Building> Search([FromBody] PhoneData phoneData)
        {
            string key =
                $"{nameof(Search)}-{phoneData?.Direction}-{phoneData?.PhoneLocation?.Longitude}-{phoneData?.PhoneLocation?.Latitude}";
            return _cacheService.GetOrStore(key, () => _buildingService.SearchBuildingWithPhoneData(phoneData), TimeSpan.FromHours(1));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _buildingService.Dispose();
            }
        }

    }
}