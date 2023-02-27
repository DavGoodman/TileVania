using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    //[SerializeField] float levelLoadDelay = 1;
    GameSession gameSession;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        //yield return new WaitForSecondsRealtime(levelLoadDelay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;


        if(currentSceneIndex != 0) 
        {
            var scenePersist = FindObjectOfType<ScenePersist>();
            var gameSession = FindObjectOfType<GameSession>();

            scenePersist.ResetScenePersist();
        }
        
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void Restart()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.ResetGameSession();
    }
}
