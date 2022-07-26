using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_test : MonoBehaviour
{
    public static PlayerController_test instance;
    
    private float currentSpeed;
    public float maxSpeedLimit;
    public Animator animator;

    private bool isVerticalMoving;
    Rigidbody2D rb2D;
    
    public bool isInConversation;

    public List<Transform> SceneEnterPoints;
    public List<Vector3> SceneEnterPointPositions;
    public int SceneEnterPointPositionTogoIndex;
        
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //循环 for while foreach
        
        for (int i = 0; i < SceneEnterPoints.Count; i++)
        {
            Debug.Log("i = " + i);
            SceneEnterPointPositions[i] = SceneEnterPoints[i].position;
        }
        
    }
    private void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1;
            animator.SetBool("isWalkingBack", true);
        }
        else
        {
            animator.SetBool("isWalkingBack", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.A) && !isVerticalMoving)
        {
            moveDirection.x = -1;
            animator.SetBool("isWalkingLeft", true);
        }
        else
        {
            animator.SetBool("isWalkingLeft", false);
        }

        if (Input.GetKey(KeyCode.D) && !isVerticalMoving)
        {
            moveDirection.x = 1;
            animator.SetBool("isWalingRight", true);
        }
        else
        {
            animator.SetBool("isWalingRight", false);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            isVerticalMoving = true;
        }
        else
        {
            isVerticalMoving = false;
        }

        //如果玩家处于对话状态，则speed为0；反之则为默认值
        if (isInConversation)
        {
            currentSpeed = 0;
            animator.enabled = false;
        }
        else
        {
            currentSpeed = maxSpeedLimit;
            animator.enabled = true;
        }
        rb2D.velocity = moveDirection * currentSpeed;
    }

    //delegate 代理
    //int, float, bool, string
    //function
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        //do stuff
        Debug.Log("transfer to right position");
        gameObject.transform.position = SceneEnterPointPositions[SceneEnterPointPositionTogoIndex];
        //使用IF判断，条件分别是 从哪来 和 到哪去
    }
    
}
