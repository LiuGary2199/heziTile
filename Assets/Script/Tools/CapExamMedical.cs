using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
public class TriggerType
{
    public static string Brave_Sandy= "level_start";
    public static string Spank_Flannel= "panel_display";
    public static string Sale_Balsam= "fish_unlock";
    public static string Who_Meal= "get_tile";
    public static string Firn_Bend= "game_init";
}
public class ConditionType
{
    public static string Spank= "panel";
    public static string Sale_Yam= "fish_num";
    public static string Renowned_Yam= "aquarium_num";
    public static string Brave_Sandy_Yam= "level_start_num";
    public static string Meal_Yam= "tile_num";
    public static string Balsam_Sale_Yam= "unlock_fish_num";

}
public class CapExamMedical : MonoSingleton<CapExamMedical>
{
    public GameObject Arab;
    public GameObject Arab2;
    public GameObject MoveYellow;
    public GameObject PlateauDawn;
    public GameObject Trend;
    Button BeerUntold;
    List<Button> BeerUntoldLend;
    List<GameObject> BeerMarvelLend;
    List<int> BeerThinkLend;
    System.Action IconCane;
    protected override void Awake()
    {
        base.Awake();
        BeerThinkLend = new List<int>();
        BeerUntoldLend = new List<Button>();
        BeerMarvelLend = new List<GameObject>();
        Arab.GetComponent<Canvas>().sortingLayerName = "NewUserMask";
        Arab.GetComponent<Canvas>().sortingOrder = 1;
    }

    public void NoteArab(bool showMask, bool showHand, Vector3 handPosition, GameObject obj)
    {
        Arab.SetActive(true);
        Arab.GetComponent<Image>().enabled = showMask;
        Arab.transform.Find("Hand").gameObject.SetActive(showHand);
        if (showMask)
        {
            Arab.transform.Find("Hand").GetComponent<RectTransform>().localPosition = handPosition;
            Canvas canvas = obj.AddComponent<Canvas>();
            if (canvas != null)
            {
                canvas.overrideSorting = true;
                canvas.sortingLayerName = "NewUserMask";
                canvas.sortingOrder = 2;
                obj.AddComponent<GraphicRaycaster>();
            }
            MessageCenterLogic.GetInstance().Send(CConfig.mg_WindowOpen);
        }
    }

    public void RareArab(GameObject obj, bool hideCanvas = false)
    {
        Arab.SetActive(false);
        if (hideCanvas)
        {
            Destroy(obj.GetComponent<GraphicRaycaster>());
            Destroy(obj.GetComponent<Canvas>());
        }
        MessageCenterLogic.GetInstance().Send(CConfig.mg_WindowClose);
    }

    public void AmnesiaStony(string type)
    {
        //string triggerType = type;
        //foreach (NewUserGuideItemData itemData in NetInfoMgr.instance.gameData.NewUserGuide)
        //{
        //    if (!SaveDataManager.GetBool(CConfig.sv_NewUserStep + itemData.ID))
        //    {
        //        //Debug.Log("bool1:"+CheckCondition(itemData.Condition[0]));
        //        //Debug.Log("bool2:"+(itemData.Trigger == triggerType));
        //        //Debug.Log("id:"+ itemData.ID);
        //        if (itemData.Trigger == triggerType && CheckCondition(itemData.Condition[0]))
        //        {
        //            ShowStep(itemData);
        //            break;
        //        }
        //    }
        //}
    }
    public bool SpearOvernight(Dictionary<string,string> condition)
    {
        //List<string> keyList = new List<string>(condition.Keys);
        //bool isReady = true;
        //foreach (string key in keyList)
        //{
        //    if (key == ConditionType.panel)
        //    {
        //        if (condition[key] != UIManager.GetInstance().PanelName)
        //        {
        //            isReady = false;
        //        }
        //    }
        //    if (key == ConditionType.fish_num)
        //    {
        //        if (CommonUtil.IsApple() && int.Parse(condition[key]) != 7)
        //        {
        //            if (int.Parse(condition[key]) != Dire.instance.getHaveFishCount() + 1)
        //            {
        //                isReady = false;
        //            }
        //        }
        //        else
        //        {
        //            if (int.Parse(condition[key]) != Dire.instance.getHaveFishCount())
        //            {
        //                isReady = false;
        //            }
        //        }
        //    }
        //    if (key == ConditionType.aquarium_num)
        //    {
        //        if (int.Parse(condition[key]) != SaveDataManager.GetIntArray(CConfig.sv_UnlockFishTankList).Length)
        //        {
        //            isReady = false;
        //        }
        //    }
        //    if (key == ConditionType.level_start_num)
        //    {
        //        if (SaveDataManager.GetInt(CConfig.sv_Level_Id) != int.Parse(condition[key]))
        //        {
        //            isReady = false;
        //        }
        //    }
        //    if (key == ConditionType.tile_num)
        //    {
        //        if(Dire.instance.levelCreate.GetComponent<ExtolToll>().getCount != int.Parse(condition[key]))
        //        {
        //            isReady = false;
        //        }
        //    }
        //    if (key == ConditionType.unlock_fish_num)
        //    {
        //        if (Dire.instance.getNextUnlockFishData() != int.Parse(condition[key]))
        //        {
        //            isReady = false;
        //        }
        //    }
        //}
        //return isReady;
        return true;
    }
    public void NoteTale(NewUserGuideItemData data)
    {
        //Arrow.SetActive(false);
        //stepIndexList.Add(data.ID);
        //if (data.TargetPanel == "Tile")
        //{
        //    TileNewUserGuide(data);
        //}
        //else
        //{
        //    Mask.GetComponent<Image>().color = new Color(0, 0, 0, (float)data.MaskAlpha);
        //    Mask.SetActive(true);
        //    Dire.instance.gamePauseMaskAll();
        //    StartCoroutine(setTargetWaitTime(data));
        //}

    }
    IEnumerator BusMarvelCentTerm(NewUserGuideItemData data)
    {
        yield return new WaitForSeconds(0.5f);
        //Debug.Log(data.TargetPath);
        //Transform target = UIManager.GetInstance().MainCanvas.transform.Find(data.TargetPath);
        //if (target)
        //{
        //    //oldParent = target.transform.parent;
        //    Canvas targetCanvas = target.gameObject.AddComponent<Canvas>();
        //    target.gameObject.AddComponent<GraphicRaycaster>();
        //    if (data.Trigger == TriggerType.get_tile)
        //    {
        //        target.Find("LockImage").gameObject.SetActive(false);
        //    }
        //    targetCanvas.overrideSorting = true;
        //    targetCanvas.sortingLayerName = "NewUserLight";
            
        //    targetCanvas.sortingOrder = 1;
        //    if (data.Content.Length > 0)
        //    {
        //        if (data.ID != 1 ) 
        //        {
        //            ContentText.GetComponent<Transform>().Find("ContentText").GetComponent<Text>().fontSize = 40;
        //        }
        //        ContentText.SetActive(true);
        //        ContentText.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)data.ContentPos_X, (float)data.ContentPos_Y-1);
        //        ContentText.GetComponent<Transform>().Find("ContentText").GetComponent<Text>().text = I2.Loc.LocalizationManager.GetTranslation("guide/"+data.Content);
        //    }
        //    else
        //    {
        //        ContentText.SetActive(false);
        //    }

        //    GameObject Hand = Instantiate(HandPrefab, target);
        //    Hand.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)data.HandOffset_X , (float)data.HandOffset_Y );
        //    Hand.SetActive(true);
        //    FindButton(target.gameObject);
        //    if (stepButton)
        //    {
        //        stepButton.onClick.AddListener(finishNewUserStep);
        //        stepButtonList.Add(stepButton);
        //    }
        //    stepTargetList.Add(target.gameObject);
        //}
        //else
        //{
        //    Debug.LogError("找不到引导路径");
        //}
    }

    public void ImpendCapExamTale()
    {
        //ContentText.SetActive(false);
        //int stepIndex = stepIndexList[0];
        //stepIndexList.RemoveAt(0);
        //if (getTriggerWithID(stepIndex) != TriggerType.level_start)
        //{
        //    Button step_button = stepButtonList[0];
        //    GameObject target = stepTargetList[0];
        //    step_button.onClick.RemoveListener(finishNewUserStep);
        //    Destroy(target.GetComponent<GraphicRaycaster>());
        //    Destroy(target.GetComponent<Canvas>());
        //    Destroy(target.transform.Find("Hand(Clone)").gameObject);
        //    stepButtonList.Remove(step_button);
        //    stepTargetList.Remove(target);
        //    Dire.instance.canelGamePauseMaskAll();
        //}
        //if (stepIndexList.Count == 0)
        //{
        //    Mask.SetActive(false);
        //}
        //SaveDataManager.SetBool(CConfig.sv_NewUserStep + stepIndex, true);
    }

    public void BarnArabMovePlateau(Vector2 content_pos,string content_str,Vector2 handpos,bool needHand,GameObject target,bool targetCanTouch,System.Action cb)
    {

        //Mask.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        //Mask.SetActive(true);
        //if (target)
        //{
        //    Canvas targetCanvas = target.gameObject.AddComponent<Canvas>();
        //    if (targetCanTouch)
        //    {
        //        target.gameObject.AddComponent<GraphicRaycaster>();
        //        FindButton(target);
        //        callBack = cb;
        //        stepButton.onClick.AddListener(callBackAction);
        //    }
        //    targetCanvas.overrideSorting = true;
        //    targetCanvas.sortingLayerName = "NewUserLight";
        //    targetCanvas.sortingOrder = 1;
        //    stepTargetList.Add(target);
        //}
        //if (content_str.Length > 0)
        //{
        //    //ContentText.GetComponent<Transform>().Find("ContentText").GetComponent<Text>().fontSize = 42;
        //    Arrow.SetActive(true);
        //    ContentText.SetActive(true);
        //    ContentText.GetComponent<RectTransform>().anchoredPosition = content_pos;/*new Vector2(content_pos.x, content_pos.y * (Screen.height / 1334f));*/
        //    ContentText.GetComponent<Transform>().Find("ContentText").GetComponent<Text>().text = I2.Loc.LocalizationManager.GetTranslation("guide/" + content_str);
        //}
        //else
        //{
        //    ContentText.SetActive(false);
        //}
        //if (needHand)
        //{
        //    GameObject Hand = Instantiate(HandPrefab, target.transform);
        //    Hand.GetComponent<RectTransform>().anchoredPosition = handpos;
        //    Hand.SetActive(true);
        //}
        
    }
    void IconCaneSaline()
    {

        //Mask.SetActive(false);
        //GameObject target = stepTargetList[0];
        //if (!target.name.Contains("Bubble"))
        //{
        //    Destroy(target.GetComponent<GraphicRaycaster>());
        //    Destroy(target.GetComponent<Canvas>());
        //}
        //Destroy(target.transform.Find("Hand(Clone)").gameObject);
        //stepTargetList.Remove(target);
        //callBack();
        //callBack = null;

        //stepButton.onClick.RemoveListener(callBackAction);
    }
    public void BoomUntold(GameObject goParent)
    {
        //Transform parent = goParent.transform;
        //if (parent.GetComponent<Button>())
        //{
        //    stepButton = parent.GetComponent<Button>();
        //    return;
        //}
        //int childCount = parent.childCount;
        //for (int i = 0; i < childCount; i++)
        //{
        //    Transform chile = parent.GetChild(i);
        //    if (chile.GetComponent<Button>())
        //    {
        //        stepButton = chile.GetComponent<Button>();
        //        return;
        //    }
        //    if (chile.childCount > 0)
        //    {
        //        FindButton(chile.gameObject);
        //    }
        //}
    }
    void WordCapExamPivot(NewUserGuideItemData data)
    {
        PlateauDawn.GetComponent<Transform>().Find("ContentText").GetComponent<Text>().fontSize = 35;
        Arab.GetComponent<Image>().color = new Color(0, 0, 0, 0f);
        Arab.SetActive(true);
        if (data.Content.Length > 0)
        {
            PlateauDawn.SetActive(true);
            PlateauDawn.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)data.ContentPos_X, (float)data.ContentPos_Y);
            PlateauDawn.GetComponent<Transform>().Find("ContentText").GetComponent<Text>().text = I2.Loc.LocalizationManager.GetTranslation("guide/"+data.Content);
        }
        Dire.instance.BraveScheme.PpmExamTale();
    }
    public void WordCapExamPivotCrouch()
    {
        PlateauDawn.SetActive(false);

    }
    public string WhoAmnesiaLampID(int id)
    {
        foreach (NewUserGuideItemData data in NetInfoMgr.instance.gameData.NewUserGuide)
        {
            if (id == data.ID)
            {
                return data.Trigger;
            }
        }
        return "";
    }
    public List<int> WhoIDLendLampAmnesia(string type)
    {
        List<int> id_list = new List<int>();
        foreach (NewUserGuideItemData data in NetInfoMgr.instance.gameData.NewUserGuide)
        {
            if (type == data.Trigger)
            {
                id_list.Add(data.ID);
            }
        }
        return id_list;
    }
    static public List<int> WhoIDLendLampAmnesiaCrisis(string type)
    {
        List<int> id_list = new List<int>();
        foreach (NewUserGuideItemData data in NetInfoMgr.instance.gameData.NewUserGuide)
        {
            if (type == data.Trigger)
            {
                id_list.Add(data.ID);
            }
        }
        return id_list;
    }
    //public void step
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
