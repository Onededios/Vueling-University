// Ejercicio 7 - Obtener el promedio de las edades de los usuarios mayores de edad

const age = [6,7,18,20,75,32,76,28,12,16,17];

function getAgeMeridian(ageArray) {
    let qtyHT18 = 0;
    let allHT18 = 0;

    for (let index = 0; index < ageArray.length; index++) {
        if (ageArray[index] >= 18) {
            qtyHT18++;
            allHT18 += ageArray[index];
        }
    }
    return allHT18/qtyHT18;
}

console.log("El promedio de edad de los mayores de 18 años es: "+getAgeMeridian(age)+" años.");