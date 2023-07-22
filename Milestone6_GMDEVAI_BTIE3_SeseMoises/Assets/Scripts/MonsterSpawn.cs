using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject[] obstacles;
    GameObject[] agents;

    private void Start()
    {
        agents = GameObject.FindGameObjectsWithTag("agent");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnObject(0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnObject(1);
        }
    }

    private void SpawnObject(int i)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            Instantiate(obstacles[i], hit.point, obstacles[i].transform.rotation);
            foreach (GameObject a in agents)
            {
                Debug.Log(a.name + " reacted");
                a.GetComponent<AIControl>().DetectNewObstacle(i, hit.point);
            }
        }
    }
}
