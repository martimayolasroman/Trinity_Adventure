using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run2 : StateMachineBehaviour
{


    Transform players;
    Rigidbody2D rb;
    public float speed = 2.5f;
    public float attackRange = 3f;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //animator.GetComponent<Boss>().LookAtPlayer();
        players = GameObject.FindGameObjectWithTag("Players").transform;
        Vector2 target = new Vector2(players.position.x, rb.position.y);
       Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        rb.MovePosition(newPos);

        if (Vector2.Distance(players.position, rb.position) <= attackRange)
        {

            //Attack

            animator.SetTrigger("Attack");

        }

        
    }

// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{

        animator.ResetTrigger("Attack");

}


}
