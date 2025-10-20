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

    public class TennisScoreCalculator
    {
        public string Score(int player1Points, int player2Points)
        {
            throw new NotImplementedException();
        }
    }
}