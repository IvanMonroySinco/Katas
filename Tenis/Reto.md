Resumen
Esta kata es ideal para aquellos desarrolladores que tienen cierta familiaridad con los conceptos básicos de TDD y quieren mejorar sus habilidades de diseño de algoritmos. Se trata de una versión stateless y algorítmica de la clásica kata de Tenis (en la cual el programa muestra la puntuación y actualiza su estado cada vez que un jugador obtiene un punto nuevo).

Tanto la kata de Tenis como la de Bowling se pueden resolver manteniendo el estado (por ejemplo, con un método scorePoint() de algún tipo). Sin embargo, cuando se aprende TDD algorítmico puro, preferimos resolverla de manera stateless, ya que la dificultad añadida de mantener el estado puede distraerte de los principales puntos de aprendizaje.

Instrucciones
Escribe un programa que acepte dos números enteros y los traduzca al puntaje típico del tenis.

Las reglas de puntuación del tenis (según Wikipedia) son las siguientes:

El primer jugador en obtener al menos cuatro puntos en total y al menos dos puntos más que su adversario, gana un juego.

Los puntos de cero a tres son respectivamente denominados ''15'', ''30'', y ''40''.

Si cada jugador gana al menos tres puntos y las puntuaciones son iguales, el resultado es "deuce" o ''iguales''.

Si cada jugador gana al menos tres puntos y un jugador tiene un punto más que su adversario, la puntuación para el jugador que lleva la delantera se denomina "ventaja".

Comienza con la siguiente interfaz:

public class TennisScoreCalculator {
public string Score(int player1Points, int player2Points);
}
 