using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject loginPanel,SignUpPanel,TOSPanel,forgotPassPanel,loadingScreenPanel,BGDarken; 
    LoadingBarProgress loadingBarProgressScript;
    public GameObject startText;
    public bool clickToStart = true;



    void Update()
    {
        if(Input.anyKeyDown && clickToStart)
        {
            
            clickToStart = false;
            BGDarken.SetActive(true);
            startText.SetActive(false);
            loginPanel.SetActive(true);
        }
    
    }

    void Start()
    {
        loadingBarProgressScript = GetComponent<LoadingBarProgress>();
        SetPanelsNonActive();
    }

    public void SendToClickToStart()
    {
        CloseModal();
        BGDarken.SetActive(false);
        StartCoroutine(ClickToStartDelay());
    }

    public void SendToSignup()
    {
        CloseModal();
        StartCoroutine(Delay(SignUpPanel));
    }

    public void SendToLogin()
    {
        CloseModal();
        StartCoroutine(Delay(loginPanel));
    }

    public void SendToForgotPass()
    {
        CloseModal();
        StartCoroutine(Delay(forgotPassPanel));
    }

    public void SendToTOS()
    {
        TOSPanel.SetActive(true);
    }

    public void SendToLoading()
    {

        CloseModal();
        BGDarken.SetActive(false);
        StartCoroutine(Delay(loadingScreenPanel));
        loadingBarProgressScript.StartLoading();
    }

    public void CloseModal()
    {
        GameObject curPanel = EventSystem.current.currentSelectedGameObject.transform.parent.parent.gameObject;
        //Debug.Log(curPanel);
        curPanel.GetComponentInChildren<GrowAndShrinkText>().PanelShrink();

    }


    // add a delay to the ability to click to start, this fixed bugs with all modals being removed and not allowing the user to do anything
    IEnumerator ClickToStartDelay() 
    {
        yield return new WaitForSeconds(0.5f);
        startText.SetActive(true);
        yield return new WaitForSeconds(.6f);
        clickToStart = true;
    }

    // wait for the modal to be removed before adding a new one
    IEnumerator Delay(GameObject OBJ)
    {
        yield return new WaitForSeconds(.5f);
        OBJ.SetActive(true);
    }

    void SetPanelsNonActive() // set all panels ,exept the main menu, to false
    {
        BGDarken.SetActive(false);
        TOSPanel.SetActive(false);
        forgotPassPanel.SetActive(false);
        loginPanel.SetActive(false);
        SignUpPanel.SetActive(false);
        loadingScreenPanel.SetActive(false);
    }
}
