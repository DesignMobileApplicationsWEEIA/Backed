using Core.Domain.Model;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Web.Controllers
{
    [Route("api/[controller]")]
    public class BuildingController
    {
        private readonly IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost("search")]
        public Result<Building> Search([FromBody] PhoneData phoneData)
        {
            return _buildingService.SearchBuildingWithPhoneData(phoneData);
        }

    }
}