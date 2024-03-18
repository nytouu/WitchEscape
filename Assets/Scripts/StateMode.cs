using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMode : MonoBehaviour
{
    private bool puzzleMode;
    private bool analysisMode;


    void Start()
    {
        puzzleMode = false;
        analysisMode = false;
    }

    void Update()
    {

    }

    public void QuitPuzzleMode()
    {
        puzzleMode = false;
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
