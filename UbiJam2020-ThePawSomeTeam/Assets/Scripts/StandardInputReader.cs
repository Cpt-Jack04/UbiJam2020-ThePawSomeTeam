using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class StandardInputReader : MonoBehaviour
{
    private CharacterMovement movement = null;

    private float horizontalMovementInput = 0f;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }

    public void Update()
    {
        movement.MoveHorizontally(horizontalMovementInput);
    }

    public void ReadHorizontalMovement(CallbackContext context)
    {
        horizontalMovementInput = context.ReadValue<float>();
    }
}