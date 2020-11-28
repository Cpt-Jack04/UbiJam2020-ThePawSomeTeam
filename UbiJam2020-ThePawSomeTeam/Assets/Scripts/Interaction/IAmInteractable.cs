public interface IAmInteractable
{
    bool IsBeingInteractedWith { get; }

    void ShowPrompt(bool shouldShow);

    void BeginInteraction();
    void EndInteraction();
}