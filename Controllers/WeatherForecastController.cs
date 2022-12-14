using Microsoft.AspNetCore.Mvc;
using MSykutera.Tinkering.MongoDB.Model;
using MSykutera.Tinkering.MongoDB.Repostories;
using MSykutera.Tinkering.MongoDB.ViewModel;

namespace MSykutera.Tinkering.MongoDB.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IRepository<WeatherForecast> _repository;

    public WeatherForecastController(IRepository<WeatherForecast> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken token) => await _repository.GetAsync(token);

    [HttpDelete("{id:string")]
    public async Task Delete(string id, CancellationToken token) => await _repository.DeleteAsync(id, token);

    [HttpPost]
    public async Task<string> Add(WeatherForecastViewModel viewModel, CancellationToken token)
    {
        var model = new WeatherForecast
        {
            Date = viewModel.Date,
            Summary = viewModel.Summary,
            TemperatureC = viewModel.TemperatureC
        };
        return await _repository.AddAsync(model, token);
    }

    [HttpPut]
    public async Task Update(WeatherForecastViewModel viewModel, CancellationToken token)
    {
        var model = new WeatherForecast
        {
            Date = viewModel.Date,
            Summary = viewModel.Summary,
            TemperatureC = viewModel.TemperatureC
        };
        await _repository.UpdateAsync(model, token);
    }
}