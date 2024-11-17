using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIEnemy : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint;
    private bool reachedEnd = false;
    private Seeker seeker;
    private Rigidbody2D rb;
    private bool facingRight;

    public Transform enemyTransform;
    // Start is called before the first frame update
    void Start()
    {

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();


        InvokeRepeating("UpdatePath", 0f, 0.5f);
        
        
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {

            seeker.StartPath(rb.position, target.position, OnPathComplete);

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(path == null)
        {

            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {

            reachedEnd = true;
            return;
        }
        else 
        {

            reachedEnd = false;
        }

        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {

            currentWaypoint++;
        }
         if(rb.velocity.x >= 0.01f && facingRight)
        {

            FlipFacing();
            

        }
        else if (rb.velocity.x <= 0.01f && !facingRight)
        {

            FlipFacing();
            

        }
        
    }

    void OnPathComplete(Path p)
    {

        if(!p.error)
        {

            path = p;
            currentWaypoint = 0;

        }

    }
    void FlipFacing(){

        Vector3 tempRotation = enemyTransform.localScale;
        tempRotation.x *= -1.0f;
        enemyTransform.localScale = tempRotation;

        facingRight = !facingRight;

    }

    
}
