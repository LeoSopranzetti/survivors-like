using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack;
    float timer;
    PlayerMove playerMove;

    [SerializeField] GameObject firePrefab;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnFire();
    }

    private void SpawnFire()
    {
        if (playerMove.lastHorizontalVector == 0)
        {
            return;
        }
        GameObject fire = Instantiate(firePrefab);
        fire.transform.position = transform.position;
        fire.GetComponent<FireProjectile>().SetDirection(playerMove.lastHorizontalVector, 0f);
    }
}
