using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startTime;
    public Transform[] waypoints;
    private int randomWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        randomWaypoint = Random.Range(0, waypoints.Length);        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[randomWaypoint].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, waypoints[randomWaypoint].position)< 0.2f)
        {
            if (waitTime <= 0)
            {
                randomWaypoint = Random.Range(0, waypoints.Length);
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
    }
}
