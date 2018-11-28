using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public bool pause;
    public GameObject btnL, btnR;

	// Use this for initialization
	void Start () {
        btnL = GameObject.Find("leftButton");
        btnR = GameObject.Find("rightButton");
	}
	
	// Update is called once per frame
	void Update () {
		if(pause == true)
        {
            Time.timeScale = 0;
            btnL.gameObject.SetActive(false);
            btnR.gameObject.SetActive(false);
        }
        if(pause == false)
        {
            Time.timeScale = 1;
            btnL.gameObject.SetActive(true);
            btnR.gameObject.SetActive(true);
        }
	}
}
