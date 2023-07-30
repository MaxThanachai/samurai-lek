using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform player;
    private Vector2 previous;
    private Vector2 current;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            Destroy(gameObject);
        }
        else
        {
            previous = current;
            current = player.position;
            Orbit();
            Turn();
        }
    }

    void Orbit()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -1);
    }

    void Turn()
    {
        Vector3 relativePos = current - previous;
        if (relativePos != Vector3.zero) { 
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
