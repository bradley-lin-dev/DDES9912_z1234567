using UnityEngine;

public class CarouselBobbing : MonoBehaviour
{
    [SerializeField]
    private Vector3 bobbingOffset = Vector3.up;
    [SerializeField]
    private float bobbingSpeed = 0.1f;
    private float m_bobbingTimeOffset;
    private Vector3 m_originalLocalPosition;
    private float m_elapsedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_originalLocalPosition = transform.localPosition;
        m_bobbingTimeOffset = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = m_originalLocalPosition + bobbingOffset * Mathf.Sin(((bobbingSpeed * m_elapsedTime) + m_bobbingTimeOffset) * 2f * Mathf.PI);
        m_elapsedTime += Time.deltaTime;
    }
}
