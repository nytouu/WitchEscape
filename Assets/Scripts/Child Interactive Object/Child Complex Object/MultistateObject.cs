using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultistateObject : ComplexObject
{
    public int state; //�tat actuel
    public int minState; //1er �tat, �tat le plus bas
    public int maxState; //nombre d'�tats max

    void Start()
    {
        
    }

    void Update()
    {
        if (state > maxState) //remise � z�ro
        {
            state = minState;
        }
        
    }

    public override void Interact()
    {
        state++;
    }

}
