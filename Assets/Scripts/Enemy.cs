using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject damageFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int healthPoints = 100;

    ScoreBoard scoreBoard;
    Player player;

    private void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        player = FindObjectOfType<Player>();
    }

    void AddBoxCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHit);
        TakeDamage();
    }

    private void TakeDamage()
    {
        healthPoints = healthPoints - player.gunDamage;
        GameObject fx = Instantiate(damageFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        if(healthPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
