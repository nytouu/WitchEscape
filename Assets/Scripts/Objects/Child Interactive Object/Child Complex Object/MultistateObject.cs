using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultistateObject : ComplexObject
{
    [SerializeField]
    protected int state; //état actuel
    protected int minState = 1; //1er état, état le plus bas
    public int maxState; //nombre d'états max
    private int targetState = 2;
    private bool goodState = false;

    public virtual void Start()
    {
        state = minState;
        typeOfPuzzle = "Puzzle";
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

    public virtual void CheckGoodState()
    {
        if (state == targetState)
        {
            goodState = true;
        }
        else
        {
            goodState = false;
        }
    }

    public bool GetGoodState()
    {
        return goodState;
    }

}
