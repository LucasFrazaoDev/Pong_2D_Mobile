using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector2 _direction;

    private void Update()
    {
        // Verifica se o jogador está tocando ou deslizando na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                // Converte a posição do toque para uma direção de movimento
                Vector2 touchPosition = touch.position;
                float screenHalfHeight = Screen.height / 2f;
                if (touchPosition.y > screenHalfHeight)
                {
                    _direction = Vector2.up;
                }
                else if (touchPosition.y < screenHalfHeight)
                {
                    _direction = Vector2.down;
                }
                else
                {
                    _direction = Vector2.zero;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _direction = Vector2.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            _rigibody.AddForce(_direction * speed);
        }
    }
}
