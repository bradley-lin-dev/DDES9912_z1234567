using UnityEngine;

public class ItemChanceSpawner : MonoBehaviour
{
    [Header("Spawn Item Information")]
    public GameObject template; // Should be coin for lottery winnings.
    public Transform spawnPoint;
    public GameObject lastObject;
    public Vector3 randomPositionOffset;
    [Space(2.0f)]
    public bool parent2SpawnPoint = false;

    [Header("Spawn Chance Rules")]
    [Range(0f, 1f)]
    public float spawnChance = 0.1f;
    public uint spawnCount = 5;


    private void Start()
    {
        // Ensure spawn point exists before teleporting self to it.
        if (spawnPoint == null)
            spawnPoint = transform;
    }

    // Create the template object in the given location.
    public void Spawn()
    {
        if (Random.value <= spawnChance)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                // Randomly change spawn location for more realistic effect.
                Vector3 offset = new Vector3(
                    Random.Range(-randomPositionOffset.x, randomPositionOffset.x),
                    Random.Range(-randomPositionOffset.y, randomPositionOffset.y),
                    Random.Range(-randomPositionOffset.y, randomPositionOffset.y)
                    );

                lastObject = Instantiate(template, spawnPoint.position + offset, spawnPoint.rotation);

                if (parent2SpawnPoint)
                {
                    lastObject.transform.parent = spawnPoint;
                }
            }
            
        }
        
    }

    public void DetatchSpawPointChildren()
    {
        foreach (Transform child in spawnPoint)
        {
            child.transform.parent = null;
        }
    }
}
