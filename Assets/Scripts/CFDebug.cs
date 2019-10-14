using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CFDebug : MonoBehaviour {

    List<CFDebugObject> debugObjects = new List<CFDebugObject>();

    public Vector2 startingPosition = new Vector2(10,10);
    public int verticalSpacing = 30;
    public int horizontalSpacing = 300;
    public int labelHeight = 20;
    public int labelWidth = 100;

    public int fontSize = 25;
    public Color fontColor = Color.white;

    public bool showBox = true;

    public int padding = 40;

    private GUIStyle gUIStyle = new GUIStyle();


	private void OnGUI()
	{
        int numDebugObjects = debugObjects.Count;
        int currentIteration = 0;

        gUIStyle.fontSize = fontSize;
        gUIStyle.normal.textColor = fontColor;

        if (showBox)
        {

            GUI.Box(new Rect(startingPosition.x, startingPosition.y, labelWidth * 2 + horizontalSpacing + (padding * 2), debugObjects.Count * (verticalSpacing + labelHeight) + (padding * 2)), "CFDebug Ver 1.0");
        }

        foreach (CFDebugObject d in debugObjects) {

            string desc = d.description;
            string val = d.value;

            int yPos = (int)startingPosition.y + padding + ((verticalSpacing + labelHeight) * currentIteration);

            GUI.Label(new Rect(startingPosition.x + padding, yPos, labelWidth, labelHeight), desc, gUIStyle);
            GUI.Label(new Rect(labelWidth + horizontalSpacing, yPos, labelWidth, labelHeight), val, gUIStyle);

            currentIteration++;
        }


	}

    public void Add (string description, string value, string label) {

        CFDebugObject debugObject = new CFDebugObject();

        debugObject.description = description;
        debugObject.value = value;
        debugObject.label = label;

        //- Find if an object with the specified label already exists
        int index = debugObjects.FindIndex(x => x.label == label);

        if (index != -1) {

            //- The item was found
            debugObjects.RemoveAt(index);
            debugObjects.Insert(index, debugObject);
        
        } else {

            //- The item doesn't exist
            debugObjects.Add(debugObject);
        }

    }

    public void Clear () {

        debugObjects.Clear();
    
    }

    public int NextLocation () {

        int numObjects = debugObjects.Count;

        return numObjects;
    }
}

public class CFDebugObject : MonoBehaviour {

    public string description;
    public string value;
    public string label;
}