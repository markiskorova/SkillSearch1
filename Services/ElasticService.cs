using Nest;
using SkillSearch.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SkillSearch.Services;

public class ElasticService
{
    private readonly ElasticClient _client;

    public ElasticService()
    {
        var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
            .DefaultIndex("resources");
        _client = new ElasticClient(settings);
    }

    public async Task IndexResourcesAsync(IEnumerable<Resource> resources)
    {
        foreach (var resource in resources)
        {
            await _client.IndexDocumentAsync(resource);
        }
    }

    public async Task<ISearchResponse<Resource>> SearchAsync(string query)
    {
        return await _client.SearchAsync<Resource>(s => s
            .Query(q => q
                .MultiMatch(m => m
                    .Fields(f => f
                        .Field(r => r.Title)
                        .Field(r => r.Description))
                    .Query(query)
                )
            )
        );
    }

    public async Task<AggregateDictionary> GetTagsAggregationAsync()
    {
        var result = await _client.SearchAsync<Resource>(s => s
            .Size(0)
            .Aggregations(a => a
                .Terms("tags", t => t
                    .Field("tags.keyword")
                )
            )
        );
        return result.Aggregations;
    }
}