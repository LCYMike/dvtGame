using UnityEngine;
using UnityEngine.UI;

public class Prefs : MonoBehaviour {

    private int controls;

    public Text controlsTxt;
    public Text InstTxt;

    private void Awake()
    {
        controls = PlayerPrefs.GetInt("ControlType");
    }

    private void Start()
    {
        SetControls();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UpdateControls();
        }
    }

    public void Error()
    {
        InstTxt.text = "Please select a controller \nPress 'CONTROLS'";
    }

    public void UpdateControls()
    {
        controls++;
        SetControls();
    }

    void SetControls()
    {

        int mobileBuild = PlayerPrefs.GetInt("IsMobileBuild");

        if (mobileBuild == 1)
        {
            Gyro();
        } else if (mobileBuild == 0)
        {
            if (controls == 1)
            {
                KeyMouse();
            }
            else if (controls == 2)
            {
                Cont();
            }
            else if (controls == 3)
            {
                controls = 1;
                KeyMouse();
            }
        }
        

    }

    public void KeyMouse()
    {
        PlayerPrefs.SetInt("ControlType", 1);
        PlayerPrefs.Save();
        controlsTxt.text = "Keyboard & Mouse";
        InstTxt.text = "Space to shoot & Mouse to Aim";
    }

    public void Cont()
    {
        PlayerPrefs.SetInt("ControlType", 2);
        PlayerPrefs.Save();
        controlsTxt.text = "Controller";
        InstTxt.text = "Left JoyStick to Aim & on PlayStation Use 'SQUARE' on XBox use 'A' to Shoot";
    }

    public void Gyro()
    {
        PlayerPrefs.SetInt("ControlType", 3);
        PlayerPrefs.Save();
        controlsTxt.text = "Mobile";
        InstTxt.text = "Tilt Device to aim & Tap to Shoot";
    }
}
