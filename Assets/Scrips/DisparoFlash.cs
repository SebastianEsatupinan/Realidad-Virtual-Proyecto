using System.Collections;
using UnityEngine;

public class DisparoFlash : MonoBehaviour
{
    public Light flashLight;               // Luz que simula el flash de la cámara
    public Light statusLight;              // Luz que indica el estado de cooldown
    public AudioSource shootSound;         // Sonido de la cámara
    public GameObject impactCollider;      // Collider que se genera al disparar

    public Transform firePoint;            // Punto de salida del flash
    public float flashDuration = 0.05f;    // Duración del flash
    public float cooldownDuration = 2f;    // Duración del cooldown entre disparos

    private bool canShoot = true;          // Controla si se puede disparar o no

    public void Disparar()
    {
        if (canShoot)
        {
            StartCoroutine(FlashEffect());
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator FlashEffect()
    {
        shootSound.Play();

        // Activa el flash
        flashLight.enabled = true;

        // Crea el collider en el punto del flash
        GameObject colliderInstance = Instantiate(impactCollider, firePoint.position, firePoint.rotation);

        // Espera para desactivar el flash
        yield return new WaitForSeconds(flashDuration);

        flashLight.enabled = false;

        // Desactiva el collider después de un tiempo si es necesario
        Destroy(colliderInstance, 0.5f);
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        statusLight.color = Color.red;     // Cambia la luz de estado a rojo durante el cooldown

        // Espera la duración del cooldown
        yield return new WaitForSeconds(cooldownDuration);

        canShoot = true;
        statusLight.color = Color.green;   // Cambia la luz de estado a verde cuando se puede disparar de nuevo
    }
}
