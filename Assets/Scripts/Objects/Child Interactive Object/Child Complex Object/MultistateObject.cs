using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultistateObject : ComplexObject
{
    [SerializeField]
    protected int state; //�tat actuel
    protected int minState = 1; //1er �tat, �tat le plus bas
    public int maxState; //nombre d'�tats max

    public virtual void Start()
    {
        state = minState;
    }

    public override void Interact()
    {
        state++;
        if (state > maxState) //remise � z�ro
        {
            state = minState;
        }
    }

    public virtual int GetState()
    {
        return state;
    }

}
