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
        araña.Posicion.Should().Be(0);
        araña.Nombre.Should().Be("Cazadora");
    }
    
    [Fact]
    public void LaAraña_Deberia_MoverseAUnNodoConectado()
    {
        //Arrange
        var mapa = new Mapa();
        var araña = new Araña("Cazadora", 0);
        //Act
        var destino = mapa.Nodos[1];
        bool movimiento = araña.Mover(destino, mapa);
        //Assert
        movimiento.Should().BeTrue();

    }
}

public class Mapa
{
    public Dictionary<int, int> Nodos { get; set; }
}

public class Araña
{
    public string Nombre { get; set; }
    public int Posicion { get; set; }

    public Araña(string nombre, int posicion)
    {
        this.Nombre = nombre;
        this.Posicion = posicion;
    }

    public bool Mover(object destino, Mapa mapa)
    {
        throw new NotImplementedException();
    }
}