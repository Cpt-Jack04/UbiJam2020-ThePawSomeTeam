using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class StandardInputReader : MonoBehaviour
{
    private CharacterMovement movement = null;
    private ICanInteract interacter = null;

    private float horizontalMovementInput = 0f;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }

    private void Start()
    {
        interacter = GetComponentInChildren<ICanInteract>();
    }

    public void Update()
    {
        movement.MoveHorizontally(horizontalMovementInput);
    }

    public void ReadHorizontalMovement(CallbackContext context)
    {
        horizontalMovementInput = context.ReadValue<float>();
    }

    public void ReadInteraction(CallbackContext context)
    {
        if (context.performed)
        {
            if (!interacter.IsInteracting)
                interacter.StartInteracting();
            else
                interacter.StopInteracting();
        }
    }
}