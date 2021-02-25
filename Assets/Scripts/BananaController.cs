using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading;


public class BananaController : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;

    NavMeshAgent agent;
    public float EnnemyDistanceRun = 3.0f;
    public bool beEaten;
    public AudioSource jump;
    private float timeRemaining;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.transform.position);
        beEaten = false;
        timeRemaining = Random.Range(3.0f, 9.0f);
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (!jump.isPlaying && timeRemaining <= 0)
        {
            jump.Play();
            timeRemaining = Random.Range(3.0f, 9.0f);
        }
        Vector3 ennemy = SelectNearestEnnemy();
        MoveBanana(ennemy);
        ReachGoal();
    }

    private Vector3 SelectNearestEnnemy()
    {
        GameObject[] monkeys = GameObject.FindGameObjectsWithTag("Monkey");
        float distance = -1;
        GameObject ennemy;

        ennemy = monkeys[0];

        foreach (GameObject monkey in monkeys)
        {
            float tmpDistance = Vector3.Distance(transform.position, monkey.transform.position);
            if (distance == -1)
            {
                distance = tmpDistance;
                ennemy = monkey;
            }
            else if (distance > tmpDistance)
            {
                distance = tmpDistance;
                ennemy = monkey;
            }
        }
        return ennemy.transform.position;
    }

    private void MoveBanana(Vector3 ennemy)
    {
        float distance = Vector3.Distance(transform.position, ennemy);

        if (beEaten)
        {
            agent.isStopped = true;
            return;
        }

        if (distance < EnnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - ennemy;
            Vector3 newPosition = transform.position + dirToPlayer;

            agent.SetDestination(newPosition);
        }
        else
        {
            agent.SetDestination(goal.transform.position);
        }
    }

    private void ReachGoal()
    {
        if (Vector3.Distance(transform.position, goal.transform.position) < 1)
        {
            GameObject text = GameObject.FindGameObjectWithTag("Saved");
            text.GetComponent<BananaSavedText>().AddScore();
            Destroy(this.gameObject);
        }
    }
}
