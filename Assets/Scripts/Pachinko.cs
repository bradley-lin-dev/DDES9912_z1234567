using UnityEngine;

public class Pachinko : MonoBehaviour
{
    [SerializeField]
    GameObject ballReservoirParent;

    Rigidbody[] m_balls;

    [SerializeField]
    Transform launchTransform;

    [SerializeField]
    float launchSpeed;

    [SerializeField]
    BallLauncherSelector ballLauncherSelector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_balls = ballReservoirParent.GetComponentsInChildren<Rigidbody>(false);
    }

    // Update is called once per frame
    public void LaunchBall()
    {
        ballLauncherSelector.selectedBall.GetComponent<Rigidbody>().position = launchTransform.position;
        ballLauncherSelector.selectedBall.GetComponent<Rigidbody>().linearVelocity = Vector3.up * launchSpeed;
    }
}
