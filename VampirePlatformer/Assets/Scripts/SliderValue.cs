using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderValue : MonoBehaviour
{
    public Text sliderText;
    public Slider slider;

    GameObject soundController;
    private void Awake()
    {
        soundController = GameObject.Find("SoundController");
    }
    private void Start()
    {
        if (slider != null)
        {
            slider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
        }

    }
    public void SetVolume()
    {
        PlayerPrefs.SetFloat("SoundVolume", slider.value);
        soundController.GetComponent<AudioMenager>().SetAllVolume();
    }
    // Update is called once per frame
    void Update()
    {
        sliderText.text = (Mathf.Round(slider.value * 100)).ToString();
    }
}
