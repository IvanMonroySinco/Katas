namespace KatasTDD;

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