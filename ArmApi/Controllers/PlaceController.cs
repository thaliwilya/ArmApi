﻿using ArmApi.Interface;
using ArmApi.Model.Services.GoogleAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly ILogger<PlaceController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IGooglePlacesAPI _IGooglePlacesAPI;
        public PlaceController(ILogger<PlaceController> logger, IConfiguration configuration ,IGooglePlacesAPI IGooglePlacesAPI)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into PlaceController");
            _configuration = configuration;
            _IGooglePlacesAPI = IGooglePlacesAPI;
        }

        [HttpGet("queryPlace")]
        public async Task<ActionResult> queryPlaceAsync([FromQuery] string? name)
        {
            _logger.LogInformation("Hello, this Place Get!");
            var result = await _IGooglePlacesAPI.ApplyAsync(name);
            var item = result.results.Select(a => a.geometry.location).ToList();

            //return Ok(result.results);
            return Ok(item);
        }
    }
}
