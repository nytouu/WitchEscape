using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultistateObject : ComplexObject
{
    [SerializeField]
    protected int state; //état actuel
    protected int minState = 1; //1er état, état le plus bas
    public int maxState; //nombre d'états max

    public virtual void Start()
    {
        state = minState;
    }

    public override void Interact()
    {
        state++;
        if (state > maxState) //remise à zéro
        {
            state = minState;
        }
    }

    public virtual int GetState()
    {
        return state;
    }

}
