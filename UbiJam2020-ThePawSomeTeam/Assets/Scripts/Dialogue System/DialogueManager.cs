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
        Doublsb.Dialog.DialogData dialog = new Doublsb.Dialog.DialogData(currentConversation.ConverstationStarter, currentConversation.With.ToString());
        for (int index = 0; index < currentConversation.PlayerChoices.Count; index++)
        {
            dialog.SelectList.Add(index.ToString(), currentConversation.PlayerChoices[index].ChoiceText);
        }
        dialog.Callback = () =>
        {
            string responseText = currentConversation.GetResponseToChoice(int.Parse(dialogueDisplay.Result));
            Doublsb.Dialog.DialogData response = new Doublsb.Dialog.DialogData(responseText, currentConversation.With.ToString());

            dialogueDisplay.Show(new List<Doublsb.Dialog.DialogData>() { response });   

            playerInteracter.ChoiceMade();
        };

        dialogueDisplay.gameObject.SetActive(true);
        dialogueDisplay.Show(new List<Doublsb.Dialog.DialogData>() { dialog });
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