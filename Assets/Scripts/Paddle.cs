using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    protected Rigidbody2D _rigibody;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }
}
