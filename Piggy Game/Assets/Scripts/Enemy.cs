using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private float timeToWaitBeforeMove;
    public float startWaitTime;

    public Transform pointToMove;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        pointToMove.parent = null;

        timeToWaitBeforeMove = startWaitTime;

        pointToMove.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointToMove.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, pointToMove.position) < 0.2f)
        {
            if(timeToWaitBeforeMove <= 0)
            {
                timeToWaitBeforeMove = startWaitTime;
                pointToMove.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
            else
            {
                timeToWaitBeforeMove -= Time.deltaTime;
            }
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.currentNumOfEnemies--;
    }
}
