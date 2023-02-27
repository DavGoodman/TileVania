using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int deathCount = 0;
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI deathsText;
    [SerializeField] TextMeshProUGUI scoreText;
    public bool gunUnlocked;

    void Awake() 
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else DontDestroyOnLoad(gameObject);
    }

    void Start() 
    {
        deathsText.text = deathCount.ToString();
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        AddDeath();
    }

    public void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(1);
        Destroy(gameObject);
    }

    void AddDeath()
    {
        deathCount++;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        deathsText.text = deathCount.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
}
