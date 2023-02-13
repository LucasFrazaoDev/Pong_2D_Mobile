using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    private void OnCollisionEnter2D(Collision2D target)
    {
        Ball ball = target.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 normal = target.GetContact(0).normal;
            ball.AddForce(-normal * this.bounceStrength);
        }
    }
}
