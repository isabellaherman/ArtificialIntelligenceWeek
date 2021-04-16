using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    //Start()
    public float speed;
    private PatrolWaypoints patrol;
    private int randomSpot;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        patrol = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<PatrolWaypoints>();

        randomSpot = Random.Range(0, patrol.patrolPoints.Length);
       
   }

    // Update()
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Vector2.Distance(animator.transform.position, patrol.patrolPoints
            [randomSpot].position) > 0.02f)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position,
                patrol.patrolPoints[randomSpot].position, speed * Time.deltaTime);
        }
        else
        {
            randomSpot = Random.Range(0, patrol.patrolPoints.Length);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("isPatrolling", false);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
