﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUp_SO itemDefinition;

    public CharacterStats charStats;
    CharacterInventory charInventory;

    GameObject foundStats;

    #region Constructors
    public ItemPickUp()
    {
        charInventory = CharacterInventory.instance;
    }

    #endregion

    private void Start()
    {
        if (charStats != null)
        {
            foundStats = GameObject.FindGameObjectWithTag("Player");
            charStats = foundStats.GetComponent<CharacterStats>();
        }
    }

    void StoreItemInventory()
    {
        charInventory.StoreItem(this);
    }

    public void UseItem()
    {
        switch(itemDefinition.itemType)
        {
            case ItemTypeDefinitions.HEALTH:
                {
                    charStats.ApplyHealth(itemDefinition.itemAmount);
                    break;
                }
            case ItemTypeDefinitions.MANA:
                {
                    charStats.ApplyMana(itemDefinition.itemAmount);
                    break;
                }
            case ItemTypeDefinitions.WEALTH:
                {
                    charStats.GiveWealth(itemDefinition.itemAmount);
                    break;
                }
            case ItemTypeDefinitions.WEAPON:
                {
                    charStats.ChangeWeapon(this);
                    break;
                }
            case ItemTypeDefinitions.ARMOR:
                {
                    charStats.ChangeArmor(this);
                    break;
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (itemDefinition.isStorable)
            {
                StoreItemInventory();
            }
            else
            {
                UseItem();
            }
        }
    }
}
