
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    private ScriptManager ScriptManager;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        float Force = Mathf.Floor(Random.Range(-500f, 500f));

        rb.AddForce(new Vector3(Force, 0f, 0f));

        ScriptManager = FindObjectOfType<ScriptManager>();
        if (transform.localScale.x == 0.6f || transform.localScale.x == 0.7f)
        {
            rb.drag = 0.5f;
        }
        else if (transform.localScale.x == 0.8f)
        {
            rb.drag = 1f;
        }
        else if (transform.localScale.x == 0.9f || transform.localScale.x == 1f)
        {
            rb.drag = 2f;
        }
    }

    // Update is called once per frame
    void Update () {
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
