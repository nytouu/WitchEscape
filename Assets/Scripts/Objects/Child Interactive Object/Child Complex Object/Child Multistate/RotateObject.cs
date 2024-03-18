using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MultistateObject
{
    [SerializeField]
    private bool clockwise = true;
    private float rotation;
    private bool isRotate = false;
    private LerpObject lerpObjectScript;
    private float delay = 0.7f;
    private Quaternion baseRotation;
    private Quaternion newRotation;
 

    public override void Start()
    {
        base.Start();
        lerpObjectScript = FindObjectOfType<LerpObject>();
        baseRotation = transform.rotation;
    }

    public override void Interact()
    {
 
        if (!isRotate)
        {
            base.Interact();

            if (state == minState)
            {
                newRotation = baseRotation; // permet de reset le d�calage quand l'objet fait un tour complet
            }
            else
            {
                rotation = 360 / maxState;
                float finalRotation = clockwise ? Mathf.Abs(rotation) : -Mathf.Abs(rotation);
                isRotate = true;

                Quaternion currentRotation = transform.rotation;
                newRotation = currentRotation * Quaternion.Euler(0f, finalRotation, 0f); // rotation sur l'axe y uniquement, parall�le au sol
            }
            
            lerpObjectScript.MoveToTarget(transform, transform.position, newRotation);
            StartCoroutine(ResetIsRotate(delay)); // passe isRotate apr�s delay secondes

            // alternative au compte � rebours en checkant si l'objet bouge et tourne encore
            // un d�calage se cr�� � chaque rotation
        }
    }

    

    IEnumerator ResetIsRotate(float delay)
    {
        yield return new WaitForSeconds(delay);
        isRotate = false;
    }

}
