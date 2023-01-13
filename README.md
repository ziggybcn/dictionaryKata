# Anagrams Dictionary Kata (game)

Kata

Nuestro CEO nos ha pedido que identifiquemos todas las palabras del diccionario en Inglés que son anagramas, es decir, identificar todas las palabras del diccionario que se escriben con las mismas letras de otra palabra, en distinto orden.

Por ejemplo: bored y robed son anagramas entre sí, igual que artist, strait y traits también lo son entre sí.

El objetivo de la Kata es crear una lista de todas las palabras que son anagramas entre sí, partiendo del documento English.txt que podéis encontrar en la carpeta adjunta.

La lista de anagramas no hace falta que esté ordenada de ninguna forma específica.

## Enfoque de la Kata

Esta kata es una kata gamificada, pensada para hacerse en varios grupos de Mob (o parejas) a la vez.

### Primera fase del juego:

En una primera iteración, cada equipo se centrará en hacer el algoritmo más eficiente (en tiempo de ejecución) posible. 

Quien gana esta fase:

* El primer equipo que llegue a un tiempo de ejecución de 15ms o menos gana.

* Si nadie llega a esos tiempos, el equipo que tenga un tiempo de ejecución más pequeño al terminar el timebox gana.

Nota: buscamos entregar rápido un código muy optimizado así que:

Viva la complejidad accidental, la sobreingeniería, los shortcuts y las guarrerías locas que se os puedan ocurrir. Está bien gnerar legacy en esta parte.

### Segunda fase del juego

Pongamos que hemos conseguido un tiempo de ejecución razonable en la fase anterior. Ahora nos toca convertir el código en código bonito y fácil de mantener.

Cómo se gana esta fase:

* Teniendo un test de performance sobre el algoritmo anterior, que no sea flacky

* Teniendo cobertura de test que "demuestre" que el algoritmo funciona

* Habiendo conseguido una versión orientada a objetos, con alta cohesión, bajo acoplamiento (SOLID etc etc etc...)

El equipo que antes considere que tiene una versión suficientemente buena, gana, siempre que el resto de personas estén deacuerdo :)

### Tercera fase

Compartimos learnings, estrategias, y lo que veamos que puede tener valor para el resto de personas.

