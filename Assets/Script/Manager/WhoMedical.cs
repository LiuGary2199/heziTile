using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoMedical : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("FlyClan")]    [UnityEngine.Serialization.FormerlySerializedAs("FlyClan")]public GameObject FlyClan;
    public static WhoMedical Instance;
[UnityEngine.Serialization.FormerlySerializedAs("isOpenFly")]
[UnityEngine.Serialization.FormerlySerializedAs("isOpenFly")]    public bool NoDumpWho;
[UnityEngine.Serialization.FormerlySerializedAs("leftOrRight")]    [UnityEngine.Serialization.FormerlySerializedAs("leftOrRight")]public int MastToBound;

    private int _SandyDumpTerm;
    private int _BisAddTerm;

    private void Awake()
    {
        Instance = this;
        _BisAddTerm = 0;
        NoDumpWho = true;
        _SandyDumpTerm = NetInfoMgr.instance.gameFlyData.cold_down;
        //_startOpenTime = 0;
        MastToBound = 0;
        MessageCenterLogic.GetInstance().Register(CConfig.mg_PassLevel, (messageData) =>
        {
            LichenWhoClan();
        });
        MessageCenterLogic.GetInstance().Register(CConfig.mg_StartLevel, (messageData) =>
        {
            BendWho();
        });
    }

    private void OnEnable()
    {
        //OpenIEFly();
    }

    public void DumpIEWho()
    {
        StopCoroutine(nameof(DumpWhoLocust));
        StartCoroutine(nameof(DumpWhoLocust));
    }

    public void BendWho()
    {
        _BisAddTerm = NetInfoMgr.instance.gameFlyData.cold_down;
        StopCoroutine(nameof(DumpWhoLocust));
        StartCoroutine(nameof(DumpWhoLocust));
    }
    IEnumerator DumpWhoLocust()
    {
        while (NoDumpWho)
        {
            if (_BisAddTerm >= _SandyDumpTerm)
            {
                SchemeWhoClan();
            }
            _BisAddTerm++;
            yield return new WaitForSeconds(1);
        }
    }

    public void LichenWhoClan()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<FlyClan>().CartoonWhoClan();
            NoDumpWho = true;
            _BisAddTerm = 0;
        }
    }

    public void SchemeWhoClan()
    {
        if (CommonUtil.IsApple())
        {
            return;
        }
        else
        {

        }
        if (!NoDumpWho) { return; }
        if (Dire.instance.OakDireCrouch()) { return; }
        if (Dire.instance.WhoExamExtol() > 1 && !CommonUtil.IsApple())
        {
            NoDumpWho = false;
            _BisAddTerm = 0;
            GameObject obj = Instantiate(FlyClan.gameObject);
            obj.transform.SetParent(transform);
            obj.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            obj.transform.localPosition = MastToBound == 0 ? new Vector3(-450, 0, 0) : new Vector3(450, 0, 0);
        }
    }
}
