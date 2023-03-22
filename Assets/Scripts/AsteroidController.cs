using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] float minScale;
    [SerializeField] float maxScale;
    [SerializeField] float rotationOffset;

    public static float destructionDelay = 1f;
    Transform _transform;
    Vector3 randomRotation;

    // Start is called before the first frame update
    void Start()
    {
        _transform = this.transform;
        
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

        transform.localScale = scale;

        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Rotate(randomRotation * Time.deltaTime);
    }
    
    public void SelfDestruct() {
        var timer = Random.Range(0f, destructionDelay);

        Invoke("GoBoom", timer);
    }

    void GoBoom() {
        GetComponent<Explosion>().BlowUp();
    }
}
