using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDirectionAdjuster : MonoBehaviour, IDragHandler
{
    [SerializeField] private DiscAimer target;

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.delta;
        target.Rotate(delta);
    }
}
