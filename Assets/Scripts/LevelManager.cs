using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame() {
        StartCoroutine(WaitAndLoadScene("Game", 0.5f));
    }

    public void LoadMenu() {
        StartCoroutine(WaitAndLoadScene("Menu", 0.5f));
    }

    public void LoadGameOver() {
        StartCoroutine(WaitAndLoadScene("Game Over", 1.2f));
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }

    IEnumerator WaitAndLoadScene(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
