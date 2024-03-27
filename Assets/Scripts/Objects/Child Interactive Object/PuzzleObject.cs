using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PuzzleObject : InteractiveObject
{
    public StateMode stateModeScript;
    private Transform transformChild;
    private Lerp lerpScript;
    public bool isPuzzle = true;

    public virtual void Start()
    {
        typeOfPuzzle = "Puzzle";
        lerpScript = FindObjectOfType<Lerp>();
        stateModeScript = FindObjectOfType<StateMode>();
        transformChild = transform.Find("View"); // recupere le transform de l'enfant "View"
        
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        stateModeScript.EnterPuzzleMode();
        lerpScript.MoveToTarget(Camera.main.transform, transformChild);
    }

}
