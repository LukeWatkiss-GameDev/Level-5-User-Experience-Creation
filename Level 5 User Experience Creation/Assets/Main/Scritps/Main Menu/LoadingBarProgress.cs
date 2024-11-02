using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBarProgress : MonoBehaviour
{
    public Slider loadingBar;
    public TMP_Text loadingBarText;
    public void StartLoading()
    {
        StartCoroutine(StartLoadingBar());
    }

    IEnumerator StartLoadingBar()
    {

        while(loadingBar.value < 100)
        {
            
            loadingBar.value += Random.Range(10,25);
            loadingBarText.SetText(loadingBar.value.ToString() +"%");
            yield return new WaitForSeconds(Random.Range(1,4));

        }
        Debug.Log("Loading finished");
        // load the next scene
        SceneManager.LoadScene("Lobby");

    }
}
