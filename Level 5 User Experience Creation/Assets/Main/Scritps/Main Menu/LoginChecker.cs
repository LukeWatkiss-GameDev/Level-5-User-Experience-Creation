using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginChecker : MonoBehaviour
{
    AccountInfoHolder accountInfoHolder;
    MainMenuButtons mainMenuButtonsScript;

    [System.Serializable]
    public class NameAndPassPair
    {
        // class to hold name and password pairs
        public string name;
        public string password;
        public string accountName;
    }
    public List<NameAndPassPair> loginInfo = new List<NameAndPassPair>(); // list of name and password pairs
    
    public TMP_InputField enteredName;
    public TMP_InputField enteredPass;

    void Start()
    {
        mainMenuButtonsScript = GetComponent<MainMenuButtons>();
        accountInfoHolder = GameObject.Find("Account Info").GetComponent<AccountInfoHolder>();
    }

    public void CheckNameAndPass()
    {
        // check if the entered name and password is in the usable names and passwords 
        foreach (var info in loginInfo)
        {
            if(info.name == enteredName.text && info.password == enteredPass.text)
            {
                Debug.Log("correct name and password");
                mainMenuButtonsScript.SendToLoading();

                // manage sending over player account name 
                accountInfoHolder.accountName = info.accountName;
            }
            else
            {
                Debug.Log("Wrong name and/or password");
            }
        }
    }
}
