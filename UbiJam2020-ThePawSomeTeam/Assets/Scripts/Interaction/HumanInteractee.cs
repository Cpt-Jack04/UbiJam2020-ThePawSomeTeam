using System.Collections.Generic;
using UnityEngine;

public class HumanInteractee : MonoBehaviour, IAmInteractable
{
    [SerializeField] private Conversation conversation = null;
    [SerializeField] private List<Conversation> conversations = new List<Conversation>();
    private int currentConversationIndex = 0;

    [Space]

    [SerializeField] private List<Conversation> continueAfterTheseConvos = new List<Conversation>();

    [Space]

    [SerializeField] private Mood currentMood = Mood.Neutral;

    private Canvas interactionPrompt = null;

    public bool IsBeingInteractedWith { get; private set; } = false;

    private void Awake()
    {
        conversation = conversations[0];
    }

    private void OnEnable()
    {
        Conversation.ConversationCompleted += (convoName) =>
        {
            foreach (Conversation convo in continueAfterTheseConvos)
            {
                if (convoName == convo.name)
                    SelectNextConversation();
            }
        };
    }

    private void Start()
    {
        interactionPrompt = GetComponentInChildren<Canvas>();
        ShowPrompt(false);

        conversation.Initialize();
    }

    private void OnDisable()
    {
        Conversation.ConversationCompleted += (convoName) =>
        {
            foreach (Conversation convo in continueAfterTheseConvos)
            {
                if (convoName == convo.name)
                    SelectNextConversation();
            }
        };
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

    public void SelectNextConversation()
    {
        currentConversationIndex++;

        if (currentConversationIndex >= conversations.Count)
            currentConversationIndex = conversations.Count - 1;

        conversation = conversations[currentConversationIndex];
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