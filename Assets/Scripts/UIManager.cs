using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject mainPanel;
    public TMP_Text mainText;
    public GameObject actionPanel;
    public TMP_Text actionText;
    public List<Button> choices;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        ClearUI();
    }

    public void ClearUI()
    {
        mainPanel.SetActive(false);
        mainText.text = "";
        actionPanel.SetActive(false);
        actionText.text = "";

        HideChoiches();
    }

    public void ShowPanelText(string storyText) // TODO: Use String builder?
    {
        mainPanel.SetActive(true);
        mainText.text = storyText;
    }

    public void ShowActionText(string storyText)
    {
        actionPanel.SetActive(true);
        actionText.text = storyText;
    }

    private void HideChoiches()
    {
        foreach (Button choice in choices)
        {
            choice.GetComponentInChildren<TMP_Text>().text = "";
            choice.gameObject.SetActive(false);
        }
    }

    public void ShowChoices(string choiceText, int index)
    {
        foreach (Button choice in choices)
        {
            if (choice.gameObject.activeSelf == false)
            {
                choice.gameObject.SetActive(true);
                choice.GetComponentInChildren<TMP_Text>().text = choiceText;

                choice.onClick.RemoveAllListeners();
                choice.onClick.AddListener(delegate
                {
                    StoryManager.Instance.ChooseChoice(index);
                });
                return;

            } else
            {
                continue;
            }
        }

        // TODO: Add one more button to the list? Like pooling
        Debug.LogError("Not enaugh choice button to hold all the options!");
    }

}
