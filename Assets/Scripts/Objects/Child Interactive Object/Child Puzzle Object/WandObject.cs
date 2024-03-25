using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Cinemachine;

public class WandObject : PuzzleObject
{
    private bool wandMode = false;
    private bool solved = false;
    [SerializeField]
    private List<GameObject> targetObjects = new List<GameObject>();

    [SerializeField]
    private List<GameObject> solutionList;

    [SerializeField]
    private CinemachineVirtualCamera cameraWand;


    //ouverture de la porte, peut être dans un autre script ou objet
    [SerializeField]
    private Vector3 endPosition;
    [SerializeField]
    private Quaternion endRotation;
    private LerpObject lerpObjectScript;

    public override void Start()
    {
        base.Start();
        lerpObjectScript = FindObjectOfType<LerpObject>();
    }

    void Update()
    {

        if (wandMode == true) 
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)) // quitte le mode baguette
            {
                wandMode = false;
                Cursor.lockState = CursorLockMode.Locked;
                DisplayMeshRenderer(false);
            }

            if (Input.GetMouseButton(0))
            {
                //baguette active

                Vector3 mousePosition = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.IsChildOf(transform) && hit.transform != transform)
                    {
                        GameObject targetObject = hit.collider.gameObject;

                        if (!targetObjects.Contains(targetObject))
                        {
                            targetObjects.Add(targetObject);
                        }
                    }
                }
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                //on lance le sort et on vérifie la solution

                if (targetObjects.Count == solutionList.Count) //premiere vérif de taille de liste
                {
                    bool listsAreEqual = true;
                    for (int i = 0; i < targetObjects.Count; i++)
                    {
                        if (targetObjects[i] != solutionList[i])
                        {
                            listsAreEqual = false;
                            break;
                        }
                    }

                    if (listsAreEqual)
                    {
                        Debug.Log("Alohomora !"); //sort réussi
                        solved = true;
                        targetObjects.Clear();
                        DisplayMeshRenderer(false);
                        PuzzleSolved();

                        //quitte le mode puzzle et baguette
                        wandMode = false;
                        Cursor.lockState = CursorLockMode.Locked;
                        stateModeScript.QuitPuzzleMode();
                        // le mode puzzle se quitte depuis le script interaction

                    }
                    else
                    {
                        targetObjects.Clear();
                    }
                }
                else
                {
                    targetObjects.Clear();
                }
            }


            }
        else
        {
           
        }
    }

    public override void Interact()
    {
        // if Baguette magique en main 
        base.Interact();
        wandMode = true;
        Cursor.lockState = CursorLockMode.None;
        //cameraWand.Priority = 15;
        DisplayMeshRenderer(true);

    }

    public bool GetSolved()
    {
        return solved;
    }

    private void PuzzleSolved()
    {
        lerpObjectScript.MoveToTarget(transform, endPosition, endRotation);
    }

   private void DisplayMeshRenderer(bool boolean)
    {
        foreach (Transform child in transform)
        {
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = boolean;
            }
        }
    }


}
