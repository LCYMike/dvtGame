using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public GameObject projectile;

    public GameObject TouchInput;

    public AudioSource shootSound;
    
    private bool lase = false;

    private float fireRate = 0.25f;

	// Update is called once per frame
	void Update () {

        fireRate -= Time.deltaTime;


        if (PlayerPrefs.GetInt("ControlType") == 1)
        {
            if (Input.GetButtonDown("Jump") && lase == false && fireRate <= 0)
            {
                shoot();
                fireRate = 0.25f;
            }
        }
        if (PlayerPrefs.GetInt("ControlType") == 2 && lase == false && fireRate <= 0)
        {
            if (Input.GetButtonDown("AButton"))
            {
                shoot();
                fireRate = 0.25f;
            }
        }

        if (PlayerPrefs.GetInt("ControlType") == 3)
        {
            TouchInput.SetActive(true);
        } else
        {
            TouchInput.SetActive(false);
        }


    }

    public void TouchInputFunction()
    {
        if (PlayerPrefs.GetInt("ControlType") == 3 && lase == false && fireRate <= 0)
        {
            shoot();
            fireRate = 0.25f;
        }
    }

    public void shoot()
    {
        shootSound.Play();
        var shoot = Instantiate(projectile, transform.position, Quaternion.identity);
        shoot.transform.rotation = transform.rotation;
    }

    public void laser()
    {
        CancelInvoke("shoot");
        CancelInvoke("overheat");
        InvokeRepeating("shoot", 0f, 0.1f);
        lase = true;
        Invoke("overheat", 15f);
    }

    public void overheat()
    {
        CancelInvoke("shoot");
        lase = false;
    }

}
