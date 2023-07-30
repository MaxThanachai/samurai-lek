using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float attackRange = 3f;
    [SerializeField] int attackPower = 1;
    Rigidbody2D rb;
    GameObject target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (target && target.transform)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
            AttackPlayer();
        }
    }

    private void FixedUpdate()
    {
        if (target && target.transform)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void AttackPlayer()
    {
        if ((target.transform.position - transform.position).magnitude > attackRange) return;
        HealthPoint targetHp = target.GetComponent<HealthPoint>();
        if (targetHp == null) return;
        targetHp.ModifyHealthPoint(-attackPower);
        Debug.Log("Attack player");
    }

}
