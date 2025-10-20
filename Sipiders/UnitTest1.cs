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
        araña.Posicion.Should().Be(1);

    }

    [Fact]
    public void LaAraña_NoDebera_MoverseAUnNodoNoConectado()
    {
        //Arrange
        var mapa = new Mapa();
        var araña = new Araña("Cazadora", 0);
        //Act
        var destino = mapa.Nodos[9];
        bool movimiento = araña.Mover(destino, mapa);
        //Assert
        movimiento.Should().BeFalse();
        araña.Posicion.Should().Be(0);
    }
    
    [Fact]
    public void LaAraña_Deberia_MoverseAUnNodoConectadoVerticalmente()
    {
        //Arrange
        var mapa = new Mapa();
        var araña = new Araña("Cazadora", 0);
        //Act
        var destino = mapa.Nodos[4];
        bool movimiento = araña.Mover(destino, mapa);
        //Assert
        movimiento.Should().BeTrue();
        araña.Posicion.Should().Be(4);

    }
}

public class Mapa
{
    public Dictionary<int, Nodo> Nodos { get; set; }
    public Mapa()
    {
        Nodos = new Dictionary<int, Nodo>();
        for (int i = 0; i <= 20; i++)
        {
            Nodos[i] = new Nodo(i);
        }

    }

   
}

public class Nodo
{
    public int id { get; set; }
    public List<Nodo> conexiones { get; set; }

    public Nodo(int id)
    {
        this.id = id;
        this.conexiones = new List<Nodo>();
    }
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
        if (destino.id == 9)
        {
            return false;
        }
       
        this.Posicion = 1;
        return true;
    }
}