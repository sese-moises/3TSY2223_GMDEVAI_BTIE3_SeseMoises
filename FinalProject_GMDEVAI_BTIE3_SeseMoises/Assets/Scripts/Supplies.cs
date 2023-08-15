using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Supplies : MonoBehaviour
{
    public bool _canTakeSupplies;
    public int _supplyStock;
    public Text _supplyStockText;
    public Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _supplyStockText.text = $"{_supplyStock} / 15\nPress E to replenish Supplies";
        _supplyStockText.gameObject.SetActive(false);
        _canTakeSupplies = false;
        _supplyStock = 10;
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canTakeSupplies && _supplyStock > 0)
        {
            if (_inventory._supplies < 10)
            {
                _inventory._supplies += 1;
                _supplyStock -= 1;
                _supplyStockText.text = $"{_supplyStock} / 15\nPress E to replenish Supplies";
                _inventory.UpdateUI();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canTakeSupplies = true; 
            _supplyStockText.text = $"{_supplyStock} / 15\nPress E to replenish Supplies";
            _supplyStockText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _supplyStockText.gameObject.SetActive(false);
            _canTakeSupplies = false;
        }
    }
}
