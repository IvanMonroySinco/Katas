using FluentAssertions;

namespace KatasTDD;

public class SpidersTest
{
    [Fact]
    public void LaAraña_Debera_IniciarConUnaPosicionEnviada()
    {
        //Arrange
        
        //Act
        var araña = new Araña("Cazadora", 0);
        //Assert
        araña.posicion.Should().Be(0);
    }
    
    
}

public class Araña
{
    public object posicion;

    public Araña(string cazadora, int i)
    {
        throw new NotImplementedException();
    }
}