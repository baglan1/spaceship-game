using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{   
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject mainMenu;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject playerSpawnPosition;

    void Start() {
        ShowMainMenu();
    }

    void OnEnable() {
        EventManager.OnStartGame += ShowGameUI;
        EventManager.OnPlayerDeath += ShowMainMenu;
    }

    void OnDisable(){
        EventManager.OnStartGame -= ShowGameUI;
        EventManager.OnPlayerDeath -= ShowMainMenu;
    }

    void ShowMainMenu() {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    void ShowGameUI() {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);

        Instantiate(playerPrefab, playerSpawnPosition.transform.position, playerSpawnPosition.transform.rotation);
    }
}
