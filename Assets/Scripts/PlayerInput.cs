using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] LaserController[] lasers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            for (int i = 0; i < lasers.Length; i++) {
                lasers[i].FireLaser();
            }
        }
    }
}
