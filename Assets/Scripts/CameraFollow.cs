using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    //public Vector3 cameraOffset;

    [Range(0.01f , 1.0f)]
    public  float smoothness = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //cameraOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newPos = player.position;
        transform.position = new Vector3(player.position.x,player.position.y,-10);
    }
}
