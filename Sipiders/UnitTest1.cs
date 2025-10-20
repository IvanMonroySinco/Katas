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
        
        bool movimiento = araña.Mover(null, mapa);
        //Assert
        movimiento.Should().BeTrue();
        araña.Posicion.Should().Be(1);

    }
}

public class Mapa
{
    public Dictionary<int, Nodo> Nodos { get; set; }

}

public class Nodo
{

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

    public bool Mover(Nodo destino, Mapa mapa)
    {
        this.Posicion = 1;
        return true;
    }
}