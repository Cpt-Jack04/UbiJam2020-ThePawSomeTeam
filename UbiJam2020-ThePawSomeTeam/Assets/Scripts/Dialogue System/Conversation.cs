using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable, CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    
    [SerializeField] private Participant with = Participant.Damsel;

    [Space]

    [SerializeField] private List<ChoicePoint> choicePoints = new List<ChoicePoint>();

    public Participant With => with;
    public List<ChoicePoint> ChoicePoints => choicePoints;
    public ChoicePoint CurrentChoicePoint => choicePoints[CurrentPointIndex];
    public int CurrentPointIndex { get; private set; } = 0;

    public void Initialize()
    {
        CurrentPointIndex = 0;
    }

    public void MoveToNextChoicePoint()
    {
        CurrentPointIndex++;

        if (CurrentPointIndex >= choicePoints.Count)
            CurrentPointIndex = 0;
    }

    public string GetResponseToChoice(int choiceIndex)
    {
        if (choiceIndex >= 0 && choiceIndex < choicePoints[CurrentPointIndex].Choices.Count)
            return choicePoints[CurrentPointIndex].Choices[choiceIndex].ResponseText;

        return "";
    }

    public enum Participant
    {
        Damsel,
        Knight,
        OldWoman,
        PlagueCat,
    }

    [System.Serializable]
    public class PlayerChoice
    {
        [SerializeField, TextArea(1, 10)] private string choiceText = "";
        [SerializeField, TextArea(1, 10)] private string responseText = "";

        public string ChoiceText => choiceText;
        public string ResponseText => responseText;

        public UnityEvent ChoiceMade;
    }

    [System.Serializable]
    public class ChoicePoint
    {
        [SerializeField, TextArea(1, 10)] private List<string> pointTexts = new List<string>();
        [SerializeField] private List<PlayerChoice> choices = new List<PlayerChoice>();

        public List<string> PointTexts => pointTexts;
        public List<PlayerChoice> Choices => choices;
    }
}