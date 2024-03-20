using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : SimpleObject
{
    private bool objectHeld;

    [SerializeField]
    private bool objectOnSlot = false;
    private GameObject slot = null;
    private StateMode stateScript;
    private Interaction interactionScript;
    private Rigidbody rb;
    private Transform parentTransform;
    private Vector3 localPosition = new Vector3(0.57f, 0f, 0.748f); //position relative au joueur quand l'objet est tenu

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
        if (Input.GetMouseButtonDown(1) && !stateScript.GetPuzzleMode() && objectHeld) //objet rel�ch� ou quitter mode analyse
        {
            if (stateScript.GetAnalysisMode())
            {
                stateScript.QuitAnalysisMode();
            }
            else
            {
                //v�rification si l'objet est en collision avec d'autres objets avec un trigger

                interactionScript.SetHandFree();
                rb.useGravity = true;
                rb.detectCollisions = true;
                objectHeld = false;
                transform.parent = null;
                rb.constraints = RigidbodyConstraints.None;
            }
        }

        if ((Input.GetKeyDown(KeyCode.E)) && !stateScript.GetPuzzleMode() && objectHeld) // Utilisation de l'objet
        {
            // dans ce script ou le script Interaction ?

            // possibilit� 1 : enfant de pickupObject
            // possibilit� 2 : un if selon le type de action possible, allumer bougie
        }

        if ((Input.GetKeyDown(KeyCode.Q) && !stateScript.GetPuzzleMode() && objectHeld) && objectHeld) // analyse de l'objet
        {
            if (!stateScript.GetAnalysisMode()) // passage en mode analyse
            {
                stateScript.EnterAnalysisMode();
            }
            else // sortie du mode analyse
            {
                stateScript.QuitAnalysisMode();
            }
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
            interactionScript.SetObjectHeld(gameObject);
			transform.rotation = Quaternion.Euler(0, 180, 0);

            transform.SetParent(parentTransform, false);
            transform.localPosition = localPosition;
            transform.rotation = Quaternion.identity;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            if (objectOnSlot) //si l'objet �tait sur un slot
            {
                SlotObject slotScript = slot.GetComponent<SlotObject>(); //d�tection du slot
                slotScript.SetSlotEmpty(); // vidage du slot
                objectOnSlot = false;
                slot = null;
            }
        }
    }

    public void SetObjectOnSlot() //quand l'objet est pos� sur un slot
    {
        objectOnSlot = true;
        objectHeld = false;
        transform.parent = null;
        rb.detectCollisions = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void SetSlot(GameObject slotObj) //r�cup�re le slotObject occup�, utile pour le vider en prenant l'objet directement
    {
        slot = slotObj;
    }

    // id�alement faire en sorte que l'objet suive � 80% la cam�ra sur l'axe vertical
    // faire bouger l�g�rement l'objet en main pour la respiration
    // condition pour remettre l'objet � sa position d'origine (si jamais il glitch)
}
