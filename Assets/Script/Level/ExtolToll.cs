using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using Lofelt.NiceVibrations;
public class ExtolToll : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("selectTileGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("selectTileGroup")]public GameObject CooperWordModel;
[UnityEngine.Serialization.FormerlySerializedAs("selectTileList")]    [UnityEngine.Serialization.FormerlySerializedAs("selectTileList")]public List<GameObject> CooperWordLend;
[UnityEngine.Serialization.FormerlySerializedAs("waitRemoveList")]    [UnityEngine.Serialization.FormerlySerializedAs("waitRemoveList")]public List<GameObject> OralEasilyLend;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("canTouch")]    [UnityEngine.Serialization.FormerlySerializedAs("canTouch")]public bool SewPluck= true;
    DateTime startTime;
    bool CreekDuetTerm;
[UnityEngine.Serialization.FormerlySerializedAs("selectTileObj")]    [UnityEngine.Serialization.FormerlySerializedAs("selectTileObj")]public GameObject CooperWordSum;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]    [UnityEngine.Serialization.FormerlySerializedAs("Hand")]public GameObject Move;
    [HideInInspector]
[UnityEngine.Serialization.FormerlySerializedAs("getCount")]    [UnityEngine.Serialization.FormerlySerializedAs("getCount")]public int WhoGrass= 0;
    bool NoRefiner= false;
    // Start is called before the first frame update
    private void OnEnable()
    {

        CreekDuetTerm = false;
        startTime = DateTime.Now;
    }
    private void OnDisable()
    {
        if (!CreekDuetTerm)
        {
            int sec = GetSystemData.GetInstance().SecDateDiff(startTime.ToString(), DateTime.Now);
            Debug.Log("sec:" + sec);
            SaveDataManager.SetInt(CConfig.sv_LevelAllTime, sec + SaveDataManager.GetInt(CConfig.sv_LevelAllTime));
        }
    }
    void Start()
    {
        MessageCenterLogic.GetInstance().Register(CConfig.mg_undo,(messageData)=> {

            JoltFlairSaline();
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_hint, (messageData)=> {

            VoltFlairSaline();
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_shuffle, (messageData)=> {

            RoadbedFlairSaline();
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_revive, (messageData) => {

            ReviveFlairSaline();
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_WindowOpen, (messageData) => {
            SewPluck = false;
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_WindowClose, (messageData) => {
            SewPluck = true;
        });
    }
    /// <summary>
    /// 关卡初始化
    /// </summary>
    public void BraveTour()
    {
        WhoGrass = 0;
        CooperWordLend = new List<GameObject>();
        OralEasilyLend = new List<GameObject>();
        NoRefiner = false;
        MessageCenterLogic.GetInstance().Send(CConfig.mg_DissmissAutoButton);
        
    }
    /// <summary>
    /// 获取点击方块
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.P))
        //{
        //    if (!readySaveTime)
        //    {
        //        levelComplete();
        //        print("MUYU:levelComplete");
        //    }
                
            
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    AutoMatch();
        //}

        if (Input.GetMouseButtonDown(0) && SewPluck)
        {
            
            if (CooperWordLend.Count < 7 || RepelKnit())
            {
                RaycastHit2D[] rayHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                foreach (RaycastHit2D ray in rayHits)
                {
                    if (ray.transform.GetComponent<WordClan>() != null && int.Parse(ray.transform.GetComponent<WordClan>().Halt.diff_layer) == 0)
                    {
                        if (!RepelCapExam())
                        {
                            ray.transform.DOScale(1.2f, 0.1f);
                            ray.transform.GetComponent<WordClan>().BusLeave("18", 1000);
                            CooperWordSum = ray.transform.gameObject;
                        }
                        else
                        {
                            if (RepelCapExamJawMetric(ray.transform.GetComponent<WordClan>().Halt))
                            {
                                ray.transform.DOScale(1.2f, 0.1f);
                                CooperWordSum = ray.transform.gameObject;
                            }
                        }
                            
                        break;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && SewPluck)
        {
            if (CooperWordLend.Count < 7 || RepelKnit())
            {
                RaycastHit2D[] rayHits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                foreach (RaycastHit2D ray in rayHits)
                {
                    if (ray.transform.GetComponent<WordClan>() != null && int.Parse(ray.transform.GetComponent<WordClan>().Halt.diff_layer) == 0 && CooperWordSum == ray.transform.gameObject)
                    {
                        if (!RepelCapExam())
                        {
                            ray.transform.DOScale(1f, 0.1f);
                            CooperWordSum = null;
                            CooperWord(ray.transform);
                        }
                        else
                        {
                            if (RepelCapExamJawMetric(ray.transform.GetComponent<WordClan>().Halt))
                            {
                                ray.transform.DOScale(1f, 0.1f);
                                CooperWordSum = null;
                                CooperWord(ray.transform);
                            }
                        }
                        break;
                    }
                }
                if (CooperWordSum != null)
                {
                    if (!RepelCapExam())
                    {
                        CooperWordSum.GetComponent<WordClan>().BusLeave(CooperWordSum.GetComponent<WordClan>().Halt.layer_name, CooperWordSum.GetComponent<WordClan>().Halt.layer_order);
                    }
                    CooperWordSum.transform.DOScale(1f, 0.1f);
                }
            }
        }
    }
    /// <summary>
    /// 点击方块
    /// </summary>
    /// <param name="tile"></param>
    void CooperWord(Transform tile,Action finish = null)
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
        WhoGrass++;
        if (!NoRefiner)
        {
            ADManager.Instance.autoInterTouch();
        }
        if (RepelCapExam())
        {
            if (WhoGrass == 1)
            {
                Move.transform.position = GetComponent<ExtolReelScheme>().WhoCapExamWord(Dire.instance.PivotForty[1][0], Dire.instance.PivotForty[1][1]).transform.position;
            }
            if (WhoGrass == 2)
            {
                Move.transform.position = GetComponent<ExtolReelScheme>().WhoCapExamWord(Dire.instance.PivotForty[2][0], Dire.instance.PivotForty[2][1]).transform.position;
            }
            if (WhoGrass == 3)
            {
                Move.SetActive(false);
                GetComponent<ExtolReelScheme>().PpmExamArab.SetActive(false);
                SaveDataManager.SetInt(CConfig.sv_NewUserStep, 1);
            }
        }

        MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_TouchCube);

        GetComponent<ExtolReelScheme>().CooperWordMeeting(tile.GetComponent<WordClan>().Halt);
        tile.GetComponent<WordClan>().Halt.diff_layer = "-1";
        string select_img_name = tile.GetComponent<WordClan>().Halt.img_name;
        bool isInsert = false; ;
        for (int i = CooperWordLend.Count - 1; i >= 0; i--)
        {
            GameObject obj = CooperWordLend[i];
            if (obj.GetComponent<WordClan>().Halt.img_name == select_img_name)
            {
                if (i > 1 && CooperWordLend[i - 2].GetComponent<WordClan>().Halt.img_name == select_img_name)
                {
                    CooperWordLend.Add(tile.gameObject);
                    isInsert = true;
                }
                else
                {
                    CooperWordLend.Insert(i + 1, tile.gameObject);
                    isInsert = true;
                }
                break;
            }
        }
        if (!isInsert)
        {
            CooperWordLend.Add(tile.gameObject);

            //新手引导:收取tile记录
            if (SaveDataManager.GetInt(CConfig.sv_NewUserStep) <= 4)
            {
                MessageCenterLogic.GetInstance().Send(CConfig.mg_ShowSkillGuide, new MessageData(Dire.instance.BraveScheme.BravePointe));
            }
        }
        MeetingMetricModel();
        if (!NoRefiner)
        {
            if (GetComponent<ExtolReelScheme>().WhoJawLimb())
            {
                //MessageCenterLogic.GetInstance().Send(CConfig.mg_ShowAutoButton);
                // 自动开启自动合并
                LimbLodge();
            }
        }
    }
    /// <summary>
    /// 移除手牌区相同方块
    /// </summary>
    /// <param name="list"></param>
    void ClutchKnitWord(List<GameObject> list)
    {
        List<TileAnimationData> anmList = new List<TileAnimationData>();
        for (int j = 0; j < 3; j++)
        {
            TileAnimationData anmData = list[j].GetComponent<WordClan>().Halt.anmData;
            //list[j].GetComponent<WordClan>().data.isRemoving = true;
            anmList.Add(anmData);
            OralEasilyLend.Add(list[j]);
            
        }
        MusicMgr.GetInstance().PlayEffect(MusicType.SceneMusic.Sound_MergeDisapper);
        //动画:消除
        AnimationController.CubeMergeAni(anmList,()=> {
            Transform position = list[0].transform;
            for (int j = 0; j < 3; j++)
            {
                //动画:消除
                OralEasilyLend.Remove(list[0]);
                CooperWordLend.Remove(list[0]);
                Destroy(list[0]);
                list.RemoveAt(0);
            }
            int count1 = OralEasilyLend.Count;
            for(int i = count1 - 1; i >= 0; i--)
            {
                if (OralEasilyLend[i] == null)
                {
                    OralEasilyLend.RemoveAt(i);
                }
            }
            int count2 = CooperWordLend.Count;
            for (int i = count2 - 1; i >= 0; i--)
            {
                if (CooperWordLend[i] == null)
                {
                    CooperWordLend.RemoveAt(i);
                }
            }
            //MUYU
            ExtolDDMedical.Datebase.BraveProbeHero();
 
            MeetingMetricModel();
            if (CooperWordLend.Count == 0 && GetComponent<ExtolReelScheme>().ThatOust.target.Count == 0)
            {
                BraveEmphasis();
            }

            // 是否触发大额奖励
            TileReward tileReward = GameUtil.GetInstance().getBigReward();
            if (tileReward != null && tileReward.rewardValue > 0 && !NoRefiner)
            {
                // 大奖弹框
                Dire.instance.GapGroove = tileReward;
                UIManager.GetInstance().ShowUIForms(nameof(SillyRider));
            }
            else
            {
                // 是否触发小额奖励
                tileReward = GameUtil.GetInstance().getSmallReward();
                if (tileReward != null && tileReward.rewardValue > 0)
                {
                    if (tileReward.rewardType == RewardType.cash)
                    {
                        // 现金奖励
                        Dire.instance.OwnCook(tileReward.rewardValue, position);
                    }
                    else if (tileReward.rewardType == RewardType.gold)
                    {
                        // 金币奖励
                        Dire.instance.OwnLord(tileReward.rewardValue, position);
                    }
                }
            }
        });
    }
    /// <summary>
    /// 过关成功
    /// </summary>
    void BraveEmphasis()
    {
        Dire.instance.DogDireCrouch(true);
        MessageCenterLogic.GetInstance().Send(CConfig.mg_PassLevel);
        PostEventScript.GetInstance().SendEvent("1208", GetComponent<ExtolReelScheme>().BravePointe.ToString(), GetComponent<ExtolReelScheme>().ThatOust.target.Count.ToString());
        SaveDataManager.SetInt(CConfig.sv_Level_Id, SaveDataManager.GetInt(CConfig.sv_Level_Id) + 1);
        double cashNumber = Dire.instance.WhoExtolLoveCook();
        int expNumber = 1;
        Dire.instance.OwnDay(expNumber);
        Dire.instance.WhosRakeSumDay();
        UIManager.GetInstance().ShowUIForms(nameof(ExtolEmphasisRider));
        MessageCenterLogic.GetInstance().Send(CConfig.mg_LevelCompletePanel_Reward, new MessageData((int)cashNumber, expNumber));
        int sec = GetSystemData.GetInstance().SecDateDiff(startTime.ToString(), DateTime.Now);
        SaveDataManager.SetInt(CConfig.sv_LevelAllTime, sec + SaveDataManager.GetInt(CConfig.sv_LevelAllTime));
        CreekDuetTerm = true;
        Dire.instance.RailGapGrooveTerm();

    }
    /// <summary>
    /// 刷新手牌区位置
    /// </summary>
    void MeetingMetricModel(Action finish = null)
    {
        Dictionary<string, List<GameObject>> dic = new Dictionary<string, List<GameObject>>();
        for (int i = 0; i < CooperWordLend.Count; i++)
        {
            float tileW = (GetSystemData.GetInstance().getSpriteSize(CooperWordModel).x - 0.15f * CooperWordModel.transform.localScale.x * 2) / 7;
            float width = tileW * 7;
            float x= -width / 2f + tileW * i + tileW / 2;
            GameObject obj = CooperWordLend[i];
            if (!RepelCapExam())
            {
                obj.GetComponent<WordClan>().BusLeave("18", 1000+i);
            }
            string name = obj.GetComponent<WordClan>().Halt.img_name;
            if (!obj.GetComponent<WordClan>().Halt.isRemoving)
            {

                if (dic.ContainsKey(name) && dic[name].Count > 0)
                {
                    dic[name].Add(obj);
                }
                else
                {
                    dic.Add(name, new List<GameObject>());
                    dic[name].Add(obj);
                }
            }

            obj.GetComponent<WordClan>().MealSackMe(new Vector2(x, CooperWordModel.transform.position.y), () =>
            {
                

                if (dic.ContainsKey(obj.GetComponent<WordClan>().Halt.img_name) && dic[obj.GetComponent<WordClan>().Halt.img_name].Count >= 3)
                {
                    
                    bool allStop = true;
                    for (int j = 0; j < 3; j++)
                    {
                        if (dic[obj.GetComponent<WordClan>().Halt.img_name][j].GetComponent<WordClan>().NoAppear)
                        {
                            allStop = false;
                        }
                    }
                    if (allStop)
                    {
                        ClutchKnitWord(dic[obj.GetComponent<WordClan>().Halt.img_name]);
                    }

                }
                else
                {
                    if (CooperWordLend.Count >= 7)
                    {
                        if (!RepelKnit())
                        {
                            bool allStop = true;
                            foreach (GameObject tile_obj in CooperWordLend)
                            {
                                if (tile_obj.GetComponent<WordClan>().NoAppear)
                                {
                                    allStop = false;
                                    break;
                                }
                            }
                            if (allStop)
                            {
                                PostEventScript.GetInstance().SendEvent("1205", GetComponent<ExtolReelScheme>().BravePointe.ToString(), GetComponent<ExtolReelScheme>().ThatOust.target.Count.ToString());
                                UIManager.GetInstance().ShowUIForms(nameof(CementRider));
                            }
                        }
                    }
                }

            });
            
        }

    }
    bool RepelKnit()
    {
        bool haveSame = false;
        Dictionary<string, int> sameDic = new Dictionary<string, int>();
        foreach (GameObject tile in CooperWordLend)
        {
            string img = tile.GetComponent<WordClan>().Halt.img_name;
            if (sameDic.ContainsKey(img))
            {
                sameDic[img] += 1;
            }
            else
            {
                sameDic.Add(img, 1);
            }
        }
        int allCount = CooperWordLend.Count;
        foreach (int count in sameDic.Values)
        {
            if (count >= 3)
            {
                allCount -= 3;
            }
        }
        if (allCount < 7)
        {
            haveSame = true;
        }
        return haveSame;
    }
    /// <summary>
    /// 撤销技能
    /// </summary>
    void JoltFlairSaline()
    {
        if (CooperWordLend.Count > OralEasilyLend.Count)
        {
            PostEventScript.GetInstance().SendEvent("1202", GetComponent<ExtolReelScheme>().BravePointe.ToString(), GetComponent<ExtolReelScheme>().ThatOust.target.Count.ToString());

            GameObject undo_tile = null;
            for (int i = CooperWordLend.Count - 1; i >= 0; i--)
            {
                if (!OralEasilyLend.Contains(CooperWordLend[i]))
                {
                    undo_tile = CooperWordLend[i];
                    break;
                }
            }
            LevelItemData Halt= undo_tile.GetComponent<WordClan>().Halt;
            undo_tile.GetComponent<WordClan>().MealSackMe(Halt.pos, () => { });
            undo_tile.GetComponent<WordClan>().BusLeave(Halt.layer_name, Halt.layer_order);
            GetComponent<ExtolReelScheme>().DollFlairMeeting(Halt, undo_tile);
            CooperWordLend.Remove(undo_tile);
            MeetingMetricModel();
        }
    }
    /// <summary>
    /// 提示技能
    /// </summary>
    void VoltFlairSaline()
    {
        PostEventScript.GetInstance().SendEvent("1203", GetComponent<ExtolReelScheme>().BravePointe.ToString(), GetComponent<ExtolReelScheme>().ThatOust.target.Count.ToString());
        int needCount = 0;
        string imgName = "";
        if (CooperWordLend.Count > 0)
        {
            if (CooperWordLend.Count > 1)
            {
                WordClan item1 = CooperWordLend[0].GetComponent<WordClan>();
                WordClan item2 = CooperWordLend[1].GetComponent<WordClan>();
                imgName = item1.Halt.img_name;
                if (item1.Halt.img_name == item2.Halt.img_name)
                {
                    needCount = 1;
                }
                else
                {
                    needCount = 2;
                }
            }
            else
            {
                imgName = CooperWordLend[0].GetComponent<WordClan>().Halt.img_name;
                needCount = 2;
            }
        }
        else
        {
            needCount = 3;
            imgName = GetComponent<ExtolReelScheme>().ThatOust.target[0].img_name;
        }

        List<LevelItemData> levelDataList = new List<LevelItemData>(GetComponent<ExtolReelScheme>().ThatOust.target);
        foreach(LevelItemData data in levelDataList)
        {
            if (data.img_name == imgName)
            {
                GetComponent<ExtolReelScheme>().MealRow[data].GetComponent<WordClan>().SpringState(0);
                CooperWord(GetComponent<ExtolReelScheme>().MealRow[data].transform);
                needCount--;
            }
            if (needCount == 0)
            {
                break;
            }    
        }

    }
    /// <summary>
    /// 洗牌技能
    /// </summary>
    void RoadbedFlairSaline()
    {
        SewPluck = false;
        UIManager.GetInstance().ShowUIForms(nameof(GrooveRider));
        PostEventScript.GetInstance().SendEvent("1204", GetComponent<ExtolReelScheme>().BravePointe.ToString(), GetComponent<ExtolReelScheme>().ThatOust.target.Count.ToString());
        GetComponent<ExtolReelScheme>().RareWordFormation(() =>
        {
            GetComponent<ExtolReelScheme>().ScowlMeetingNomad(CooperWordLend);
            GetComponent<ExtolReelScheme>().NoteWordFormation(()=> {
                SewPluck = true;
                UIManager.GetInstance().CloseOrReturnUIForms("GrooveRider");
            });
        });
        
    }
    /// <summary>
    /// 
    /// </summary>
    public void LimbLodge()
    {
        UIManager.GetInstance().ShowUIForms(nameof(MoveRider));
        //MusicMgr.GetInstance().PlayEffect(MusicType.UIMusic.Sound_AutoMerge);
        //Time.timeScale = 2f;
        NoRefiner = true;
        Dire.instance.FirnMessyArabHis();
        List<LevelItemData> allTileDataList = new List<LevelItemData>(GetComponent<ExtolReelScheme>().MealRow.Keys);
        List<GameObject> autoList = new List<GameObject>();
        if (CooperWordLend.Count > 0)
        {
            int listCount = CooperWordLend.Count;
            Dictionary<string, int> selectTileDic = new Dictionary<string, int>();
            foreach (GameObject tile in CooperWordLend)
            {
                if (selectTileDic.ContainsKey(tile.GetComponent<WordClan>().Halt.img_name))
                {
                    selectTileDic[tile.GetComponent<WordClan>().Halt.img_name] += 1;
                } 
                else
                {
                    selectTileDic.Add(tile.GetComponent<WordClan>().Halt.img_name, 1);
                }
            }
            foreach (string key in selectTileDic.Keys)
            {
                int addCount = 0;
                int i = 0;
                while (addCount != 3 - selectTileDic[key] && i != allTileDataList.Count)
                {
                    LevelItemData Halt= allTileDataList[i];
                    if (Halt.img_name == key)
                    {
                        if (!autoList.Contains(GetComponent<ExtolReelScheme>().MealRow[Halt]))
                        {
                            autoList.Add(GetComponent<ExtolReelScheme>().MealRow[Halt]);
                            addCount++;
                        }
                    }
                    i++;
                }
            }
        }
        List<string> imageNameList = new List<string>();
        foreach (LevelItemData data in allTileDataList)
        {
            if (!imageNameList.Contains(data.img_name))
            {
                imageNameList.Add(data.img_name);
            }
        }
        foreach (string imageName in imageNameList)
        {
            foreach (LevelItemData data in allTileDataList)
            {
                if (data.img_name == imageName && !autoList.Contains(GetComponent<ExtolReelScheme>().MealRow[data]))
                {
                    autoList.Add(GetComponent<ExtolReelScheme>().MealRow[data]);
                }
            }
        }

        StartCoroutine(LimbMetric(autoList));
        //AutoSelect(autoList,0);
    }
    //void AutoSelect(List<GameObject> autoList,int i)
    //{
    //    GameObject tile = autoList[i];
    //    selectTile(tile.transform,()=> {
    //        i++;
    //        if (i < autoList.Count)
    //        {
    //            AutoSelect(autoList, i);
    //        }
    //    });
    //}
    IEnumerator LimbMetric(List<GameObject> autoList)
    {
        foreach (GameObject tile in autoList)
        {
            CooperWord(tile.transform);
            yield return new WaitForSeconds(0.2f);
        }
        //Time.timeScale = 1f;
        Dire.instance.ChafeDireMessyArabHis();
    }
    /// <summary>
    /// 复活
    /// </summary>
    void ReviveFlairSaline()
    {
        SewPluck = false;
        UIManager.GetInstance().ShowUIForms(nameof(GrooveRider));
        PostEventScript.GetInstance().SendEvent("1206", GetComponent<ExtolReelScheme>().BravePointe.ToString(), GetComponent<ExtolReelScheme>().ThatOust.target.Count.ToString());
        Dictionary<string,int> imgList = new Dictionary<string, int>();
        List<GameObject> surplusList = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            if (!imgList.ContainsKey(CooperWordLend[i].GetComponent<WordClan>().Halt.img_name))
            {
                if (i != 3)
                {
                    imgList.Add(CooperWordLend[i].GetComponent<WordClan>().Halt.img_name,2);
                }
            }
            else
            {
                imgList[CooperWordLend[i].GetComponent<WordClan>().Halt.img_name] -= 1;
            }
        }
        for (int i = 3; i < 7; i++)
        {
            if (!imgList.ContainsKey(CooperWordLend[i].GetComponent<WordClan>().Halt.img_name))
            {
                surplusList.Add(CooperWordLend[i]);
            }
        }
        foreach (string key in imgList.Keys)
        {
            int needCount = imgList[key];
            string imgName = key;
            List<LevelItemData> levelDataList = new List<LevelItemData>(GetComponent<ExtolReelScheme>().ThatOust.target);
            foreach (LevelItemData data in levelDataList)
            {
                if (data.img_name == imgName)
                {
                    GetComponent<ExtolReelScheme>().MealRow[data].GetComponent<WordClan>().SpringState(0);
                    CooperWord(GetComponent<ExtolReelScheme>().MealRow[data].transform);
                    needCount--;
                }
                if (needCount == 0)
                {
                    break;
                }
            }
        }

        //洗牌动画
        GetComponent<ExtolReelScheme>().RareWordFormation(() =>
        {
            GetComponent<ExtolReelScheme>().ScowlMeetingNomad(surplusList);
            GetComponent<ExtolReelScheme>().NoteWordFormation(()=> {

                SewPluck = true;
                UIManager.GetInstance().CloseOrReturnUIForms("GrooveRider");
            });
        });

    }

    bool RepelCapExam()
    {
        return SaveDataManager.GetInt(CConfig.sv_NewUserStep) == 0;
    }
    bool RepelCapExamJawMetric(LevelItemData data)
    {
        List<int> id_list = CapExamMedical.GetInstance().WhoIDLendLampAmnesia(TriggerType.Brave_Sandy);
        if (SaveDataManager.GetBool(CConfig.sv_NewUserStep + id_list[0]))
        {
            return true;
        } 
        else
        {
            if ((data.px == Dire.instance.PivotForty[0][0] && data.py == Dire.instance.PivotForty[0][1]) && WhoGrass == 0)
            {
                return true;
            }
            if ((data.px == Dire.instance.PivotForty[1][0] && data.py == Dire.instance.PivotForty[1][1]) && WhoGrass == 1)
            {
                return true;
            }
            if ((data.px == Dire.instance.PivotForty[2][0] && data.py == Dire.instance.PivotForty[2][1]) && WhoGrass == 2)
            {
                return true;
            }
        }
        return false;
    }
}
