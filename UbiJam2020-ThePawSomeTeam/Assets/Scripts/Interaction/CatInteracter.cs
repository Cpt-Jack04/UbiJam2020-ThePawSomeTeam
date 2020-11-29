using UnityEngine;

public class CatInteracter : MonoBehaviour, ICanInteract
{
    private CharacterMovement movement = null;
    private GameObject avaliableTarget = null;
    private IAmInteractable targetInteractable = null;

    public bool IsInteracting { get; private set; } = false;

    private void Awake()
    {
        movement = GetComponentInParent<CharacterMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IAmInteractable>() != null)
        {
            avaliableTarget = collision.gameObject;
            targetInteractable = collision.GetComponent<IAmInteractable>();
            targetInteractable.ShowPrompt(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<IAmInteractable>() == targetInteractable)
        {
            targetInteractable.ShowPrompt(false);
            avaliableTarget = null;
            targetInteractable = null;
        }
    }

    public void StartInteracting()
    {
        if (targetInteractable == null || targetInteractable.IsBeingInteractedWith)
            return;

        IsInteracting = true;
        movement.CanMove = false;
        targetInteractable.BeginInteraction();
    }

    public void ChoiceMade()
    {
        if (avaliableTarget.GetComponent<HumanInteractee>() != null)
            avaliableTarget.GetComponent<HumanInteractee>().SetMood(HumanInteractee.Mood.Happy);
    }

    public void StopInteracting()
    {
        if (avaliableTarget == null)
            return;

        targetInteractable.EndInteraction();
        IsInteracting = false;
        movement.CanMove = true;
    }
}
