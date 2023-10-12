using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 tumbleDirection;
    private GameObject player;
    private PlayerManager playerManager;
    private bool tumble;
    private float tumbleTime;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerManager = (PlayerManager)player.GetComponent("PlayerManager");
    }
    private void Update()
    {
        ProcessInput(); 
    }
    private void FixedUpdate()
    {
        //print(tumble + " drunkLevel: " + playerManager.drunkLevel);
        if (tumble)
        {
            print("tumble: " + tumbleDirection);
            Tumble();
            tumbleTime--;
            if (tumbleTime <= 0)
            {
                tumble = false;
            }
        }
        else
        {
            tumble = Random.Range(playerManager.drunkLevel, 200) > Random.Range(0, 200)*25;
            if (tumble)
            {
                SetTumbleDirection();
                tumbleTime = playerManager.drunkLevel * 0.1f;
            }
            Move();
        }
    }

    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void SetTumbleDirection()
    {
        float tumbleX = Random.Range(-1f, 1f);
        float tumbleY = Random.Range(-1f, 1f);

        tumbleDirection = new Vector2(tumbleX, tumbleY).normalized;
    }
    private void Tumble()
    {
        rb.velocity = new Vector2(tumbleDirection.x * playerManager.drunkLevel * 0.005f, tumbleDirection.y * playerManager.drunkLevel * 0.005f);
    }
}
