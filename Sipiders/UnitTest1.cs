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
    
    [Fact]
    public void LaAraña_Deberia_MoverseAUnNodoConectadoDiagonalmente()
    {
        //Arrange
        var mapa = new Mapa();
        var araña = new Araña("Cazadora", 0);
        //Act
        var destino = mapa.Nodos[8];
        bool movimiento = araña.Mover(destino, mapa);
        //Assert
        movimiento.Should().BeTrue();
        araña.Posicion.Should().Be(8);

    }
    
    [Fact]
    public void LaAraña_Deberia_MoverseHaciaAtras()
    {
        //Arrange
        var mapa = new Mapa();
        var araña = new Araña("Cazadora", 3);
        //Act
        var destino = mapa.Nodos[2];
        bool movimiento = araña.Mover(destino, mapa);
        //Assert
        movimiento.Should().BeTrue();
        araña.Posicion.Should().Be(2);

    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(9)]
    [InlineData(13)]
    [InlineData(17)]
    public void LaAraña_Deberia_MoverseHaciaTodasLasDirecciones(int idNodo)
    {
        //Arrange
        var mapa = new Mapa();
        var araña = new Araña("Cazadora", 8);
        //Act
        var destino = mapa.Nodos[idNodo];
        bool movimiento = araña.Mover(destino, mapa);
        //Assert
        movimiento.Should().BeTrue();
        araña.Posicion.Should().Be(idNodo);

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

        //Conexiones horizontales
        Connect(0, 1);
        Connect(1, 2);
        Connect(2, 3);
        
        Connect(4, 5);
        Connect(5, 6);
        Connect(6, 7);
        
        Connect(9, 10);
        Connect(10, 11);
        Connect(11, 12);
        
        Connect(13, 14);
        Connect(14, 15);
        Connect(15, 16);
        
        Connect(17, 18);
        Connect(18, 19);
        Connect(19, 20);
        
        //Conexiones verticales
        Connect(0, 4);
        Connect(4, 9);
        Connect(9, 13);
        Connect(13, 17);

        
        Connect(1, 5);
        Connect(5, 10);
        Connect(10, 14);
        Connect(14, 18);
        
        Connect(2, 6);
        Connect(6, 11);
        Connect(11, 15);
        Connect(15, 19);
        
        
        Connect(3, 7);
        Connect(7, 12);
        Connect(12, 16);
        Connect(16, 20);
        
        //Conexiones diagonales
        Connect(0, 8);
        Connect(4, 8);
        Connect(9, 8);
        Connect(13, 8);
        Connect(17, 8);
        
        
    }

    private void Connect(int nodoA, int nodoB)
    {
        Nodos[nodoA].conexiones.Add(Nodos[nodoB]);
        Nodos[nodoB].conexiones.Add(Nodos[nodoA]);
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
        var posicionActual = mapa.Nodos[this.Posicion];
        if (posicionActual.conexiones.Contains(destino))
        {
            this.Posicion = destino.id;
            return true;
        }

        return false;
    }
}