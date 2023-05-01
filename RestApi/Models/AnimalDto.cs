namespace RestApi.Models;

public class AnimalDto
{
    public string Name { get; set; } = null!;
    public string Art { get; set; } = null!;
    public int Age { get; set; }
    public string CompoundName { get; set; } = null!;
}