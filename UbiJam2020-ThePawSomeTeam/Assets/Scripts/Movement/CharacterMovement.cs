using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;

    [SerializeField] private float moveDistPerSec = 10f;
    private bool lastMovedLeft = false;

    public bool CanMove { get; set; } = true;
    public bool CanJump { get; set; } = true;
    public bool IsLanded { get; private set; } = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void MoveHorizontally(float direction)
    {
        if (CanMove)
        {
            Vector2 targetPos = transform.position + Vector3.right * moveDistPerSec * direction * Time.fixedDeltaTime;

            rb.MovePosition(targetPos);
            if ((direction == -1 && !lastMovedLeft) || (direction == 1 && lastMovedLeft))
                Flip();
        }
    }

    private void Flip()
    {
        lastMovedLeft = !lastMovedLeft;
        sr.flipX = lastMovedLeft;
    }
}