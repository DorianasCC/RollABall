using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, jumpForce, 0.0f);

        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 20)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

        GetComponent < Rigidbody >().AddForce( Physics.gravity, ForceMode.Acceleration);

        // if (Input.GetKeyDown(KeyCode.Space) && Mathf.Approximately(rb.velocity.y, 0.0f))
        // {
        //     rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Approximately(rb.velocity.y, 0.0f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}

// public class TransformJump : MonoBehaviour
// {
//     public GroundCheck groundCheck;
//     public float jumpForce = 20;
//     public float gravity = -9.81f;
//     public float gravityScale = 5;
//     float velocity;

//     void Update()
//     {
//         velocity += gravity * gravityScale * Time.deltaTime;
//         if (groundCheck.isGrounded && velocity < 0)
//         {
//             velocity = 0;
//         }
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             velocity = jumpForce;
//         }
//         transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
//     }
// }

// public class GroundCheck : MonoBehaviour
// {
//     public float distanceToCheck = 0.5f;
//     public bool isGrounded;
//     public float offset = 0.2f;
//     private void Update()
//     {
//         if (Physics.Raycast(transform.position, Vector3.down, distanceToCheck))
//         {
//             isGrounded = true;
//         }
//         else
//         {
//             isGrounded = false;
//         }
//     }
// }