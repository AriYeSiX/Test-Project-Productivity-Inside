using UnityEngine;

public enum InteractableType
{
    ObjectView,
    ObjectKiller,
    Experience,
    ObjectDestroy,
    Door,
    SpecialObject,
}

public class Interactable : MonoBehaviour
{
    public InteractableType _interactableType;
    
    public virtual void Interactive()
    {
        switch (_interactableType)
        {
            case InteractableType.ObjectView:
                print("Вывожу описание объекта");
                break;
            case InteractableType.ObjectDestroy:
                print("Разрушаю объект");
                break;
            case InteractableType.ObjectKiller:
                print("Наношу урон");
                break;
            case InteractableType.Experience:
                print("Даю опыт");
                break;
            case InteractableType.Door:
                print("Телепортирую");
                break;
            case InteractableType.SpecialObject:
                print("Опыта больше 500");
                break;
            default:
                break;
        }
    }    
    
}
