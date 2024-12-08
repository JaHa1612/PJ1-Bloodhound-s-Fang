using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton_AnimationTriggers : MonoBehaviour
{
    private Enemy_skeleton enemy => GetComponentInParent<Enemy_skeleton>();

    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player_new>() != null)
                hit.GetComponent<Player_new>().Damage();
        }
    }
    private void OpenCounterWindow() => enemy.OpenCounterAttackWindow();
    private void CloseCounterWindow() => enemy.CloseCounterAttackWindow();
}
