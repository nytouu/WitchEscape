using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement du lerp
    private Coroutine moveCoroutine;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MoveToTarget(Transform target, Transform targetDestination)
    {
        // Arrêter la coroutine existante si elle est en cours
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);

        // Lancer une nouvelle coroutine pour déplacer la caméra vers la position cible
        moveCoroutine = StartCoroutine(MoveCoroutine(target, targetDestination));
    }

    private IEnumerator MoveCoroutine(Transform target, Transform targetDestination)
    {
        // Calculer la distance entre la caméra et la position cible
        float distance = Vector3.Distance(target.position, targetDestination.position);

        // Tant que la distance est supérieure à une petite valeur (pour éviter les problèmes de flottement),
        // continuer à déplacer la caméra vers la position cible
        while (distance > 0.01f)
        {
            // Calculer la nouvelle position de la caméra en utilisant lerp
            Vector3 newPosition = Vector3.Lerp(target.position, targetDestination.position, moveSpeed * Time.deltaTime);

            // Calculer la nouvelle rotation de la caméra en utilisant lerp
            Quaternion newRotation = Quaternion.Slerp(target.rotation, targetDestination.rotation, moveSpeed * Time.deltaTime);

            // Déplacer la caméra vers la nouvelle position
            target.position = newPosition;

            // Faire tourner la caméra vers la nouvelle rotation
            target.rotation = newRotation;

            // Mettre à jour la distance
            distance = Vector3.Distance(target.position, targetDestination.position);

            // Attendre la prochaine frame
            yield return null;
        }
    }
}
