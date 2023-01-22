# Detalles y cosas varias

Para seguir el código de la Kata:

La clase **Runner** (en Runner.cs) contiene el código que ejecuta la cata varias veces, midiendo el tiempo que le lleva cada iteración, y registrando la iteración más rápida y el tiempo medio de cada una.

Sin embargo, la kata en sí, parte de la clase **AnagramsKata** en el archivo AnagramsKata.cs 

Se trata de un algoritmo a medida para la kata (no de fuerza bruta), en el que se ha añadido una cantidad **indecente de complejidad** para conseguir un tiempo de ejecución óptimo.

Hay un proyecto de test que cubre la kata, pero en el que no he invertido mucho tiempo en refactor. Es muy mejorable.

----

### La idea de fondo:

* Leer el stream de forma que en una única pasada se obtenga la lista de palabras limpia, sin que se tenga que filtrar basura ni carácteres inválidos en un segundo paso.
* Generar un AnagramHash para todas las palabras. Un anagram hash es un hash que se calcula ordenando las letras de la palabra alfabéticamente, de forma que todas las palabras que son anagramas, tienen el mismo hash.
* Agrupamos todas las palabras que tienen el mismo Hash y, de esta forma, obtenemos el conjunto de anagramas.

### Todo esto teniendo en cuenta:
* No crear substrings en lo posible
* Evitar bucles anidados
* Paralelizar si algo tiene sentido (por ejemplo, el cálculo de cada hash es una función pura y costosa)
* Evitar la creación de basura que nos lance el GC a mitad del algoritmo, en la medida de lo posible.