using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airdrop : MonoBehaviour
{
    public Inventory _inventory;
    public Food _foodStock;
    public Supplies _supplyStock;
    public Text _computerText;
    public bool _available;
    public bool _canRefill;
    public float _timer;

    private void Start()
    {
        _computerText.gameObject.SetActive(false);
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _available = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _available && _canRefill)
        {
            _foodStock._foodStock = 15;
            _supplyStock._supplyStock = 15;
            _inventory.UpdateUI();
            _available = false;
            _timer += 60f;
        }

        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _available = true;
        }


        _computerText.text = "Press E to replenish stocks";
        if (_timer > 0)
        {
            _computerText.text = $"Cooldown: {_timer:##}s";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _computerText.gameObject.SetActive(true);
            _canRefill = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _computerText.gameObject.SetActive(false);
            _canRefill = false;
        }
    }
}
