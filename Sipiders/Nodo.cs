namespace KatasTDD;

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