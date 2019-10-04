using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPointer : MonoBehaviour
{
    public float sensitivity = 10f; //sensitivity of the mouse
    public float maxYAngle = 80f; //maximum angle that the player is able to look up
    private Vector2 currentRotation; //used to facilitate rotation calculation

    private void Start()
    {
        Cursor.visible = false; //sets the default unity cursor to be invisible(?)
    }
    void Update()
    {

        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity; //gets the x component of the movement of the mouse and stores it in the x component of currentRotation
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity; //gets the y component of the movement of the mouse and stores it in the y component of currentRotation
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360); //loops currentRotation.x so it is always greater than 0 and less than 360 then sets it to the currentrotation
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle); //clamps the Y component of the camera rotation so it cannot be above or below a maxYangle.
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0); //sets the camera rotation to = currentRotation
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Cursor.lockState = CursorLockMode.Locked; //i dont think this is needed anymore.
        //}
    }
}
