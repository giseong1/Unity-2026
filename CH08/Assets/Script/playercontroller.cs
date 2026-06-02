using System.Runtime;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    Rigidbody rb;
    Animator anim;

    Vector3 moveDriection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))


        moveDriection = new Vector3(xInput, 0, zInput);

        if(moveDriection.magnitude > 0.1f)
        {
            moveDriection.Normalize();
            anim.SetBool("IsWalking", true);

            //transform.forward = moveDriection; // /Rotation
            rb.MovePosition(rb.position + 
                moveDriection * moveSpeed * Time.deltaTime);
            
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
