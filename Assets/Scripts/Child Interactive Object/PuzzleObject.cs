using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PuzzleObject : InteractiveObject
{
    private StateMode stateModeScript;
    private Camera playerCamera;
    private Transform playerPosition;
    private Transform transformChild;
    private Lerp lerpScript;

    void Start()
    {
        //moveScript = FindObjectOfType<Move>();
        playerCamera = FindObjectOfType<Camera>();
        lerpScript = FindObjectOfType<Lerp>();
        stateModeScript = FindObjectOfType<StateMode>();

        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
        transformChild = transform.Find("View"); // recupere le transform de l'enfant "View"
        
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        stateModeScript.puzzleMode = true;
        lerpScript.MoveToTarget(Camera.main.transform, transformChild);
        
    }

}
