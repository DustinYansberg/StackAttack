using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTest : MonoBehaviour
{
    public Transform targetObject;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialOffset = transform.position - targetObject.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraPosition = targetObject.position + initialOffset;
        transform.position = cameraPosition;
    }
}
