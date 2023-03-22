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
        EventManager.OnPlayerDeath += DelayedShowMainMenu;
    }

    void OnDisable(){
        EventManager.OnStartGame -= ShowGameUI;
        EventManager.OnPlayerDeath -= DelayedShowMainMenu;
    }

    void ShowMainMenu() {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    void DelayedShowMainMenu() {
        Invoke("ShowMainMenu", AsteroidController.destructionDelay);
    }

    void ShowGameUI() {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);

        Instantiate(playerPrefab, playerSpawnPosition.transform.position, playerSpawnPosition.transform.rotation);
    }
}
