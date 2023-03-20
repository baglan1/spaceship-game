using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerUI;

    float timePassed;
    bool keepTime;

    void OnEnable() {
        EventManager.OnStartGame += StartTimer;
        EventManager.OnPlayerDeath += StopTimer;
    }

    void OnDisable() {
        EventManager.OnStartGame -= StartTimer;
        EventManager.OnPlayerDeath -= StopTimer;
    }

    void Update() {
        if (keepTime) {
            timePassed += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    void StartTimer() {
        timePassed = 0f;
        keepTime = true;
    }

    void StopTimer() {
        keepTime = false;
    }

    void UpdateTimerUI() {
        int minutes = Mathf.FloorToInt(timePassed / 60f);
        float seconds = timePassed % 60f;

        timerUI.text = string.Format("{0}:{1:00.00}", minutes, seconds);
    }
}
