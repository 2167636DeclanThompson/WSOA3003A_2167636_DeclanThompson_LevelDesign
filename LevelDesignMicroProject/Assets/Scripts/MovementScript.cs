using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public float Lives = 3f;
    public float Speed;
    public Rigidbody2D rigidBody;
    public KeyCode Shoot;    
    public float JumpSpeed;
    public float horizontalMovement = 20f;
    public bool onPlatform;
    public LayerMask groundLayer;
    public LayerMask platformLayer;
    public bool onGround;
    public float CollisionRadius;
    public Vector2 groundOffset;
    public Color gizmoColor = Color.red;
    public bool FacingRight;
    public bool FacingLeft;
    public bool FacingUp;
    public GameObject bullet;
    public Vector2 bulletPosition;
    public float FireRate = 0.5f;    
    public BulletScript bulletScript;
    public GameManager gameManager;
    public Text Life;

    private void Start()
    {
        Life.text = Lives.ToString();
    }

    public void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + groundOffset, CollisionRadius, groundLayer);
        onPlatform = Physics2D.OverlapCircle((Vector2)transform.position + groundOffset, CollisionRadius, platformLayer);

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y);
        Move(direction);

        if (Input.GetButton("Jump"))
        {
            if (onGround == true || onPlatform == true)
            {
                rigidBody.AddForce(new Vector2(0, JumpSpeed));
            }
            else
            {

            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            FacingRight = false;
            FacingLeft = true;
            FacingUp = false;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            FacingRight = true;
            FacingLeft = false;
            FacingUp = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            FacingRight = false;
            FacingLeft = false;
            FacingUp = true;
        }

        if (Lives <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + groundOffset, CollisionRadius);
        
    }

    public void Move(Vector2 dir)
    {
        rigidBody.velocity = new Vector2(dir.x * Speed, rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            transform.position = gameManager.lastCheckpoint;
            Lives = Lives - 1;
            Life.text = Lives.ToString();
        }

        if (collider.gameObject.name == "MovingPlatform")
        {
            onPlatform = true;
            this.transform.parent = collider.transform;
        }

        if (collider.gameObject.tag == "OneWayPlatform")
        {
            onPlatform = true;
        }


    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.name == "MovingPlatform")
        {
            onPlatform = false;
            this.transform.parent = null;
        }

        if (collider.gameObject.tag == "OneWayPlatform")
        {
            onPlatform = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Death")
        {
            transform.position = gameManager.lastCheckpoint;
            Lives = Lives - 1;
            Life.text = Lives.ToString();
        }
    }

    void Fire()
    {
        if (FacingRight == true)
        {
            bulletPosition = transform.position;
            bulletPosition += new Vector2(+1f, 0f);
            bulletScript.xVelocity = 6f;
            bulletScript.yVelocity = 0f;
            Instantiate(bullet, bulletPosition, Quaternion.identity);
        }
        else if (FacingLeft == true)
        {
            bulletPosition = transform.position;
            bulletPosition += new Vector2(-1f, 0f);
            bulletScript.xVelocity = -6f;
            bulletScript.yVelocity = 0f;
            Instantiate(bullet, bulletPosition, Quaternion.identity);
        }    
        
        if (FacingUp == true)
        {
            bulletPosition = transform.position;
            bulletPosition += new Vector2(0f, +1f);
            bulletScript.xVelocity = 0f;
            bulletScript.yVelocity = 6f;
            Instantiate(bullet, bulletPosition, Quaternion.identity);
        }
        

    }
}
