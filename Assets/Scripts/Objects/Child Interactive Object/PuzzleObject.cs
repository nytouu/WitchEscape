using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Cinemachine;

public class PuzzleObject : InteractiveObject
{
    public StateMode stateModeScript;
<<<<<<< Updated upstream
    public Transform transformChild;
    public Lerp lerpScript;

    public virtual void Start()
    {
        lerpScript = FindObjectOfType<Lerp>();
        stateModeScript = FindObjectOfType<StateMode>();

        transformChild = transform.Find("View"); // recupere le transform de l'enfant "View"
=======
    private Transform transformChild;

    private CinemachineVirtualCamera childVirtualCamera;

    public virtual void Start()
    {
        typeOfPuzzle = "Puzzle";
        stateModeScript = FindObjectOfType<StateMode>();
        childVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
>>>>>>> Stashed changes
        
    }

    void Update()
    {
        
    }

    public override void Interact()
    {
        stateModeScript.EnterPuzzleMode();
        childVirtualCamera.Priority = 15;

    }

}
