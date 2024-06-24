using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public GameObject cameraHolder;
    public Vector3 cameraFollow;
    public Quaternion cameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = cameraHolder.transform.position;
        cameraRotation = cameraHolder.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollow = cameraHolder.transform.position;
        transform.position = cameraFollow;
    }
}
