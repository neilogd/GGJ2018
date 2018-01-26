using System.Collections.Generic;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
public class TiledProcessor : Tiled2Unity.ICustomTiledImporter
{

    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {
        System.Console.WriteLine(customProperties.Keys);
        if (customProperties.ContainsKey("Terrain"))
        {
            // Add the terrain tile game object
            // StrategyTile tile = gameObject.AddComponent<StrategyTile>();
            // tile.TileType = customProperties["Terrain"];
            // tile.TileNote = customProperties["Note"];
        }
    }

    public void CustomizePrefab(GameObject prefab)
    {
    }
}