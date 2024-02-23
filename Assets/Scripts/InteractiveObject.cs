using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public abstract class InteractiveObject : MonoBehaviour
{

    public virtual void Interact()
    {

    }
}
