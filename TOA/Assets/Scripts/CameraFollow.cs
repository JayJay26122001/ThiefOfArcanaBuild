using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Fara a Camera seguir o Player

    public Transform targetObject;
    public Vector3 cameraOffset;
    void Start()
    {
        cameraOffset = transform.position - targetObject.position;
    }
    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, cameraOffset.z + targetObject.position.z);
        transform.position = newPosition;
    }
}
