using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    private float XSens = 30f;
    private float YSens = 30f; 

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -=(mouseY * Time.deltaTime) * YSens;
        xRotation = Mathf.Clamp(xRotation, -80f, 80);
        cam.transform.localRotation = Quaternion.Euler(xRotation,0,0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * XSens);

    }

}
