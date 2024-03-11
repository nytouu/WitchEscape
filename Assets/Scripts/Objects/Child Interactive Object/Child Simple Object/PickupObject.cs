using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : SimpleObject
{
    private bool objectHeld;

    void Start()
    {
        objectHeld = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        objectHeld = true;
    }


    // prévoir le code quand on lache l'objet

}
