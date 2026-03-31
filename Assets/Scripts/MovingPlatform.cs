using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Hello!")]
    [SerializeField]
    private float platformSpeed;
    [SerializeField]
    private Vector3 globalStartLocation;
    [SerializeField]
    private Vector3 globalEndLocation;

    enum Mode
    {
        PingPong,
        Sine,
        Square
    }

    [Tooltip("Type of oscillating motion."), SerializeField]
    private Mode mode;

    private float m_movingProgress;

    void Update()
    {
        float interpolation;
        switch (mode)
        {
            case Mode.Sine:
                interpolation = (1f + Mathf.Sin(m_movingProgress * Mathf.PI * 2f)) / 2f;
                break;
            case Mode.PingPong:
                interpolation = Mathf.PingPong(m_movingProgress, 0.5f);
                break;
            case Mode.Square:
                interpolation = ((m_movingProgress % 1f) > 0.5f) ? 1f : 0f;
                break;
            default:
                interpolation = 0f;
                break;
        }
        transform.position = Vector3.Lerp(globalStartLocation, globalEndLocation, interpolation);
        m_movingProgress += Time.deltaTime * platformSpeed;
        
    }
}
