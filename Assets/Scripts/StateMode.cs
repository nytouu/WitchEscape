using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StateMode : MonoBehaviour
{
    private bool puzzleMode;
    private bool analysisMode;

    private CinemachineVirtualCamera activeVirtualCamera;
    private CinemachineBrain cinemachineBrain;
    private UICrosshair uiC;


    void Start()
    {
        uiC = FindObjectOfType<UICrosshair>();
        puzzleMode = false;
        analysisMode = false;
        // faire des getter

        cinemachineBrain = FindObjectOfType<CinemachineBrain>();
    }

    void Update()
    {

    }

    public void QuitPuzzleMode()
    {
        puzzleMode = false;
        activeVirtualCamera = cinemachineBrain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
        activeVirtualCamera.Priority = 0;
        uiC.crossHair.gameObject.SetActive(true);
    }

    public void EnterPuzzleMode()
    {
        puzzleMode = true;
    }

    public bool GetPuzzleMode()
    {
        return puzzleMode;
    }


    public void QuitAnalysisMode()
    {
        analysisMode = false;
    }

    public void EnterAnalysisMode()
    {
        analysisMode = true;
    }

    public bool GetAnalysisMode()
    {
        return analysisMode;
    }



}
