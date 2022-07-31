using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private bool isSettings = false;
    [SerializeField] Slider volumeSlider;

    //public static Settings instance;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = SaveAndLoad.instance.volume;

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
}
