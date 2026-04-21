using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class TerrainDebugReveal : MonoBehaviour
{
    Terrain m_terrain;

    [SerializeField]
    MeshRenderer targetMesh;

    [SerializeField]
    Transform followTransform;

    [SerializeField]
    TerrainData editableTerrainData;

    [SerializeField]
    float ploughDepth;

    TerrainData m_existingTerrainData;

    void Start()
    {
        m_terrain = GetComponent<Terrain>();
        Debug.Log("Terrain Pos: " + m_terrain.GetPosition());
        m_existingTerrainData = m_terrain.terrainData;
        m_terrain.terrainData = editableTerrainData;
        m_terrain.terrainData.SetAlphamaps(0, 0, m_existingTerrainData.GetAlphamaps(0, 0, m_existingTerrainData.alphamapWidth, m_existingTerrainData.alphamapHeight));
        m_terrain.terrainData.SetHeights(0, 0, m_existingTerrainData.GetHeights(0, 0, m_existingTerrainData.heightmapResolution, m_existingTerrainData.heightmapResolution));
    }

    // Update is called once per frame
    void Update()
    {
        targetMesh.material.SetTexture("_BaseMap", m_terrain.terrainData.alphamapTextures[0]);
        //Debug.Log("Terrain Draw x: " + (int)(m_terrain.terrainData.alphamapWidth * Mathf.InverseLerp(m_terrain.GetPosition().x, m_terrain.GetPosition().x + m_terrain.terrainData.size.x, followTransform.position.x)) + ", Terrain Draw y: " + (int)(m_terrain.terrainData.alphamapHeight * Mathf.InverseLerp(m_terrain.GetPosition().z, m_terrain.GetPosition().z + m_terrain.terrainData.size.z, followTransform.position.z)));

        float xNormalizedPosition = Mathf.InverseLerp(m_terrain.GetPosition().x, m_terrain.GetPosition().x + m_terrain.terrainData.size.x, followTransform.position.x);
        float yNormalizedPosition = Mathf.InverseLerp(m_terrain.GetPosition().z, m_terrain.GetPosition().z + m_terrain.terrainData.size.z, followTransform.position.z);


        float[,,] map = new float[1, 1, 3] { { { 0, 0, 1 } } };
        float[,] heightUnit = new float[1, 1] { { (m_existingTerrainData.GetHeight(
            Mathf.RoundToInt(m_terrain.terrainData.heightmapResolution * xNormalizedPosition),
            Mathf.RoundToInt(m_terrain.terrainData.heightmapResolution * yNormalizedPosition)) - ploughDepth) / m_existingTerrainData.size.y } };
        m_terrain.terrainData.SetHeights(
            Mathf.RoundToInt(m_terrain.terrainData.heightmapResolution * xNormalizedPosition),
            Mathf.RoundToInt(m_terrain.terrainData.heightmapResolution * yNormalizedPosition),
            heightUnit);
        m_terrain.terrainData.SetAlphamaps(
        Mathf.RoundToInt(m_terrain.terrainData.alphamapWidth * xNormalizedPosition),
        Mathf.RoundToInt(m_terrain.terrainData.alphamapHeight * yNormalizedPosition),
        map);
        m_terrain.Flush();
    }
}
