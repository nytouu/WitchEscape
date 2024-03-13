using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultistateObject : ComplexObject
{
    public int state; //état actuel
    public int minState; //1er état, état le plus bas
    public int maxState; //nombre d'états max

    void Start()
    {
        
    }

    void Update()
    {
        if (state > maxState) //remise à zéro
        {
            state = minState;
        }
        
    }

    public override void Interact()
    {
        state++;
    }

}
