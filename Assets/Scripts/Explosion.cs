using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject blowUpPrefab;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] float hitModifier = 5f;
    [SerializeField] Shield shield;

    public void Hit(Vector3 hitPos) {
        var explosionGo = Instantiate(explosion, hitPos, Quaternion.identity, transform);
        Destroy(explosionGo, 6f);

        if (shield != null) shield.TakeDamage();
    }

    void OnCollisionEnter(Collision collision) {
        foreach(var contactPoint in collision.contacts) {
            Hit(contactPoint.point);
        }
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource) {
        if (rigidBody == null)
            return;

        Hit(hitPosition);

        Vector3 direction = hitSource.position - hitPosition;
        rigidBody.AddForceAtPosition(direction.normalized * hitModifier, hitPosition, ForceMode.Impulse);
    }

    public void BlowUp() {
        Instantiate(blowUpPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
