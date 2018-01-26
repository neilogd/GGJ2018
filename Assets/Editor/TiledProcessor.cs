using System.Collections.Generic;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
public class TiledProcessor : Tiled2Unity.ICustomTiledImporter
{

    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {
        if (customProperties.ContainsKey("Behaviour"))
        {
            Debug.Log(customProperties.Count);
            if (customProperties["Behaviour"] == "Spinning")
            {
                CustomBehaviour customBehaviour = gameObject.AddComponent<Spinning>();
                customBehaviour.Import(customProperties);
            }
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