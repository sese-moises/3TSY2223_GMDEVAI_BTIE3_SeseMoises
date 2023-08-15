using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int _supplies;
    public int _food;
    public Hunger _hunger;
    public int _currentHunger;
    public float _time;
    public Text _foodText;
    public Text _supplyText;
    public Text _buttonText;

    private void Start()
    {
        _supplies = 5;
        _supplyText.text = $"Supplies: {_supplies} / 10";
        _food = 5;
        _foodText.text = $"Food: {_food} / 10";
        _currentHunger = 100;
        _hunger.SetMaxHunger(100);
        _time = 0;
        _buttonText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _food > 0)
        {
            Eat(25);
            _food -= 1;
            UpdateUI();
        }

        _time += 1f * Time.deltaTime;
        
        if (_time > 5f)
        {
            GetHungry(5);
            _time = 0f;
        }

        if (_currentHunger < 50)
        {
            _buttonText.gameObject.SetActive(true);
        }
        else
        {
            _buttonText.gameObject.SetActive(false);
        }
    }

    void GetHungry(int hunger)
    {
        _currentHunger -= hunger;

        _currentHunger = Mathf.Max(0, _currentHunger);
        _hunger.SetHunger(_currentHunger);
    }

    void Eat(int hunger)
    {
        _currentHunger += hunger;

        _currentHunger = Mathf.Min(100, _currentHunger);
        _hunger.SetHunger(_currentHunger);
    }

    public void UpdateUI()
    {
        _supplyText.text = $"Supplies: {_supplies} / 10";
        _foodText.text = $"Food: {_food} / 10";
    }
}
