using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        SaveAndLoad.instance.Load();
        nameInput.onEndEdit.AddListener(NameChange);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Switches scenes from main menu to pachinko main scene. Used from button on main menu
    public void ChangeToMain()
    {
        SceneManager.LoadScene(1);
        SaveAndLoad.instance.Save()
    }

    public void ChangeToLevel1()
    {
        SceneManager.LoadScene(2);
    }

    private void NameChange(string name)
    {
        SaveAndLoad.instance.newName = name;
        SaveAndLoad.instance.Save();
    }
}
