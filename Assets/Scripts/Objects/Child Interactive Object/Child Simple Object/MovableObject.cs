using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovableObject : SimpleObject
{

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 endPosition;
    private Quaternion endRotation;

    public bool stateOpen = false;

    private Transform transformChid;
    private Lerp lerpScript;

    // CREER UN TRANSFORM AU START DE L'OBJET ?

    // CODE A REECRIRE POUR PRENDRE EN COMPTE LA POSITION DU CHILD

    void Start()
    {
        transformChid = transform.GetChild(0);
        lerpScript = FindObjectOfType<Lerp>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {

    }
    public override void Interact()
    {
        if (!stateOpen)
        {
            //lerpScript.MoveToTarget(transform, transformChild);
            stateOpen = true;
        }
        else
        {
            //lerpScript.MoveToTarget(transform, transformStart);
            stateOpen = false;
        }
    }
}