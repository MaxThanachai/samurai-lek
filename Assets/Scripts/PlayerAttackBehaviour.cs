using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    public float attackRange = 2;

    private Vector3 attackDirection;
    private Vector3 previous;
    private Vector3 current;
    private float attackCooldown, attackDuration;
    private bool isAttacking = false;

    void Start()
    {
        attackCooldown = 3;
        attackDuration = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateAttackDirection();

        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            isAttacking = false;
        }
        else if (attackDuration > 0)
        {
            attackDuration -= Time.deltaTime;
            isAttacking = true;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position + attackDirection, new Vector2(attackRange, attackRange), 0);

            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    Destroy(collider.gameObject);
                }
            }
        }
        else
        {
            attackCooldown = 3;
            attackDuration = 0.75f;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = isAttacking ? new Color(1, 0, 0, 0.5f) : new Color(1, 0, 0, 0.1f);
        Vector3 attackPosition = transform.position + attackDirection;
        Gizmos.DrawCube(attackPosition, new Vector3(attackRange, attackRange, 1));
    }

    void CalculateAttackDirection()
    {
        previous = current;
        current = transform.position;
        Vector3 normalized = (current - previous).normalized;
        if (normalized.magnitude == 0) return;
        attackDirection = normalized;
    }
}
