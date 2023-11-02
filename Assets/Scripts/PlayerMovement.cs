using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator anim;

    private SpriteRenderer spriteRenderer;
    private Vector2 moveDirection;
    private Vector2 tumbleDirection;
    private PlayerManager playerManager;
    private bool tumble;
    private float tumbleTime;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerManager = GetComponent<PlayerManager>();
    }
    private void Update()
    {
        if (!tumble) ProcessInput();
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
            tumble = Random.Range(playerManager.drunkLevel*100, 200) > Random.Range(0, 200)*40;
            if (tumble)
            {
                SetTumbleDirection();
                tumbleTime = playerManager.drunkLevel * 2f;
            }
            if (playerManager.currentHealth>0) Move();
        }

    }

    private void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        if (Vector2.Equals(moveDirection, Vector2.zero))
        {
            anim.SetBool("isMoving", false);
        }
    }
    private void Move()
    {
        anim.SetBool("isMoving", true);
        if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDirection.x < 0) { 
            spriteRenderer.flipX = true; 
        }
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
        rb.velocity = new Vector2(tumbleDirection.x * playerManager.drunkLevel*0.5f, tumbleDirection.y * playerManager.drunkLevel * 0.5f);
    }
}
