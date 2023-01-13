# Anagrams Dictionary Kata (game)

Nuestro CEO nos ha pedido que identifiquemos todas las palabras del diccionario en Inglés que son anagramas, es decir, identificar todas las palabras del diccionario que se escriben con las mismas letras de otra palabra, en un orden distinto.

Por entender en qué consiste esto de los anagramas: {_bored_ , _robed_} son un conjunto de anagramas, igual que {_artist_, _strait_, _traits_} también lo son. Otro ejemplo sería {_pores, poser, prose, ropes, spore}. 

Al parecer hay una gran oportunidad en el mercado de los anagramas, y si conseguimos implementar este algoritmo en los próximos MINUTOS, posiblemente generemos dinero suficiente como para vivir sin preocupaciones el resto de nuestras vidas (y las de nuestra descendencia durante varias generaciones, así que esto VA MUY EN SERIO).

El objetivo de la Kata es **crear una lista de todos los conjuntos de anagramas que existen en el idioma Inglés**, partiendo del documento English.txt que podéis encontrar en la carpeta documents del repo.

## Enfoque de la Kata

Esta kata es una kata gamificada, pensada para hacerse en varios grupos de Mob (o parejas) a la vez.

### Primera fase del juego:

En una primera iteración, cada equipo se centrará en hacer el algoritmo más eficiente (en tiempo de ejecución) posible. 

Quien gana esta fase:

* El primer equipo que llegue a un tiempo de ejecución de 15ms o menos gana.

* Si nadie llega a esos tiempos, el equipo que tenga un tiempo de ejecución más pequeño al terminar el timebox gana.

**IMPORTANTE**: buscamos entregar rápido un código muy optimizado así que ¡Viva la complejidad accidental, la sobreingeniería, los shortcuts y las guarrerías locas que se os puedan ocurrir!

Está bien generar legacy en esta parte, usar concurrencia, ChatGPT o lo que sea que os parezca que os puede ayudar a terminar antes y ganar esta parte.

### Segunda fase del juego

Asumiendo que hemos conseguido un tiempo de ejecución razonable en la fase anterior, ahora nos toca convertir el código en código bonito y fácil de mantener.

Cómo se gana esta fase:

* Manteniendo el tiempo de ejecución conseguido con el código anterior (la ejecución debería ser igual de buena que antes, ese es el "valor" que queremos proteger).

* Teniendo un test de performance sobre el algoritmo anterior, que no sea flacky y nos garantice que el tiempo de ejecución no se ha degradado. (_nBench_ puede ser útil en este punto).

* Teniendo cobertura de test que "demuestre" que el algoritmo funciona

* Habiendo conseguido una versión orientada a objetos, con alta cohesión, bajo acoplamiento, SOLID etc etc etc...

El equipo que antes considere que tiene una versión _suficientemente buena_ gana esta parte, siempre que consiga convencer al resto de participantes :)

### Tercera fase

Compartimos learnings, estrategias, y lo que veamos que puede tener valor para el resto de personas.

