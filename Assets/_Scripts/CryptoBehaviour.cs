using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum CryptoStates
{
    IDLE,
    RUN,
    JUMP
}

public class CryptoBehaviour : MonoBehaviour
{
    [Header("Line of Sight")]
    public bool HasLOS;
    public GameObject player;


    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasLOS)
        {
            agent.SetDestination(player.transform.position);
        }

        if (HasLOS)
        {
            agent.SetDestination(player.transform.position);
            animator.SetInteger("AnimState", (int)CryptoStates.RUN);

            if (Vector3.Distance(transform.position, player.transform.position) < 3.5f)
            {
                animator.SetInteger("AnimState", (int)CryptoStates.IDLE);
                transform.LookAt(transform.position - player.transform.forward);
            }
        } 
        else
        {
            animator.SetInteger("AnimState", (int)CryptoStates.IDLE);
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = true;
            player = other.transform.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HasLOS = false;
        }
    }
}
