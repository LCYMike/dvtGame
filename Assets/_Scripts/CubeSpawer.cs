using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CubeSpawer : MonoBehaviour {

    public GameObject cube;


    public GameObject PowerUp1;
    public GameObject PowerUp2;
    public GameObject PowerUp3;

    public Text waveTxt;

    public float spawnTime = 2f;

    private int counter = 0;

    GameObject _PowerUp;

    private bool called = false;

    void Start()
    {
        InvokeRepeating("count", 4f, 1f);
    }

    private void Update()
    {
        if (counter == 0)
        {
            waveTxt.text = "wave : 1/3";
        }
        if (counter == 30)
        {
            waveTxt.text = "wave : 2/3";
        }
        if (counter == 60)
        {
            waveTxt.text = "wave : 3/3";
        }
    }

    private void wave()
    {
        switch (counter)
        {
            case 1:
                InvokeRepeating("SpawnCube", 0f, 2f);
                break;
            case 30:
                InvokeRepeating("SpawnCube", 0f, 1f);
                break;
            case 60:
                InvokeRepeating("SpawnCube", 0f, 0.75f);
                break;
            case 90:
                SceneManager.LoadScene(3);
                break;
        }
    }

    private void count()
    {
        counter++;
        if (counter == 1 || counter == 30 || counter == 60 || counter == 90)
        {
            CancelInvoke("SpawnCube");
            wave();
        }
    }

    void SpawnCube() {
        float power = Mathf.Floor(Random.Range(1f, 100f));

        if (power == 1f)
        {
            SpawnPowerUp();
        }

        float rand = Mathf.Floor(Random.Range(6f, 10f));
        rand = rand / 10;
        cube.transform.localScale = new Vector3(rand, rand, rand);

        Instantiate(cube, new Vector3(Random.Range(-2,2), transform.position.y, 0), Quaternion.identity);
    }

    void SpawnPowerUp() {
    

        float pu = Mathf.Floor(Random.Range(1f, 3.5f));

        if (pu == 1)
        {
            _PowerUp = PowerUp1;
        }
        else if (pu == 2)
        {
            _PowerUp = PowerUp2;
        }
        else if (pu == 3)
        {
            _PowerUp = PowerUp3;
        }


        Instantiate(_PowerUp, new Vector3(Random.Range(-2, 2), transform.position.y, 0), Quaternion.identity);
    }

}
