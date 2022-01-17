using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper scoreKeeper;

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        Debug.Log("scoreKeeper: ", scoreKeeper);
    }


    public void LoadGame() {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2() {
        SceneManager.LoadScene("Level 2");
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

    IEnumerator WaitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}