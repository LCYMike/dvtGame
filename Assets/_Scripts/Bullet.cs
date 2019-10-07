using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public ScriptManager ScriptManager;

    public ParticleSystem Explosion;

    private bool isPaused = false;

    private void Start()
    {
        ScriptManager = FindObjectOfType<ScriptManager>();
        transform.Translate(new Vector3(0f, 0.6f, 0f));
    }

    public float bulletVelocity = 0.3f;
	
	// Update is called once per frame
	void Update () {
        if (isPaused == false)
        {
            transform.Translate(new Vector3(0f, bulletVelocity, 0f));
            if (transform.position.y > 20 || transform.rotation.z < -59 || transform.rotation.z > 61)
            {
                Destroy(gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                freeze();
            }
            else if (isPaused == true)
            {
                unFreeze();
            }
        }

    }

    private void freeze()
    {
        isPaused = true;
    }

    public void unFreeze()
    {
        isPaused = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ScriptManager.addPoint();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(Explosion, collision.transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PowerUp1")
        {
            ScriptManager.PU1();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PowerUp2")
        {
            ScriptManager.PU2();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "PowerUp3")
        {
            ScriptManager.PU3();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
