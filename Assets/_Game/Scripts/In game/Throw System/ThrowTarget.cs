using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTarget : MonoBehaviour
{
    [SerializeField] private BoxCollider basketArea;
    [SerializeField] private LayerMask mask;
    
    public bool IsInBasket(Disc disc){
        var colliders = Physics.OverlapBox(basketArea.center, VectorUtils.Multiply(basketArea.size, basketArea.transform.lossyScale) / 2, basketArea.transform.rotation, mask);
        foreach(var col in colliders){
            var d = col.GetComponent<Disc>();
            if(disc == d) return true;
        }
        return false;
    }
}
