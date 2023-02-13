using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 50f;
    private Rigidbody2D _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddStartForce();
    }

    private void AddStartForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigibody.AddForce(direction * this.speed);
    }
}
