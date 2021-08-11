using System.Collections.Generic;
using UnityEngine;
public class ObjectDestroy : Interactable
{
    [SerializeField] private int _clickCount;

    [SerializeField] private List<GameObject> _destroyableObjects;

    private void Awake()
    {
        
        for (int i = 0; i < _clickCount; i++)
        {
            var parentPosition = transform.position;
            _destroyableObjects.Add(Instantiate(Resources.Load<GameObject>("Prefabs/Destroyable Child"),new Vector3(parentPosition.x,(parentPosition.y+i)*2/2,parentPosition.z), Quaternion.identity));
            _destroyableObjects[i].transform.SetParent(gameObject.transform);
        }
    }

    public override void Interactive()
    {
        if (_destroyableObjects.Count>1)
        {
            base.Interactive();
            Destroy(_destroyableObjects[_destroyableObjects.Count-1]);
            _destroyableObjects.RemoveAt(_destroyableObjects.Count-1);
        }
        else
        {
            base.Interactive();
            Destroy(_destroyableObjects[_destroyableObjects.Count-1]);
            _destroyableObjects.RemoveAt(_destroyableObjects.Count-1);
            Destroy(gameObject);
        }
    }
}
