// Ejercicio 4 - Encontrar el número más grande en un array de números negativos y positivos

const num = [1,2,-1,4,9,10,-10,-17,50,3,97,100,-200];

function getTheMaxNumFromArray(numArrayInp) {
    /*
        Si el valor devuelto es negativo, el primer elemento se coloca antes del segundo en la array.
        Si el valor devuelto es positivo, el segundo elemento se coloca antes del primero en la array.
        Si el valor devuelto es cero, el orden de los elementos no cambia.
    */
    numArrayInp.sort((a, b) => b - a);
    return numArrayInp[0];
}

console.log("The highest num of the array is: "+getTheMaxNumFromArray(num));