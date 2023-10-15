using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject Handle;

    [SerializeField] float MoveRadius;

    static JoystickController instance;
    //Ссылка на джойстик

    public static Vector2 Position
    {
        get //Это называется геттер. Код ниже будет выполняться, когда мы считываем значение свойства
        {
            return (instance.Handle.transform.position - instance.gameObject.transform.position).normalized;
        }
        //При считывании значения позиции ручки, возвращаем нормализованное направление от ручки до центра
    }


    private void Start()
    {
        instance = this;
        //В ссылку закидываем этот джойстик
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 inputPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        Vector3 offset = inputPosition - gameObject.transform.position;

        offset = new Vector3(offset.x, offset.y, 0);
        Handle.gameObject.transform.position = gameObject.transform.position + Vector3.ClampMagnitude(offset, MoveRadius);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Handle.gameObject.transform.localPosition = Vector3.zero;
    }
}
