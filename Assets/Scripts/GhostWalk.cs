using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GhostWalk : MonoBehaviour {
    NavMeshAgent agent;
    [SerializeField]
    Transform destination;
    [SerializeField]
    float rotationEasingTau = 16f;

    public bool shouldTraverse;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        agent.destination = destination.position;
        Vector3 lookDirection = (destination.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection - Vector3.Project(lookDirection, -Physics.gravity), -Physics.gravity);
        transform.rotation = Quaternion.Slerp(targetRotation, transform.rotation, Mathf.Exp(-rotationEasingTau * Time.deltaTime));
        agent.isStopped = !shouldTraverse;
    }
}
