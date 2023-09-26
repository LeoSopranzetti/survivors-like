using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector2Int currentTilePosition;
    [SerializeField] Vector2Int playerTilePosition;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrainTiles;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Update()
    {
        playerTilePosition.x = (int) (playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}
