using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideStateSoldier : StateMachineBehaviour
{
    Enemy enemy;
    Shooter shooter;
    MeleeAttacker meleeAttacker;
    PlayerHealth player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        meleeAttacker = animator.GetComponent<MeleeAttacker>();
        shooter = animator.GetComponent<Shooter>();
        player = FindObjectOfType<PlayerHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.IsDead()) return;

        if (meleeAttacker.InMeleeRange())
        {
            animator.SetBool("meleeMode", true);
        }

        else if (shooter.InShootingRange())
        {
            animator.SetBool("shootMode", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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
