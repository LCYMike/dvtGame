using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour {

    public int points = 0;
    public int lives = 3;
    private int countDown = 0;

    private bool isPaused = false;
    private bool isSlowDown = false;
    private bool devToolsEnabled = false;

    public Text scoreTxt;
    public Text livesTxt;
    public Text waveTxt;
    public Text CountDownTxt;
    public Text PUTxt;
    public Text highScoretxt;

    public GameObject spawnr;
    public GameObject Body;
    public GameObject Barrel;
    public GameObject Hurt;

    public GameObject PauseMenu;

    public GameObject PowerUp1;
    public GameObject PowerUp2;
    public GameObject PowerUp3;

    public CamShake CamShake;

    private void Awake()
    {
        PauseMenu.SetActive(false);
        Hurt.SetActive(false);
        InvokeRepeating("CountDown", 0f, 1f);
        waveTxt.enabled = false;
        scoreTxt.enabled = false;
        livesTxt.enabled = false;
        PUTxt.enabled = false;
        highScoretxt.enabled = false;
    }

    private void Update()
    {
        if (//DEV :D
        Input.GetKey(KeyCode.D) &&
        Input.GetKey(KeyCode.E) &&
        Input.GetKey(KeyCode.V))
        {
                    devToolsEnabled = true;
        }


        if (devToolsEnabled == true)
        {
            //healup
            if (Input.GetKeyDown(KeyCode.H))
            {
                lives = 1000;
            }

            //spawn PowerUp's
            if (Input.GetKeyDown(KeyCode.F1))
            {
                PU1();
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                PU2();
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                PU3();
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                Instantiate(PowerUp1, new Vector3(Random.Range(-2, 2), spawnr.transform.position.y, 0), Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                Instantiate(PowerUp2, new Vector3(Random.Range(-2, 2), spawnr.transform.position.y, 0), Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                Instantiate(PowerUp3, new Vector3(Random.Range(-2, 2), spawnr.transform.position.y, 0), Quaternion.identity);
            }

        }

        scoreTxt.text = "Points : " + points;
        PlayerPrefs.SetInt("Score", points);
        livesTxt.text = "Lives : " + lives;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                pauseGame();
            }else if (isPaused == true)
            {
               playGame();
            }
        }

        if (lives <= 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }

    }

    public void addPoint()
    {
        points++;
    }

    public void loseLife()
    {
        lives--;
        StartCoroutine(CamShake.Shake(0.5f));

    }

    private void pauseGame()
    {
        isPaused = true;
        waveTxt.enabled = false;
        scoreTxt.enabled = false;
        livesTxt.enabled = false;
        highScoretxt.enabled = false;
        Barrel.GetComponent<Shoot>().enabled = false;
        Body.GetComponent<CanonRotation>().enabled = false;
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    public void Continue()
    {
        playGame();
        var bullet = FindObjectOfType<Bullet>();
        bullet.unFreeze();
    }

    public void playGame()
    {
        isPaused = false;
        if (countDown >= 5)
        {
            waveTxt.enabled = true;
            scoreTxt.enabled = true;
            livesTxt.enabled = true;
            highScoretxt.enabled = true;
        }
        Barrel.GetComponent<Shoot>().enabled = true;
        Body.GetComponent<CanonRotation>().enabled = true;
        if (isSlowDown == true)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1;
        }
        PauseMenu.SetActive(false);
    }

    public void Retry()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }


    public void Menu()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void endGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(3);
    }

    private void CountDown()
    {
        countDown++;
        switch (countDown)
        {
            case 1:
                CountDownTxt.text = "3";
                break;
            case 2:
                CountDownTxt.text = "2";
                break;
            case 3:
                CountDownTxt.text = "1";
                break;
            case 4:
                CountDownTxt.text = "GO!";
                break;
            case 5:
                CountDownTxt.enabled = false;
                waveTxt.enabled = true;
                scoreTxt.enabled = true;
                livesTxt.enabled = true;
                highScoretxt.enabled = true;
                break;

        }

    }

    public void PU1()
    {
        PUTxt.color = Color.blue;
        PUTxt.text = "LASER";
        PUTxt.enabled = true;
        FindObjectOfType<Shoot>().laser();
        Invoke("RemoveTxt", 3f);
    }
    public void PU2()
    {
        PUTxt.color = Color.red;
        PUTxt.text = "MedKit";
        PUTxt.enabled = true;
        lives += 10;
        Invoke("RemoveTxt", 3f);
    }
    public void PU3()
    {
        PUTxt.color = Color.green;
        PUTxt.text = "SlowDown";
        PUTxt.enabled = true;
        SlowDown();
        Invoke("RemoveTxt", 1.5f);
    }

    private void SlowDown()
    {
        isSlowDown = true;
        Time.timeScale = 0.5f;
        Invoke("speedUp", 10f);
    }

    private void speedUp()
    {
        isSlowDown = false;
        Time.timeScale = 1f;
    }


    //laser
    private void SpawnPU1()
    {
        Instantiate(PowerUp1, new Vector3(Random.Range(-2, 2), spawnr.transform.position.y, 0), Quaternion.identity);
    }

    //medkit
    private void SpawnPU2()
    {
        Instantiate(PowerUp2, new Vector3(Random.Range(-2, 2), spawnr.transform.position.y, 0), Quaternion.identity);
    }

    //slowdown
    private void SpawnPU3()
    {
        Instantiate(PowerUp3, new Vector3(Random.Range(-2, 2), spawnr.transform.position.y, 0), Quaternion.identity);
    }

    private void RemoveTxt()
    {
        PUTxt.enabled = false;
    }

}
