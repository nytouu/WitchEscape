using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextObject : SimpleObject
{
    [TextArea]
    public string description;
    private StateMode stateScript;
    private float rangeInteraction = 3f;
    private RaycastHit hit;
    private TextMeshProUGUI currentInteractionText;
    private Camera playerCamera;

    

    void Start()
    {
        stateScript = FindObjectOfType<StateMode>();

        playerCamera = Camera.main;
        currentInteractionText = FindObjectOfType<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float centerX = Screen.width / 2f;
        float centerY = Screen.height / 2f;

        Ray ray = playerCamera.ScreenPointToRay(new Vector3(centerX, centerY, 0f));
        if (Physics.Raycast(ray, out hit))
        {
            // Vérifier si l'objet touché est un objet interactif
            if (hit.collider.gameObject.CompareTag("InteractiveObject") && hit.distance <= rangeInteraction)
            {
                currentInteractionText.text = hit.collider.gameObject.name;
            }
            else
            {
                currentInteractionText.text = "";
            }
        }
        else
        {
            currentInteractionText.text = "";
        }

    }


    public override void Interact()
    {
        Debug.Log(description);
        //Afficher sur l'UI la description de l'objet
        //Prevoir plusieurs variantes

    }

}
