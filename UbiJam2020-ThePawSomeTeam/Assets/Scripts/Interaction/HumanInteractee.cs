using UnityEngine;

public class HumanInteractee : MonoBehaviour, IAmInteractable
{
    [SerializeField] private Conversation conversation = null;

    [Space]

    [SerializeField] private Mood currentMood = Mood.Neutral;

    private Canvas interactionPrompt = null;

    public bool IsBeingInteractedWith { get; private set; } = false;

    private void Start()
    {
        interactionPrompt = GetComponentInChildren<Canvas>();
        ShowPrompt(false);

        conversation.Initialize();
    }

    public void ShowPrompt(bool shouldShow)
    {
        interactionPrompt.enabled = shouldShow;
    }

    public void BeginInteraction()
    {
        DialogueManager.Instance.SetNewConversation(conversation);
        IsBeingInteractedWith = true;
    }

    public void EndInteraction()
    {
        DialogueManager.Instance.HideDisplay();
        IsBeingInteractedWith = false;
    }

    public void SetMood(Mood newMood)
    {
        currentMood = newMood;
    }

    public enum Mood
    {
        Sad,
        Happy,
        Neutral,
        Blushing
    }
}