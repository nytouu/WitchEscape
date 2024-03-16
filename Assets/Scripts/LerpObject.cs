using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpObject : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f; // Vitesse de déplacement du lerp
    private Coroutine moveCoroutine;

    public void MoveToTarget(Transform target, Vector3 position, Quaternion rotation)
    {
        // Arrêter la coroutine existante si elle est en cours
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        // Lancer une nouvelle coroutine pour déplacer la caméra vers la position cible
        moveCoroutine = StartCoroutine(MoveCoroutine(target, position, rotation));
    }

    private IEnumerator MoveCoroutine(Transform target, Vector3 position, Quaternion rotation)
    {
        float distance = Vector3.Distance(target.position, position);
        float angleDifference = Mathf.Abs(Quaternion.Angle(target.rotation, rotation));

        // Tant que la distance et l'angle sont supérieurs à une petite valeur (pour éviter les problèmes de flottement),
        while (distance > 0.01f || angleDifference > 0.001f)
        {
            Vector3 newPosition = Vector3.Lerp(target.position, position, moveSpeed * Time.deltaTime);

            Quaternion newRotation = Quaternion.Slerp(target.rotation, rotation, moveSpeed * Time.deltaTime);


            target.position = newPosition;

            target.rotation = newRotation;

            // Mettre à jour la distance
            distance = Vector3.Distance(target.position, position);
            angleDifference = Mathf.Abs(Quaternion.Angle(target.rotation, rotation));

            // Attendre la prochaine frame
            yield return null;
        }
    }
}
