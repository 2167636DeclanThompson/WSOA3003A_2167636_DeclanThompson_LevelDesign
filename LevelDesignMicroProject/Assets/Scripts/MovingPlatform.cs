using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float Speed;
    public bool movingRight = true;
    public bool movingUp = true;
    public bool movingX;

    private void Update()
    {
        if (movingX == true)
        {
            if (movingRight == true)
            {
                transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
            }
            else if (movingRight == false)
            {
                transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
            }
        }
        else if (movingX == false)
        {
            if (movingUp == true)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Speed * Time.deltaTime);
            }
            else if (movingRight == false)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (movingX == true)
        {
            if (collider.gameObject.tag == "Waypoint" && movingRight == false)
            {
                movingRight = true;
            }
            else if (collider.gameObject.tag == "Waypoint" && movingRight == true)
            {
                movingRight = false;
            }
        }
        else if (movingX == false)
        {
            if (collider.gameObject.tag == "Waypoint" && movingUp == false)
            {
                movingUp = true;
            }
            else if (collider.gameObject.tag == "Waypoint" && movingUp == true)
            {
                movingUp = false;
            }
        }



    }
}

