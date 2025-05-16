using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RookieItem
{
    public Button Indeed;
    public Image Shade;
    public Image Patch;
    public Image Brave;
    public int id;
}
public class SpiralMiocene : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ButtonGroup")]    [UnityEngine.Serialization.FormerlySerializedAs("ButtonGroup")]public GameObject UntoldModel;
[UnityEngine.Serialization.FormerlySerializedAs("SubmitButton")]    [UnityEngine.Serialization.FormerlySerializedAs("SubmitButton")]public Button HardlyUntold;
    List<RookieItem> ClanLend;
    List<RookieItem> MetricLend;
[UnityEngine.Serialization.FormerlySerializedAs("maskImage")]    [UnityEngine.Serialization.FormerlySerializedAs("maskImage")]public GameObject SagoNomad;
    // Start is called before the first frame update
    void Start()
    {
        SagoNomad.SetActive(true);
        HardlyUntold.onClick.AddListener(Hardly);
        MetricLend = new List<RookieItem>();
        ClanLend = new List<RookieItem>();
        for (int i = 0; i < UntoldModel.transform.childCount; i++)
        {
            int Boost= i;
            GameObject obj = UntoldModel.transform.GetChild(i).gameObject;
            RookieItem item = new RookieItem();
            item.Indeed = obj.GetComponent<Button>();
            item.Patch = obj.transform.Find("Light").GetComponent<Image>();
            item.Shade = obj.transform.Find("Image").GetComponent<Image>();
            item.Brave = obj.transform.Find("level").GetComponent<Image>();
            ClanLend.Add(item);
            int rookieId = ForestPoemOustMedical.instance.ForestPoemOust.RookiePackage[i];
            item.id = rookieId;
            RobloxItemData itemData = ForestPoemOustMedical.instance.ForestClanReply[rookieId];
            item.Brave.sprite = Resources.Load<Sprite>(CConfig.RRobloxJsonrobloximgLevel + itemData.Level);
            item.Shade.sprite = ForestPoemOustMedical.instance.OakRuggedMeID(rookieId);
            item.Patch.gameObject.SetActive(false);
            item.Indeed.onClick.AddListener(()=> {
                MetricClan(Boost);
            });
        }
    }
    void MetricClan(int i)
    {
        
        RookieItem item = ClanLend[i];
        if (!MetricLend.Contains(item))
        {
            item.Patch.gameObject.SetActive(true);
            if (MetricLend.Count < 3)
            {
                MetricLend.Add(item);
            }
            else
            {
                MetricLend[0].Patch.gameObject.SetActive(false);
                MetricLend.RemoveAt(0);
                MetricLend.Add(item);
            }
        }
        else
        {
            item.Patch.gameObject.SetActive(false);
            MetricLend.Remove(item);
        }
        if (MetricLend.Count == 3)
        {
            SagoNomad.SetActive(false);
        }
        else
        {
            SagoNomad.SetActive(true);
        }
    }
    void Hardly()
    {
        if (MetricLend.Count == 3)
        {
            List<int> idList = new List<int>();
            foreach (RookieItem item in MetricLend)
            {
                idList.Add(item.id);
            }
            SaveDataManager.SetIntArray("RookieList", idList.ToArray());
            gameObject.SetActive(false);
            ForestPoemOustMedical.instance.MeetingForeshadow();
            ForestPoemRider.instance.MeetingArbitraryGroove();
            ForestPoemRider.instance.Pivot(4);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
