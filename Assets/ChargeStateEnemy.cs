using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeStateEnemy : StateMachineBehaviour
{
    Enemy enemy;
    MeleeAttacker meleeAttacker;
    PlayerHealth player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemy.MultiplySpeed(enemy.runSpeedMultiplier);
        meleeAttacker = animator.GetComponent<MeleeAttacker>();
        player = FindObjectOfType<PlayerHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.Move();

        if (player.IsDead())
        {
            animator.SetBool("isProvoked", false);
        }

        else if (meleeAttacker.InMeleeRange())
        {
            animator.SetBool("meleeMode", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.MultiplySpeed(1.0f / enemy.runSpeedMultiplier);
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
