using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;    
    public float jumpForce = 10f;  
    public Transform groundCheck;  
    public LayerMask groundLayer;  

    private Rigidbody2D rb;        
    private bool isGrounded;       
    private float groundCheckRadius = 0.2f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInputX = Input.GetAxis("Horizontal"); 
        float moveInputY = Input.GetAxis("Vertical");   

        Vector2 moveVelocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed); 
        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y); 

        
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); 
        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
        }
    }
}