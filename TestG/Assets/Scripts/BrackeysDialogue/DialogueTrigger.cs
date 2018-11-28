using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public GameObject speechBox, characP, btnL, btnR;
    
    int i = 0;

    

    private void Start()
    {
        //----------------------contBtn = GameObject.Find("ContButton");
    }

    private void OnTriggerEnter2D(Collider2D coltr)
    {
        if(coltr.gameObject.tag == "Player"&& i<1) {
            //GetComponent<CircleCollider2D>().isTrigger = false;
            btnL.gameObject.SetActive(false);
            btnR.gameObject.SetActive(false);

            

            speechBox.gameObject.SetActive(true);
            

            //contBtn.gameObject.GetComponent<Button>().enabled = false;
            //contBtn.gameObject.GetComponent<Button>().interactable = false;
            

            characP.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().flipX = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

            //contBtn.gameObject.GetComponent<Button>().interactable = true;
            i++;
        }
    }
}
