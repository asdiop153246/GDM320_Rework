using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.InputSystem.Utilities;

public class AiIndian : MonoBehaviour
{
    public float moveSpeed = 200f;
    public float nextWayPointDistance = 3f;
    public Transform target;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        aiGetComponent();

        //seeker.StartPath(rb.position, target.position, OnPathComplete);
        InvokeRepeating("UpdatePath", 1, 0.5f);
    }

    private void aiGetComponent()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p; currentWayPoint = 0;
        }
    }

    void Update()
    {
        checkWaypoint();

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * moveSpeed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(
            rb.position, 
            path.vectorPath[currentWayPoint]);

        checkNextWayPoint(distance);
        checkFlip(force);
    }
    private void checkWaypoint()
    {
        if (path == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
            reachedEndOfPath = false;
    }


    private void checkNextWayPoint(float distance)
    {
        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }
    private void checkFlip(Vector2 force)
    {
        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }
        if (force.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }
    }
}
