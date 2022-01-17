using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper scoreKeeper;

    static int currentLevel = 1;

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        Debug.Log("scoreKeeper: ", scoreKeeper);
    }


    public void LoadGame() {
        scoreKeeper.ResetScore();
        currentLevel = 1;
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLNextLevel() {
        currentLevel += 1;
        SceneManager.LoadScene("Level " + currentLevel);
    }


    public void LoadVictory() {
        SceneManager.LoadScene("Victory");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void LoadNextLevelMenu() {
        StartCoroutine(WaitAndLoad("GoNextLevel", sceneLoadDelay));
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void ResetCurrentLevel() {
        currentLevel = 1;
    }

    IEnumerator WaitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
