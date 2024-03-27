using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICrosshair : MonoBehaviour
{
    // code à harmoniser avec le script Interaction
    private RaycastHit hit;
    private Camera playerCamera;
    private float rangeInteraction = 3f;
    private Image crossHair;
    private Sprite interactingCrosshair, baseCrosshair, puzzleCrosshair;
    private PuzzleObject pO;
    private ComplexObject cO;
    private SimpleObject sO;

    void Start()
    {
        playerCamera = Camera.main;
        crossHair = GameObject.Find("Crosshair").GetComponent<Image>();
        baseCrosshair = Resources.Load<Sprite>("BaseCrosshair");
        interactingCrosshair = Resources.Load<Sprite>("InteractingCrosshair");
        puzzleCrosshair = Resources.Load<Sprite>("PuzzleCrosshair");

    }

    void Update()
    {
        // Récupère les coordonnées du centre de l'écran
        float centerX = Screen.width / 2f;
        float centerY = Screen.height / 2f;
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(centerX, centerY, 0f));

        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet touché est un objet interactif
            if (hit.collider.gameObject.GetComponent<PuzzleObject>() && hit.distance <= rangeInteraction)
            {
                crossHair.sprite = puzzleCrosshair;
            }
            else if (hit.collider.gameObject.GetComponent<ComplexObject>() && hit.distance <= rangeInteraction)
            {
                crossHair.sprite = interactingCrosshair;
            }
            else if (hit.collider.gameObject.GetComponent<SimpleObject>() && hit.distance <= rangeInteraction)
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

