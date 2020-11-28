using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class StandardInputReader : MonoBehaviour
{
    private CharacterMovement movement = null;
    private CatMusicBox musicBox = null;
    private ICanInteract interacter = null;

    private float horizontalMovementInput = 0f;
    private float audioInput = 0f;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        musicBox = GetComponent<CatMusicBox>();
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

    public void ReadAudioInput1(CallbackContext context)
    {
        if (context.performed)
        {
            musicBox.playSound(0);
        }      
    }

    public void ReadAudioInput2(CallbackContext context)
    {
        if (context.performed)
        {
            musicBox.playSound(1);
        }
    }

    public void ReadAudioInput3(CallbackContext context)
    {
        if (context.performed)
        {
            musicBox.playSound(2);
        }

    }

    public void ReadAudioInput4(CallbackContext context)
    {
        if (context.performed)
        {
            musicBox.playSound(3);
        }
    }
    public void ReadAudioInput5(CallbackContext context)
    {
        if (context.performed)
        {
            musicBox.playSound(4);
        }
    }

    public void ReadAudioInput6(CallbackContext context)
    {
        if (context.performed)
        {
            musicBox.playSound(5);
        }
    }

    public void ReadAudioInput7(CallbackContext context)
    {
        if (context.performed)
        {
            musicBox.playSound(6);
        }
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