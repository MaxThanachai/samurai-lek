using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    Vector3 attackDirection;
    private Vector2 previous;
    private Vector2 current;
    float TimerForNextAttack, Cooldown;
    void Start()
    {
        Cooldown = 3;
        TimerForNextAttack = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        previous = current;
        current = transform.position;
        attackDirection = (current - previous).normalized;

        if (TimerForNextAttack > 0)
        {
            TimerForNextAttack -= Time.deltaTime;
        }
        else if (TimerForNextAttack <= 0)
        {
            TimerForNextAttack = Cooldown;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + attackDirection, new Vector2(1, 1), 0);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Destroy(collider.gameObject);
                }
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Vector3 attackPosition = transform.position + attackDirection;
        Gizmos.DrawCube(attackPosition, new Vector3(1, 1, 1));
    }
}
