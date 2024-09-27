using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIThrowSelector : MonoBehaviour
{
    [SerializeField] private Button openBtn;
    [SerializeField] private Button btnDriveMode, btnPuttMode;
    [SerializeField] private GameObject panel;

    private void Awake(){
        openBtn.onClick.AddListener(TogglePanel);
        this.btnDriveMode.onClick.AddListener(this.DriveModeButtonClick);
        this.btnPuttMode.onClick.AddListener(this.PuttModeButtonClick);
        this.gameObject.SetActive(false);
    }

    public void ShowUI(){
        this.gameObject.SetActive(true);
    }

    public void HideUI(){
        this.gameObject.SetActive(false);
    }

    public void TogglePanel(){
        this.panel.gameObject.SetActive(!this.panel.activeSelf);
    }

    private void DriveModeButtonClick(){
        this.TogglePanel();
        DiscSelector.Instance.SetThrowerDrive();
    }
    private void PuttModeButtonClick(){
        this.TogglePanel();
        DiscSelector.Instance.SetThrowerPutt();
    }
}
