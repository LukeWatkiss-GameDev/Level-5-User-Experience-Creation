using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject loginPanel,SignUpPanel,TOSPanel,forgotPassPanel,loadingScreenPanel,BGDarken; 

    void Start()
    {
        SetPanelsNonActive();
    }
    public void SendToSignup()
    {
        CloseModal();
        SignUpPanel.SetActive(true);
    }

    public void SendToLogin()
    {
        CloseModal();
        loginPanel.SetActive(true);
    }

    public void SendToForgotPass()
    {
        CloseModal();
        forgotPassPanel.SetActive(true);
    }

    public void SendToTOS()
    {
        TOSPanel.SetActive(true);
    }

    public void SendToLoading()
    {
        CloseModal();
        BGDarken.SetActive(false);
        loadingScreenPanel.SetActive(true);
    }

    public void CloseModal()
    {
        GameObject curPanel = EventSystem.current.currentSelectedGameObject.transform.parent.parent.gameObject;
        Debug.Log(curPanel);
        curPanel.GetComponentInChildren<GrowAndShrinkText>().panelShrink();

    }

    void SetPanelsNonActive()
    {
        BGDarken.SetActive(false);
        TOSPanel.SetActive(false);
        forgotPassPanel.SetActive(false);
        loginPanel.SetActive(false);
        SignUpPanel.SetActive(false);
    }
}
