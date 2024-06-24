using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseRotationX;
    public float mouseRotationY;
    public float mouseSensitivity = 0.1f;
    public GameObject playerOrientation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseRotationX += (Input.GetAxisRaw("Mouse Y") * mouseSensitivity) / 2;
        mouseRotationY += (Input.GetAxisRaw("Mouse X") * mouseSensitivity) / 2;

        //Debug.Log($"X: {mouseRotationX}, Y: {mouseRotationY}");

        mouseRotationX = Mathf.Clamp(mouseRotationX, -90f, 90f);

        transform.localEulerAngles = new Vector3(-mouseRotationX, mouseRotationY, 0);

        playerOrientation.transform.localEulerAngles = new Vector3(transform.rotation.x, mouseRotationY, transform.rotation.y);
    }
}
