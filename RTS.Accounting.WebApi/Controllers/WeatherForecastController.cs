using MediatR;
using Microsoft.AspNetCore.Mvc;
using RTS.Accounting.Application.Commands.Document.AddDocument;
using System.Runtime.CompilerServices;

namespace RTS.Accounting.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        private readonly ILogger<WeatherForecastController> _logger = logger;

        [HttpGet(Name = "GetWeatherForecast")]
        public int Get()
        {
            _mediator.Send(new AddDocumentCommand("test"));
            return 0;
        }
    }
}
