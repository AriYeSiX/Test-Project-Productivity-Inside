using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerScriptableObject _playerData;

    public PlayerScriptableObject playerData => _playerData;

    [SerializeField] private NavMeshAgent _playerAgent;

    public InteractableEvent _interactableQueue;
    
    private NavMeshPath _playerPath;

    [SerializeField] private Text healthText;

    [SerializeField] private Text ExperienceText;

    [SerializeField] private bool _canInteract;

    public bool canInteract
    {
        get => _canInteract;
        set => _canInteract = value;
    }

    private void Awake()
    {
        healthText = GameObject.Find("Health").GetComponent<Text>();
        ExperienceText = GameObject.Find("Experience").GetComponent<Text>();
    }

    private void Start()
    { 
        _playerData.playerData[0].health = _playerData.playerData[0].MaxHealth;
    }

    private void Update()
    {
        healthText.text = "Health: " + _playerData.playerData[0].health + " / " +_playerData.playerData[0].MaxHealth;
        ExperienceText.text = "Experience: " + _playerData.playerData[0].experience;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.currentSelectedGameObject)
            {
                _playerPath = new NavMeshPath();
                if (_playerAgent.CalculatePath(hit.point, _playerPath))
                {
                    _playerAgent.SetPath(_playerPath);
                }

                if (canInteract)
                {
                    InteractableEvent _interactable = hit.collider.GetComponent<InteractableEvent>();
                    _interactableQueue = _interactable;
                }
            }
        }

        if (!_playerAgent.hasPath && _interactableQueue)
        {
            _interactableQueue.onClick.Invoke();
            _interactableQueue = null;
        }
    }
}
