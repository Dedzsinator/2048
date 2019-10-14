using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public int tileValue;
    public bool mergedThisTurn;

    public Vector2 startingPosition;
    public Vector2 moveToPosition;

    public bool DestroyMe = false;

    public Transform collidingTile;

    public bool willMergeWithCollidingTile;

}
