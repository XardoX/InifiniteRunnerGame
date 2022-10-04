using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    [SerializeField]
    float lerpDuration = 0.1f;

    [SerializeField]
    float distance;

    Vector3 newPosition, lerpStartPos;
    float lerpTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update() {
        //transform.position += transform.forward * Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lerpStartPos = transform.position;
            newPosition = transform.position + (-Vector3.right * distance);
            lerpTime = 0f;
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lerpStartPos = transform.position;
            newPosition = transform.position + (Vector3.right * distance);
            lerpTime = 0f;
        }


        if(lerpTime >= lerpDuration)
        {
        } else{
            lerpTime += Time.deltaTime;
        }


        transform.position = new Vector3( Vector3.Lerp(lerpStartPos, newPosition, lerpTime).x, transform.position.y, transform.position.x);

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
