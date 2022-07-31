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
    [SerializeField] Toggle randomForce;
    [SerializeField] Toggle randomSize;
    [SerializeField] Slider timeSlider;
    [SerializeField] Toggle shinyBalls;

    //public static Settings instance;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Settings opened");
        volumeSlider.value = SaveAndLoad.instance.volume;
        gameSlider.value = SaveAndLoad.instance.gameVolume;
        bouncyness.value = SaveAndLoad.instance.bouncyness;
        timeSlider.value = SaveAndLoad.instance.timeScale;
        randomForce.GetComponent<Toggle>().isOn = SaveAndLoad.instance.isRandomForce;
        shinyBalls.GetComponent<Toggle>().isOn = SaveAndLoad.instance.isShiny;
        //randomForce.GetComponent<Toggle>().isOn = true;
        randomSize.GetComponent<Toggle>().isOn = SaveAndLoad.instance.isRandomSize;
        //randomSize.GetComponent<Toggle>().isOn = true;


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

    public void IsRandomForce(bool isChecked)
    {
        SaveAndLoad.instance.isRandomForce = isChecked;
        SaveAndLoad.instance.Save();
        Debug.Log(SaveAndLoad.instance.isRandomForce);
    }

    public void IsRandomSize(bool isChecked)
    {
        SaveAndLoad.instance.isRandomSize = isChecked;
        SaveAndLoad.instance.Save();
        Debug.Log(SaveAndLoad.instance.isRandomSize);
    }

    public void OnTimeScaleChanged(float timeChanged)
    {
        SaveAndLoad.instance.timeScale = timeChanged;
        SaveAndLoad.instance.Save();
    }

    public void IsShiny(bool isTicked)
    {
        SaveAndLoad.instance.isShiny = isTicked;
        SaveAndLoad.instance.Save();
    }
}
