using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5.0f;
    private Vector2 _playerMovementInput;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MovePlayer();
        HandleAnimation();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(_playerMovementInput.x, _playerMovementInput.y, 0);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }


    void OnMove(InputValue iv)
    {
        _playerMovementInput = iv.Get<Vector2>();
    }

    void OnAttack(InputValue iv)
    {
        animator.SetTrigger("isAttacking");
    }

    void HandleAnimation()
    {
        if (_playerMovementInput.x != 0 || _playerMovementInput.y != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (_playerMovementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (_playerMovementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
