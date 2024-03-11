using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Camera playerCamera;
    private RaycastHit hit;
    private StateMode stateScript;
    private Transform slotCamera;
    private float rangeInteraction = 3f;
    private Lerp lerpScript;

    void Start()
    {
        lerpScript = FindObjectOfType<Lerp>();
        stateScript = FindObjectOfType<StateMode>();
        playerCamera = Camera.main;
        slotCamera = GameObject.Find("CameraHolder").GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !stateScript.puzzleMode)
        {

            // Récupérer les coordonnées du centre de l'écran
            float centerX = Screen.width / 2f;
            float centerY = Screen.height / 2f;

            Ray ray = playerCamera.ScreenPointToRay(new Vector3(centerX, centerY, 0f));

            if (Physics.Raycast(ray, out hit))
            {
                // Vérifier si l'objet touché est un objet interactif
                if (hit.collider.gameObject.CompareTag("InteractiveObject") && hit.distance <= rangeInteraction)
                {
                    hit.collider.gameObject.GetComponent<InteractiveObject>().Interact();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)) // quitte le mode puzzle
        {
            if (stateScript.puzzleMode)
            {

                lerpScript.MoveToTarget(Camera.main.transform, slotCamera);

                stateScript.puzzleMode = false;
            }
        }
    }


}
