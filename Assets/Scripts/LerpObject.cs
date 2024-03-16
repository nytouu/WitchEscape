using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObject : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f; // Vitesse de d�placement du lerp
    private Coroutine moveCoroutine;

    public void MoveToTarget(Transform target, Vector3 position, Quaternion rotation)
    {
        // Arr�ter la coroutine existante si elle est en cours
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        // Lancer une nouvelle coroutine pour d�placer la cam�ra vers la position cible
        moveCoroutine = StartCoroutine(MoveCoroutine(target, position, rotation));
    }

    private IEnumerator MoveCoroutine(Transform target, Vector3 position, Quaternion rotation)
    {
        float distance = Vector3.Distance(target.position, position);
        float angleDifference = Mathf.Abs(Quaternion.Angle(target.rotation, rotation));

        // Tant que la distance et l'angle sont sup�rieurs � une petite valeur (pour �viter les probl�mes de flottement),
        while (distance > 0.01f || angleDifference > 0.001f)
        {
            Vector3 newPosition = Vector3.Lerp(target.position, position, moveSpeed * Time.deltaTime);

            Quaternion newRotation = Quaternion.Slerp(target.rotation, rotation, moveSpeed * Time.deltaTime);


            target.position = newPosition;

            target.rotation = newRotation;

            // Mettre � jour la distance
            distance = Vector3.Distance(target.position, position);
            angleDifference = Mathf.Abs(Quaternion.Angle(target.rotation, rotation));

            // Attendre la prochaine frame
            yield return null;
        }
    }
}
