using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float platformSpeed;
    [SerializeField]
    private Vector3 globalStartLocation;
    [SerializeField]
    private Vector3 globalEndLocation;

    private float m_movingProgress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(globalStartLocation, globalEndLocation, Mathf.PingPong(m_movingProgress, 1f));
        m_movingProgress += Time.deltaTime * platformSpeed;
        
    }
}
