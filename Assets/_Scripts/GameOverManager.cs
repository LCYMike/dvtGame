using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public void StartGame() {
    Invoke("Load", 1.5f);
    var canv = FindObjectOfType<Canvas>();
    canv.enabled = false;
    }

    private void Load()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
