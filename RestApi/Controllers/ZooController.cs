using Microsoft.AspNetCore.Mvc;
using RestApi.Models;

namespace RestApi.Controllers;

[ApiController]
public class ZooController : Controller
{
    private List<Animal> _animals = new()
    {
        new Animal { Age = 12, Name = "Katze", Art = "Saeugetiere" },
        new Animal { Age = 5, Name = "Hund", Art = "Saeugetiere" },
        new Animal { Age = 2, Name = "Rind", Art = "Saeugetiere" }
    };

    private List<Compound> _compounds = new()
    {
        new Compound { Name = "Gehege 1", Surface = 36, Animals = new List<Animal>() }
    };


    [HttpGet("compounds")]
    public List<Compound> GetAllCompounds()
    {
        return _compounds;
    }

    [HttpGet("compounds/{name}")]
    public Compound? GetCompoundByName(string name)
    {
        var result = _compounds.Find(e => e.Name == name);
        return result;
    }

    [HttpGet("animals")]
    public List<Animal> GetAllAnimals()
    {
        return _animals;
    }

    [HttpGet("/animals/{name}")]
    public Animal? GetAnimalByName(string name)
    {
        var result = _animals.Find(e => e.Name == name);
        return result;
    }

    [HttpPost("compounds/animals")]
    public bool Add(AnimalDto entity)
    {
        var animal = new Animal { Name = entity.Name, Age = entity.Age, Art = entity.Art };
        foreach (var compound in _compounds.Where(compound => compound.Name == entity.CompoundName))
            compound.Animals?.Add(animal);
        _animals.Add(animal);
        return true;
    }

    [HttpDelete("compounds/animals")]
    public bool Delete(AnimalDto entity)
    {
        var existing = GetAnimalByName(entity.Name);
        if (existing is null)
            return false;
        var animal = new Animal { Name = entity.Name, Age = entity.Age, Art = entity.Art };
        foreach (var compound in _compounds.Where(compound => compound.Name == entity.CompoundName))
            compound.Animals?.Remove(animal);
        _animals.Remove(animal);
        return true;
    }
}