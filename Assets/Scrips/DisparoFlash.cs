using System.Collections;
using UnityEngine;

public class DisparoFlash : MonoBehaviour
{
    public Light flashLight;               // Luz que simula el flash de la c�mara
    public AudioSource shootSound;         // Sonido de la c�mara
    public GameObject impactCollider;      // Collider que se genera al disparar

    public Transform firePoint;            // Punto de salida del flash
    public float flashDuration = 0.05f;    // Duraci�n del flash

    public void Disparar()
    {
        StartCoroutine(FlashEffect());
    }

    IEnumerator FlashEffect()
    {
        //shootSound.Play();

        // Activa el flash
        flashLight.enabled = true;
        
        // Crea el collider en el punto del flash
        GameObject colliderInstance = Instantiate(impactCollider, firePoint.position, firePoint.rotation);

        // Espera para desactivar el flash
        yield return new WaitForSeconds(flashDuration);

        flashLight.enabled = false;

        // Desactiva el collider despu�s de un tiempo si es necesario
        Destroy(colliderInstance, 0.5f);
    }
}
