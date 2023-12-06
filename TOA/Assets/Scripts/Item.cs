using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int rotateSpeed = 1;
    public GameObject shine;

    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter(Collider item)
    {
        if (item.CompareTag("Player"))
        {
            Instantiate(shine, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
