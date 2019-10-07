using UnityEngine;
using UnityEngine.UI;

public class StartMenuUI : MonoBehaviour {

    public GameObject Menu;
    public GameObject MobileMenu;

    void Start () {

        int mobileBuild = PlayerPrefs.GetInt("IsMobileBuild");

        if (mobileBuild == 1)
        {
            Menu.SetActive(false);
            MobileMenu.SetActive(true);
        } else if (mobileBuild == 0)
        {
            Menu.SetActive(true);
            MobileMenu.SetActive(false);
        }
	}
}
