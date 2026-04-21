using UnityEngine;

public class CopyTransform : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float translationSpeed;

    [SerializeField]
    float angularSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionDifference = target.position - transform.position;
        transform.position += positionDifference.normalized * Mathf.Min(translationSpeed * Time.deltaTime, positionDifference.magnitude);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, angularSpeed * Time.deltaTime);
    }
}
