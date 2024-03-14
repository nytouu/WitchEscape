using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OneshotObject : SimpleObject
{
    private Transform playerScale;

    void Start()
    {

    }

    void Update()
    {

    }

    public override void Interact()
    {
        Destroy(this);
    }

}
