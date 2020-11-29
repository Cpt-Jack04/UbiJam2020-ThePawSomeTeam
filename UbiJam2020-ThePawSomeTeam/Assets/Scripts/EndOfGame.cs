using System;

public class EndOfGame
{
    public static Action Reached = delegate { };

    public static void Invoke()
    {
        Reached?.Invoke();
    }
}