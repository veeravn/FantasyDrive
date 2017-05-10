using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollower : MonoBehaviour {
    public Transform Player;
    private GameObject Obstacle;
    public GameObject Hurdles;
    private Transform rotation;
    // Use this for initialization
    void Start()
    {

        InvokeRepeating("createHurdles", 2, 7.0F);

    }

    void createHurdles()
    {



        Vector3 playerPos = Player.position;

        Vector3 ObstaclePosition = transform.position;

        ObstaclePosition.y = 1;
        Obstacle = Instantiate(Resources.Load("Obstacles/Hurdle"), ObstaclePosition, transform.rotation) as GameObject;
        Obstacle.transform.rotation = Player.transform.rotation;
        Debug.Log("rotation :" + Obstacle.transform.rotation);
        Obstacle.transform.parent = Hurdles.transform;


        Debug.Log("Hurdle created at :" + ObstaclePosition);

    }
    // Update is called once per frame
    void Update()
    {



        float dist = Vector3.Distance(Player.position, transform.position);
        Debug.Log("Distance :" + dist);
    }
}

