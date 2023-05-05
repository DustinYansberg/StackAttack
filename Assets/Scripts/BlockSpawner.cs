using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Sprite[] blockSprites;
    public int numberOfBlocks;
    public float spawnInterval;
    

    void Start()
    {
        InvokeRepeating("SpawnBlocks", 0f, spawnInterval);
    }

    void SpawnBlocks()
    {
        GameObject floorObject = GameObject.FindWithTag("Floor");
        for (int i = 0; i < numberOfBlocks; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(i, 0, 0);
            Sprite sprite = blockSprites[Random.Range(0, blockSprites.Length)];
            GameObject block = new GameObject("Block");
            block.transform.position = spawnPosition;
            block.AddComponent<SpriteRenderer>().sprite = sprite;
            block.GetComponent<SpriteRenderer>().sortingOrder = 2;
            block.AddComponent<BoxCollider2D>();
            block.AddComponent<Block>();
            //block.layer = 0;
            Rigidbody2D rb = block.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0.5f;
            rb.rotation = 0;
            rb.freezeRotation = true;
            //Block blockScript = block.AddComponent<Block>();
            //blockScript.Init(floorObject);
        }
    }

}

