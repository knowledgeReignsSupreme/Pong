using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");

        // we flipped the object 90 degrees because its natural shape is horizontal
        transform.Translate(_speed * Time.deltaTime * new Vector3(verticalInput, 0, 0));

        if (transform.position.y >= 4.4f)
        {
            transform.position = new Vector3(transform.position.x, 4.4f, 0);
        }
        else if (transform.position.y <= -4.4f)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, 0);
        }

    }
}
