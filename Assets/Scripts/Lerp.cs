using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement du lerp
    private Coroutine moveCoroutine;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MoveToTarget(Transform target, Transform targetDestination)
    {
        // Arr�ter la coroutine existante si elle est en cours
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        // Lancer une nouvelle coroutine pour d�placer la cam�ra vers la position cible
        moveCoroutine = StartCoroutine(MoveCoroutine(target, targetDestination));
    }

    private IEnumerator MoveCoroutine(Transform target, Transform targetDestination)
    {
        // Calculer la distance entre la cam�ra et la position cible
        float distance = Vector3.Distance(target.position, targetDestination.position);

        // Tant que la distance est sup�rieure � une petite valeur (pour �viter les probl�mes de flottement),
        // continuer � d�placer la cam�ra vers la position cible
        while (distance > 0.01f)
        {
            // Calculer la nouvelle position de la cam�ra en utilisant lerp
            Vector3 newPosition = Vector3.Lerp(target.position, targetDestination.position, moveSpeed * Time.deltaTime);

            // Calculer la nouvelle rotation de la cam�ra en utilisant lerp
            Quaternion newRotation = Quaternion.Slerp(target.rotation, targetDestination.rotation, moveSpeed * Time.deltaTime);

            // D�placer la cam�ra vers la nouvelle position
            target.position = newPosition;

            // Faire tourner la cam�ra vers la nouvelle rotation
            target.rotation = newRotation;

            // Mettre � jour la distance
            distance = Vector3.Distance(target.position, targetDestination.position);

            // Attendre la prochaine frame
            yield return null;
        }
    }
}
