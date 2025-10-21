using System;
namespace KatasTDD;

class Program
{
    static void Main()
    {
        var mapa = new Mapa();
        
        var random = new Random();
        var arañaCazadora = new Araña("Cazadora", random.Next(0, 21));
        var arañaPresa = new Araña("Presa", random.Next(0, 21));
        var partida = new Juego(mapa, arañaCazadora, arañaPresa);

        while (!partida.Finalizado)
        {
            Console.Clear();
            Console.WriteLine($"Turnos restantes: {partida.TurnosRestantes}");
            Console.WriteLine(mapa.MostrarMapa(arañaCazadora.Posicion, arañaPresa.Posicion));
            
            Console.WriteLine($"️Ingresa un nodo destino:");
            var input = Console.ReadLine();
            
            
            if (int.TryParse(input, out int next))
            {
                if (!arañaCazadora.Mover(mapa.Nodos[next], mapa))
                {
                    Console.WriteLine("Movimiento inválido. Intenta otro nodo conectado.");
                    Console.ReadKey();
                }
                else if (partida.ValidarVictoria())
                {
                    Console.Clear();
                    Console.WriteLine(mapa.MostrarMapa(arañaCazadora.Posicion, arañaPresa.Posicion));
                    Console.WriteLine("¡Has atrapado a la presa! ¡Ganaste!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("⚠️ Ingresa un número válido.");
                Console.ReadKey();
            }
            partida.TurnoCompletado();
        }
        Console.WriteLine("💀 Se acabaron los turnos. Tu araña ha muerto...");
    }
}