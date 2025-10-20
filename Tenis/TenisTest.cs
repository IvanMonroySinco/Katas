using System.Diagnostics;
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
    public void Debera_Retornar_Deuce_SiLosJugadoresTienenMasDe3PuntosYEstanEmpatados()
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
    public void Debera_Retornar_Ventaja_SiLosJugadoresTienenMasDe3PuntosYUnoLlevaLaVentaja()
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
    
    [Fact]
    public void Debera_Retornar_Game_SiUnJugadorTieneMasDe4PuntosYLeLlevaAlMenos2DeVentaja()
    {
        //Arrage
        var puntajeJugador1 = 4;
        var puntajeJugador2 = 2;
        //Act
        var scoreCalculator = new TennisScoreCalculator();
        var result = scoreCalculator.Score(puntajeJugador1, puntajeJugador2);
        //Asert
        result.Should().Be("Game");

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

            if ((player1Points >= 4 || player2Points >= 4) && Math.Abs(player1Points - player2Points) >= 2)
            {
                return "Game";
            }
            
            if (player1Points >= 3 && player2Points >= 3)
            {
                return ScoreExtraordinario(player1Points, player2Points);
            }
            
            if (player1Points == 0 && player2Points == 0)
            {
                return "love-all";
            }
            
            return textoPuntaje(player1Points) + "-" + textoPuntaje(player2Points);
            
        }

        private string ScoreExtraordinario(int player1Points, int player2Points)
        {
            switch (Math.Abs(player1Points - player2Points))
            {
                case 0:
                    return "Deuce";
                case 1:
                    return "Ventaja";
                default:
                    return "";
            } ;
        }
        
    }
}