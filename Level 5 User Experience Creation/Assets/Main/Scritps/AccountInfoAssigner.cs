using TMPro;
using UnityEngine;

public class AccountInfoAssigner : MonoBehaviour
{
    AccountInfoHolder accountInfoHolder;
    string currentAccountName;
    public TMP_Text[] characterNameStrings;

    // Start is called before the first frame update
    void Start()
    {
        accountInfoHolder = GameObject.Find("Account Info").GetComponent<AccountInfoHolder>();
        currentAccountName = accountInfoHolder.accountName;
        SetAllStrings();
    }

    void SetAllStrings()
    {
        
        foreach (var item in characterNameStrings)
        {
            if(currentAccountName != null)
            {
                item.SetText(currentAccountName);

            }
        }
    }
}
