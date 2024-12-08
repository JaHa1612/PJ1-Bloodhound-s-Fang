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
}
