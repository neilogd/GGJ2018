using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
public class TiledProcessor : Tiled2Unity.ICustomTiledImporter
{
    Dictionary<String, Type> behaviourTypes;
    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {
        if (behaviourTypes == null)
        {
            var test = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                from assemblyType in domainAssembly.GetTypes()
                where typeof(CustomBehaviour).IsAssignableFrom(assemblyType)
                select assemblyType).ToArray();
            behaviourTypes = new Dictionary<string, Type>();
            foreach (var t in test)
            {
                if (t.Name == "CustomBehaviour")
                    continue;
                behaviourTypes.Add(t.Name, t);
            }
        }
        if (customProperties.ContainsKey("Behaviour"))
        {
            String behaviour = customProperties["Behaviour"];
            if (behaviourTypes.ContainsKey(behaviour))
            {
                CustomBehaviour customBehaviour = (CustomBehaviour)gameObject.AddComponent(behaviourTypes[customProperties["Behaviour"]]);
                customBehaviour.Import(customProperties);
            }
            else
            {
                Debug.LogErrorFormat("CustomBehaviour {0} not defined", behaviour);
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