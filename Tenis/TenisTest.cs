using FluentAssertions;

namespace Tenis;

public class TenisTest
{
    [Fact]
    public void Debera_RetornarLoveAll_DadosAmbosPuntajesEnCero()
    {
        //Arrage
        var puntajeJugador1 = 0;
        var puntajeJugador2 = 0;
        //Act
        var scoreCalculator = new TennisScoreCalculator();
        var result = scoreCalculator.Score(puntajeJugador1, puntajeJugador2);
        //Asert
        result.Should().Be("love-all");

    }
    
    [Fact]
    public void Debera_Retornar_0_15_SiLosPuntajesSon_0_1()
    {
        //Arrage
        var puntajeJugador1 = 0;
        var puntajeJugador2 = 1;
        //Act
        var scoreCalculator = new TennisScoreCalculator();
        var result = scoreCalculator.Score(puntajeJugador1, puntajeJugador2);
        //Asert
        result.Should().Be("0-15");

    }
    
    [Fact]
    public void Debera_Retornar_0_30_SiLosPuntajesSon_0_2()
    {
        //Arrage
        var puntajeJugador1 = 0;
        var puntajeJugador2 = 2;
        //Act
        var scoreCalculator = new TennisScoreCalculator();
        var result = scoreCalculator.Score(puntajeJugador1, puntajeJugador2);
        //Asert
        result.Should().Be("0-30");

    }

    
    [Fact]
    public void Debera_Retornar_0_40_SiLosPuntajesSon_0_3()
    {
        //Arrage
        var puntajeJugador1 = 0;
        var puntajeJugador2 = 3;
        //Act
        var scoreCalculator = new TennisScoreCalculator();
        var result = scoreCalculator.Score(puntajeJugador1, puntajeJugador2);
        //Asert
        result.Should().Be("0-40");

    }
    
    [Fact]
    public void Debera_Retornar_Deuce_SiLosJugadoresTienenMasDe4PuntosYEstanEmpatados()
    {
        //Arrage
        var puntajeJugador1 = 4;
        var puntajeJugador2 = 4;
        //Act
        var scoreCalculator = new TennisScoreCalculator();
        var result = scoreCalculator.Score(puntajeJugador1, puntajeJugador2);
        //Asert
        result.Should().Be("Deuce");

    }
    
    [Fact]
    public void Debera_Retornar_Ventaja_SiLosJugadoresTienenMasDe4PuntosYUnoLlevaLaVentaja()
    {
        //Arrage
        var puntajeJugador1 = 4;
        var puntajeJugador2 = 5;
        //Act
        var scoreCalculator = new TennisScoreCalculator();
        var result = scoreCalculator.Score(puntajeJugador1, puntajeJugador2);
        //Asert
        result.Should().Be("Ventaja");

    }
    
    public class TennisScoreCalculator
    {
        public string Score(int player1Points, int player2Points)
        {
            string textoPuntaje(int puntaje)
            {
                switch (puntaje)
                {
                    case 0:
                        return "0";
                    case 1:
                        return "15";
                    case 2:
                        return "30";
                    case 3:
                        return "40";
                    default:
                        return "-";
                }
            }
            
            if (player1Points >= 3 && (player1Points == player2Points))
            {
                return "Deuce";
            }
            
            if (player1Points == 0 && player2Points == 0)
            {
                return "love-all";
            }
            
            return textoPuntaje(player1Points) + "-" + textoPuntaje(player2Points);
            
        }
    }
}