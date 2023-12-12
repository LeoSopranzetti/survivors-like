using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase
{

    [SerializeField] GameObject bulletPrefab;


    public override void Attack()
    {
        UpdateVectorOfAttack();

        if (vectorOfAttack.x == 0 && vectorOfAttack.y == 0)
        {
            return;
        }

        for (int i = 0; i < weaponStats.numerOfAttacks; i++)
        {
            GameObject fire = Instantiate(bulletPrefab);

            Vector3 newFirePosition = transform.position;



            fire.transform.position = newFirePosition;

            FireProjectile fireProjectile = fire.GetComponent<FireProjectile>();
            Debug.Log(vectorOfAttack.y);
            fireProjectile.SetDirection(vectorOfAttack.x, vectorOfAttack.y);
            fireProjectile.damage = GetDamage();
        }

    }
}
