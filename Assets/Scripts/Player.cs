using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float playerRotationSpeed = 100.0f;
    void Start()
    {
    }

    void Update()
    {
        SelectNearestEnnemy();
    }
    void FixedUpdate()
    {
        float translation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * playerRotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }

    private void HitBadMonkey(GameObject ennemy)
    {
        ennemy.GetComponentInChildren<Animator>().SetBool("Attacked", true);
        ennemy.GetComponent<BadMonkeyController>().beAttacked = true;
    }

    private void SelectNearestEnnemy()
    {
        GameObject[] monkeys = GameObject.FindGameObjectsWithTag("Monkey");
        GameObject ennemy;

        ennemy = monkeys[0];

        foreach (GameObject monkey in monkeys)
        {
            if (Vector3.Distance(transform.position, monkey.transform.position) < 1.5)
            {
                HitBadMonkey(monkey);
            }
        }
    }
}
