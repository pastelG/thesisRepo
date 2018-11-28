using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLevelInfo : MonoBehaviour {

    private int indexLoad;
    public Text highS, lvlTxt;
    private float score;
    private string highStr;
    public GameObject thisPanel;

	// Use this for initialization
	void Start () {
       
        highStr = "HighScore" + indexLoad.ToString();
        Debug.Log(highStr);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void btnClick2(string lvl)
    {
        lvlTxt.text = lvl;
    }

    public void btnClickLvl(int idxLoad)
    {
        indexLoad = idxLoad;
        thisPanel.gameObject.SetActive(true);
        highStr = "HighScore" + lvlTxt.text;
        score = PlayerPrefs.GetFloat(highStr, 0);
        highS.text = "High Score: " + score.ToString() +" / 100";
        Debug.Log(highS.text);
    }

    public void levelStart()
    {
        
        FindObjectOfType<LoadSceneOnClick>().LoadByIndex(indexLoad);
    }
}
