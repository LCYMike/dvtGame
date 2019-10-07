using UnityEngine;
using UnityEngine.UI;

public class CanonRotation : MonoBehaviour

{

    private Gyroscope gyro;

    void Update()
    {
        if (PlayerPrefs.GetInt("ControlType") == 1)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

            if (angle > -60 + 90 && angle < 60 + 90)
            {
                transform.rotation = rotation;
            }
        }
        if (PlayerPrefs.GetInt("ControlType") == 2)
        {
            Vector3 InputDirection = Vector3.zero;
            InputDirection.x = Input.GetAxis("LeftStickX");
            float angle = InputDirection.x * 90;
            if (angle > -60 && angle < 60)
            {
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        if (PlayerPrefs.GetInt("ControlType") == 3)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            Vector3 direction = new Vector3(0f, 0f, gyro.rotationRate.z * 10);

            Quaternion A = Quaternion.Euler(gyro.rotationRate);
            Quaternion B = transform.rotation;
            Quaternion rotation = B * A;
            rotation.x = 0;
            rotation.y = 0;

            if (transform.rotation.z > -60 && transform.rotation.z < 60)
            {
                transform.rotation = rotation;
            }

        }
    }
}

//smooth rotation (less responsive)
//private float speed = 5f;
//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);