using UnityEngine;

public class PaperShifter : MonoBehaviour
{

    [SerializeField]
    Transform target;

    [SerializeField]
    Transform realPaper;

    [SerializeField]
    float paperShiftDisplacement;

    [SerializeField]
    float paperSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionDifference = target.position - realPaper.position;
        realPaper.position += positionDifference.normalized * Mathf.Min(paperSpeed * Time.deltaTime, positionDifference.magnitude);
    }

    public void ShiftPaper()
    {
        target.position += Vector3.up * paperShiftDisplacement;
    }
}
