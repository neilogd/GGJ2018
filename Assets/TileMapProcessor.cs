using System.Collections;
using System.Collections.Generic;
using Tiled2Unity;
using UnityEngine;

public class TileMapProcessor : MonoBehaviour {

    public GameObject map;

	// Use this for initialization
	void Start () {
        var objects = map.GetComponentsInChildren<TmxObject>();
        foreach (var obj in objects)
        {
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
