using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombRadius;

    public LayerMask whatToDamage;

    public GameObject explosion;

    private Collider2D[] colliders;

    private void Update()
    {
        CheckCollision();
        Explode();
    }

    private void CheckCollision()
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, bombRadius, whatToDamage);
    }

    private void Explode()
    {
        foreach (Collider2D col in colliders)
        {
            Debug.Log("Detected!");

            if (explosion != null)
                Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(col.gameObject);
            Destroy(gameObject);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bombRadius);
    }
}
