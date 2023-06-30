using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform player;
    private Vector2 previous;
    private Vector2 current;

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
        previous = current;
        current = player.position;
        float angle = Vector2.Angle(previous, current);
        transform.eulerAngles = new Vector3(0,0,angle);
        Orbit();
    }
}
