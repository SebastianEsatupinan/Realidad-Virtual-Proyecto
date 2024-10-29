using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawm : MonoBehaviour
{
    // Variable pública para asignar el punto de destino en el Inspector de Unity.
    public Transform destinationPoint;

    private void Start()
    {
        if (destinationPoint == null)
        {
            Debug.LogWarning("No se ha asignado un punto de destino. Por favor, asigna uno en el inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger tiene la etiqueta "Player"
        if (other.CompareTag("Player") && destinationPoint != null)
        {
            // Cambia la posición del jugador al punto de destino
            other.transform.position = destinationPoint.position;
            Debug.Log("El jugador ha sido teletransportado al punto de destino.");
        }
        else if (destinationPoint == null)
        {
            Debug.LogWarning("No se ha asignado un destino para el teletransporte.");
        }
    }
}
