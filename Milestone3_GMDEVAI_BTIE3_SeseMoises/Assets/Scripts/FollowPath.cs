using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FollowPath : MonoBehaviour
{
    string[] locations = { "Helipad", "Twin Mountains", "Command Center", "Command Post", "Radar", "Barracks", "Middle", "Left Passage", "Factory", "Tankers", "Oil Refinery Pumps", "Right Passage", "Ruins" };
    Transform goal;
    float speed = 15f;
    float accuracy = 1f;
    float rotSpeed = 20f;
    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWaypointIndex = 0;
    Graph graph;
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        graph = wpManager.GetComponent<WaypointManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (graph.getPathLength() == 0 || currentWaypointIndex == graph.getPathLength())
        {
            return;
        }

        // the node we are closest to at the moment
        currentNode = graph.getPathPoint(currentWaypointIndex);

        // if we are close enough to the current waypoint, move to the next one
        if (Vector3.Distance(graph.getPathPoint(currentWaypointIndex).transform.position, transform.position) < accuracy)
        {
            currentWaypointIndex++;
        }

        // IF WE ARE NOT AT THE END OF THE PATH
        if (currentWaypointIndex < graph.getPathLength())
        {
            goal = graph.getPathPoint(currentWaypointIndex).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
    public void GoToLocation()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        for (int i = 0; i < locations.Length; i++)
        {
            if (name == locations[i])
            {
                graph.AStar(currentNode, wps[i]);
                currentWaypointIndex = 0;
                break;
            }
        }
            
    }
}
