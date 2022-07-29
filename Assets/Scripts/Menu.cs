using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Switches scenes from main menu to pachinko main scene. Used from button on main menu
    public void ChangeToMain()
    {
        SceneManager.LoadScene(1);
    }
}
