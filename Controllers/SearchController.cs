using Microsoft.AspNetCore.Mvc;
using SkillSearch.Models;
using SkillSearch.Services;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillSearch.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase
{
    private readonly ElasticService _elastic;

    public SearchController(ElasticService elastic)
    {
        _elastic = elastic;
    }

    [HttpPost("index")]
    public async Task<IActionResult> Index()
    {
        var json = await System.IO.File.ReadAllTextAsync("data/resources.json");
        var resources = JsonSerializer.Deserialize<List<Resource>>(json);
        await _elastic.IndexResourcesAsync(resources!);
        return Ok("Data indexed.");
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string q)
    {
        var result = await _elastic.SearchAsync(q);
        return Ok(result.Documents);
    }

    [HttpGet("tags")]
    public async Task<IActionResult> Tags()
    {
        var aggs = await _elastic.GetTagsAggregationAsync();
        return Ok(aggs["tags"]);
    }
}