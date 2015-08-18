using UnityEngine;
using System.Collections;

public class guardController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 startPosition;  //Give it a startPosition so it knows where it's 'home' location is.
    private bool wandering = true;  //Set a bool or state so it knows if it's wandering or chasing a player
    private bool chasing = false;
    private float wanderSpeed = 5.0f;  //Give it the movement speeds
    public GameObject target;  //The target you want it to chase
    private float wanderRange = 10.0f;
    private float time = 0.0f;
    private bool openingDoor = false;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent("NavMeshAgent") as NavMeshAgent;
        agent.speed = wanderSpeed;
        startPosition = this.transform.position;
        //Start Wandering
        InvokeRepeating("Wander", 1f, 5f);

        Debug.Log("kappa");
    }

    //void Update()


    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time > 10.0f)
        {
            time = 0.0f;
            int randomNumber = Random.Range(0, 3);

            if (randomNumber == 0)
            {
                //agent.destination = gameObject.transform.position;
                agent.destination = target.transform.position;
                CancelInvoke("Wander");
                Debug.Log("door");
                openingDoor = true;
            }

        }

        if (openingDoor == true)
        {
            Debug.Log(Vector3.Distance(target.transform.position, gameObject.transform.position));
            if (Vector3.Distance(target.transform.position, gameObject.transform.position) < 2.5f)
            {
                target.transform.position += new Vector3(0, 10.0f, 0);
                openingDoor = false;
            }
        }



    }

    void Wander()
    {
        Vector3 destination = startPosition + new Vector3(Random.Range(-wanderRange, wanderRange), 0, Random.Range(-wanderRange, wanderRange));
        agent.SetDestination(destination);
    }
}
