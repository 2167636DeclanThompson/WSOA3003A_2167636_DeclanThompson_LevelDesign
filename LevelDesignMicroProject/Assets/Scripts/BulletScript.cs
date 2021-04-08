using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float xVelocity = 5f;
    public float yVelocity = 0f;
    public Rigidbody2D rigidBody;
    public MovementScript moveScript;   
    

    private void Update()
    {
        rigidBody.velocity = new Vector2(xVelocity, yVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {

        StartCoroutine(Destroy());


    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.1f);                
        Destroy(this.gameObject);
    }

}

