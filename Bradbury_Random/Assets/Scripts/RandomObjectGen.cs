﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Andrew Bradbury
//Purpose: Create multiple instances of an object and place it randomly around the scene
public class RandomObjectGen : MonoBehaviour
{
    [SerializeField]
    private GameObject myPrefab;

    [Range(30, 50)]
    public int numberOfRandomObjects = 30;
    private Vector3 pos;
    private Vector3 worldSize;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        //can be placed anywhere on the terrain
        worldSize = Terrain.activeTerrain.terrainData.size;
        rotation = new Quaternion();

        for(int i = 0; i < numberOfRandomObjects; i++)
        {
            //x and z are random, y is based on terrain height
            float randomX = Random.Range(0f, worldSize.x);
            float randomZ = Random.Range(0f, worldSize.z);

            float heightY = Terrain.activeTerrain.SampleHeight(new Vector3(randomX, 0, randomZ));

            pos = new Vector3(randomX, heightY, randomZ);

            Instantiate(myPrefab, pos, rotation);
        }
    }
}
