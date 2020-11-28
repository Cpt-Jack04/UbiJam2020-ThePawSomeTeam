using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb = null;

    [SerializeField] private float moveDistPerSec = 10f;

    [Space]

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask isGround = 0;

    public bool CanMove { get; set; } = true;
    public bool CanJump { get; set; } = true;
    public bool IsLanded { get; private set; } = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveHorizontally(float direction)
    {
        if (CanMove)
        {
            Vector2 targetPos = transform.position + Vector3.right * moveDistPerSec * direction * Time.deltaTime;

            rb.MovePosition(targetPos);
        }
    }
/*
    public void Jump()
    {
        if (CanJump)
        {
            rb.AddForce(Vector2.up);

            CanJump = false;
            IsLanded = false;
        }
    }*/
}