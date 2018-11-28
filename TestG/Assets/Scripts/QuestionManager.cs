using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour {

    //public Question[] questions;
    public Text questionText;
    public Text txtChoice1, txtChoice2, txtChoice3, txtChoice4;
    //public GameObject btnChoice1, btnChoice2, btnChoice3, btnChoice4;
    public GameObject canvasQ;
    
    private int qIndex;
    //private string[] txts = new string[4];
    //private Text[] texts = new Text[4];
    //private string[] strings = new string[4];
    private int randomIndex;
    private static List<int> list = new List<int>();

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TriggerQuestionDisplay(Question[] questions)
    {
        StartDisplayQuestion(questions);
    }

    public void StartDisplayQuestion(Question[] questions)
    {
        canvasQ.gameObject.SetActive(true);
        string[] txts = new string[4];
        string[] strings = new string[4];
        int randomIndex;

        strings[0] = questions[qIndex].ansC;
        strings[1] = questions[qIndex].ansW1;
        strings[2] = questions[qIndex].ansW2;
        strings[3] = questions[qIndex].ansW3;

        for (int n = 0; n < 4; n++)    //  Populate list
        {
            list.Add(n);
        }

        int iNum;

        for (int i = 0; i < 4; i++)
        {
            randomIndex = Random.Range(0, list.Count - 1);    //  Pick random element from the list
            iNum = list[randomIndex];    //  i = the number that was randomly picked
            list.RemoveAt(randomIndex);   //  Remove chosen element

            txts[iNum] = strings[i];

            //Buttons[i] = (int)Random.Range(1.0f,4.0f);
        }

        questionText.text = questions[qIndex].question;
        txtChoice1.text = txts[0];
        txtChoice2.text = txts[1];
        txtChoice3.text = txts[2];
        txtChoice4.text = txts[3];



        
    }

    
   

    public void CheckIfRightChoice(Question[] questions, Text clickedT)
    {
        
        if (clickedT.text == questions[qIndex].ansC)
        {
            FindObjectOfType<PlayerMovement>().OnClickDestroyEnemy(true);
        }
        else
            FindObjectOfType<PlayerMovement>().OnClickDestroyEnemy(false);
        qIndex++;
    }

    
    
}
