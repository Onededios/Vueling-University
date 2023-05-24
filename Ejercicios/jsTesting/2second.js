// Ejercicio 2 - Crea una función que tome un número entero positivo y verifique si es un número primo

function isPrime(inpNum) {
    if (inpNum <= 1) {return false;}
    for (let index = 2; index < inpNum; index++) {
        if (inpNum % index === 0) {
            return false;
        }
    }
    return true;
}

for (let index = 0; index < 10; index++) {
    console.log("El num "+index+" es primo? "+isPrime(index));
}