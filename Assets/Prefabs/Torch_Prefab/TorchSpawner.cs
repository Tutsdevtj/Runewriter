using UnityEngine;
using UnityEngine.Tilemaps;

public class TorchSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase torchTile;
    public GameObject torchPrefab; 

    void Start()
    {
        if (tilemap == null || torchTile == null || torchPrefab == null)
        {
            Debug.LogWarning("TorchSpawner");
            return;
        }

        BoundsInt bounds = tilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(pos);
            if (tile == torchTile)
            {
                Vector3 worldPos = tilemap.GetCellCenterWorld(pos);
                Instantiate(torchPrefab, worldPos, Quaternion.identity, transform);
            }
        }
    }
}
