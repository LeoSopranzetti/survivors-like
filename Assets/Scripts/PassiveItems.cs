using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] List<Item> items;
    Character character;


    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
    }

    public void Equip(Item itemToEquip)
    {
        if (items == null)
        {
            items = new List<Item>();
        }
        Item newItemInstance = new Item();
        newItemInstance.Init(itemToEquip.Name);
        newItemInstance.itemStats.Sum(itemToEquip.itemStats);

        items.Add(newItemInstance);
        newItemInstance.Equip(character);
    }

    public void UnEquip(Item itemToUnEquip)
    {

    }

    internal void UpgradeItem(UpgradeData upgradeData)
    {
        Item itemToUpgrade = items.Find(id => id.Name == upgradeData.item.Name);
        itemToUpgrade.UnEquip(character);
        itemToUpgrade.itemStats.Sum(itemToUpgrade.itemStats);
        itemToUpgrade.Equip(character);
    }
}
