using UnityEngine;

[CreateAssetMenu(fileName = "Spawn objects", menuName = "Spawn objects", order = 52)]
public class SpawnScriptableObjects : ScriptableObject
{
    [SerializeField] private SpawnData[] _spawnDatas;
    
    public SpawnData[] spawnDatas => _spawnDatas;
}
