using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float angularSpeed = 10f;
    [SerializeField]
    private Vector3 angularAxis = Vector3.up;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation *= Quaternion.AngleAxis(angularSpeed * Time.deltaTime, angularAxis);
    }
}
