using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomba : MonoBehaviour
{
    public Transform[] navPoints; // array of nav points
    public float speed;
    public GameObject playerHolder = null;

    private int navPointIndex; // which nav point in the array it is currently seeking
    public float distanceToPoint; // distance to nav point

    public bool standardPatrol;

    void Start()
    {
        navPointIndex = 0;
        transform.LookAt(navPoints[navPointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPoint = Vector3.Distance(transform.position, navPoints[navPointIndex].position);
        if (distanceToPoint < 1f)
        {
            IncreaseIndex();
        }
        if (standardPatrol) { Patrol(); }
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        navPointIndex++;
        if(navPointIndex >= navPoints.Length)
        {
            navPointIndex = 0;
        }
        transform.LookAt(navPoints[navPointIndex].position);
        if(playerHolder != null)
        {
            playerHolder.SendMessage("InvertControls");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHolder = other.gameObject;
        }
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHolder = null;
        }
        other.transform.parent = null;
    }
}
    
