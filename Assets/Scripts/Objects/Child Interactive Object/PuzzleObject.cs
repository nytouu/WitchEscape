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
    private UICrosshair uiC;

    public virtual void Start()
    {
        uiC = FindObjectOfType<UICrosshair>();
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
        childVirtualCamera.Priority = 2;
        uiC.crossHair.gameObject.SetActive(false);
    }
}
