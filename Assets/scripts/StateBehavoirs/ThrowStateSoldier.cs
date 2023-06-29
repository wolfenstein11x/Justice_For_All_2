using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStateSoldier : StateMachineBehaviour
{
    [SerializeField] float throwRange = 10f;

    Enemy enemy;
    Shooter shooter;
    MeleeAttacker meleeAttacker;
    GrenadeThrower grenadeThrower;
    PlayerHealth player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        meleeAttacker = animator.GetComponent<MeleeAttacker>();
        shooter = animator.GetComponent<Shooter>();
        grenadeThrower = animator.GetComponent<GrenadeThrower>();
        player = FindObjectOfType<PlayerHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.IsDead()) return;

        float distanceToPlayer = Mathf.Abs(Vector2.Distance(animator.transform.position, player.transform.position));
        bool inThrowRange = (distanceToPlayer <= throwRange);
        animator.SetBool("throwMode", inThrowRange);

        if (meleeAttacker.InMeleeRange())
        {
            animator.SetBool("meleeMode", true);
        }

        else if (shooter.InShootingRange())
        {
            animator.SetBool("shootMode", true);
        }

        if (enemy.PlayerInSight())
        {
            animator.SetBool("isProvoked", true);
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
