using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMode : MonoBehaviour
{
    private bool puzzleMode;


    void Start()
    {
        puzzleMode = false;
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

}
