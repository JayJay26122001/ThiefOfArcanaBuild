using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int rotateSpeed = 1;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider item)
    {
        if (item.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
