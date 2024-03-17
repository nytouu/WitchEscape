using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : SimpleObject

{
    private bool objectHeld;
    private StateMode stateScript;
    private Interaction interactionScript;
    private Rigidbody rb;
    private Transform parentTransform;
    private Vector3 localPosition = new Vector3(0.57f, 0f, 0.748f);

    void Start()
    {
        objectHeld = false;
        stateScript = FindObjectOfType<StateMode>();
        interactionScript = FindAnyObjectByType<Interaction>();
        rb = GetComponent<Rigidbody>();
        parentTransform = GameObject.FindWithTag("Player").transform;

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !stateScript.GetPuzzleMode() && objectHeld) //objet relâché
        {
            //vérification si l'objet est en collision avec d'autres objets

            interactionScript.SetHandFree();
            rb.useGravity = true;
            rb.detectCollisions = true;
            objectHeld = false;
            transform.parent = null;
            
        }
    }

    public override void Interact()
    {
        if (interactionScript.GetHandFree())
        {
            rb.useGravity = false;
            rb.detectCollisions = false;
            objectHeld = true;
            interactionScript.SetHandBusy();
            
            transform.SetParent(parentTransform, false);
            transform.localPosition = localPosition;

        }
        
    }
    // idéalement faire en sorte que l'objet suive à 80% la caméra sur l'axe vertical
    // faire bouger légèrement l'objet en main pour la respiration
    // condition pour remettre l'objet à sa position d'origine (si jamais il glitch)



}
