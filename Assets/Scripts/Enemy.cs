using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform ballPosition;
    private float _awareness = 1.8f;
    private float _hitPointRange = 0.25f;
    private float _yLength;

    double _minHitPointBottom, _minHitPointTop;
    void Start()
    {
        ballPosition = GameObject.Find("Ball").transform;
        _yLength = GetComponent<Collider2D>().bounds.size.y;
    }

    void Update()
    {
        CalculateMovement();


    }
    private void FixedUpdate()
    {

    }

    private void CalculateMovement()
    {
        float _enemyToBallDot = Vector3.Dot(transform.position.normalized, ballPosition.position.normalized);

        if (_enemyToBallDot + _awareness >= 1)
        {
            _minHitPointBottom = transform.position.y - (_yLength * _hitPointRange);
            _minHitPointTop = transform.position.y + (_yLength * _hitPointRange);
            if (ballPosition.position.y > _minHitPointTop && transform.position.y < 4.4f)
            {
                transform.Translate(4f * Time.deltaTime * new Vector3(1, 0, 0));

            }
            else if (ballPosition.position.y < _minHitPointBottom && transform.position.y > -4.4f)
            {
                transform.Translate(4f * Time.deltaTime * new Vector3(-1, 0, 0));
            }
        }

    }

}
