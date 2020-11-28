using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; } = null;

    private Doublsb.Dialog.DialogManager dialogueDisplay = null;
    private Conversation currentConversation = null;

    private CatInteracter playerInteracter = null;

    private bool atChoicePoint = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        dialogueDisplay = GetComponentInChildren<Doublsb.Dialog.DialogManager>(true);
        HideDisplay();

        playerInteracter = FindObjectOfType<PlayerInput>().GetComponentInChildren<CatInteracter>();

        DontDestroyOnLoad(gameObject);
    }

    public void SetNewConversation(Conversation newConversation)
    {
        currentConversation = newConversation;

        dialogueDisplay.gameObject.SetActive(true);
        dialogueDisplay.Show(new List<Doublsb.Dialog.DialogData>(BuildChoicePoint(currentConversation.CurrentPointIndex)));
    }

    public void ContinueConversation()
    {
        if (atChoicePoint)
            dialogueDisplay.Click_Window();
        else
        {
            currentConversation.MoveToNextChoicePoint();

            if (currentConversation.CurrentPointIndex > 0)
                dialogueDisplay.Show(new List<Doublsb.Dialog.DialogData>(BuildChoicePoint(currentConversation.CurrentPointIndex)));
            else
            {
                dialogueDisplay.Click_Window();
                DisplayClosed();
            }
        }
    }

    private Queue<Doublsb.Dialog.DialogData> BuildChoicePoint(int pointIndex)
    {
        atChoicePoint = true;

        Conversation.ChoicePoint pointToBuild = currentConversation.ChoicePoints[pointIndex];
        Queue<Doublsb.Dialog.DialogData> toReturn = new Queue<Doublsb.Dialog.DialogData>();

        for (int index = 0; index < pointToBuild.PointTexts.Count - 1; index++)
        {
            Doublsb.Dialog.DialogData point = new Doublsb.Dialog.DialogData(pointToBuild.PointTexts[index], currentConversation.With.ToString());
            toReturn.Enqueue(point);
        }

        Doublsb.Dialog.DialogData pointWithChoices = new Doublsb.Dialog.DialogData(pointToBuild.PointTexts[pointToBuild.PointTexts.Count - 1], currentConversation.With.ToString());
        for (int index = 0; index < pointToBuild.Choices.Count; index++)
        {
            pointWithChoices.SelectList.Add(index.ToString(), pointToBuild.Choices[index].ChoiceText);
        }
        pointWithChoices.Callback = () =>
        {
            int choiceIndex = int.Parse(dialogueDisplay.Result);

            string responseText = currentConversation.GetResponseToChoice(int.Parse(dialogueDisplay.Result));
            Doublsb.Dialog.DialogData response = new Doublsb.Dialog.DialogData(responseText, currentConversation.With.ToString());

            dialogueDisplay.Show(new List<Doublsb.Dialog.DialogData>() { response });

            pointToBuild.Choices[choiceIndex].ChoiceMade?.Invoke();

            atChoicePoint = false;
        };
        toReturn.Enqueue(pointWithChoices);

        return toReturn;
    }

    public void HideDisplay()
    {
        dialogueDisplay.gameObject.SetActive(false);
    }

    public void DisplayClosed()
    {
        playerInteracter.StopInteracting();
    }
}