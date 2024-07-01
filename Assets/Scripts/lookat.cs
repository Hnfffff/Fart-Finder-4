using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public Vector3 lok;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lok = new Vector3(player.transform.position.x, -90f, player.transform.position.z);
        transform.LookAt(lok);
    }
}
