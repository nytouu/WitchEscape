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
    private bool handFree = true;
    private GameObject objectHeld;


    void Start()
    {
        lerpScript = FindObjectOfType<Lerp>();
        stateScript = FindObjectOfType<StateMode>();
        playerCamera = FindObjectOfType<Camera>();
        slotCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !stateScript.GetPuzzleMode() &&!stateScript.GetAnalysisMode()) // check si objet interactif, si oui interaction
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

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)) && stateScript.GetPuzzleMode()) // quitte le mode puzzle
        {
            QuitPuzzleMode();
        }
    }

    public void QuitPuzzleMode()
    {
        if (stateScript.GetPuzzleMode())
        {
            lerpScript.MoveToTarget(Camera.main.transform, slotCamera); //bug actuellement à cause de cinemachine

            stateScript.QuitPuzzleMode();
        }
    }


    public bool GetHandFree()
    {
        return handFree;
    }

    public void SetHandFree()
    {
        handFree = true;
        SetObjectHeld(null);
    }

    public void SetHandBusy()
    {
        handFree = false;
    }

    public GameObject GetObjectHeld()
    {
        return objectHeld;
    }

    public void SetObjectHeld(GameObject obj)
    {
        objectHeld = obj;
    }

}
