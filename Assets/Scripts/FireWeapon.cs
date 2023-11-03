using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : WeaponBase
{

    PlayerMove playerMove;

    [SerializeField] GameObject firePrefab;

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }


    public override void Attack()
    {
        if (playerMove.lastHorizontalVector == 0)
        {
            return;
        }
        GameObject fire = Instantiate(firePrefab);
        fire.transform.position = transform.position;
        FireProjectile fireProjectile = fire.GetComponent<FireProjectile>();
        fireProjectile.SetDirection(playerMove.lastHorizontalVector, 0f);
        fireProjectile.damage = weaponStats.damage;
    }
}
