using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    // Variables
    public int numeroEntero = 5; // Variables para numeros enteros
    private float numeroDecimal = 7.5f; // Variable para numeros decimales
    bool Boleana = true; // Variable de interruptor true o false
    string cadenaTexto = "Hola Mundo"; // Variable de texto



    // Start is called before the first frame update
    void Start()
    {
        Calculos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Calculos()
    {
        Debug.Log(numeroEntero);
        numeroEntero = 17;
        Debug.Log(numeroEntero);
        numeroEntero = 7 + 5; //para sumar 7+5
        numeroEntero ++; //para  sumar 1
        numeroEntero --; //para restar 1
        numeroEntero += 2; //para cojer el valor actual y sumarle el numero variable (2)
        numeroEntero -= 6; //para cojer el valor actual y restaler el numero variable (6)
        Debug.Log(numeroEntero);
    }
}