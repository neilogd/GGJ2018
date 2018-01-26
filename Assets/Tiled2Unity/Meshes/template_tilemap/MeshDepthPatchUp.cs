using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDepthPatchUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var meshFilter = gameObject.GetComponent<MeshFilter>();
        var mesh = meshFilter.mesh;




        var layer = GetComponentInParent<Tiled2Unity.TileLayer>();
        var map = GetComponentInParent<Tiled2Unity.TiledMap>();


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
