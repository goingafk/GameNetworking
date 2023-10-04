using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    Rigidbody _rigidbody;
    public float movementSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") ==0)
            return;
        
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var rotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, verticalInput));
        var transform1 = transform;
        transform1.rotation = rotation;

        Vector3 movementDir = transform1.forward * (Time.deltaTime * movementSpeed);
        _rigidbody.MovePosition(_rigidbody.position + movementDir);
    }
}
