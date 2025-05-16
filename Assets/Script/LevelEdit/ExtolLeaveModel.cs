using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using LitJson;
using System.IO;
using System.Text.RegularExpressions;
using System;
[Serializable]
public class LevelData
{
    public string x;
    public string He;
    public string y;
    public string It;
    public string Fluke;
}
[Serializable]
public class LimitItem
{
    public int x;
    public int y;
    public bool FictionFifth;
}
[ExecuteInEditMode]
public class ExtolLeaveModel : MonoBehaviour
{
    static ExtolLeaveModel instance;
    float Ideal_x= -0.03f;
    float Ideal_y= -0.15f;
[UnityEngine.Serialization.FormerlySerializedAs("levelDic")]    [UnityEngine.Serialization.FormerlySerializedAs("levelDic")]public Dictionary<string, GameObject> BraveRow;
    List<LimitItem> Canoe_Seem;
[UnityEngine.Serialization.FormerlySerializedAs("full_sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("full_sprite")]public Sprite Song_Ashore;
[UnityEngine.Serialization.FormerlySerializedAs("empty_sprite")]    [UnityEngine.Serialization.FormerlySerializedAs("empty_sprite")]public Sprite Dimly_Ashore;
[UnityEngine.Serialization.FormerlySerializedAs("oddList")]    [UnityEngine.Serialization.FormerlySerializedAs("oddList")]public int[] TugLend= new int[] {0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20};
[UnityEngine.Serialization.FormerlySerializedAs("evenList")]    [UnityEngine.Serialization.FormerlySerializedAs("evenList")]public int[] AiryLend= new int[] {1, 3, 5, 7, 9, 11, 13, 15, 17, 19};
[UnityEngine.Serialization.FormerlySerializedAs("fullCount")]    [UnityEngine.Serialization.FormerlySerializedAs("fullCount")]public int SongGrass= 0;
    Color[] DebutLend= new Color[] {
        new Color(255.0f / 255f ,54.0f/ 255f ,54.0f/ 255f),
        new Color(149.0f/ 255f  ,255.0f/ 255f  ,54.0f/ 255f),
        new Color(54.0f / 255f ,65.0f / 255f ,255.0f/ 255f),
        new Color(255.0f/ 255f ,147.0f/ 255f,54.0f/ 255f),
        new Color(54.0f/ 255f ,255.0f/ 255f  ,161.0f/ 255f),
        new Color(154.0f / 255f ,54.0f / 255f,255.0f/ 255f),
        new Color(255.0f/ 255f  ,232.0f/ 255f  ,54.0f/ 255f),
        new Color(54.0f / 255f ,176.0f / 255f ,255.0f/ 255f),
        new Color(255.0f / 255f,54.0f / 255f,238.0f/ 255f),
    };
    private void Awake()
    {
        Debug.Log("levelLayerGroup Awake");
        instance = this;
        BraveRow = new Dictionary<string, GameObject>();
        Dimly_Ashore = Resources.Load<Sprite>(CConfig.Empty);
        Song_Ashore = Resources.Load<Sprite>(CConfig.Full);
    }

    public void ExtractShinGrass()
    {
        SongGrass = 0;
        foreach (GameObject obj in BraveRow.Values)
        {
            if (obj.GetComponent<SpriteRenderer>().sprite == Song_Ashore)
            {
                SongGrass++;
                //Debug.Log(fullCount);
            }
        }
        
    }
    public static ExtolLeaveModel OakDatebase()
    {
        if (instance == null)
        {
            GameObject obj = GameObject.Find("ExtolLeaveModel");
            if (!obj)
            {
                obj = new GameObject("ExtolLeaveModel");
                instance = obj.AddComponent<ExtolLeaveModel>();
            }
            else
            {
                instance = obj.GetComponent<ExtolLeaveModel>();
            }
        }
        return instance;
    }
    public void LintelLeave(List<LimitItem> limitList)
    {
        Canoe_Seem = new List<LimitItem>(limitList);
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        BraveRow = new Dictionary<string, GameObject>();
        GameObject levelLayerPrefab = Resources.Load<GameObject>(CConfig.PrefabLevelLayer);
        GameObject tileEditItemPrefab = Resources.Load<GameObject>(CConfig.PrefabTileEditItem);
        Vector2 imageSize = WhoWithoutDuckUnit(tileEditItemPrefab);
        int Fluke= 0;
        foreach (LimitItem limit_item in limitList)
        {
            int limit_x = limit_item.x;
            int limit_y = limit_item.y;
            GameObject levelLayer = Instantiate(levelLayerPrefab, transform);
            
            levelLayer.name = "LevelLayer_" + Fluke;
            levelLayer.GetComponent<ExtolLeave>().Dimly_Barn = limit_item.FictionFifth;
            float all_w = Ideal_x * (limit_x - 1) + imageSize.x * limit_x;
            float all_h = Ideal_y * (limit_y - 1) + imageSize.y * limit_y;
            //Debug.Log(all_h);
            for (int y = 0; y < limit_y; y++)
            {
                for (int x = 0; x < limit_x; x++)
                {
                    GameObject tileEditItem = Instantiate(tileEditItemPrefab, levelLayer.transform);
                    float pos_x = -(all_w / 2f) + (Ideal_x + imageSize.x) * x + imageSize.x / 2;
                    float pos_y = (all_h / 2f) - (Ideal_y + imageSize.y) * y  - imageSize.y / 2;
                    tileEditItem.transform.position = new Vector2(pos_x, pos_y);
                    tileEditItem.GetComponent<SpriteRenderer>().sortingOrder = y * limit_x + x;
                    tileEditItem.GetComponent<SpriteRenderer>().sortingLayerName = (Fluke + 1).ToString();
                    //Debug.Log(ColorList[layer]);
                    tileEditItem.GetComponent<SpriteRenderer>().color = DebutLend[Fluke % 9];
                    string key = Fluke + "_" + x + "_" + y;
                    //Debug.Log(key);
                    BraveRow.Add(key, tileEditItem);
                }
            }
            levelLayer.transform.position = new Vector2(0, 0 /** 0.153f*/);
            Fluke++;
        }
        ExtractShinGrass();
    }
    public void OwnLeave(LimitItem item)
    {
        Canoe_Seem.Add(item);
        GameObject levelLayerPrefab = Resources.Load<GameObject>(CConfig.PrefabLevelLayer);
        GameObject tileEditItemPrefab = Resources.Load<GameObject>(CConfig.PrefabTileEditItem);
        GameObject levelLayer = Instantiate(levelLayerPrefab, transform);
        
        Vector2 imageSize = WhoWithoutDuckUnit(tileEditItemPrefab);
        int Fluke= (Canoe_Seem.Count - 1);
        
        levelLayer.name = "LevelLayer_" + Fluke;
        int limit_x = item.x;
        int limit_y = item.y;
        float all_w = Ideal_x * (limit_x - 1) + imageSize.x * limit_x;
        float all_h = Ideal_y * (limit_y - 1) + imageSize.y * limit_y;
        for (int y = 0; y < limit_y; y++)
        {
            for (int x = 0; x < limit_x; x++)
            {

                GameObject tileEditItem = Instantiate(tileEditItemPrefab, levelLayer.transform);
                float pos_x = -(all_w / 2f) + (Ideal_x + imageSize.x) * x+ imageSize.x / 2;
                float pos_y = (all_h / 2f) - (Ideal_y + imageSize.y) * y - imageSize.y / 2;
                tileEditItem.transform.position = new Vector2(pos_x, pos_y);
                tileEditItem.GetComponent<SpriteRenderer>().sortingOrder = y * limit_x + x;
                tileEditItem.GetComponent<SpriteRenderer>().sortingLayerName = (Fluke + 1).ToString();
                tileEditItem.GetComponent<SpriteRenderer>().color = DebutLend[(int)Mathf.Repeat(Fluke,8)];
                string key = Fluke + "_" + x + "_" + y;
                BraveRow.Add(key, tileEditItem);
            }
        }
        levelLayer.transform.position = new Vector2(0, 0);
        ExtractShinGrass();
    }
    public void ClutchLeave()
    {
        LimitItem limit_item = Canoe_Seem[Canoe_Seem.Count - 1];
        int limit_x = limit_item.x;
        int limit_y = limit_item.y;
        for (int y = 0; y < limit_y; y++)
        {
            for (int x = 0; x < limit_x; x++)
            {
                BraveRow.Remove((Canoe_Seem.Count - 1) + "_" + x + "_" + y);
            }
        }
        DestroyImmediate(transform.Find("LevelLayer_" + (Canoe_Seem.Count - 1)).gameObject);
        Canoe_Seem.RemoveAt(Canoe_Seem.Count - 1);
        ExtractShinGrass();
    }
    public void SpringFifthBiter(List<LimitItem> limitList)
    {
        int count = limitList.Count > transform.childCount ? transform.childCount : limitList.Count;
        for (int i = 0; i < count; i++)
        {
            if (limitList[i].FictionFifth != transform.GetChild(i).GetComponent<ExtolLeave>().Dimly_Barn)
            {
                Transform Meaty= transform.GetChild(i);
                Meaty.GetComponent<ExtolLeave>().Dimly_Barn = limitList[i].FictionFifth;
                LimitItem item = Canoe_Seem[i];
                item.FictionFifth = limitList[i].FictionFifth;
                Canoe_Seem[i] = item;
                for (int Boost= 0; Boost < Meaty.childCount; Boost++)
                {
                    Transform itemTrans = Meaty.GetChild(Boost);
                    if (itemTrans.GetComponent<SpriteRenderer>().sprite == null || itemTrans.GetComponent<SpriteRenderer>().sprite == Dimly_Ashore)
                    {
                        itemTrans.GetComponent<SpriteRenderer>().sprite = limitList[i].FictionFifth ? null: Dimly_Ashore;
                    }
                }
                break;
            }
        }
    }
    public Vector2 WhoWithoutDuckUnit(GameObject obj)
    {
        float x = obj.GetComponent<SpriteRenderer>().bounds.extents.x * 2 / obj.transform.lossyScale.x;
        float y = obj.GetComponent<SpriteRenderer>().bounds.extents.y * 2 / obj.transform.lossyScale.y;
        return new Vector2(x, y);
    }
    public void DungExtolFast(string fileName)
    {


        string levelFilepath = Application.streamingAssetsPath + "/LevelJson/Level_" + fileName + ".json";
        levelFilepath = levelFilepath.Replace("StreamingAssets", "Resources");
        FileInfo levelFileInfo = new FileInfo(levelFilepath);
        if (levelFileInfo.Exists)
        {
            StreamReader reader = new StreamReader(levelFilepath);
            string jsonString = reader.ReadToEnd();

            LevelReadJsonData jsonData = JsonMapper.ToObject<LevelReadJsonData>(jsonString);
            List<LevelData> levelDataList =  new List<LevelData>(jsonData.Charge);
            List<string> keyList = new List<string>();
            foreach(LevelData data in levelDataList)
            {
                string key = data.Fluke + "_" + data.x + "_" + data.y;
                keyList.Add(key);
            }
            foreach (string key in BraveRow.Keys)
            {
                if (!keyList.Contains(key))
                {
                    if (Canoe_Seem[int.Parse(key.Split('_')[0])].FictionFifth)
                    {
                        BraveRow[key].GetComponent<SpriteRenderer>().sprite = null;
                    }
                    else
                    {
                        BraveRow[key].GetComponent<SpriteRenderer>().sprite = Dimly_Ashore;
                    }
                }
                else
                {
                    BraveRow[key].GetComponent<SpriteRenderer>().sprite = Song_Ashore;
                }
            }
        }
        ExtractShinGrass();
    }
    public void SakeExtolFast(string fileName,string figureNum)
    {
        string levelFilepath = Application.streamingAssetsPath + "/LevelJson/Level_"+ fileName+ ".json";
        string levelEditFilepath = Application.streamingAssetsPath + "/LevelEditJson/Level_Edit_"+ fileName+ ".json";
        levelEditFilepath = levelEditFilepath.Replace("StreamingAssets", "Resources");
        string levelFileResourcesPath = levelFilepath.Replace("StreamingAssets", "Resources");
        Debug.Log(levelFilepath);
        //FileInfo levelFileInfo = new FileInfo(levelFilepath);

        //if (!levelFileInfo.Exists)
        //{
            
        //    levelFileInfo.Create().Dispose();
        //    levelFileInfo.Refresh();
        //}

        FileInfo levelEditFileInfo = new FileInfo(levelEditFilepath);

        if (!levelEditFileInfo.Exists)
        {
            
            levelEditFileInfo.Create().Dispose();
            levelEditFileInfo.Refresh();
        }

        FileInfo levelFileResourcesInfo = new FileInfo(levelFileResourcesPath);

        if (!levelFileResourcesInfo.Exists)
        {
            levelFileResourcesInfo.Create().Dispose();
            levelFileResourcesInfo.Refresh();
           
        }

        


        List<LevelData> levelDataList = new List<LevelData>();
        for (int Fluke= 0; Fluke < Canoe_Seem.Count; Fluke++)
        {
            LimitItem limit_item = Canoe_Seem[Fluke];
            int limit_x = limit_item.x;
            int limit_y = limit_item.y;
            for (int y = 0; y < limit_y; y++)
            {
                for (int x = 0; x < limit_x; x++)
                {
                    string key = Fluke + "_" + x + "_" + y;
                    if (BraveRow[key].GetComponent<SpriteRenderer>().sprite != Dimly_Ashore && BraveRow[key].GetComponent<SpriteRenderer>().sprite != null)
                    {
                        LevelData Halt= new LevelData();
                        Halt.Fluke = Fluke.ToString();
                        Halt.x = x.ToString();
                        Halt.y = y.ToString();
                        if (limit_x % 2 != 0)
                        {
                            int Boost= (11 - limit_x) / 2;
                            Boost += x;
                            Halt.He = TugLend[Boost].ToString();
                        }
                        else
                        {
                            int Boost= (10 - limit_x) / 2;
                            Boost += x;
                            Halt.He = AiryLend[Boost].ToString();
                        }
                        if (limit_y % 2 != 0)
                        {
                            int Boost= (11 - limit_y) / 2;
                            Boost += y;
                            Halt.It = TugLend[Boost].ToString();
                        }
                        else
                        {
                            int Boost= (10 - limit_y) / 2;
                            Boost += y;
                            Debug.Log("index:" + Boost);
                            Halt.It = AiryLend[Boost].ToString();
                        }
                        levelDataList.Add(Halt);
                    }
                }
            }
        }
        Debug.Log(levelDataList.Count);
        List<LimitItem> levelEditDataList = new List<LimitItem>(Canoe_Seem);
        string levelJsonData = JsonUtility.ToJson(new LevelJsonData(levelDataList, figureNum));
        string levelEditJsonData = SerializeList.ListToJson<LimitItem>(levelEditDataList);
        //Debug.Log(levelJsonData);
        //Debug.Log(levelEditJsonData);
        //写入内容
        //StreamWriter levelWrite = new StreamWriter(levelFilepath);
        //levelWrite.WriteLine(levelJsonData);
        //levelWrite.Dispose();
        //levelWrite.Close();
        StreamWriter levelEditWrite = new StreamWriter(levelEditFilepath);
        levelEditWrite.WriteLine(levelEditJsonData);
        levelEditWrite.Dispose();
        levelEditWrite.Close();
        StreamWriter levelResourceWrite = new StreamWriter(levelFileResourcesPath);
        levelResourceWrite.WriteLine(levelJsonData);
        levelResourceWrite.Dispose();
        levelResourceWrite.Close();
#if UNITY_EDITOR
        //刷新文件列表
        AssetDatabase.Refresh();
#endif 
    }
}
public class SerializeList
{
    public static string ListToJson<T>(List<T> l)
    {
        return JsonUtility.ToJson(new SerializationList<T>(l));
    }

    public static List<T> LendFromFast<T>(string str)
    {
        return JsonUtility.FromJson<SerializationList<T>>(str).MeLend();
    }
}
[Serializable]
public class SerializationList<T>
{
    [SerializeField]
    List<T> Charge;
    string SovietRed;
    public List<T> MeLend() { return Charge; }

    public SerializationList(List<T> target)
    {
        this.Charge = target;
    }
}
[Serializable]
public class LevelJsonData
{
    [SerializeField]
    public List<LevelData> Charge;
    [SerializeField]
    public string SovietRed;
    
    public LevelJsonData(List<LevelData> t, string f)
    {
        this.Charge = t;
        this.SovietRed = f;

    }
}
public class LevelReadJsonData
{
    public List<LevelData> Charge;
    public string SovietRed;
}
[Serializable]
public class LevelEditMessage
{
    [SerializeField]
    public int Brave_Ox;
    [SerializeField]
    public int Fluke_Acorn;
    [SerializeField]
    public int Meal_Acorn;

    public LevelEditMessage(int id, int layer, int tile)
    {
        this.Brave_Ox = id;
        this.Fluke_Acorn = layer;
        this.Meal_Acorn = tile;

    }
}

public class LevelRemoveData
{
    public List<LevelRemoveItem> Clutch_Seem;
}
public class LevelRemoveItem
{
    public int ExtolRed;
    public int Cuban;
}

