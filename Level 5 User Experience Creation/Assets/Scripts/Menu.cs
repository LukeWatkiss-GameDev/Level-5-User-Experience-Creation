using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Menu : MonoBehaviour
{

    public GameObject[] mainMenuButtons;
    public Transform mainMenutitle;
    public Transform gameRunningText;
    public Transform[] emoji;
    public GameObject[] menuScreens; // mainMenu - 0 | settings - 1 | inGame UI - 2
    public int lastScreenIndex;
    public bool normalMode;

    int x,y;

    void Start()
    {
        x = Screen.width/2;
        y = Screen.height/2;
        ChangeScreen(0);
        if(!normalMode)
        {
            for(int i = 0; i < mainMenuButtons.Length ; i++)
            {
                mainMenuButtons[i].transform.DOShakePosition(5,new Vector3(100,100,100),2,Random.Range(10,90),false).SetLoops(-1); 
                //mainMenuButtons[i].transform.DOPunchRotation(new Vector3(26,27,24),10,1,2); 
            } 

            mainMenutitle.DOScale(new Vector3(0,0,0), 1).SetLoops(-1,LoopType.Yoyo);
            mainMenutitle.DOLocalRotate(new Vector3(0,0,360),1,RotateMode.FastBeyond360).SetLoops(-1);
        }
    }

    public void SettingsButton()
    {
        ChangeScreen(1);
    }
    public void PlayButton()
    {
        ChangeScreen(2);
        if(!normalMode)
        {
            gameRunningText.DOMove(new Vector3(x,0,0),1);
            gameRunningText.DOMove(new Vector3(x,y,0),1);

            gameRunningText.DOScale(new Vector3(1.5f,1.5f,1.5f), 1).SetLoops(-1,LoopType.Yoyo);
            for(int i = 0; i < emoji.Length ; i++)
            {
                emoji[i].DOScale(new Vector3(1.5f,1.5f,1.5f), 1).SetLoops(-1,LoopType.Yoyo);
            }
        }
    
    }

    public void BackButton()
    {
        ChangeScreen(0);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void NormalModeToggle()
    {
        normalMode = !normalMode;
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
