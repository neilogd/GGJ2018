using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
    public void Import(IDictionary<string, string> customProperties)
    {
        var type = this.GetType();
        var fields = type.GetFields();

        foreach (var kvp in customProperties)
        {
            if (kvp.Key == "Behaviour")
                continue;
            var field = fields.Where(u => u.Name == kvp.Key).SingleOrDefault();
            if (field == null)
            {
                Debug.Log("No field found: " + kvp.Key);
                continue;
            }
            var myType = field.FieldType;
            if (myType == typeof(string))
            {
                field.SetValue(this, kvp.Value);
            }
            else if (myType == typeof(float))
            {
                try
                {
                    Debug.Log(float.Parse(kvp.Value));
                    field.SetValue(this, float.Parse(kvp.Value));
                }
                catch
                {
                    Debug.LogErrorFormat("Could not convert {0} to float on property {1}", kvp.Value, kvp.Key);
                }
            }
            else if (myType == typeof(bool))
            {
                try
                {
                    field.SetValue(this, bool.Parse(kvp.Value));
                }
                catch
                {
                    Debug.LogErrorFormat("Could not convert {0} to bool on property {1}", kvp.Value, kvp.Key);
                }
            }
            else if (myType == typeof(int))
            {
                try
                {
                    field.SetValue(this, int.Parse(kvp.Value));
                }
                catch 
                {
                    Debug.LogErrorFormat("Could not convert {0} to int on property {1}", kvp.Value, kvp.Key);
                }
            }
            else
            {
                Debug.LogErrorFormat("Could not load type {0} into {1}", myType, kvp.Key);
            }
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
