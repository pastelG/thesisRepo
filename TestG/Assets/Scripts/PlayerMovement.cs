using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private HealthStat health;

    //private EnemyScript enemyScript;

    public CharacterController2D controller;
    public Animator animator;

    //public Button leftBtn, rightBtn;
    public GameObject canvasQuiz, finishP, btnL, btnR, glowI, txtScore, highScore, audioS;

    public float runSpeed = 2f;

    float horizontalMove = 0f;

    public bool EnemyMove = false;
    public bool playWin = false;
    private bool endGame = false;
    private GameObject enemy;

    public int currentLvl;
    private int reachLvl;
    private float currentSc, highSc;

    private string highScStr;
    


    private void Awake()
    {
        health.Initialize();

        //enemyScript = GameObject.FindObjectOfType<EnemyScript>();
        //questionManager = GameObject.FindObjectOfType<QuestionManager>();
        reachLvl = PlayerPrefs.GetInt("ReachLevel", 1);

        highScStr = "HighScore" + currentLvl.ToString();

        highSc = PlayerPrefs.GetFloat(highScStr,0);

    }

    // Use this for initialization
    void Start () {

        btnL = GameObject.Find("leftButton");
        btnR = GameObject.Find("rightButton");
        
        

    }
	
	// Update is called once per frame
	void Update () {
        horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") *runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (endGame == true)
        {
            Time.timeScale = 0;
            /*for (int i = 0; i < 4; i++)
            {
                glowI.GetComponent<Image>().canvasRenderer.SetAlpha(1.0f);
                StartP();
                glowI.GetComponent<Image>().CrossFadeAlpha(0.5f, 1.5f, false);
            }*/
        }
	}

    IEnumerator StartP()
    {
        yield return new WaitForSeconds(2.5f);
    }

    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        
    }
    
    

    public void OnClickDestroyEnemy(bool playerWin)
    {
        playWin = playerWin;
        canvasQuiz.gameObject.SetActive(false);
        



        if (playerWin == true)
        {
            Debug.Log("this paramater is true");

            enemy.GetComponent<EnemyScript>().EnemyDead();
           //enemyScript.EnemyDead();
            DestroyEnemy();
            animator.SetBool("PlyWins", true);
            animator.SetBool("ColEnm", false);
        }
        else
        {
            Debug.Log("This paramater is false");
            enemy.GetComponent<CircleCollider2D>().enabled = false;
            EnemyMove = true;

            enemy.GetComponent<EnemyScript>().EnemyMovement(EnemyMove);
            //enemyScript.EnemyMovement(EnemyMove);

            Destroy(enemy, 3);
            animator.SetBool("PlyWins", false);
            animator.SetBool("ColEnm", false);

            health.CurrentVal -= 20;
            
            
        }
        btnL.gameObject.SetActive(true);
        btnR.gameObject.SetActive(true);
        currentSc = health.CurrentVal;

        GameObject.Find("FightingAudio").GetComponent<AudioSource>().Stop();

        if (health.CurrentVal == 0)
        {
            GameObject.Find("errorAudio").GetComponent<AudioSource>().Play();
            FindObjectOfType<LoadSceneOnClick>().LoadByIndex(3);
        }
        audioS.gameObject.GetComponent<AudioSource>().UnPause();
        //canvasQuiz.gameObject.SetActive(false);

    }
    public void DestroyEnemy()
    {
        
        if (playWin == true)
        {
            
            Debug.Log("Player Wins");
            Destroy(enemy, 2);
        }


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Enemy")
        {
            audioS.gameObject.GetComponent<AudioSource>().Pause();
            GameObject.Find("FightingAudio").GetComponent<AudioSource>().Play();
            btnL.gameObject.SetActive(false);
            btnR.gameObject.SetActive(false);
            Debug.Log("Collided with an Enemy");
            animator.SetBool("ColEnm",true);
            canvasQuiz.gameObject.SetActive(true);
            //questionManager.StartDisplayQuestion();
            

            enemy = collision.gameObject;
            if(playWin == true)
            {
                Debug.Log("hmmph!");
                
            }
            else
            {
                Debug.Log("What?!");
            }
            //StartP();
            enemy.GetComponent<CircleCollider2D>().isTrigger = true;
            enemy.GetComponent<EnemyScript>().EnemyAttack();
            
        }
        else
        {
            animator.SetBool("ColEnm", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            btnL.gameObject.SetActive(false);
            btnR.gameObject.SetActive(false);
            Debug.Log("Finish Line");
            finishP.gameObject.SetActive(true);
            audioS.gameObject.GetComponent<AudioSource>().Stop();
            GameObject.Find("WinAudio").GetComponent<AudioSource>().Play();
            endGame = true;

            if (highSc < currentSc)
            {
                highSc = currentSc;
                PlayerPrefs.SetFloat(highScStr, highSc);
            }

            txtScore.GetComponent<Text>().text = "Score: " + currentSc.ToString() + " / " + health.MaxVal.ToString();
            highScore.GetComponent<Text>().text = "High Score: " + highSc.ToString() + " / " + health.MaxVal.ToString();

            if (currentLvl == reachLvl)
            {
                PlayerPrefs.SetInt("ReachLevel",currentLvl+1);
                
            }
            
        }
    }


}
