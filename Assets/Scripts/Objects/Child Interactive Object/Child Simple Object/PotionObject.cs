using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PotionObject : SimpleObject
{
    private Transform playerScale;

    void Start()
    {
        playerScale = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {

        playerScale.localScale /= 2f;
        // réduire la speed aussi
        
        //Destroy(this);

    }

}
