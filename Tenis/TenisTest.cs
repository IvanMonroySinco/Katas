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
    
    public class TennisScoreCalculator
    {
        public string Score(int player1Points, int player2Points)
        {
            if (player1Points == 0 && player2Points == 1)
            {
                return "0-15";
            }
            if (player1Points == 0 && player2Points == 2)
            {
                return "0-30";
            }
            return "love-all";
        }
    }
}