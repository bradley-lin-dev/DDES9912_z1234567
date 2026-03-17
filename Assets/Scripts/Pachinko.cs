using UnityEngine;

public class Pachinko : MonoBehaviour {
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
    void Start() {
        m_balls = ballReservoirParent.GetComponentsInChildren<Rigidbody>(false);
    }

    // Update is called once per frame
    public void LaunchBall() {
        if (ballLauncherSelector.selectedBall != null) {
            ballLauncherSelector.selectedBall.GetComponent<Rigidbody>().MovePosition(launchTransform.position);
            ballLauncherSelector.selectedBall.GetComponent<Rigidbody>().linearVelocity = Vector3.up * launchSpeed;
            ballLauncherSelector.selectedBall = null;
            Physics.SyncTransforms();
        }
    }
}
