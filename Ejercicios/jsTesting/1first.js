// Ejercicio 1 - Crear function javascript que calcule si eres mayor de edad o no


let age = 20;
function overAge(inpAge) {
    if (inpAge >= 18) {
        console.log("Eres mayor de edad.");
    }
    else {
        console.log("Eres menor de edad.");
    }
}

overAge(age);