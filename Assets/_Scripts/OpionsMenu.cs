using UnityEngine;
using UnityEngine.UI;

public class OpionsMenu : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject MainMenuMobile;
    public GameObject Optionsmenu;

    public void Main()
    {
        int mobileBuild = PlayerPrefs.GetInt("IsMobileBuild");

        if (mobileBuild == 1)
        {
            MainMenuMobile.SetActive(true);
        }
        else if (mobileBuild == 0)
        {
            MainMenu.SetActive(true);
        }

        Optionsmenu.SetActive(false);
    }

}
