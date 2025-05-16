using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelOriginalItemData
{
    public string x;
    public string px;
    public string y;
    public string py;
    public string layer;
}
public class LevelOriginalMainData
{
    public List<LevelOriginalItemData> target;
    public string figureNum;
}
[System.Serializable]
public class LevelItemData
{
    public string px;
    public string py;
    public string layer;
    public string diff_layer;
    public string img_name;
    public Vector2 pos;
    public string layer_name;
    public int layer_order;
    public bool isCashTile;
    public TileAnimationData anmData;
    public bool isRemoving;
}
public class LevelMainData
{
    public List<LevelItemData> target;
    public string figureNum;
}
