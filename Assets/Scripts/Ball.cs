using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private UIManager _uiManager;
    private int _playerScore;
    private int _enemyScore;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    void Start()
    {

        OnRoundStart();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rb.AddForce(-other.contacts[0].normal +
    new Vector2(Random.Range(-1, 12), Random.Range(-1, 8)));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnRoundEnded(other.gameObject.tag);
    }

    private void OnRoundEnded(string goalTag) {
        OnRoundStart();
       _uiManager.OnGoalConceieved(goalTag);
    }


    private void OnRoundStart()
    {
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = Vector3.zero;
        StartCoroutine(KickstartGame());
    }

    private IEnumerator KickstartGame()
    {
        yield return new WaitForSeconds(1f);
        Vector3 randomDirection = GetRandomDirection();
        rb.AddForce(randomDirection * 120f);
    }
    private Vector3 GetRandomDirection()
    {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 1)
        {
            return transform.right;
        }
        else
        {
            return -transform.right;
        }
    }
}
