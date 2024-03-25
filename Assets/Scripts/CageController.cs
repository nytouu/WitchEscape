using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CageController : MonoBehaviour
{
    [SerializeField]
    private float lookSpeed = 2f;

    [SerializeField]
    private float lookXLimit = 80f;

	private CinemachineVirtualCamera playerCamera;
    private float rotationX = 0;

	private CinemachineBrain brain;

	[SerializeField]
	private float transitionTime;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

		playerCamera = GetComponent<CinemachineVirtualCamera>();

		brain.m_DefaultBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseOut, transitionTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        /* rotationX += -Input.GetAxis("Mouse Y") * lookSpeed; */
        /* rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit); */
        /* playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); */
        /* transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0); */
    }
}
