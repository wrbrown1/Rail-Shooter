using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    new Collider collider;

    private void Start()
    {
        AddBoxCollider();
    }
    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    void AddBoxCollider()
    {
        collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }
}
