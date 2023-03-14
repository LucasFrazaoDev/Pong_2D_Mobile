using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{
    [SerializeField] private Rigidbody2D ball;

    private void FixedUpdate()
    {
        if (ball.velocity.x > 0)
        {
            if (ball.position.y > transform.position.y)
            {
                _rigibody.AddForce(Vector2.up * Speed);
            }
            else if (ball.position.y < transform.position.y)
            {
                _rigibody.AddForce(Vector2.down * Speed);
            }
        }
        else
        {
            if (transform.position.y > 0)
            {
                _rigibody.AddForce(Vector2.down * Speed);
            }
            else if (transform.position.y < 0)
            {
                _rigibody.AddForce(Vector2.up * Speed);
            }
        }
    }
}
