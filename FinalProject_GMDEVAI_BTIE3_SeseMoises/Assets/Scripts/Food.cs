using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public bool _canTakeFood;
    public int _foodStock;
    public Text _foodStockText;
    public Inventory _inventory;
    // Start is called before the first frame update
    void Start()
    {
        _foodStockText.text = $"{_foodStock} / 15\nPress E to replenish Food";
        _foodStockText.gameObject.SetActive(false);
        _canTakeFood = false;
        _foodStock = 10;
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canTakeFood && _foodStock > 0)
        {
            if (_inventory._food < 10)
            {
                _inventory._food += 1;
                _foodStock -= 1;
                _foodStockText.text = $"{_foodStock} / 15\nPress E to replenish Food";
                _inventory.UpdateUI();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canTakeFood = true;
            _foodStockText.text = $"{_foodStock} / 15\nPress E to replenish Food";
            _foodStockText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))

        _foodStockText.gameObject.SetActive(false);
        _canTakeFood = false;
    }
}
