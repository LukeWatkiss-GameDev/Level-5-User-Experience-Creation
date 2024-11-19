using UnityEngine;

public class ClickToStart : MonoBehaviour
{
    public GameObject startText;
    public GameObject loginModal;
    public GameObject BGDarken;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            BGDarken.SetActive(true);
            startText.SetActive(false);
            loginModal.SetActive(true);
            Destroy(gameObject);
        }
    }
}
