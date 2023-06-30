using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform player;

    void Orbit()
    {
        transform.position = player.position;
        //transform.RotateAround(player.position, Vector3.forward, 0);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Orbit();
    }
}
