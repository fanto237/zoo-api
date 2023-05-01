using RestApi.Controllers;
using RestApi.Models;

namespace RestApiUnittests;

public class ZooControllerTests
{
    private readonly ZooController _controller;

    public ZooControllerTests()
    {
        _controller = new ZooController();
    }


    [Fact]
    public void GetAllCompounds_Should_Return_All_Compound()
    {
        // Arrange
        const int expected = 1;
        
        // Act
        var result  = _controller.GetAllCompounds().Count;

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void GetCompoundByName_Should_Return_A_Compound_Based_On_Its_Name()
    {
        // Arrange
        const string name = "Gehege 1";
        var expected = new Compound { Name = name, Surface = 36, Animals = new List<Animal>() };
        
        // Act
        var result  = _controller.GetCompoundByName(name);

        // Assert
        Assert.Equivalent(expected, result);
    }

    [Fact]
    public void GetAllAnimals_Should_Return_All_Animals()
    {
        // Arrange
        const int expected = 3; 
        
        // Act
        var result = _controller.GetAllAnimals().Count;

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetAnimalByName_Should_Return_An_Animal_Based_On_Its_Name()
    {
        // Arrange
        const string name = "Hund";
        var expected = new Animal { Age = 5, Name = name, Art = "Saeugetiere" };
       
        // Act
        var result = _controller.GetAnimalByName(name);
        
        // Assert
        Assert.Equivalent(expected, result);
    }

    [Fact]
    public void Add_Should_Add_An_New_Animal()
    {
        // Arrange 
        const string name = "Danger";
        var newAnimal = new AnimalDto() { Age = 12, Art = "Saugetiere", Name = "Danger", CompoundName = "Gehege 1" };
        
        // Act
        _ =_controller.Add(newAnimal);
        var result = _controller.GetAnimalByName(name);
        
        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public void Delete_Should_Delete_An_Animal()
    {
        // Arrange
        var animal2Delete = new AnimalDto() { Age = 12, Name = "Katze", Art = "Saeugetiere" };


        // Act
           var result = _controller.Delete(animal2Delete);

        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void Delete_Should_Return_False_When_The_AnimalToDelete_Not_Exist()
    {
        // Arrange
        var animal2Delete = new AnimalDto() { Age = 12, Name = "Dangui", Art = "Saeugetiere" };
        
        // Act
        var result = _controller.Delete(animal2Delete);

        // Assert
        Assert.True(!result);
    }
}