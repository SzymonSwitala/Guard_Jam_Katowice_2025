using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private void Start()
    {

        gameOverPanel.SetActive(false);
        StatisticsManager.Instance.OnAnyStatZero += ShowGameOver;
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
    private void OnDestroy()
    {
        if (StatisticsManager.Instance != null)
            StatisticsManager.Instance.OnAnyStatZero -= ShowGameOver;
    }
}
