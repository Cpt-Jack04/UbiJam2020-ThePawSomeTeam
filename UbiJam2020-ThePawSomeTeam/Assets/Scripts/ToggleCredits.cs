using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleCredits : MonoBehaviour
{
    [SerializeField] private Conversation lastConvo = null;

    private Canvas canvas = null;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    private void OnEnable()
    {
        lastConvo.ChoicePoints[lastConvo.ChoicePoints.Count - 1].Choices[0].ChoiceMade.AddListener(() => FlipEnabaled());
    }

    private void OnDisable()
    {
        lastConvo.ChoicePoints[lastConvo.ChoicePoints.Count - 1].Choices[0].ChoiceMade.RemoveListener(() => FlipEnabaled());
    }

    public void FlipEnabaled()
    {
        canvas.enabled = !canvas.enabled;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}