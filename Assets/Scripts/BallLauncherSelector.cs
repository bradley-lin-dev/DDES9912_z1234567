using UnityEngine;

public class BallLauncherSelector : MonoBehaviour
{
    [SerializeField]
    LayerMask ballLayer;

    public GameObject selectedBall;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("testL " + other.name + ". " + ballLayer.value + ", " + other.gameObject.layer);
        if ((ballLayer.value & (1 << other.gameObject.layer)) != 0u)
        {
            selectedBall = other.gameObject;
        }
    }
}
