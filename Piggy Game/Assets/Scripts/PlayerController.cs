using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform pointToMove;
    public LayerMask collideWith;
    public LayerMask whatIsEnemy;

    public float radius;

    public GameObject bombPrefab;

    private void Start()
    {
        pointToMove.parent = null;
    }

    private void Update()
    {
        Move();
        PlaceBomb();
        GotCaught();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointToMove.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, pointToMove.position) <= 0.5f)
        {
            if (Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal")) == 1)
            {
                if (!Physics2D.OverlapCircle(pointToMove.position + new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, 0), 0.2f, collideWith))
                {
                    pointToMove.position += new Vector3(CrossPlatformInputManager.GetAxis("Horizontal") * 1.6f, 0, 0);
                }
            }
            else if (Mathf.Abs(CrossPlatformInputManager.GetAxis("Vertical")) == 1)
            {
                if (!Physics2D.OverlapCircle(pointToMove.position + new Vector3(0, CrossPlatformInputManager.GetAxis("Vertical"), 0), 0.2f, collideWith))
                {
                    pointToMove.position += new Vector3(CrossPlatformInputManager.GetAxis("Vertical") * 0.15f, CrossPlatformInputManager.GetAxis("Vertical") * 1.8f, 0);
                }
            }
        }
    }

    private void PlaceBomb()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Instantiate(bombPrefab, transform.position, bombPrefab.transform.rotation);
        }
    }

    private void GotCaught()
    {
        if(Physics2D.OverlapCircle(transform.position, radius, whatIsEnemy))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
