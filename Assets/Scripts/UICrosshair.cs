using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICrosshair : MonoBehaviour
{
    private RaycastHit hit;
    private Camera playerCamera;
    private float rangeInteraction = 3f;
    public Image crossHair;
    public Sprite interactingCrosshair, baseCrosshair;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // R�cup�rer les coordonn�es du centre de l'�cran
        float centerX = Screen.width / 2f;
        float centerY = Screen.height / 2f;
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(centerX, centerY, 0f));

        if (Physics.Raycast(ray, out hit))
        {
            // V�rifier si l'objet touch� est un objet interactif
            if (hit.collider.gameObject.CompareTag("InteractiveObject") && hit.distance <= rangeInteraction)
            {
                crossHair.sprite = interactingCrosshair;
            }
            else
            {
                crossHair.sprite = baseCrosshair;
            }
        }
        else
        {
            crossHair.sprite = baseCrosshair;
        }
    }
}

