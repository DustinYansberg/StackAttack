using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFromBlockTest : MonoBehaviour
{
    private Rigidbody2D rb;
    public Sprite[] blockSprites;
    public bool spawnAvail = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UpZone"))
        {
            rb.isKinematic = true;
            transform.Translate(Vector3.up * .5f * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UpZone"))
        {
            transform.Translate(Vector3.up * .5f * Time.deltaTime);
            rb.isKinematic = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("UpZone"))
        {
            rb.isKinematic = false;
        }

        if (other.gameObject.CompareTag("Spawner"))
        {
            //Debug.Log("departed spawner");
            //Debug.Log(transform.position);
            Debug.Log(blockSprites);
            spawnAvail = true;
            Vector3 spawnPosition = transform.position - new Vector3(0, 1, 0);
            Sprite sprite = blockSprites[Random.Range(0, blockSprites.Length)];
            GameObject block = new GameObject("Block");
            block.transform.position = spawnPosition;
            block.AddComponent<SpriteRenderer>().sprite = sprite;
            block.GetComponent<SpriteRenderer>().sortingOrder = 2;
            block.AddComponent<BoxCollider2D>();
            block.AddComponent<SpawnFromBlockTest>();
            block.tag = "Blocks";
        }
    }


}
