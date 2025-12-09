using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public Vector2 Input;
    private Vector2 originalposition;
    private Vector2 lastposition;
    public void OnDrag(PointerEventData data)
    {
        Vector2 dir=data.position - originalposition;
        Input = dir.normalized;
    }
    public void OnPointerDown(PointerEventData data)
    {
        originalposition = transform.position;
        OnDrag(data);
    }
    public void OnPointerUp(PointerEventData data)
    {
        Input = Vector2.zero;
    }
}
