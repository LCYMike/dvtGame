using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    public Slider volumeSlider;

    public AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("CurVol");
        volumeSlider.value = music.volume;
        volumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("CurVol",music.volume);
        PlayerPrefs.Save();    }

    public void ValueChangeCheck()
    {
        music.volume = volumeSlider.value;
    }

}
