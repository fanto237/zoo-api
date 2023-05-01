namespace RestApi.Models;

public class Compound
{
    public string Name { get; set; } = null!;
    public decimal Surface { get; set; }
    public List<Animal>? Animals { get; set; } = new();
}