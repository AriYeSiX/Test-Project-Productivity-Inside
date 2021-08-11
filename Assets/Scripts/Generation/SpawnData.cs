using System;
using UnityEngine;

[Serializable]
public class SpawnData
{
    [SerializeField] private GameObject _spot;

    public GameObject spot
    {
        get => _spot;
        set => _spot = value;
    }

    [SerializeField] private GameObject _InteractableObjects;

    public GameObject interactableObjects => _InteractableObjects;
}
