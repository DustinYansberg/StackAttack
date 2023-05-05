using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask blockLayerMask;
    public LayerMask groundLayer;
    private int speed = 1000;


    void Start()
    {
        //Debug.Log("Start happened");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    //void FixedUpdate()
    //{
    //    // TODO I am not sure if any of this works
    //    // Check if there's a block beneath the current block
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 100f, 0), 0.1f, blockLayerMask);
    //    bool isBlockBeneath = false;
    //    foreach (Collider2D collider in colliders)
    //    {
    //        if (collider.gameObject != gameObject)
    //        {
    //            isBlockBeneath = true;
    //            break;
    //        }
    //    }

    //    if (isBlockBeneath)
    //    {
    //        // Stop the block from falling
    //        rb.velocity = Vector3.zero;
    //        rb.isKinematic = true;
    //    }
    //    else
    //    {
    //        // Keep the block falling
    //        rb.isKinematic = false;
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Collision");
            // Stop the block from falling
            //rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }

        if (collision.gameObject.CompareTag("UpZone"))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            rb.isKinematic = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
