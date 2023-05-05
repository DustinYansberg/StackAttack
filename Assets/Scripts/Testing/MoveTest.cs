using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool spawnAvail;
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

        if (collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("Destroyer touched");
            Destroy(gameObject);
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
    }
}
