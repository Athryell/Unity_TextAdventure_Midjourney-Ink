using UnityEngine;
using Ink.Runtime;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    //public TextAsset inkJSON;
    private Story story;

    public bool IsTalking { get; private set; }

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && story != null)
        {
            ShowStory();
        }
    }

    public void SetSceneDialogue(TextAsset inkJSON)
    {
        story = new Story(inkJSON.text);
        ShowStory();
    }

    private void ShowStory() // Will become coroutine not in update, while story.canContinue
    {
        if (story.canContinue)
        {
            if (!IsTalking)
            {
                UIManager.Instance.ClearUI();
            }

            IsTalking = true;

            string text = story.Continue();

            foreach (var t in story.currentTags)
            {
                print(t); //TODO: for now
            }

            if (story.currentTags.Contains("action"))
            {
                UIManager.Instance.ShowActionText(text);
            } else
            {
                UIManager.Instance.ShowPanelText(text);
            }
        }
        else
        {
            SetChoices();
        }
    }

    private void SetChoices()
    {
        if (story.currentChoices != null)
        {
            foreach (Choice choice in story.currentChoices)
            {
                UIManager.Instance.ShowChoices(choice.text, choice.index);
            }
        } else
        {
            IsTalking = false;
        }
    }

    public void ChooseChoice(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);

        print("Index: " + choiceIndex);

        UIManager.Instance.ClearUI();

        ShowStory();
    }
}
