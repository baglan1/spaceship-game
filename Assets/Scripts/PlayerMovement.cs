using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 10f;

    [SerializeField]
    float turningSpeed = 60f;

    [SerializeField]
    Thruster[] thrusters;

    Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Turn();
    }

    void Turn() {
        float yaw = turningSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = -turningSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = -turningSpeed * Time.deltaTime * Input.GetAxis("Roll");

        _transform.Rotate(pitch, yaw, roll);
    }

    void Thrust() {
        if (Input.GetAxis("Vertical") > 0f) {
            _transform.position += _transform.forward * movementSpeed * Time.deltaTime 
                * Input.GetAxis("Vertical");   

            for(int i = 0; i < thrusters.Length; i++) {
                thrusters[i].SetInstensity(Input.GetAxis("Vertical"));
            }
        }
    }
}
