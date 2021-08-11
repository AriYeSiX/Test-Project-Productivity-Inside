using UnityEngine;
using UnityEngine.Events;

public class InteractableEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _onClick;

    public UnityEvent onClick => _onClick;
}
