// Ejercicio 5 - Crea una función que tome una cadena de palabras separadas por espacios y devuelva la palabra más larga.

frase = "Es el vecino el que elige al alcalde, y es el alcalde el que quiere que sean los vecinos el alcalde. By MarianoElRajoy";

function theLongestWord(inpString) {
    chain = inpString.split(" ");
    console.log(chain);
    chain.sort((a, b) => b.length - a.length);
    console.log(chain);
    return chain[0];
}

console.log("La palabra más grande la frase '"+frase+"' es: \n"+theLongestWord(frase));