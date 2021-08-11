using UnityEngine;


public class Experience : Interactable
{
    [SerializeField] private int experienceGain;

    [SerializeField] private Player _player;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    public override void Interactive()
    {
        base.Interactive();
        _player.playerData.playerData[0].experience += experienceGain;
    }
}
