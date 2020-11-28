using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    
    [SerializeField] private Participant with = Participant.Damsel;
    [SerializeField, TextArea(1, 10)] private string converstationStarter = "";

    [Space]

    [SerializeField] private List<PlayerChoice> playerChoices = new List<PlayerChoice>();

    public Participant With => with;
    public string ConverstationStarter => converstationStarter;
    public List<PlayerChoice> PlayerChoices => playerChoices;

    public string GetResponseToChoice(int choiceIndex)
    {
        if (choiceIndex >= 0 && choiceIndex < playerChoices.Count)
            return playerChoices[choiceIndex].ResponseText;

        return "";
    }

    public enum Participant
    {
        Damsel,
        Knight,
        OldWoman,
        Priest,
    }

    [System.Serializable]
    public class PlayerChoice
    {
        [SerializeField, TextArea(1, 10)] private string choiceText = "";
        [SerializeField, TextArea(1, 10)] private string responseText = "";

        public string ChoiceText => choiceText;
        public string ResponseText => responseText;
    }
}