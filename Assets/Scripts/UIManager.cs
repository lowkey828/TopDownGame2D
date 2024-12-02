using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI coinEatenCount;
    public TextMeshProUGUI enemyKillCount;
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject menuPanel;
    public AudioSource audioSource;

    private int coinsEaten = 0;
    private int enemyKill = 0;

    private void Start()
    {
        menuPanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        Time.timeScale = 0f;

        UpdateUI();

        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    private void UpdateUI()
    {
        coinEatenCount.text = "Coin: " + coinsEaten.ToString();
        enemyKillCount.text = "Enemy: " + enemyKill.ToString();
    }

    public void EatCoin()
    {
        coinsEaten++;
        UpdateUI();
    }

        public void UpdateEnemyKill()
    {
        enemyKill++;
        UpdateUI();

        if (enemyKill == 2)
        {
            ShowWinScreen();
        }
    }

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowLoseScreen()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;

        audioSource.Play();
    }
}
