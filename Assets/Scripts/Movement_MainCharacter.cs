using UnityEngine;

public class Movement_MainCharacter : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed;
    Vector2 movement;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetTrigger("isAttacking");

        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(movement.x, movement.y, 0) * moveSpeed * Time.deltaTime;
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);

        }
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;

        }

    }
}
