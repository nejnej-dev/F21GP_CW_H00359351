using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadMonkeyController : MonoBehaviour
{
    NavMeshAgent agent;
    private bool eat;
    public bool beAttacked;
    private float timeRemaining;
    private GameObject prey;
    public Animator animator;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        eat = false;
        beAttacked = false;
        timeRemaining = 1;
        prey = null;
    }

    void Update()
    {
        if (animator.GetBool("Attacked") == false)
        {
            beAttacked = false;
        }
        SetTarget();
        CheckTimer();
        if (eat == false && beAttacked == false)
        {
            agent.isStopped = false;
        }
    }

    private void CheckTimer()
    {
        if (eat)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                Destroy(prey);
                prey = null;
                eat = false;
                GameObject text = GameObject.FindGameObjectWithTag("Eaten");
                text.GetComponent<BananaEatenText>().AddScore();
                agent.isStopped = false;
                timeRemaining = 1;
            }
        }
    }

    private void SetTarget()
    {
        GameObject[] bananas = GameObject.FindGameObjectsWithTag("Banana");
        float distance = -1;
        GameObject target;

        if (eat || beAttacked)
        {
            agent.isStopped = true;
            return;
        }

        if (bananas.Length == 0)
        {
            return;
        }

        target = bananas[0];

        foreach (GameObject banana in bananas)
        {
            float tmpDistance = Vector3.Distance(transform.position, banana.transform.position);
            if (distance == -1)
            {
                distance = tmpDistance;
                target = banana;
            }
            else if (distance > tmpDistance)
            {
                distance = tmpDistance;
                target = banana;
            }
        }
        agent.SetDestination(target.transform.position);
        EatBanana(distance, target);
    }

    private void EatBanana(float distance, GameObject target)
    {
        if (distance < 1.5 && target.GetComponent<BananaController>().beEaten == false)
        {
            eat = true;
            target.GetComponent<BananaController>().beEaten = true;
            prey = target;
        }
    }
}
