using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIAfterThrow : UIComponent
{
    [SerializeField] private Button throwAgainBtn, moveToTieBtn;
    [SerializeField] private GameObject outOfBoundNoti;

    public void RegisterThrowAgainClick(UnityAction callback){
        this.throwAgainBtn.onClick.AddListener(callback);
    }

    public void RegisterMoveToTieClick(UnityAction callback){
        this.moveToTieBtn.onClick.AddListener(callback);
    }

    public void RemoveCallbacks(){
        this.throwAgainBtn.onClick.RemoveAllListeners();
        this.moveToTieBtn.onClick.RemoveAllListeners();
    }

    private void OnEnable()
    {
        var disc = DiscSelector.Instance.SelectedDisc;
        var discInWater = Singleton<WaterBox>.Instance.IsInsideWater(disc.GetComponent<Collider>());
        this.throwAgainBtn.gameObject.SetActive(
            !discInWater);
        this.moveToTieBtn.GetComponentInChildren<TMP_Text>().text = discInWater ? "Throw Again" : "Move To Tie";
        this.outOfBoundNoti.gameObject.SetActive(discInWater);
    }
}
