using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    public Sprite[] blockSprites;
    private bool spawnAvail = true;
    public int numberOfBlocks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnAvail)
        {

            
            //Debug.Log("Spawn is available");
            Vector3 spawnPosition = transform.position;
            //Debug.Log(spawnPosition);
            Sprite sprite = blockSprites[Random.Range(0, blockSprites.Length)];
            GameObject block = new GameObject("Block");
            block.transform.position = transform.position;
            block.AddComponent<SpriteRenderer>().sprite = sprite;
            block.GetComponent<SpriteRenderer>().sortingOrder = 2;
            block.AddComponent<BoxCollider2D>();
            block.AddComponent<MoveTest>();
            block.tag = "Blocks";

            Rigidbody2D rb = block.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.rotation = 0;
            rb.freezeRotation = true;
            spawnAvail = false;



        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            spawnAvail = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blocks"))
        {
            spawnAvail = true;
        }
    }
}
