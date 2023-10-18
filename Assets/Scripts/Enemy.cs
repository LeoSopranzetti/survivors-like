using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform targetDestination;
    [SerializeField] float speed;
    GameObject targetGameObject;
    Rigidbody2D rgbd2d;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = targetDestination.gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        //Debug.Log("Attack the character");
    }
}
