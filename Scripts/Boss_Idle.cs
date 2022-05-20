using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public class Boss_Idle : StateMachineBehaviour
{   

    public float speed = 5.0f;
    public float attackRange = 8.0f;

    Transform player;
    Transform playerLoc;
    public static Rigidbody2D rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        } catch (NullReferenceException ex) {
            Debug.Log("Player is dead!");
        }    
        rb = animator.GetComponent<Rigidbody2D>();
    }
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //rb = animator.GetComponent<Rigidbody2D>();
    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try {
            playerLoc = GameObject.FindGameObjectWithTag("Player").transform;
        } catch (NullReferenceException ex) {
            Debug.Log("Player is dead!");
        }    
        if (playerLoc != null) {
            Vector2 target = new Vector2(playerLoc.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            //Debug.Log(animator.GetBool("isEnraged"));
            if (Vector2.Distance(playerLoc.position, rb.position) <= attackRange) {
                animator.SetTrigger("Attack");
            }  
        } else {
            return;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}
