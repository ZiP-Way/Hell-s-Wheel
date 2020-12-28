using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private GameObject player;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if(eventData.delta.x > 0)
            {
                player.GetComponent<WheelController>().MoveRight();
            }
            else
            {
                player.GetComponent<WheelController>().MoveLeft();
            }
        }
        else
        {
            if (eventData.delta.y > 0)
            {
                player.GetComponent<WheelController>().MoveUp();
            }
            else
            {
                player.GetComponent<WheelController>().MoveDown();
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
