using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    [SerializeField] RectTransform barRectTransform;

    float maxWidth;

    void Start() {
        maxWidth = barRectTransform.rect.width;
    }

    void OnEnable() {
        EventManager.OnTakeDamage += UpdateShieldDisplay;
    }

    void OnDisable() {
        EventManager.OnTakeDamage -= UpdateShieldDisplay;
    }

    void UpdateShieldDisplay(float percentage) {
        barRectTransform.sizeDelta = new Vector2(percentage * maxWidth , 30f);
    }
}
