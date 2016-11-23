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
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly ICacheService _cacheService;

        public PlaceController(IPlaceService placeService, ICacheService cacheService)
        {
            _placeService = placeService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public Result<IEnumerable<Place>> Get()
        {
            string key = $"{nameof(Get)}-{nameof(PlaceController)}";
            return _cacheService.GetOrStore(key, () => _placeService.GetAll(null, string.Empty), TimeSpan.FromDays(1));
        }

        [HttpPost]
        public Result<bool> Search([FromBody] ApiPlace place)
        {
            return _placeService.Add(place, "");
        }

    }
}