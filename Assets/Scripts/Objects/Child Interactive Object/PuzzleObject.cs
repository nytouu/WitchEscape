using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Cinemachine;

public class PuzzleObject : InteractiveObject
{
    public StateMode stateModeScript;
    private CinemachineVirtualCamera childVirtualCamera;

    public virtual void Start()
    {
        typeOfPuzzle = "Puzzle";
        stateModeScript = FindObjectOfType<StateMode>();
        childVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();

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
