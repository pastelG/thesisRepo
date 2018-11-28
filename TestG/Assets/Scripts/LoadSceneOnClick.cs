using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    private int scI;

	public void LoadByIndex(int sceneIndex)
    {
        Time.timeScale = 1;
        scI = sceneIndex;
        StartCoroutine(StartP());
        //SceneManager.LoadScene(sceneIndex);
    }

    public void DeleteAllPref()
    {
        PlayerPrefs.DeleteAll();
    }

    IEnumerator StartP()
    {
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(0.5f);
        
        SceneManager.LoadScene(scI);
        
    }
}
