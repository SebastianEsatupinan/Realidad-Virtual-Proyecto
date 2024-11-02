using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muert3 : MonoBehaviour
{
    public Transform spawnPoint; // Punto inicial de la escena donde se teletransportará el jugador

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisiona es el jugador
        if (collision.collider.CompareTag("Player"))
        {
            // Teletransporta al jugador al punto inicial
            Rigidbody playerRigidbody = collision.collider.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero; // Detiene el movimiento del jugador
                playerRigidbody.angularVelocity = Vector3.zero;
            }
            collision.collider.transform.position = spawnPoint.position;
            Debug.Log("El jugador ha sido teletransportado al punto inicial.");

            // Destruye al monstruo que colisionó con el jugador
            Destroy(gameObject);
        }
    }
}



