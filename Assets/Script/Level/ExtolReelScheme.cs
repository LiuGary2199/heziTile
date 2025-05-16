using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class TileAnimationData
{
    public Vector2 Sandy_Nor;
    public Vector2 Fix_Nor;
    public Transform Meaty;
    
}
public class ExtolReelScheme : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("isTest")]    [UnityEngine.Serialization.FormerlySerializedAs("isTest")]public bool NoReal;
[UnityEngine.Serialization.FormerlySerializedAs("mainData")]    [UnityEngine.Serialization.FormerlySerializedAs("mainData")]public LevelMainData ThatOust;
[UnityEngine.Serialization.FormerlySerializedAs("tileBG")]    [UnityEngine.Serialization.FormerlySerializedAs("tileBG")]public GameObject MealBG;
[UnityEngine.Serialization.FormerlySerializedAs("tileGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("tileGroup")]public GameObject MealModel;
[UnityEngine.Serialization.FormerlySerializedAs("tileDic")]    [UnityEngine.Serialization.FormerlySerializedAs("tileDic")]public Dictionary<LevelItemData, GameObject> MealRow;
[UnityEngine.Serialization.FormerlySerializedAs("imgNameList")]    [UnityEngine.Serialization.FormerlySerializedAs("imgNameList")]public Dictionary<int,int> SitLobeLend;
    Dictionary<int, int> WhatLeaveGrassRow;
[UnityEngine.Serialization.FormerlySerializedAs("selectTileGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("selectTileGroup")]public GameObject CooperWordModel;
[UnityEngine.Serialization.FormerlySerializedAs("levelNumber")]    [UnityEngine.Serialization.FormerlySerializedAs("levelNumber")]public int BravePointe;
[UnityEngine.Serialization.FormerlySerializedAs("newUserMask")]    [UnityEngine.Serialization.FormerlySerializedAs("newUserMask")]public GameObject PpmExamArab;
[UnityEngine.Serialization.FormerlySerializedAs("SelectTileGroupLayout")]
[UnityEngine.Serialization.FormerlySerializedAs("SelectTileGroupLayout")]
    //MUYU
    //public int lastLevelScore;
    //public levelDD userLevelDD;
    //public enum levelDD 
    //{
    //    master = 0,
    //    hard = -1,
    //    mid = -2,
    //    easy = -3     
    //}

    public AutoLayout MetricWordModelSyntax;
    GameObject MealClanYellow;
    float Ideal_x= -0.2f;
    float Ideal_y= -0.3f;
    //float layerOffectY = 0.153f;
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

    //public LevelOriginalMainData omainData;
    private void Awake()
    {
        if (NoReal)
        {
            SaveDataManager.SetInt(CConfig.sv_Level_Id, BravePointe);
        }
        MealClanYellow = Resources.Load<GameObject>(CConfig.PrefabTileItem);
    }
    /// <summary>
    /// 读取json
    /// </summary>
    /// <param name="levelName"></param>
    public void DungExtolFast(string levelName)
    {
        WhatLeaveGrassRow = new Dictionary<int, int>();
        ThatOust = new LevelMainData();
        string LevelJsonString = Resources.Load<TextAsset>( CConfig.LevelJsonLevel + levelName).ToString();
        //Debug.Log("LevelJsonString:" + LevelJsonString);
        LevelOriginalMainData originalMainData = JsonMapper.ToObject<LevelOriginalMainData>(LevelJsonString);
        List<LevelItemData> levelItemDataList = new List<LevelItemData>();
        for(int i = 0; i < originalMainData.target.Count; i++)
        {
            LevelOriginalItemData odata = originalMainData.target[i];
            LevelItemData Halt= new LevelItemData();
            Halt.px = odata.px;
            Halt.py = odata.py;
            Halt.layer = odata.layer;
            levelItemDataList.Insert(0,Halt);
        }
        ThatOust.target = new List<LevelItemData>();
        for (int i = 0; i < levelItemDataList.Count; i++)
        {
            LevelItemData Halt= levelItemDataList[i];
            int diff_layer = WhoHostLeave(Halt, ThatOust.target);
            //Debug.Log("diff_layer:"+diff_layer);
            if (WhatLeaveGrassRow.ContainsKey(diff_layer))
            {
                WhatLeaveGrassRow[diff_layer]++;
            }
            else
            {
                WhatLeaveGrassRow.Add(diff_layer, 1);
            }
            Halt.diff_layer = diff_layer.ToString();
            LevelItemData data1 = Halt;
            bool is_insert = false;
            for (int j = 0; j < ThatOust.target.Count; j++)
            {
                LevelItemData data2 = ThatOust.target[j];
                if (int.Parse(data2.diff_layer) >= int.Parse(data1.diff_layer))
                {
                    ThatOust.target.Insert(j, data1);
                    is_insert = true;
                    break;
                }
            }
            if (!is_insert)
            {
                ThatOust.target.Add(data1);
            }
        }
        ThatOust.figureNum = originalMainData.figureNum;
        BusNomadModel();
    }
    /// <summary>
    /// 获取关卡中tile实际层级
    /// </summary>
    /// <param name="select_data">获取目标</param>
    /// <param name="levelItemDataList">全部方块情况</param>
    /// <returns></returns>
    int WhoHostLeave(LevelItemData select_data, List<LevelItemData> levelItemDataList)
    {
        int Fluke= int.Parse(select_data.layer);
        int He= int.Parse(select_data.px);
        int It= int.Parse(select_data.py);
        List<LevelItemData> upList = new List<LevelItemData>();
        foreach (LevelItemData odata in levelItemDataList)
        {
            if (int.Parse(odata.layer) > Fluke)
            {
                upList.Add(odata);
            }
        }
        List<string> upLayerList = new List<string>();
        int diffLayerMax = -1;
        foreach (LevelItemData upData in upList)
        {
            int up_px = int.Parse(upData.px);
            int up_py = int.Parse(upData.py);
            if (up_px >= He - 1 && up_px <= He + 1 && up_py >= It - 1 && up_py <= It + 1)
            {
                if (int.Parse(upData.diff_layer) > diffLayerMax)
                {
                    diffLayerMax = int.Parse(upData.diff_layer);
                }
            }
        }
        return diffLayerMax+1;
    }
    /// <summary>
    /// 生成关卡tile
    /// </summary>
    void LintelExtolWord()
    {
        MealRow = new Dictionary<LevelItemData, GameObject>();
        float bg_w = GetSystemData.GetInstance().getSpriteSize(MealBG).x;
        float bg_h = GetSystemData.GetInstance().getSpriteSize(MealBG).y;
        float base_tile_w = GetSystemData.GetInstance().getSpriteSize(MealClanYellow).x;
        float base_tile_h = GetSystemData.GetInstance().getSpriteSize(MealClanYellow).y;
        float group_w = base_tile_w * 11f + Ideal_x * 10f;
        float group_h = base_tile_h * 11f + Ideal_y * 10f;
        float group_scale = bg_w / (base_tile_w * 8f + Ideal_x * 7f);
        Vector2 bg_pos = MealBG.transform.position;
        MealModel.transform.position = bg_pos;
        Vector2 oddV2 = new Vector2(-group_w / 2f, group_h / 2f);
        Vector2 evenV2 = new Vector2(-(base_tile_w * 10f + Ideal_x * 9f) / 2f, (base_tile_h * 10f + Ideal_y * 9f) / 2f);
        for (int i = 0; i < ThatOust.target.Count; i++)
        {
            LevelItemData Halt= ThatOust.target[i];
            GameObject tileItem = Instantiate<GameObject>(MealClanYellow);
            float pos_x = 0;
            float pos_y = 0;
            int He= int.Parse(Halt.px) / 2;
            int It= int.Parse(Halt.py) / 2;
            if (int.Parse(Halt.px) % 2 == 0)
            {
                pos_x = oddV2.x + He * (base_tile_w + Ideal_x) + base_tile_w / 2f;
            }
            else
            {
                pos_x = evenV2.x + He * (base_tile_w + Ideal_x) + base_tile_w / 2f;
            }
            if (int.Parse(Halt.py) % 2 == 0)
            {
                pos_y = oddV2.y - It * (base_tile_h + Ideal_y) - base_tile_h / 2f;
            }
            else
            {
                pos_y = evenV2.y - It * (base_tile_h + Ideal_y) - base_tile_h / 2f;
            }
            tileItem.transform.parent = MealModel.transform;
            tileItem.transform.localPosition = new Vector3(pos_x, pos_y + GetSystemData.GetInstance().getCameraHeight() * 1.5f + 1, 0);
            tileItem.GetComponent<WordClan>().BusLeave((int.Parse(Halt.layer) + 1).ToString(), (int.Parse(Halt.py) * 21 + int.Parse(Halt.px)) * 4);
            tileItem.GetComponent<WordClan>().SpringState(int.Parse(Halt.diff_layer));
            tileItem.GetComponent<WordClan>().Halt = Halt;
            //设置图片
            if (BravePointe != 1)
            {
                int img_name = WhoWordNomad(Halt);
                tileItem.GetComponent<WordClan>().BusWordNomad(img_name);
                Halt.img_name = img_name.ToString();
            }
            else
            {
                if ((Halt.px == Dire.instance.PivotForty[0][0] && Halt.py == Dire.instance.PivotForty[0][1]) 
                    || (Halt.px == Dire.instance.PivotForty[1][0] && Halt.py == Dire.instance.PivotForty[1][1]) 
                    || (Halt.px == Dire.instance.PivotForty[2][0] && Halt.py == Dire.instance.PivotForty[2][1]))
                {
                    List<int> keys = new List<int>(SitLobeLend.Keys);
                    tileItem.GetComponent<WordClan>().BusWordNomad(keys[0]);
                    Halt.img_name = keys[0].ToString();
                }
                else
                {
                    int img_name = WhoWordNomad(Halt);
                    tileItem.GetComponent<WordClan>().BusWordNomad(img_name);
                    Halt.img_name = img_name.ToString();
                }
            }
            
            //调整动画终点位置
            Halt.pos = new Vector2(pos_x * group_scale, pos_y * group_scale+0.5f);
            Halt.layer_name = (int.Parse(Halt.layer) + 1).ToString();
            Halt.layer_order = (int.Parse(Halt.py) * 21 + int.Parse(Halt.px)) * 4;

            Halt.anmData = new TileAnimationData();
            Halt.anmData.Sandy_Nor = new Vector2(pos_x * group_scale, pos_y  * group_scale + GetSystemData.GetInstance().getCameraHeight() * 1.5f + 1);
            Halt.anmData.Fix_Nor = Halt.pos;
            Halt.anmData.Meaty = tileItem.transform;

            MealRow.Add(Halt, tileItem);
        }
        MealModel.transform.localScale = new Vector3(group_scale, group_scale, 0);
        CooperWordModel.transform.localScale = new Vector3(group_scale, group_scale+0.2f, 0);
        MetricWordModelSyntax.layoutAction();
        Dire.instance.FirnMessyArabHis();
        NoteWordFormation(()=> {
            Dire.instance.ChafeDireMessyArabHis();
            CapExamMedical.GetInstance().AmnesiaStony(TriggerType.Brave_Sandy);

            if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) == 0)
            {
                PpmExamTale();
            }
            else if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) == 1)
            {
                if (GameUtil.IsApple())
                {
                    SaveDataManager.SetInt(CConfig.sv_NewUserStep, 2);
                }
                else
                {
                    MessageCenterLogic.GetInstance().Send(CConfig.mg_ShowCashShopGuide);
                }
            }
            
        });
    }

    public void NoteWordFormation(System.Action finish = null)
    {
        GetComponent<ExtolToll>().SewPluck = false;
        //UIManager.GetInstance().ShowUIForms("GrooveRider");
        
        List<TileAnimationData> list = new List<TileAnimationData>();
        for (int i = ThatOust.target.Count - 1; i >= 0; i--)
        {
            LevelItemData Halt= ThatOust.target[i];
            TileAnimationData anmData = Halt.anmData;
            list.Add(anmData);
        }
        AnimationController.CubeShow(list, () =>
        {
            GetComponent<ExtolToll>().SewPluck = true;
            
            if (finish != null)
            {
                finish();
            }
        });
    }
    public void RareWordFormation(System.Action finish = null)
    {
        GetComponent<ExtolToll>().SewPluck = false;
        finish();
        //List<TileAnimationData> list = new List<TileAnimationData>();
        //for (int i = 0; i < mainData.target.Count; i++)
        //{
        //    LevelItemData data = mainData.target[i];
        //    TileAnimationData anmData = data.anmData;
        //    list.Add(anmData);
        //}
        //AnimationController.CubeHide(list, () =>
        //{
        //    if (finish != null)
        //    {
        //        finish();
        //    }
            
        //});
    }

    /// <summary>
    /// 获取tile图片
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    int WhoWordNomad(LevelItemData data)
    {
        int m = int.Parse(data.diff_layer);
        //Debug.Log("m:" + m);
        int A = 0;
        for (int a = 0; a <= m; a++)
        {
            A += WhatLeaveGrassRow[a];
            if (a == m && A <= 3)
            {
                if (WhatLeaveGrassRow.ContainsKey(m + 1))
                {
                    m += 1;
                }
            }
        }

        List<int> allKeyList = new List<int>(SitLobeLend.Keys);
        //Debug.Log(allKeyList[0]);
        int kMax = (A / 2) < allKeyList.Count ? (A / 2) : allKeyList.Count;
        if (kMax <= 0)
        {
            kMax = 1;
        }
        List<int> canUseKeyList = new List<int>();
        int i = 0;
        while (i < kMax)
        {
            int key = allKeyList[i];
            if (SitLobeLend[key] > 0)
            {
                canUseKeyList.Add(key);
            }
            i++;
        }
        if (canUseKeyList.Count == 0)
        {
            i = 0;
            while (canUseKeyList.Count < kMax && i < allKeyList.Count)
            {
                int key = allKeyList[i];
                if (SitLobeLend[key] > 0)
                {
                    canUseKeyList.Add(key);
                }
                i++;
            }
        }

        int img_name = canUseKeyList[Random.Range(0, canUseKeyList.Count)];
        SitLobeLend[img_name]--;
        return img_name;
    }

    /// <summary>
    /// 获取当前关卡图案数（附加难度动态调整） //MUYU
    /// </summary>
    /// <returns></returns>
    int WhoRibbonRed()
    {
        
        int SovietRed= int.Parse(ThatOust.figureNum) + (int)ExtolDDMedical.Datebase.SuitExtolDD;
        Debug.Log("getFigureNum: " + SovietRed + ", " + int.Parse(ThatOust.figureNum) + ", " + ExtolDDMedical.Datebase.SuitExtolDD);
        return SovietRed > 3 ? SovietRed : 3;
    }

    /// <summary>
    /// 初始化图片池
    /// </summary>
    void BusNomadModel()
    {
        SitLobeLend = new Dictionary<int, int>();
        List<int> groupList = new List<int>();
        
        int tileCount = ThatOust.target.Count;
        if (BravePointe == 1)
        {
            tileCount -= 3;
        }
        int groupCount = tileCount / 3;
        int SovietRed= WhoRibbonRed(); //MUYU  
        if (groupCount <= SovietRed) 
        {
            int[] random = GetSystemData.GetInstance().GetRandomSequence(15, groupCount);
            for (int i = 0; i < groupCount; i++)
            {
                SitLobeLend.Add(random[i] + 1, 3);
            }
        }
        else
        {
            int[] random1 = GetSystemData.GetInstance().GetRandomSequence(15, SovietRed);
            int[] random2 = GetSystemData.GetInstance().GetRandomSequence(random1.Length, groupCount % SovietRed);
            for (int i = 0;i < groupCount; i++)
            {
                if (i < groupCount - groupCount % SovietRed)
                {
                    if (SitLobeLend.ContainsKey(random1[i % SovietRed] + 1))
                    {
                        SitLobeLend[random1[i % SovietRed] + 1] += 3;
                    }
                    else
                    {
                        SitLobeLend.Add(random1[i % SovietRed] + 1, 3);
                    }
                }
                else
                {
                    //Debug.Log("random2item:" + random2[i % figureNum]);
                    //Debug.Log("random1item:" + random1[random2[i % figureNum]]);
                    SitLobeLend[random1[random2[i % SovietRed]] + 1] += 3;
                }
            }
        }

    }
    /// <summary>
    /// 根据牌池中剩余图案刷新image
    /// </summary>
    public void ScowlMeetingNomad(List<GameObject> selectTileList)
    {
        //Debug.Log("skillRefreshImage");
        int[] randomArray = GetSystemData.GetInstance().GetRandomSequence(ThatOust.target.Count, ThatOust.target.Count);
        SitLobeLend = new Dictionary<int, int>();
        for(int i = 0; i < ThatOust.target.Count; i++)
        {
            LevelItemData Halt= ThatOust.target[randomArray[i]];
            if (SitLobeLend.ContainsKey(int.Parse(Halt.img_name)))
            {
                SitLobeLend[int.Parse(Halt.img_name)] += 1;
            }
            else
            {
                SitLobeLend.Add(int.Parse(Halt.img_name), 1);
            }
        }
        if (selectTileList.Count > 0)
        {
            List<string> selectGroupImageList = new List<string>();
            foreach (GameObject obj in selectTileList)
            {
                if (!selectGroupImageList.Contains(obj.GetComponent<WordClan>().Halt.img_name))
                {
                    selectGroupImageList.Add(obj.GetComponent<WordClan>().Halt.img_name);
                }
            }
            Dictionary<int, int> imageDic = new Dictionary<int, int>(SitLobeLend);
            SitLobeLend = new Dictionary<int, int>();
            foreach (string imgName in selectGroupImageList)
            {
                //Debug.Log("imgName:" + imgName);
                SitLobeLend.Add(int.Parse(imgName), imageDic[int.Parse(imgName)]);
            }
            foreach (int key in imageDic.Keys)
            {
                if (!SitLobeLend.ContainsKey(key))
                {
                    SitLobeLend.Add(key, imageDic[key]);
                }
            }
            List<int> keys = new List<int>(SitLobeLend.Keys);
            //Debug.Log("imgNameList First:" + keys[0]);
        }
        //设置图片
        foreach (LevelItemData data in ThatOust.target)
        {
            int img_name = WhoWordNomad(data);
            data.img_name = img_name.ToString(); ;
            MealRow[data].GetComponent<WordClan>().BusWordNomad(img_name);
            MealRow[data].GetComponent<WordClan>().Halt = data;
        }
    }
    /// <summary>
    /// 回退后刷新显示关系
    /// </summary>
    /// <param name="data"></param>
    /// <param name="obj"></param>
    public void DollFlairMeeting(LevelItemData data,GameObject obj)
    {
        //mainData.target.Add(data);
        LevelItemData data1 = data;
        bool is_insert = false;
        for (int j = 0; j < ThatOust.target.Count; j++)
        {
            LevelItemData data2 = ThatOust.target[j];
            if (int.Parse(data2.diff_layer) >= int.Parse(data1.diff_layer))
            {
                ThatOust.target.Insert(j, data1);
                is_insert = true;
                break;
            }
        }
        if (!is_insert)
        {
            ThatOust.target.Add(data1);
        }
        MealRow.Add(data, obj);
        WhatLeaveGrassRow = new Dictionary<int, int>();
        foreach (LevelItemData itemData in ThatOust.target)
        {
            int diffLayer = WhoHostLeave(itemData, ThatOust.target);
            if (WhatLeaveGrassRow.ContainsKey(diffLayer))
            {
                WhatLeaveGrassRow[diffLayer]++;
            }
            else
            {
                WhatLeaveGrassRow.Add(diffLayer, 1);
            }
            itemData.diff_layer = diffLayer.ToString();
            if (diffLayer != 0)
            {
                MealRow[itemData].GetComponent<WordClan>().SpringState(diffLayer);
            }
        }
    }
    /// <summary>
    /// 点击后刷新数据和下方层级关系
    /// </summary>
    /// <param name="data">单块数据</param>
    public void CooperWordMeeting(LevelItemData data)
    {
        ThatOust.target.Remove(data);
        MealRow.Remove(data);
        WhatLeaveGrassRow = new Dictionary<int, int>();
        foreach (LevelItemData itemData in ThatOust.target)
        {
            int diffLayer = WhoHostLeave(itemData, ThatOust.target);
            if (WhatLeaveGrassRow.ContainsKey(diffLayer))
            {
                WhatLeaveGrassRow[diffLayer]++;
            }
            else
            {
                WhatLeaveGrassRow.Add(diffLayer, 1);
            }
            itemData.diff_layer = diffLayer.ToString();
            if (diffLayer == 0)
            {
                MealRow[itemData].GetComponent<WordClan>().SpringState(diffLayer);
            }
        }
    }
    /// <summary>
    /// 初始化关卡
    /// </summary>
    public void BendExtol()
    {
        for (int i = 0; i < MealModel.transform.childCount; i++)
        {
            Destroy(MealModel.transform.GetChild(i).gameObject);
        }
        if (SaveDataManager.GetInt(CConfig.sv_Level_Id) == 0)
        {
            SaveDataManager.SetInt(CConfig.sv_Level_Id,1);
        }
        BravePointe = SaveDataManager.GetInt(CConfig.sv_Level_Id);
        UIManager.GetInstance().ShowUIForms(nameof(ExtolRider));
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelPanel_LevelNumber, new MessageData(BravePointe));
        MealModel.transform.localScale = new Vector3(1, 1, 1);
        CooperWordModel.transform.localScale = new Vector3(1, 1, 1);
        GetComponent<ExtolToll>().BraveTour();
        Dire.instance.DogDireCrouch(false);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_StartLevel);
        DungExtolFast(BravePointe.ToString());
        LintelExtolWord();
        ExtolDDMedical.Datebase.BraveProbeTour();       //MUYU
        PostEventScript.GetInstance().SendEvent("1201",BravePointe.ToString(),ThatOust.target.Count.ToString());
    }
    /// <summary>
    /// 关卡新手引导
    /// </summary>
    public void PpmExamTale()
    {
        PpmExamArab.SetActive(true);
        foreach (LevelItemData data in MealRow.Keys)
        {
            if ((data.px == Dire.instance.PivotForty[0][0] && data.py == Dire.instance.PivotForty[0][1]) 
                || (data.px == Dire.instance.PivotForty[1][0] && data.py == Dire.instance.PivotForty[1][1]) 
                || (data.px == Dire.instance.PivotForty[2][0] && data.py == Dire.instance.PivotForty[2][1]))
                {
                if (data.px == Dire.instance.PivotForty[0][0] && data.py == Dire.instance.PivotForty[0][1])
                {
                    GetComponent<ExtolToll>().Move.SetActive(true);
                    GetComponent<ExtolToll>().Move.transform.position = MealRow[data].transform.position;
                }
                MealRow[data].GetComponent<WordClan>().BusLeave("NewUserLight",0);
            }
        }
    }
    public GameObject WhoCapExamWord(string px, string py)
    {
        foreach (LevelItemData data in MealRow.Keys)
        {
            if (data.px == px && data.py == py)
            {
                return MealRow[data];
            }
        }
        return null;
    }

    public bool WhoJawLimb()
    {
        bool canAuto = true;
        foreach (LevelItemData item in MealRow.Keys)
        {
            if (item.diff_layer != "0")
            {
                canAuto = false;
                break;
            }
        }
        return canAuto;
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(nameof(loadLevelWaitTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
