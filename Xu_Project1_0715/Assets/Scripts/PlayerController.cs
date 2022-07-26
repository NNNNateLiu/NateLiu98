using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    
    private bool isVerticalMoving;
    private void Update()
    {
        Vector3 temp = gameObject.transform.position;
        
        if (Input.GetKey(KeyCode.W))
        {
            //player move
            temp.y += speed;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            //player move
            temp.y -= speed;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        if (Input.GetKey(KeyCode.A) && !isVerticalMoving)
        {
            //player move
            temp.x -= speed;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        
        if (Input.GetKey(KeyCode.D) && !isVerticalMoving)
        {
            //player move
            temp.x += speed;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            isVerticalMoving = true;
        }
        else
        {
            isVerticalMoving = false;
        }
        gameObject.transform.position = temp;
    }
}
