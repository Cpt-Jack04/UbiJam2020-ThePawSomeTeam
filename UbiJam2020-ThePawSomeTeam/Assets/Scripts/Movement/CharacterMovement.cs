using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;

    [SerializeField] private float moveDistPerSec = 10f;
    private bool lastMovedLeft = false;

    public GameObject animationObject;
    private Animator animator;

    public bool CanMove { get; set; } = true;
    public bool CanJump { get; set; } = true;
    public bool IsLanded { get; private set; } = true;

    private void Awake()
    {
        if (animationObject)
        {
            animator = animationObject.GetComponent<Animator>();
        }
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    public void MoveHorizontally(float direction)
    {
        if (animator)
        {
            animator.SetFloat("movement", Mathf.Abs(direction));
        }
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