using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MovableObject : SimpleObject
{

    private Vector3 startPosition;
    private Quaternion startRotation;
    [SerializeField]
    private Vector3 endPosition;
    [SerializeField]
    private Quaternion endRotation;

    private float delay = 1f;
    private bool stateOpen = false;
    private bool isMove = false;

    private LerpObject lerpObjectScript;


    void Start()
    {
        typeOfPuzzle = "Movable";
        lerpObjectScript = FindObjectOfType<LerpObject>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public override void Interact()
    {
        if (!isMove)
        {
            isMove = true;
            if (!stateOpen)
            {
                lerpObjectScript.MoveToTarget(transform, endPosition, endRotation);
                stateOpen = true;
            }
            else
            {
                lerpObjectScript.MoveToTarget(transform, startPosition, startRotation);
                stateOpen = false;
            }
            StartCoroutine(ResetIsMove(delay));
        }
        
    }

    IEnumerator ResetIsMove(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMove = false;
    }

    public bool GetState()
    {
        return stateOpen;
    }
}