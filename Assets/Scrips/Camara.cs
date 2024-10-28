using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Camara : MonoBehaviour
{
    public XRBaseInteractable grabInteract;
    public DisparoFlash disparoFlash;

    void Start()
    {
        grabInteract.activated.AddListener(x => ActivarFlash());
        grabInteract.deactivated.AddListener(x => DesactivarFlash());
    }

    public void ActivarFlash()
    {
        disparoFlash.Disparar();
    }

    public void DesactivarFlash()
    {
        Debug.Log("Flash desactivado");
    }
}
