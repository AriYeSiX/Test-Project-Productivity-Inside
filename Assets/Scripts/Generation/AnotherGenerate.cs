using UnityEngine;

public class AnotherGenerate : MonoBehaviour
{
    [SerializeField] private SpawnScriptableObjects _spawnObjects;

    private void Awake()
    {
        for (int i = 0; i < _spawnObjects.spawnDatas.Length; i++)
        {
            _spawnObjects.spawnDatas[i].spot = GameObject.Find("SpecialPostament"+i);
            var spotPosition = _spawnObjects.spawnDatas[i].spot.transform.position;
            GameObject newInteract = Instantiate(_spawnObjects.spawnDatas[i].interactableObjects,
                new Vector3(spotPosition.x,spotPosition.y+1,spotPosition.z),Quaternion.identity);
            newInteract.name = "Интерактивный особый Объект " + i;
        }
    }
}
