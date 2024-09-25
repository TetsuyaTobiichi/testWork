using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButtonClick : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject game;
    // Start is called before the first frame update
    void Awake()
    {
       game.SetActive(false);
    }
    public void click()
    {
        
        mainMenu.SetActive(false);
        game.SetActive(true);
    }
}

