using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField]
    private Vector2 sensitivity;

    [SerializeField]
    private Transform orientation;

    private Vector2 rotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
		// Handle mouse input
        Vector2 mouseInput;

        mouseInput.x = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity.x;
        mouseInput.y = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity.y;

        rotation.y += mouseInput.x;
        rotation.x -= mouseInput.y;

		// Clamp vertical
        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

		// Apply rotation
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
        orientation.rotation = Quaternion.Euler(0, rotation.y, 0);
    }
}
