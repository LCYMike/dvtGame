using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject MainMenuMobile;
    public GameObject Optionsmenu;

    private void Awake()
    {
        PlayerPrefs.SetInt("IsMobileBuild", 0);
    }

    public void StartGame() {

        var Prefs = FindObjectOfType<Prefs>();

        int mobileBuild = PlayerPrefs.GetInt("IsMobileBuild");
        int controls = PlayerPrefs.GetInt("ControlType");

        var spawner = FindObjectOfType<Spawner>();
        Invoke("Load", 3f);
        spawner.Explode();
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

    public void Settings()
    {
        int mobileBuild = PlayerPrefs.GetInt("IsMobileBuild");

        if (mobileBuild == 1)
        {
            MainMenuMobile.SetActive(false);
        } else
        {
            MainMenu.SetActive(false);
        }
        Optionsmenu.SetActive(true);
    }
}
