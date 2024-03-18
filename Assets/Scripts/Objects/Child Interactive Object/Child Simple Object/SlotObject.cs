using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotObject : SimpleObject
{
    [SerializeField]
    private bool slotEmpty = true; // automatiser le true false au start ?
    private GameObject objectOnSlot;
    [SerializeField]
    private GameObject targetObject; //Objet associé au slot object pour une énigme
    [SerializeField]
    private bool goodObject; //renvoie vrai si targetObject == objectOnSlot
    private Interaction interactionScript;

    void Start()
    {
        interactionScript = FindAnyObjectByType<Interaction>();
        objectOnSlot = null;
    }

    public override void Interact()
    {
        // si objet tenu et slot vide
        if (slotEmpty && !interactionScript.GetHandFree()) // si slot vide et objet en main
        {
            //on place l'objet tenu sur le slot
            objectOnSlot = interactionScript.GetObjectHeld();
            PickupObject pickupScript = objectOnSlot.GetComponent<PickupObject>();
            pickupScript.SetObjectOnSlot();
            pickupScript.SetSlot(gameObject);
            interactionScript.SetHandFree();
            slotEmpty = false;

            //tp l'objet tenu sur le slot, à peaufiner selon l'épaisseur et l'orientation du slot
            objectOnSlot.transform.position = transform.position + Vector3.up * 0.2f;

            CheckGoodObject();
        }
        else if (!slotEmpty && interactionScript.GetHandFree()) // si slot occupé et main vide
        {
            // on prend en main l'objet sur le slot
            PickupObject pickupScript = objectOnSlot.GetComponent<PickupObject>();
            pickupScript.Interact();
        }
    }

    private void CheckGoodObject()
    {
        if (objectOnSlot == targetObject)
        {
            goodObject = true;
        }
        else
        {
            goodObject = false;
        }
    }

    public bool GetGoodObject()
    {
        return goodObject;
    }

    public void SetSlotEmpty() //quand le slot se vide
    {
        slotEmpty = true;
        objectOnSlot = null;
        goodObject = false;
    }
}
