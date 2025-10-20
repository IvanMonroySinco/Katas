namespace KatasTDD;

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

    public string MostrarMapa(int arañaCazadoraPosicion, int arañaPresaPosicion)
    {
        throw new NotImplementedException();
    }
}