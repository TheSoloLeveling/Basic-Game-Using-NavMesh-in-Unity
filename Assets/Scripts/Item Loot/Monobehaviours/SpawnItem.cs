﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour, ISpawns   // link up the interface and we need to add its references
{
    public ItemPickUp_SO[] itemDefinitions;


    private int whichToSpawn = 0;
    private int totalSpawnWeight = 0;
    private int chosen = 0;

    public Rigidbody itemSpawned { get ; set; }
    public Renderer itemMaterial { get ; set; }
    public ItemPickUp itemType { get; set; }

    void Start()
    {
        
        
        foreach(ItemPickUp_SO ip in itemDefinitions)
        {
            totalSpawnWeight += ip.spawnChanceWeight;
        }
    }

    public void CreateSpawn()
    {
        foreach ( ItemPickUp_SO ip in itemDefinitions)
        {
            
            whichToSpawn += ip.spawnChanceWeight;
            if (whichToSpawn >= chosen)
            {
                itemSpawned = Instantiate(ip.itemSpawnObject, transform.position, Quaternion.Euler(-90,0,0));

                itemMaterial = itemSpawned.GetComponent<Renderer>();
                itemMaterial.material = ip.itemMaterial;

                itemType = itemSpawned.GetComponent<ItemPickUp>();
                itemType.itemDefinition = ip;
                break;
            }
        }
    }

}
