using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAIMove : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    
    public Animator guardAnimator;
    private Vector2 currentMovingDirection;

    // Start is called before the first frame update
    private void Start()
    {
        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        currentMovingDirection = (movePos.position - transform.position).normalized;

        if (currentMovingDirection.x == 0)
        {
            if (currentMovingDirection.y == 0)
            {
                guardAnimator.SetBool("isWalking",false);
                guardAnimator.SetBool("isWalkingBack",false);
                guardAnimator.SetBool("isWalkingLeft",false);
                guardAnimator.SetBool("isWalkingRight",false);
                Debug.Log("stand");
            }
            
            if (currentMovingDirection.y < 0)
            {
                guardAnimator.SetBool("isWalking",true);
                Debug.Log("walkingdown");
            }
            
            if(currentMovingDirection.y > 0)
            {
                guardAnimator.SetBool("isWalkingBack",true);
                Debug.Log("walkingup");
            }
        }
        else
        {
            if (currentMovingDirection.x < 0)
            {
                guardAnimator.SetBool("isWalkingLeft",true);
                Debug.Log("walkingleft");
            }
            else
            {
                guardAnimator.SetBool("isWalkingRight",true);
                Debug.Log("walkingright");
            }
        }

        if(Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if(waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
}
