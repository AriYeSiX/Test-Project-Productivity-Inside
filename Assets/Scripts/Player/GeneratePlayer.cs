using UnityEngine;

public class GeneratePlayer : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Player playerScript;
    private void Awake()
    {
        GameObject newPlayer = Instantiate(_player);
        newPlayer.name = "Player";
        playerScript = _player.GetComponent<Player>();
        newPlayer.transform.position = playerScript.playerData.playerData[0].playerPosition;
    }
}
