using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentSpeedController : MonoBehaviour
{
    public enum Featuress
    {
        New,
        Old
    }
    
    [Header("By HuhMonke")]
    public NavMeshAgent agent;
    public Animator anim;
    public float DefaultSpeed = 2.5f;
    public float AnimSpeedMultiplier = 10f;
    public Featuress Version;
    private bool isChasing;
    private float currentSpeed;

    private void Update()
    {

        if(Version == Featuress.New)
        {
            currentSpeed = agent.velocity.magnitude;
            if (currentSpeed >= DefaultSpeed)
            {
                isChasing = true;
            }

            if(isChasing)
            {
                float sped = agent.velocity.magnitude / DefaultSpeed;
                anim.speed = sped * AnimSpeedMultiplier;
            }
            if(!isChasing)
            {
                float sped = agent.velocity.magnitude / DefaultSpeed;
                anim.speed = sped;
            }
        }
        if(Version == Featuress.Old)
        {
            float sped = agent.velocity.magnitude / DefaultSpeed;
            anim.speed = sped * AnimSpeedMultiplier;
        }
        
    }
}
