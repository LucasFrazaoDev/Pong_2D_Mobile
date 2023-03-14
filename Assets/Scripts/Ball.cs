using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 50f;
    private Rigidbody2D _rigibody;

    [SerializeField] private AudioManager _audioManager;

    private void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetPosition();
        Invoke("AddStartForce", 1f);
    }

    public void AddStartForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigibody.AddForce(direction * speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigibody.AddForce(force);
    }

    public void ResetPosition()
    {
        _rigibody.position = Vector3.zero;
        _rigibody.velocity = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        switch(target.gameObject.tag)
        {
            case "Wall":
            _audioManager.PlaySound(_audioManager.WallSFX);
            break;
            case "Paddle":
            _audioManager.PlaySound(_audioManager.PaddleSFX);
            break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreZone"))
            _audioManager.PlaySound(_audioManager.ScoreSFX);
    }
}
