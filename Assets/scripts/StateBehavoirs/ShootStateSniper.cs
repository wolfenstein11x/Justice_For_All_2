using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStateSniper : StateMachineBehaviour
{
    Enemy enemy;
    Shooter shooter;
    MeleeAttacker meleeAttacker;
    PlayerHealth player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemy.Halt();
        shooter = animator.GetComponent<Shooter>();
        meleeAttacker = animator.GetComponent<MeleeAttacker>();
        player = FindObjectOfType<PlayerHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.IsDead())
        {
            animator.SetBool("shootMode", false);
        }

        // use TouchingPlayer instead of InMeleeRange, because if player is right on top of or right behind enemy (and not in melee range), it looks stupid for enemy to stay in hide-shoot mode
        if (meleeAttacker.TouchingPlayer())
        {
            animator.SetBool("meleeMode", true);
        }

        if (!shooter.InShootingRange())
        {
            animator.SetBool("shootMode", false);
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
