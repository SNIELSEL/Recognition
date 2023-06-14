using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieAI : MonoBehaviour
{
    public GameObject[] player;
    private NavMeshAgent agent;

    public Zombie zombie;
    public float hp, damage, speed, attackSpeed;

    public GameObject target;

    private float timer;
    public AudioSource hurtSound;
    private ColorManager colorManager;
    private PlayerStats playerStats;
    public Movement144 movement144;
    public Shoot shoot;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectsWithTag("Player");
        transform.SetParent(GameObject.Find("Enemies").transform);
        colorManager = GameObject.Find("ColorManager").GetComponent<ColorManager>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        movement144 = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement144>();
        shoot = GameObject.Find("M4A1").GetComponent<Shoot>();

        hp = zombie.hp;
        damage = zombie.damage;
        speed = zombie.speed;
        attackSpeed = zombie.attackSpeed;

        agent.speed = speed;

        target = player[0];
    }

    private void Update()
    {
        target = GetClosestPlayer().gameObject;
        agent.destination = target.transform.position;

        timer += Time.deltaTime;

        if (hp <= 0)
        {
            GameObject.Find("Spawners").GetComponent<WaveSystem>().leftEnemies -= 1;
            Destroy(gameObject);
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" && attackSpeed < timer)
        {
            if (!playerStats.isDead)
            {
                hurtSound.Play(); 
                timer = 0;
                collision.transform.GetComponent<PlayerStats>().hp -= damage;
                colorManager.IncreaseColor();
            }
            else
            {
                movement144.enabled = false;
                shoot.enabled = false;
            }
        }
    }
}
