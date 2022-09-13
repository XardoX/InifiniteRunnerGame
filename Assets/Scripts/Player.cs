using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpPower = 100f;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    bool isGrounded;
    [SerializeField]
    float moveInput;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update() {
        //transform.position += transform.forward * Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += -transform.right;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += transform.right;
        }
    }
    void FixedUpdate()
    {
        //Vector3 newVelocity = Vector3.forward * moveSpeed;
        //newVelocity.x = rb.velocity.x;
        //newVelocity.y = rb.velocity.y;
        //rb.velocity = newVelocity;

        //rb.MovePosition(transform.position + Vector3.forward * moveSpeed);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        }


    }

    private void OnCollisionEnter(Collision other) {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision other) {
        isGrounded = false;
    }
}

public enum RunningLine
{
    Left,
    Middle,
    Right
}
