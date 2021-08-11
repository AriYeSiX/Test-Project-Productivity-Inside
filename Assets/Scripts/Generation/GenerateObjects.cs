using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateObjects : MonoBehaviour
{
    [SerializeField] private SpawnScriptableObjects[] _spawnObjects;

    [SerializeField] private List<GameObject> randomObjects;

    [SerializeField] private int randomiser;
    
    private void Awake()
    {
        for (int i = 0; i < _spawnObjects[1].spawnDatas.Length; i++)
        {
            _spawnObjects[1].spawnDatas[i].spot = GameObject.Find("SpecialPostament"+i);
            var spotPosition = _spawnObjects[1].spawnDatas[i].spot.transform.position;
            GameObject newInteract = Instantiate(_spawnObjects[1].spawnDatas[i].interactableObjects,
                new Vector3(spotPosition.x,spotPosition.y+2,spotPosition.z),Quaternion.identity);
            newInteract.name = "Интерактивный особый Объект " + i;
        }
        
        while (randomObjects.Count < _spawnObjects[0].spawnDatas.Length)
        {
            randomiser = Random.Range(0, _spawnObjects[0].spawnDatas.Length);
            if (!randomObjects.Contains(_spawnObjects[0].spawnDatas[randomiser].interactableObjects))
            {
                randomObjects.Add(_spawnObjects[0].spawnDatas[randomiser].interactableObjects);
            }
        }
        
        for (int i = 0; i < randomObjects.Count; i++)
        {
            _spawnObjects[0].spawnDatas[i].spot = GameObject.Find("Postament"+i);
            var spotPosition = _spawnObjects[0].spawnDatas[i].spot.transform.position;
            GameObject newInteract = Instantiate(randomObjects[i],
                new Vector3(spotPosition.x,spotPosition.y+1,spotPosition.z),Quaternion.identity);
            newInteract.name = "Интерактивный Объект " + i;
        }
    }
}
