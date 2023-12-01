using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : WeaponBase
{

    PlayerMove playerMove;

    [SerializeField] GameObject firePrefab;
    [SerializeField] float spread = 0.5f;

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


        for (int i = 0; i < weaponStats.numerOfAttacks; i++)
        {
            GameObject fire = Instantiate(firePrefab);

            Vector3 newFirePosition = transform.position;

            if (weaponStats.numerOfAttacks > 1)
            {
                newFirePosition.y -= (spread * (weaponStats.numerOfAttacks - 1)) / 2;
                newFirePosition.y += i * spread;
            }


            fire.transform.position = newFirePosition;

            FireProjectile fireProjectile = fire.GetComponent<FireProjectile>();
            fireProjectile.SetDirection(playerMove.lastHorizontalVector, 0f);
            fireProjectile.damage = GetDamage();
        }

    }
}
