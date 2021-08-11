using System;
using UnityEngine;

public class InteractableZone : MonoBehaviour
{
    [SerializeField] private GameObject _indicator;
    
    [SerializeField] private Player _player;

    [SerializeField] private GameObject _unavailable;
    private void Awake()
    {
        _indicator = gameObject.transform.parent.GetChild(0).gameObject;
        
        if (gameObject.transform.parent.CompareTag("SpecialObject"))
        {
            _unavailable = gameObject.transform.parent.GetChild(1).gameObject;
        }
    }

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _indicator.SetActive(true);
            _player.canInteract = true;
        }
        if (gameObject.transform.parent.CompareTag("SpecialObject") && _player.playerData.playerData[0].experience<=400)
        {
            _indicator.SetActive(false);
            _unavailable.SetActive(true);
            _player.canInteract = false;
        }
        else if (gameObject.transform.parent.CompareTag("SpecialObject") && _player.playerData.playerData[0].experience>400)
        {
            _indicator.SetActive(true);
            _unavailable.SetActive(false);
            _player.canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _indicator.SetActive(false);
            _player.canInteract = false;
        }
        if (gameObject.transform.parent.CompareTag("SpecialObject"))
        {
            _indicator.SetActive(false);
            _unavailable.SetActive(false);
            _player.canInteract = false;
        }
    }
}
