using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionTrigger : MonoBehaviour {

    public GameObject questionManager, canvasQuiz;
    public Question[] questions;
    //private QuestionManager quesManage;

    // Use this for initialization
    void Start () {
        //quesManage = GameObject.FindGameObjectWithTag("QuestionController").GetComponent<QuestionManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canvasQuiz.activeInHierarchy == true)
        {
            //questionManager.GetComponent<QuestionManager>().TriggerQuestionDisplay();
            //quesManage.TriggerQuestionDisplay(questions);
            FindObjectOfType<QuestionManager>().StartDisplayQuestion(questions);
        }
        
    }

    public void AnswerRight(Text clickedT)
    {
        FindObjectOfType<QuestionManager>().CheckIfRightChoice(questions, clickedT);
    }
}
