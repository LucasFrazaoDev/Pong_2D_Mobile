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

            if (touch.phase == TouchPhase.Began)
            {
                _direction = Vector2.zero;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Converte o deslocamento do toque para uma direção de movimento
                Vector2 touchDeltaPosition = touch.deltaPosition;
                _direction = new Vector2(touchDeltaPosition.x, touchDeltaPosition.y).normalized;
            }
            else if (touch.phase == TouchPhase.Canceled ||touch.phase == TouchPhase.Ended)
            {
                _direction = Vector2.zero;
            }
        }
        else
        {
            _direction = Vector2.zero;
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
