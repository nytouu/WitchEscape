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
    private Image crosshair;
    private Sprite interactingCrosshair, baseCrosshair, puzzleCrosshair;
    private PuzzleObject pO;

    void Start()
    {
        playerCamera = Camera.main;
        pO = FindObjectOfType<PuzzleObject>();
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        interactingCrosshair = Resources.Load<Sprite>("InteractingCrosshair");
        baseCrosshair = Resources.Load<Sprite>("BaseCrosshair");
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
            //if (hit.distance <= rangeInteraction && pO.isPuzzle)
            //{
            //    crosshair.sprite = puzzleCrosshair;
            //}
            //else
            //{
            //    crosshair.sprite = baseCrosshair;
            //}
            //Vérifier si l'objet touché est un objet interactif
            if (hit.collider.gameObject.CompareTag("InteractiveObject") && hit.distance <= rangeInteraction)
            {
                crosshair.sprite = interactingCrosshair;
            }

            else
            {
                crosshair.sprite = baseCrosshair;
            }

        }
        else
        {
            crosshair.sprite = baseCrosshair;
        }
    }
}

