using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public int damage;
    public float timeToAttack;
    public int numerOfAttacks;

    public WeaponStats(int damage, float timeToAttack, int numerOfAttacks)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
        this.numerOfAttacks = numerOfAttacks;
    }

    internal void Sum(WeaponStats weaponUpgradeStats)
    {
        this.damage += weaponUpgradeStats.damage;
        this.timeToAttack += weaponUpgradeStats.timeToAttack;
        this.numerOfAttacks += weaponUpgradeStats.numerOfAttacks;
    }
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;

}
