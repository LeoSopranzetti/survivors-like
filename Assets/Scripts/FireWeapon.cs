using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : WeaponBase
{
    [SerializeField] GameObject firePrefab;
    [SerializeField] float spread = 0.5f;

    public override void Attack()
    {
        UpdateVectorOfAttack();

        if (vectorOfAttack.x  == 0 && vectorOfAttack.y == 0)
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
            Debug.Log(vectorOfAttack.y);
            fireProjectile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);
            fireProjectile.damage = GetDamage();
        }

    }
}
