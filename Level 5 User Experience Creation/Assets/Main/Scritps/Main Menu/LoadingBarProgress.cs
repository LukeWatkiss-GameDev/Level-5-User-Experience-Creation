using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBarProgress : MonoBehaviour
{
    public SceneChanger sceneChangerScript;
    public Slider loadingBar;
    public TMP_Text loadingBarText;
    public string sceneToLoad;
    bool loadingBarFinished = false;
    bool sceneLoadingDone = false;
    public void StartLoading()
    {
        StartCoroutine(StartLoadingBar());
        StartCoroutine(LoadSceneAsync());
    }


    IEnumerator StartLoadingBar()
    {

        while(loadingBar.value < 100)
        {
            // while the loading bars valuse is not full 
            // increase the value by a random number every 1-3 seconds
            // and update the slider text
            loadingBar.value += Random.Range(10,25);
            loadingBarText.SetText(loadingBar.value.ToString() +"%");
            yield return new WaitForSeconds(Random.Range(1,4));

        }
        loadingBarFinished = true;
        Debug.Log("Loading finished");

    }
    
    IEnumerator LoadSceneAsync()
    {
        // make the script wait for 1 second before begining to load the scene
        // this allows for the loading bar to appear and makes the async loading stutters less noticable
        yield return new WaitForSeconds(1);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        asyncLoad.allowSceneActivation = false; // This stops the scene automatically loading when it is done
        // while the scene is still loading return null
        while(!asyncLoad.isDone && !loadingBarFinished)
        {
            yield return null;
        }
        // fade the screen to black
        sceneChangerScript.FadeToLevel();
        // wait for the animation to finish
        yield return new WaitForSeconds(1);
        //activate the next scene
        asyncLoad.allowSceneActivation = true; // triggers the loaded scene to load
        sceneLoadingDone = true;


    }
}
