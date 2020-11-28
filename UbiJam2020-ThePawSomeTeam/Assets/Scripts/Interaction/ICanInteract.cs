public interface ICanInteract
{
    bool IsInteracting { get; }

    void StartInteracting();
    void StopInteracting();
}