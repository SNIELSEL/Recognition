using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public GameObject[] player;
    private NavMeshAgent agent;

    public Zombie zombie;
    public float hp, damage, speed;

    public GameObject target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectsWithTag("Player");
        transform.SetParent(GameObject.Find("Enemies").transform);

        hp = zombie.hp;
        damage = zombie.damage;
        speed = zombie.speed;

        agent.speed = speed;

        target = player[0];
    }

    private void Update()
    {
        target = GetClosestPlayer().gameObject;    
    }


    Transform GetClosestPlayer()
    {
        float closestDinstance = 999999999999999;
        int closestIndex = 0;

        for (int i = 0; i < player.Length; i++)
        {
            float curDistance = Vector3.Distance(transform.position, player[i].transform.position);
            if (curDistance < closestDinstance) {
                closestDinstance = curDistance;
                closestIndex = i;
            }
        }
        return player[closestIndex].transform;
    }
}
