using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }
    void Update()
    {
        if (Input.GetKeyDown("e")) {
            animator.SetBool("IsSliding", true);
            animator.SetBool("IsRunning", false);
            Debug.Log("Player slides!");
        }

        if (Input.GetKeyDown("r"))
        {
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsRunning", true);
            Debug.Log("Player has restarted running cycle!");
        }

        if (Input.GetKeyDown("d"))
        {
            animator.SetBool("IsJumpingOver", true);
            animator.SetBool("IsRunning", false);
            Debug.Log("Player jumps over!");
        }

        if (Input.GetKeyDown("f"))
        {
            animator.SetBool("IsJumpingOver", false);
            animator.SetBool("IsRunning", true);
            Debug.Log("Player has restarted running cycle!");
        }
    }
}
