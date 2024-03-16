using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeObject : PuzzleObject
{
    private Camera CameraTelescope;
    private bool modeTelescope = false;
    private float moveSpeed = 0.05f;
    private Transform map;

    public override void Start()
    {
        base.Start();
        CameraTelescope = GameObject.Find("CameraTelescope").GetComponent<Camera>();
        map = GameObject.Find("Map").GetComponent<Transform>();
    }

    void Update()
    {

        if (modeTelescope == true)
        {
            // wait quelques secondes pour que le lerp se fasse puis

            CameraTelescope.depth = 2;

            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)) // quitte le mode telescope
            {
                modeTelescope = false;
            }

            // déplacement de la carte
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 movement = new Vector3(mouseX * moveSpeed, -mouseY * moveSpeed, 0);

            map.transform.Translate(movement);

            // prévoir des bornes 

        }
        else
        {
            CameraTelescope.depth = 0;
        }
    }

    public override void Interact()
    {
        base.Interact();
        modeTelescope = true;
    }




}
