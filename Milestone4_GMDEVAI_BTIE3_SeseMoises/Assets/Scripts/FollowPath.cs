using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FollowPath : MonoBehaviour
{
    string[] locations = { "Helipad", "Twin Mountains", "Command Center", "Command Post", "Radar", "Barracks", "Middle", "Left Passage", "Factory", "Tankers", "Oil Refinery Pumps", "Right Passage", "Ruins" };
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject wpManager;
    GameObject[] wps;
    void Start()
    {
        wps = wpManager.GetComponent<WaypointManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

   
    public void GoToLocation()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        for (int i = 0; i < locations.Length; i++)
        {
            if (name == locations[i])
            {
                agent.SetDestination(wps[i].transform.position);
                /*graph.AStar(currentNode, wps[i]);
                currentWaypointIndex = 0;*/
                break;
            }
        }
            
    }
}
