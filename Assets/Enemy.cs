using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public float radius;
    private Animator anim;
    bool damage = true;
    public int health = 3;
    bool dead = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        // each frame check if the player is within the radius of the enemy
        // if he isnt , the enemy will move towards the player
        if (!anim.GetBool("hit") && !dead) agent.destination = GameManager.instance.player.transform.position;

        // if the player is within the radius of the enemy, the enemy will stop moving and attack the player
        if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < radius)
        {
            // 
            anim.SetBool("hit", true);
            // the enemy will look at the player
            transform.LookAt(GameManager.instance.player.transform);
            // the enemy will only rotate on the y axis to sound more natural
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            
            if (damage) StartCoroutine(Damage());
        }
        else // if the player is not within the radius of the enemy anymore, the enemy will stop attacking
        {
            anim.SetBool("hit", false);
            // kill all threads that are running 
            StopAllCoroutines();
            damage = true;
        }
        if (health <= 0)
        {
            dead = true;
            Die();
        }

    }
    IEnumerator Damage()
    {
        // deals damage and decreas health bar , each second the enemy is close to me 
        damage = false;
        GameManager.instance.playerHealth--;
        yield return new WaitForSeconds(1);
        StartCoroutine(Damage());
    }
    public void Die()
    {
        anim.SetBool("dead", true);
        Destroy(gameObject, 3);
    }
}

