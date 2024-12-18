using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject questPanel;
    public GameObject backgroundDarken;
    bool modalIsOpen;
    bool questIsOpen;
    void Update()
    {
        if(modalIsOpen & Input.GetMouseButtonDown(0))
        {
            // check if the user has clicked outside of the modal
            GameObject curObject = EventSystem.current.currentSelectedGameObject;
            Debug.Log(curObject);
            if(curObject == backgroundDarken)
            {
                SlidePanelout(menuPanel);
            }
        }

        if(Input.GetKeyDown(KeyCode.Q) && !questIsOpen)
        {
            questPanel.SetActive(true);
        }


    }

    // slide menu panel in
    public void SlidePanelIn(GameObject panel)
    {
        panel.transform.DOLocalMoveX(705,.25f);
        backgroundDarken.SetActive(true);
        modalIsOpen = true;
    }

    // slide menu panel out
    void SlidePanelout(GameObject panel)
    {
        panel.transform.DOLocalMoveX(1220,.25f);
        backgroundDarken.SetActive(false);
        modalIsOpen = false;
    }

    public void SendToSupport()
    {
        // when the funtion is called send the user to the website below
        Application.OpenURL("https://unity.com");
    }

    public void ChangeBool(bool input)
    {
        questIsOpen = input;
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }

}
