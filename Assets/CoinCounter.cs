using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance { get; private set; }

    [SerializeField] private TMP_Text counterText;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private int targetCoins = 10;
    [SerializeField] private MonoBehaviour playerMovement;

    [SerializeField] private AudioSource hatterzene;
    [SerializeField] private AudioClip applauseClip;
    [SerializeField] private AudioClip failClip;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeLimit = 300f;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;


    private float timeLeft;
    private int collectedCoins = 0;
    private bool gameEnded = false;

    public GameObject losePanel;

    public void RestartGame()
    {
        Debug.Log("Újra gomb megnyomva");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitGame()
    {
        Debug.Log("Kilépés gomb megnyomva");
        Time.timeScale = 1f;
        Application.Quit();
    }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        timeLeft = timeLimit;

        if (endText != null)
            endText.gameObject.SetActive(false);

        UpdateCounter();
        UpdateTimerText();

        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
    }

    private void Update()
    {
        if (gameEnded)
            return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            UpdateTimerText();
            LoseGame();
            return;
        }

        UpdateTimerText();
    }

    public void AddCoin()
    {
        if (gameEnded)
            return;

        collectedCoins++;
        UpdateCounter();

        if (collectedCoins >= targetCoins)
            WinGame();
    }

    private void UpdateCounter()
    {
        if (counterText != null)
            counterText.text = $"Gyűjtött érmék: {collectedCoins}/{targetCoins}";
    }

    private void UpdateTimerText()
    {
        if (timerText == null)
            return;

        int totalSeconds = Mathf.CeilToInt(timeLeft);
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    private void WinGame()
    {
        if (gameEnded)
            return;

        gameEnded = true;

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;

            if (losePanel != null)
                losePanel.SetActive(true);       


        if (endText != null)
        {
            endText.text = $"Gratulálok! Összegyűjtöttél {targetCoins} érmét! A játéknak vége!";
            endText.gameObject.SetActive(true);
        }

        if (playerMovement != null)
            playerMovement.enabled = false;

        if (hatterzene != null)
        {
            hatterzene.Stop();

            if (applauseClip != null)
                hatterzene.PlayOneShot(applauseClip);
        }

        Time.timeScale = 0f;
    }

    private void LoseGame()
    {
        if (gameEnded)
            return;

        gameEnded = true;

        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;                 


        if (losePanel != null)
            losePanel.SetActive(true);

        if (endText != null)
        {
            endText.text = "Lejárt az idő!";
            endText.gameObject.SetActive(true);
        }

        if (playerMovement != null)
            playerMovement.enabled = false;

        if (hatterzene != null)
        {
            hatterzene.Stop();

            if (failClip != null)
                hatterzene.PlayOneShot(failClip);
        }

        Time.timeScale = 0f;
    }
}
