using UnityEngine.SceneManagement;
using UnityEngine;

public class TravelManager : MonoBehaviour
{
    public static TravelManager Instance;

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    public void TravelTowards(DestinationPoint.GoToScene placeToGo)
    {
        SceneManager.LoadScene(placeToGo.ToString());
        print("Loading: " + placeToGo.ToString());
    }
}
