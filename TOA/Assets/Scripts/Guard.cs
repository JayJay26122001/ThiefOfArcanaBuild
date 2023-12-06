using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    private bool isMovingRight = false;
    public float horizontalSpeed;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (isMovingRight)
        {
            transform.position += new Vector3(horizontalSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(-horizontalSpeed, 0, 0) * Time.deltaTime;
        }

        if (transform.position.x < -4f && !isMovingRight)
        {
            isMovingRight = true;
        }
        else if (transform.position.x > 4f && isMovingRight)
        {
            isMovingRight = false;
        }

    }
}
