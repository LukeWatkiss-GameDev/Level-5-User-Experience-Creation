using TMPro;
using UnityEngine;

public class AccountInfoAssigner : MonoBehaviour
{
    AccountInfoHolder accountInfoHolder;
    string currentAccountName;
    public TMP_Text[] characterNameStrings;

    void Start()
    {
        // grab the acount name from the holder and find the account name
        accountInfoHolder = GameObject.Find("Account Info").GetComponent<AccountInfoHolder>();
        currentAccountName = accountInfoHolder.accountName;
        SetAllStrings();
    }

    void SetAllStrings()
    {
        // set all characterNameStrings to the characters name
        // this is an array for future proofing E.G. if there is anywhere else the acount name is needed as text
        foreach (var item in characterNameStrings)
        {
            if(currentAccountName != null)
            {
                item.SetText(currentAccountName);

            }
        }
    }
}
