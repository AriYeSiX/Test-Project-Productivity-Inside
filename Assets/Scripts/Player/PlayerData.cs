using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [SerializeField] private GameObject _player;
    
    public GameObject player => _player;

    [SerializeField]private int _experience;

    public int experience
    {
        get => _experience;
        set => _experience = value;
    }

    [SerializeField] private int _maxHealth;

    public int MaxHealth => _maxHealth;

    [SerializeField] private int _health;

    public int health
    {
        get => _health;
        set => _health = value;
    }

    [SerializeField] private Vector3 _playerPosition;

    public Vector3 playerPosition
    {
        get => _playerPosition;
        set => _playerPosition = value;
    }
}
