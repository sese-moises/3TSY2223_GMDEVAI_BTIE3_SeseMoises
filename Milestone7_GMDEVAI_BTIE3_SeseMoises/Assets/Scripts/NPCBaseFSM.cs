using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject npc;
    public GameObject opponent;
    public float speed;
    public float rotSpeed;
    public float accuracy;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        speed = 3.0f;
        rotSpeed = 2.0f;
        accuracy = 3.0f;
        npc = animator.gameObject;
        opponent = npc.GetComponent<TankAI>().GetPlayer();
    }
}
