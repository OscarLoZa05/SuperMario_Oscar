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
    private int[] numeros = {75, 1, 3};
    public int[] numeros2;
    private int[ , ] numeros3 = {{7, 8, 98}, {9, 22, 45}}; //array de dos dimensiones, Se empieza a contrar a partir del 0


    List<int> listaDeNumeros = new List<int> {3, 5, 8, 10, 53, 90};


    // Start is called before the first frame update
    void Start()
    {
        
        foreach (int numero in listaDeNumeros)
        {
            Debug.Log(numero);
        }

        listaDeNumeros.Add(22);
        listaDeNumeros.Remove(5);
        listaDeNumeros.RemoveAt(0);
        //listaDeNumeros.RemoveAt(listaDeNumeros.Count - 1);
        //listaDeNumeros.Clear();
        listaDeNumeros.Sort();
        listaDeNumeros.Reverse();

        foreach (int numero in listaDeNumeros)
        {
            Debug.Log(numero);
        }
        
        /*Debug.Log(numeros[0]);
        Debug.Log(numeros3[1,2]);*/

        Calculos();

        foreach(int numero in numeros)
        {
            Debug.Log(numero); 
        }

        for(int i = 0; i < numeros.Length; i++)
        {
            Debug.Log(numeros[1]);
        }

        /*int i = 0;
        while(i < numeros.Length)
        {
            Debug.Log(numeros[1]);
            i++;
        }*/


        /*int i = 75;
        do
        {
            Debug.Log(cadenaTexto);
        }
        while (i  < numeros.Length);
        //Se ejecuta minimo una vez*/

    }

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