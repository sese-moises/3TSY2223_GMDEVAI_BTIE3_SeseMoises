using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerEnter : MonoBehaviour
{
    public bool _canRepair;
    public Barricade _barricade;
    public Inventory _inventory;
    public GameObject _barricadePrefab;
    public GameObject _currentBarricade;
    public AgentManager _aM;
    public Text _barricadeText;
    public float _barricadeHealth;

    private void Start()
    {
        _barricadeHealth = 0;
        _barricadeText.gameObject.SetActive(false);
        _canRepair = false;
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _aM = GameObject.FindGameObjectWithTag("Agent Manager").GetComponent<AgentManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canRepair && _inventory._supplies > 0)
        {
            if (_currentBarricade == null)
            {
                _currentBarricade = Instantiate(_barricadePrefab, transform.position, transform.rotation);
                _barricade = _currentBarricade.GetComponent<Barricade>();
                _barricadeHealth += 20;
                _inventory._supplies -= 1;
                _inventory.UpdateUI();
            }
            else if (_barricadeHealth < 100)
            {
                _barricadeHealth += 20;
                _barricadeHealth = Mathf.Min(100, _barricadeHealth);

                _inventory._supplies -= 1;
                _inventory.UpdateUI();
            }
        }

        _barricadeText.text = $"Health: {_barricadeHealth:##}%\nPress E to build/repair";

        if (_barricadeHealth > 0)
        {
            _barricadeHealth -= 0.5f * Time.deltaTime;
            CheckHealth();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _barricadeText.gameObject.SetActive(true);
            _canRepair = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _barricadeText.gameObject.SetActive(false);
            _canRepair = false;
        }
    }

    public void CheckHealth()
    {
        Mathf.Max(_barricadeHealth, 0);
        if (_barricadeHealth <= 0)
        {
            Destroy(_currentBarricade);
        }
    }
}

