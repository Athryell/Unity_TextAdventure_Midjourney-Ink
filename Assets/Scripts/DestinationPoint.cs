using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DestinationPoint : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public enum GoToScene
    {
        Main_Scene,
        Volcano_Scene,
        Volcano_NPC,
        Lake_Scene,
        Lake_NPC,
        Castle_Scene,
        Castle_NPC,
        Forest_Scene,
        Forest_Hut,
        Forest_NPC
    }


    //[SerializeField] private float growSpeed = 0.2f;
    [SerializeField] private GoToScene goToScene;

    [Header("Properties")]
    [SerializeField] private Vector3 growSize = new(1.1f, 1.1f, 0);

    private Vector3 initialSize;
    private Outline outlineAlpha;

    private void Start()
    {
        initialSize = gameObject.transform.localScale;
        GetComponent<Image>().alphaHitTestMinimumThreshold = 1f;
        outlineAlpha = GetComponent<Outline>();
        outlineAlpha.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            outlineAlpha.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            outlineAlpha.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (StoryManager.Instance.IsTalking) return;

        transform.localScale = growSize;
        outlineAlpha.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (StoryManager.Instance.IsTalking) return;

        transform.localScale = initialSize;
        outlineAlpha.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (StoryManager.Instance.IsTalking) return;

        TravelManager.Instance.TravelTowards(goToScene);
    }

    public void ResetDestinationPointsSize() //TODO: DELEGATA che ascolta un evento dello story manager
    {
        return;
    }
}
