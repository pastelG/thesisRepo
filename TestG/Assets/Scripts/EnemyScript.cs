using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private bool enemyM;
    public Animator animator;
    



    private void Start()
    {
        //playCol = false;
    }

    private void FixedUpdate()
    {
        if (enemyM == true)
        {
            animator.SetBool("Run", true);
            //enemy.GetComponent<Animator>().SetTrigger("enemy_Run");
            transform.Translate(Vector3.left * 50f * Time.fixedDeltaTime);
            
        }
        
        
    }

    public void EnemyMovement(bool enemM)
    {
        //if(playCol == true)
            enemyM = enemM;
        
    }

    public void EnemyAttack()
    {
        //if (playCol == true)
            animator.SetBool("Attack", true);
    }
    public void EnemyDead()
    {
        //if (playCol == true)
            animator.SetBool("playerW", true);
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            
        }
    }
}
