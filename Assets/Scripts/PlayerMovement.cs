using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Thruster[] thrusters;

    [Header("=== Ship Movement Settings ===")]
    [SerializeField] float yawTorque = 500f;
    [SerializeField] float pitchTorque;
    [SerializeField] float rollTorque;
    [SerializeField] float thrust = 100f;
    [SerializeField] float upThrust = 50f;
    [SerializeField] float strafeThrust = 50f;
    [SerializeField, Range(.001f, .999f)]
    float thrustGlideReduction = .999f;
    [SerializeField, Range(.001f, .999f)]
    float upDownGlideReduction = .111f;
    [SerializeField, Range(.001f, .999f)]
    float leftRightGlideReduction = .111f;

    Transform _transform;
    Rigidbody _rigidbody;

    // Input values
    float thrust1D;
    float upDown1D;
    float strafe1D;
    float roll1D;
    Vector2 pitchYaw;
    float glide;
    float verticalGlide;
    float horizontalGlide;

    // Start is called before the first frame update
    void Start()
    {
        _transform = this.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        HandleMovement();
    }

    void HandleMovement() {
        _rigidbody.AddRelativeTorque(Vector3.back * roll1D * rollTorque * Time.deltaTime);
        _rigidbody.AddRelativeTorque(Vector3.right * Mathf.Clamp(-pitchYaw.y, -1f, 1f) * pitchTorque * Time.deltaTime);
        _rigidbody.AddRelativeTorque(Vector3.up * Mathf.Clamp(pitchYaw.x, -1f, 1f) * yawTorque * Time.deltaTime);

        if (thrust1D < -0.1f || thrust1D > 0.1f) {
            float currentThrust = thrust;

            _rigidbody.AddRelativeForce(Vector3.forward * thrust1D * currentThrust * Time.deltaTime);
            glide = thrust;
        } else {
            _rigidbody.AddRelativeForce(Vector3.forward * glide * Time.deltaTime);
            glide *= thrustGlideReduction;
        }

        if (upDown1D < -0.1f || upDown1D > 0.1f) {
            _rigidbody.AddRelativeForce(Vector3.up * upDown1D * upThrust * Time.deltaTime);
            verticalGlide = upDown1D * upThrust;
        } else {
            _rigidbody.AddRelativeForce(Vector3.up * verticalGlide * Time.deltaTime);
            upDown1D *= upDownGlideReduction;
        }

        if (strafe1D < -0.1f || strafe1D > 0.1f) {
            _rigidbody.AddRelativeForce(Vector3.right * strafe1D * strafeThrust * Time.deltaTime);
            horizontalGlide = strafe1D * strafeThrust;
        } else {
            _rigidbody.AddRelativeForce(Vector3.right * horizontalGlide * Time.deltaTime);
            strafe1D *= leftRightGlideReduction;
        }
    }

    #region Input Methods
    public void OnThrust(CallbackContext context) {
        thrust1D = context.ReadValue<float>();
    }

    public void OnStrafe(CallbackContext context) {
        strafe1D = context.ReadValue<float>();
    }

    public void OnUpDown(CallbackContext context) {
        upDown1D = context.ReadValue<float>();
    }

    public void OnRoll(CallbackContext context) {
        roll1D = context.ReadValue<float>();
    }

    public void OnPitchYaw(CallbackContext context) {
        pitchYaw = context.ReadValue<Vector2>();
    }
    #endregion
}
