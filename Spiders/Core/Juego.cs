namespace KatasTDD;

public class Juego
{
    private readonly Mapa _mapa;
    private readonly Araña _cazadora;
    private readonly Araña _presa;

    public Juego(Mapa mapa, Araña arañaCazadora, Araña arañaPresa)
    {
        this._mapa = mapa;
        this._cazadora = arañaCazadora;
        this._presa = arañaPresa;
    }

    public int TurnosRestantes { get; set; } = 10;
    public bool Finalizado { get; set; }
    public bool ValidarVictoria() => _cazadora.Posicion == _presa.Posicion;

    public void TurnoCompletado()
    {
        if (Finalizado == false)
            TurnosRestantes--;
        
        if (ValidarVictoria() || this.TurnosRestantes == 0) 
            this.Finalizado = true;
        
    }
}