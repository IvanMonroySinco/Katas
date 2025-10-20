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
    public void LaAraña_Podra_MoverseAUnNodoConectado()
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
    public void LaAraña_NoPodra_MoverseAUnNodoNoConectado()
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
    public void LaAraña_Podra_MoverseAUnNodoConectadoVerticalmente()
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
    public void LaAraña_Podra_MoverseAUnNodoConectadoDiagonalmente()
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
    public void LaAraña_Podra_MoverseHaciaAtras()
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
    public void LaAraña_Podra_MoverseHaciaTodasLasDirecciones(int idNodo)
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

    [Fact]
    public void LaArañaCazadora_GanaraElJuego_Si_LaPosicionDeLaArañaSeguida_EsIgual()
    {
        //Arrange
        var mapa = new Mapa();
        var arañaCazadora = new Araña("Cazadora", 8);
        var arañaPresa = new Araña("Presa", 8);

        var juego = new Juego(mapa, arañaCazadora, arañaPresa);
        //Act

        var resultado = juego.ValidarVictoria();

        //Assert
        resultado.Should().BeTrue();
    }

    [Fact]
    public void ElJuego_Debe_TerminarPasados10Turnos()
    {
        //Arrange
        var mapa = new Mapa();
        var arañaCazadora = new Araña("Cazadora", 8);
        var arañaPresa = new Araña("Presa", 10);

        var juego = new Juego(mapa, arañaCazadora, arañaPresa);
        //Act

        for (int i = 0; i < 10; i++)
        {
            juego.TurnoCompletado();
        }

        //Assert
        juego.Finalizado.Should().BeTrue();
    }

    [Fact]
    public void ElJuego_NoDebe_TerminarSiPasaronMenosDe10TurnosYLasArañasAunNoSeEncuentran()
    {
        //Arrange
        var mapa = new Mapa();
        var arañaCazadora = new Araña("Cazadora", 8);
        var arañaPresa = new Araña("Presa", 10);

        var juego = new Juego(mapa, arañaCazadora, arañaPresa);
        //Act

        for (int i = 0; i < 5; i++)
        {
            juego.TurnoCompletado();
        }

        //Assert
        juego.Finalizado.Should().BeFalse();
    }
    
    [Fact]
    public void Debera_MostrarElMapaConLasPosicionesDeLasArañas()
    {
        //Arrange
        var mapa = new Mapa();
        var arañaCazadora = new Araña("Cazadora", 8);
        var arañaPresa = new Araña("Presa", 10);

        //Act
        var resultado = mapa.MostrarMapa(arañaCazadora.Posicion, arañaPresa.Posicion);

        //Assert
        resultado.Should().Contain("C");
        resultado.Should().Contain("P");
        
    }
}