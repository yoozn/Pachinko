using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    public string newName;

    // Start is called before the first frame update
    void Start()
    {
        nameInput.onEndEdit.AddListener(NameChange);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(newName);
    }

    //Switches scenes from main menu to pachinko main scene. Used from button on main menu
    public void ChangeToMain()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeToLevel1()
    {
        SceneManager.LoadScene(2);
    }

    private void NameChange(string name)
    {
        newName = name;
    }
}
