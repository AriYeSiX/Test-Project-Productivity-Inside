using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Player Data", order = 51)]
public class PlayerScriptableObject : ScriptableObject
{
   [SerializeField] private PlayerData[] _playerData;

   public PlayerData[] playerData => _playerData;
}
