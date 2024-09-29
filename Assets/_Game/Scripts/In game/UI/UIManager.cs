using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake(){
        Instance = this;

        this.UIMoveDisc.Init();
    }
    public UIPreThrow UIPreThrow;
    public UIAfterThrow UIAfterThrow;
    public UISessionComplete UISessionComplete;
    public UIMainMenu UIMainMenu;
    public UIDirectionAdjuster UIDirectionAdjuster;
    public UIDiscSelector UIDiscSelector;
    public UIThrowSelector UIThrowSelector;
    public UIMoveDisc UIMoveDisc;
}
