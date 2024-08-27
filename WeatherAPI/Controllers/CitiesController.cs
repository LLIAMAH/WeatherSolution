using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.DB.Reps.Interfaces;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ILogger<CitiesController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CitiesController(ILogger<CitiesController> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }
    }
}
