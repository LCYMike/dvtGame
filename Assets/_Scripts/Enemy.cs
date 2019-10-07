using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public ScriptManager ScriptManager;

    public Rigidbody rb;

    private void Start()
    {
        ScriptManager = FindObjectOfType<ScriptManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Line")
        {
            ScriptManager.loseLife();
            Destroy(gameObject);
        }
    }

}
