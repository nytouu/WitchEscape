using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiStateObject : ComplexObject
{
    private int currentState;
    [SerializeField]
    private int minState;
    [SerializeField]
    private int maxState;


    void Start()
    {
        currentState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState > maxState)
        {
            currentState = minState;
        }
    }

    public override void Interact()
    {
        currentState++;
    }

}
