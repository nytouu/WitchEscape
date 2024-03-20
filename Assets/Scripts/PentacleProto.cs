using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PentacleProto : MonoBehaviour
{
    [SerializeField]
    private List<SlotObject> candlesSlot;

    [SerializeField]
    private bool puzzleComplete;

    // Start is called before the first frame update
    void Start()
    {
        puzzleComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!puzzleComplete)
        {
            CheckForPuzzle();
        }
    }

    public void CheckForPuzzle()
    {
        bool ok = true;

        foreach (var slot in candlesSlot)
        {
            if (!slot.GoodObject)
            {
                ok = false;
            }
        }

        if (ok)
        {
            puzzleComplete = true;
            Debug.Log("Puzzle Completed");
        }
    }
}
