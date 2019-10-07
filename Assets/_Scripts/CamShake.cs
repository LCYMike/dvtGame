using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour {


    public GameObject Hurt;

    public IEnumerator Shake(float duration)
    {

        Vector3 origionalPos = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            Hurt.SetActive(true);
            float x = Random.Range(-0.2f, 0.2f);
            float y = Random.Range(-0.2f, 0.2f);

            Vector3 shak = new Vector3(x, y, -16.95f);

            transform.position = origionalPos + shak;

            elapsed += Time.deltaTime;

            Debug.Log("Shakin'");

            yield return null;
        }

        transform.localPosition = origionalPos;
        Hurt.SetActive(false);

    }

}
