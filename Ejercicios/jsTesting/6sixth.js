// Ejercicio 6 - Crea una función que tome un objeto y devuelva una nueva versión del objeto donde todos los valores son duplicados.

const num = [1,2,-1,4,9,10,-10,-17,50,3,97,100,-200];

const inp = "Si el valor devuelto es cero, el orden de los elementos no cambia.";

function doubleTheNumArray(numArray) {
    for (let index = 0; index < numArray.length; index++) {
        numArray[index] = numArray[index]*2;
    }
    return numArray;
}

function doubleTheString(inpString) {
    let chain = inpString.split(" ");
    let frase = "";
    for (let index = 0; index < chain.length; index++) {
        frase = frase + chain[index]+chain[index]+" ";
    }
    return frase;
}

console.log("La array de numeros era así: \n"+num);
console.log("Queda así: \n"+doubleTheNumArray(num));

console.log("\nLa frase era así: \n"+inp);
console.log("Queda así: \n"+doubleTheString(inp));