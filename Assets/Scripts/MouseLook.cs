using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<summary>
// Handles player's rotation from mouse input
//<summary>

public class MouseLook : MonoBehaviour {
    public float lookSensitivity = 2f;
    public float lookSmoothDamp = .5f;
     [HideInInspector]
    public float yRot, xRot;
     [HideInInspector]
    public float currentY, currentX;
     [HideInInspector]
    public float yRotV, xRotV;

    // Update is called once per frame
    void Update() {
        //Reads values from mouse axes
        yRot += Input.GetAxis("Mouse X") * lookSensitivity;
        xRot += Input.GetAxis("Mouse Y") * lookSensitivity;

        //Smooths movements (moves from current to desired value over time instead of immediately)
        currentX = Mathf.SmoothDamp(currentX, xRot, ref xRotV, lookSmoothDamp);
        currentY = Mathf.SmoothDamp(currentY, yRot, ref yRotV, lookSmoothDamp);

        //Limits x rotation (up and down)
        xRot = Mathf.Clamp(xRot, -80, 80);

        //Resets camera position to center of screen
        if (Input.GetKeyDown(KeyCode.Tab) == true) {
            yRot = 0;
            xRot = 0;
        }

        //Sets rotation of camera according to mouse inputs
        transform.rotation = Quaternion.Euler(-currentX, currentY, 0);
    }
}
