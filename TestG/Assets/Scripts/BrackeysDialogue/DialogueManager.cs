using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public GameObject contTxt, speechBox, aNPC, bNPC, btnL, btnR, code;
    public Dialogue dlg;
    //private bool offB =  false;
    int i = 0;

    private Queue<string> sentences;
    

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        
    }

    void Update()
    {
        
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with" + dialogue.name);
       
        nameText.text = dialogue.name;

        if (dialogue.name == "Consola")
        {
            bNPC.gameObject.SetActive(false);
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        

        DisplayNextSentence();
        
        
    }

    public void DisplayNextSentence()
    {
        
        if(sentences.Count == 3)
        {
            code.SetActive(true);
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
            
        }
        string sentence = sentences.Dequeue();
        
        StopAllCoroutines();
        i++;
        
        //StartCoroutine(TypeSentence(sentence));
            
            
        //text button fading from 0 to 1
        if (i > 0)
        {
            
            contTxt.GetComponent<Text>().canvasRenderer.SetAlpha(0.0f);
            StartP();
            contTxt.GetComponent<Text>().CrossFadeAlpha(1.0f, 1.5f, false);
            
        }

        dialogueText.text = sentence;
        
        //Debug.Log(sentence);
    }

    

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        
    }

    IEnumerator StartP()
    {
        yield return new WaitForSeconds(2.5f);
    }

    void EndDialogue()
    {
        //Debug.Log("End of Conversation");
        speechBox.gameObject.SetActive(false);

        btnL.gameObject.SetActive(true);
        btnR.gameObject.SetActive(true);
        
    }
}
