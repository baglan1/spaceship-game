using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject playButtonGO;

    bool isDisplayed = true;

    void OnEnable() {
        EventManager.OnStartGame += HidePanel;
    }

    void OnDisable(){
        EventManager.OnStartGame -= HidePanel;
    }

    void HidePanel() {
        isDisplayed = !isDisplayed;

        playButtonGO.SetActive(isDisplayed);
    }

    public void PlayGame() {
        EventManager.StartGame();
    }
}
