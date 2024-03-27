using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    protected string typeOfPuzzle;
    public string TypeOfPuzzle { get => typeOfPuzzle; }

public virtual void Interact()
    {

    }
}
