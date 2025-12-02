using UnityEngine;
using UnityEngine.Tilemaps;

public class BonfireSpawner : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase bonfireTile;
    public GameObject bonfirePrefab;

    void Start()
    {
        BoundsInt area = tilemap.cellBounds;

        foreach (var pos in area.allPositionsWithin)
        {
            var tile = tilemap.GetTile(pos);
            if (tile == bonfireTile)
            {
                Vector3 world = tilemap.GetCellCenterWorld(pos);
                Instantiate(bonfirePrefab, world, Quaternion.identity);

                tilemap.SetTile(pos, null);
            }
        }
    }
}

