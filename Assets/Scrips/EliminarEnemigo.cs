using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarEnemigo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entra en el trigger tiene la etiqueta "Enemigo"
        if (other.CompareTag("Enemigo"))
        {
            // Eliminamos el objeto "Enemigo" del juego
            Destroy(other.gameObject);
        }
    }
}
