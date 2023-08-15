using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class Barricade : MonoBehaviour
{
    public float _health;

    private void Start()
    {
        _health = 20;
    }

    private void Update()
    {
        if (_health > 0)
        {
            _health -= 0.5f * Time.deltaTime;
            CheckHealth();
        }
    }

    public void CheckHealth()
    {
        Mathf.Max(_health, 0);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
