using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICrosshair : MonoBehaviour
{
    // code � harmoniser avec le script Interaction
    private RaycastHit hit;
    private Camera playerCamera;
    private float rangeInteraction = 3f;
    public Sprite crossHair;
    public Sprite interactingCrosshair, baseCrosshair;

    void Start()
    {
        playerCamera = Camera.main;
        crossHair = baseCrosshair;
    }

    void Update()
    {
        // R�cup�re les coordonn�es du centre de l'�cran
        float centerX = Screen.width / 2f;
        float centerY = Screen.height / 2f;
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(centerX, centerY, 0f));

        if (Physics.Raycast(ray, out hit))
        {
            // V�rifier si l'objet touch� est un objet interactif
            if (hit.collider.gameObject.CompareTag("InteractiveObject") && hit.distance <= rangeInteraction)
            {
                crossHair = interactingCrosshair;
            }
            else
            {
                crossHair = baseCrosshair;
            }
        }
        else
        {
            crossHair = baseCrosshair;
        }
    }
}

