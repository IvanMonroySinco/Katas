public class TennisScoreCalculator
{
    public string Score(int player1Points, int player2Points)
    {
        if ((player1Points >= 4 || player2Points >= 4) && Math.Abs(player1Points - player2Points) >= 2)
            return "Game";

        if (player1Points >= 3 && player2Points >= 3)
            return ScoreExtraordinario(player1Points, player2Points);

        if (player1Points == 0 && player2Points == 0)
            return "love-all";

        return textoPuntaje(player1Points) + "-" + textoPuntaje(player2Points);
    }

    private string ScoreExtraordinario(int player1Points, int player2Points)
    {
        int diferencia = Math.Abs(player1Points - player2Points);
        if (diferencia == 0) return "Deuce";
        if (diferencia == 1) return "Ventaja";
        return "";
    }

    public string textoPuntaje(int puntaje)
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
        
        
}