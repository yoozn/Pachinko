using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad instance;

    public AudioSource musicSource;
    public float volume;
    public float gameVolume;

    public float bouncyness;
    //private bool isSettings = false;
    //[SerializeField] GameObject settings;

    public int highScore1_1;
    public int highScore1_2;
    public int highScore1_3;
    public int highScore2_1;
    public int highScore2_2;
    public int highScore2_3;
    public int highScore3_1;
    public int highScore3_2;
    public int highScore3_3;
    public string newName;
    public string name1_1;
    public string name1_2;
    public string name1_3;
    public string name2_1;
    public string name2_2;
    public string name2_3;
    public string name3_1;
    public string name3_2;
    public string name3_3;


    // Start is called before the first frame update
    void Start()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Load();
        //if (SceneManager.GetActiveScene().buildIndex == 0)
        //{
        //    settings = GameObject.Find("SettingsCanvas");
        //}

        musicSource = GetComponent<AudioSource>();
        musicSource.volume = volume / 1.25f;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(volume);
    }

    class SaveData
    {
        public int highScore1_1;
        public int highScore1_2;
        public int highScore1_3;
        public int highScore2_1;
        public int highScore2_2;
        public int highScore2_3;
        public int highScore3_1;
        public int highScore3_2;
        public int highScore3_3;
        public string newName;
        public string name1_1;
        public string name1_2;
        public string name1_3;
        public string name2_1;
        public string name2_2;
        public string name2_3;
        public string name3_1;
        public string name3_2;
        public string name3_3;

        public float volume;
        public float gameVolume;

        public float bouncyness;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highScore1_1 = highScore1_1; 
        data.highScore1_2 = highScore1_2; 
        data.highScore1_3 = highScore1_3; 
        data.highScore2_1 = highScore2_1; 
        data.highScore2_2 = highScore2_2; 
        data.highScore2_3 = highScore2_3; 
        data.highScore3_1 = highScore3_1; 
        data.highScore3_2 = highScore3_2; 
        data.highScore3_3 = highScore3_3;
        data.newName = newName;
        data.name1_1 = name1_1;
        data.name1_2 = name1_2;
        data.name1_3 = name1_3;
        data.name2_1 = name2_1;
        data.name2_2 = name2_2;
        data.name2_3 = name2_3;
        data.name3_1 = name3_1;
        data.name3_2 = name3_2;
        data.name3_3 = name3_3;

        data.volume = volume;
        data.gameVolume = gameVolume;

        data.bouncyness = bouncyness;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore1_1 = data.highScore1_1;
            highScore1_2 = data.highScore1_2;
            highScore1_3 = data.highScore1_3;
            highScore2_1 = data.highScore2_1;
            highScore2_2 = data.highScore2_2;
            highScore2_3 = data.highScore2_3;
            highScore3_1 = data.highScore3_1;
            highScore3_2 = data.highScore3_2;
            highScore3_3 = data.highScore3_3;
            newName = data.newName;
            name1_1 = data.name1_1;
            name1_2 = data.name1_2;
            name1_3 = data.name1_3;
            name2_1 = data.name2_1;
            name2_2 = data.name2_2;
            name2_3 = data.name2_3;
            name3_1 = data.name3_1;
            name3_2 = data.name3_2;
            name3_3 = data.name3_3;

            volume = data.volume;
            gameVolume = data.gameVolume;

            bouncyness = data.bouncyness;
        }
    }

    //public void OnVolumeChanged(float newVolume)
    //{
    //    volume = newVolume;
    //    musicSource.volume = volume / 2;
    //    Debug.Log(newVolume);
    //}

    


}
