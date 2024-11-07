using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountCreation : MonoBehaviour
{
    LoginChecker loginCheckerScript;
    MainMenuButtons mainMenuButtonsScript;
    [Header("Input Fields")]
    public TMP_InputField[] inputFields;
    public Toggle toggleTOS;
    bool canCreateAccount;

    void Start()
    {
        mainMenuButtonsScript = GetComponent<MainMenuButtons>();
        loginCheckerScript = GetComponent<LoginChecker>();
    }
    public void CheckInfoEntered()
    {
        canCreateAccount = true;

        // Check if there is text in all of the input fields
        foreach (var inputField in inputFields)
        {
            if(inputField.text == "")
            {
                Debug.Log("No Text in " + inputField);
                canCreateAccount = false;
                break;
                
            }
            
        }

        if(!toggleTOS.isOn)
        {
            canCreateAccount = false;
            
        }

        foreach (var info in loginCheckerScript.loginInfo)
        {
            if(info.accountName == inputFields[3].text)
            {
                canCreateAccount = false;
                Debug.Log("Account with this name already exists");
            }
        }

        // create the new account
        if(canCreateAccount)
        {
            // add the name and password to a list so it can be used to login
            loginCheckerScript.loginInfo.Add(new LoginChecker.NameAndPassPair{ name = inputFields[3].text, password = inputFields[4].text, accountName = inputFields[3].text});

            mainMenuButtonsScript.SendToLogin();

            // remove all text from the text fields
            foreach (var inputField in inputFields)
            {
                inputField.text = "";
            }
        }

        
    }
}