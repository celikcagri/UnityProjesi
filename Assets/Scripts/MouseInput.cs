using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Transform player;
    public float mouseSense = 200f;
    private float xRotation ;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; //ekranda mouse görünmesini engeller
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXPos = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseYPos = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRotation -= mouseYPos;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //sýnýrlama getirir
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        

        player.Rotate(Vector3.up * mouseXPos);
    }
}
