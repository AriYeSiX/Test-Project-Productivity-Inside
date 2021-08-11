using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    [SerializeField] private Player _player;
    [SerializeField] private string _sceneName;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public override void Interactive()
    {
        base.Interactive();
        var position = GameObject.Find("Player").transform.position;
        _player.playerData.playerData[0].playerPosition = new Vector3(position.x,position.y,position.z);
        SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
    }
}
