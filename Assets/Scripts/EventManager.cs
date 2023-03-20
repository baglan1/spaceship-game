using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate OnStartGame;
    public static StartGameDelegate OnPlayerDeath;

    public delegate void TakeDamageDelegate(float percentage);
    public static TakeDamageDelegate OnTakeDamage;

    public static void StartGame() {
        if (OnStartGame != null) {
            OnStartGame();
        }
    }

    public static void TakeDamage(float percentage) {
        if (OnTakeDamage != null) {
            OnTakeDamage(percentage);
        }
    }

    public static void PlayerDeath() {
        if (OnPlayerDeath != null) {
            OnPlayerDeath();
        }
    }
}
