using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueStarter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextAsset inkJSON;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (StoryManager.Instance.IsTalking) return;

        StoryManager.Instance.SetSceneDialogue(inkJSON);
    }
}
