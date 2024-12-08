using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player_new player => GetComponentInParent<Player_new>();
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
}
