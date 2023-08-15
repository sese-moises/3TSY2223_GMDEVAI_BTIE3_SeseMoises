using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    public UnityStandardAssets.Utility.WaypointCircuit _circuit;
    public int _currentIndex;
    public float _speed;
    public float _rotSpeed;
    public float _accuracy;

    private void Start()
    {
        _speed = 50;
        _rotSpeed = 100;
        _accuracy = 1;
        _currentIndex = 0;
        
    }

    private void LateUpdate()
    {
        if (_circuit.Waypoints.Length == 0)
        {
            return;
        }

        GameObject currentWaypoint = _circuit.Waypoints[_currentIndex].gameObject;

        Vector3 lookAtGoal = new Vector3(currentWaypoint.transform.position.x, transform.position.y, currentWaypoint.transform.position.z);

        Vector3 direction = lookAtGoal - transform.position;

        if (direction.magnitude < 1.0f)
        {
            _currentIndex++;
            if (_currentIndex >= _circuit.Waypoints.Length)
            {
                _currentIndex = 0;
            }
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotSpeed);

        transform.Translate(0, 0, _speed * Time.deltaTime);
    }
}
