using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void BackToMainMenu()
    {
        Destroy(StatisticsManager.Instance.gameObject);
        Destroy(InventoryManager.Instance.gameObject);
        SceneManager.LoadScene("MainMenu");
    }
    public void RestarGame()
    {
        Destroy(StatisticsManager.Instance.gameObject);
        Destroy(InventoryManager.Instance.gameObject);
        SceneManager.LoadScene("ShoppingCenter");
    }

}
