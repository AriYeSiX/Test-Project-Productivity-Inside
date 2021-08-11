using UnityEngine;

public class ObjectKiller : Interactable
{
    [SerializeField] private Player _player;

    [SerializeField] private int _dealtDamage;

    [SerializeField] private GameObject _gameOverWindow;

    private void Awake()
    {
        _gameOverWindow = GameObject.Find("GameOverWindow");
        _gameOverWindow.SetActive(false);
    }

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public override void Interactive()
    {
        base.Interactive();
        _player.playerData.playerData[0].health -= _dealtDamage;

        if (_player.playerData.playerData[0].health <= 0)
        {
            _player.playerData.playerData[0].experience = 0;
            _player.playerData.playerData[0].playerPosition = Vector3.zero;
            _gameOverWindow.SetActive(true);
            Destroy(_player.gameObject);
        }
    }
}
