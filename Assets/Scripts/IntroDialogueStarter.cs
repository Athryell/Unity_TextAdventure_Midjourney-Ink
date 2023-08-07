using UnityEngine;

public class IntroDialogueStarter : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;

    private void OnEnable()
    {
        StoryManager.Instance.SetSceneDialogue(inkJSON);
    }
}
