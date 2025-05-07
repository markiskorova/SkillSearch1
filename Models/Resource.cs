namespace SkillSearch.Models;

public class Resource
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string[] Tags { get; set; } = [];
    public string Description { get; set; } = string.Empty;
}