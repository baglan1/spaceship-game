using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate OnStartGame;
    public static StartGameDelegate OnPlayerDeath;
    public static StartGameDelegate OnSpawnPickUp;

    public delegate void TakeDamageDelegate(float percentage);
    public static TakeDamageDelegate OnTakeDamage;

    public delegate void ScorePointsDelegate(int amount);
    public static ScorePointsDelegate OnScorePoints;

    public static void StartGame() {
        if (OnStartGame != null) {
            OnStartGame();
        }
    }

    public static void SpawnPickUp() {
        if (OnSpawnPickUp != null) {
            OnSpawnPickUp();
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

    public static void ScorePoints(int amount) {
        if (OnScorePoints != null) {
            OnScorePoints(amount);
        }
    }
}
