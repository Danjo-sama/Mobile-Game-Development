using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //allows the GameManager to be called from other scripts, in this case from PlayerControl.cs to add score

    public int score = 0;
    public TMP_Text scoreText;
    public GameObject gameOverScreen;

    private void Awake() // ensures that there is only one GameManager instance at one time while the program is running to prevent duplicate UI and score
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; //pause the game in the background so other player inputs do not interfere
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f; //resume gameplay once the scene reloads
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene("TitleScreen"); //load the title screen if the function is called from the button
    }
    private void Start()
    {
        UpdateScoreUI(); //sets an initial score when the scene reloads
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI(); //adds the value to the score and updates the UI accordingly
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"Score: {score}"; //puts the score value as an interpolated string that changes with each update
    }
}
