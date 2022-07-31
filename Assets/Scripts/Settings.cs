using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private bool isSettings = false;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider gameSlider;
    [SerializeField] Slider bouncyness;

    //public static Settings instance;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = SaveAndLoad.instance.volume;
        gameSlider.value = SaveAndLoad.instance.gameVolume;
        bouncyness.value = SaveAndLoad.instance.bouncyness;

        //gameObject.SetActive(false);
        //if (instance != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleSettings()
    {
        isSettings = !isSettings;
        //settings.GetComponent<Canvas>().enabled = isSettings;
        //GameObject.Find("SettingsCanvas").SetActive(isSettings);
        gameObject.SetActive(isSettings);

    }

    public void OnVolumeChanged(float volume)
    {
        SaveAndLoad.instance.volume = volume;
        SaveAndLoad.instance.musicSource.volume = volume / 1.5f;
        SaveAndLoad.instance.Save();
    }

    public void OnGameVolumeChanged(float volume)
    {
        SaveAndLoad.instance.gameVolume = volume;
        SaveAndLoad.instance.Save();
    }

    public void OnBouncynessChanged(float bouncyChange)
    {
        SaveAndLoad.instance.bouncyness = bouncyChange;
        SaveAndLoad.instance.Save();
    }
}
