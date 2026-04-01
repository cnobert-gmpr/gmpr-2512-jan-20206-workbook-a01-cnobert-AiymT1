using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject player;
    [SerializeField] private AlienFormation alienFormation;

    private bool gameStarted = false;
    private bool gameOver = false;
    private bool playerWon = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }

        if (gameStarted && !gameOver)
        {
            CheckWinCondition();
            CheckLoseCondition();
        }
    }

    private void StartGame()
    {
        gameStarted = true;
        gameOver = false;
        Time.timeScale = 1f;
        Debug.Log("Game Started");
    }

    private void CheckWinCondition()
    {
        if (alienFormation != null && alienFormation.AllAliensDead())
        {
            gameOver = true;
            playerWon = true;
            Time.timeScale = 0f;
            Debug.Log("You Win!");
        }
    }

    private void CheckLoseCondition()
    {
        if (player == null || !player.activeSelf)
        {
            gameOver = true;
            playerWon = false;
            Time.timeScale = 0f;
            Debug.Log("You Lose!");
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 30;
        style.alignment = TextAnchor.MiddleCenter;

        if (!gameStarted)
        {
            GUI.Label(new Rect(Screen.width / 2 - 200, 40, 400, 50), "Press Enter to Start", style);
        }
        else if (gameOver)
        {
            string message = playerWon ? "You Win!" : "You Lose!";
            GUI.Label(new Rect(Screen.width / 2 - 200, 40, 400, 50), message, style);
        }
    }
}