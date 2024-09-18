using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu : MonoBehaviour
{

    public GameObject[] menuScreens; // mainMenu - 0 | settings - 1 | inGame UI - 2
    public int lastScreenIndex;
    // Start is called before the first frame update
    void Start()
    {
        ChangeScreen(0);
    }

    public void SettingsButton()
    {
        ChangeScreen(1);
        
    }
    public void PlayButton()
    {
        ChangeScreen(2);
    }

    public void BackButton()
    {
        ChangeScreen(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }


    void ChangeScreen(int index)
    {
        
        for(int i = 0; i < menuScreens.Length ; i++)
        {
            if(i != index)
            {
                menuScreens[i].SetActive(false);
            }
            else
            {
                menuScreens[i].SetActive(true);
            }
        }
    }
}
