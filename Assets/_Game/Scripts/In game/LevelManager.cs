using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private List<LevelSession> sessionList;
    [SerializeField] private LevelSession currentSessionInfo;
    private int currentSession;
    private int currentThrow;
    private UnityAction OnLevelComplete;

    public LevelSession CurrentSessionInfo => this.currentSessionInfo;

    private void Awake(){
        Instance = this;
        UIManager.Instance.UIDiscSelector.ShowUI();
        UIManager.Instance.UIThrowSelector.ShowUI();
        this.StartSession(0);
    }

    public void StartSession(int index){
        this.currentSession = index;
        this.currentSessionInfo = sessionList[index];
        this.currentThrow = 0;
    }

    public void RegisterLevelCompleteCallback(UnityAction callback){
        this.OnLevelComplete += callback;
    }

    public void NextSession(){
        if(currentSession == sessionList.Count - 1) return;
        this.currentSessionInfo.throwTarget.gameObject.SetActive(false);
        StartSession(currentSession + 1);
        this.currentSessionInfo.throwTarget.gameObject.SetActive(true);
    }

    private void LevelComplete(){
        UIManager.Instance.UILevelComplete.ShowUI();
    }

    public void IncreaseThrow() => this.currentThrow++;
}   
[System.Serializable]
public class LevelSession{
    public ThrowTarget throwTarget;
    public Transform startInfo;
    public int par;
}
