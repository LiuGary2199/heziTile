using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurifyRealRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]    [UnityEngine.Serialization.FormerlySerializedAs("CloseButton")]public Button OvertUntold;
[UnityEngine.Serialization.FormerlySerializedAs("AdjustAdidText")]    [UnityEngine.Serialization.FormerlySerializedAs("AdjustAdidText")]public Text PurifyMoltDawn;
[UnityEngine.Serialization.FormerlySerializedAs("ServerIdText")]    [UnityEngine.Serialization.FormerlySerializedAs("ServerIdText")]public Text NearlyOnDawn;
[UnityEngine.Serialization.FormerlySerializedAs("ActCounterText")]    [UnityEngine.Serialization.FormerlySerializedAs("ActCounterText")]public Text ActAccreteDawn;
[UnityEngine.Serialization.FormerlySerializedAs("AdjustTypeText")]    [UnityEngine.Serialization.FormerlySerializedAs("AdjustTypeText")]public Text PurifyLaceDawn;
[UnityEngine.Serialization.FormerlySerializedAs("ResetActCountButton")]    [UnityEngine.Serialization.FormerlySerializedAs("ResetActCountButton")]public Button AsianSewGrassUntold;
[UnityEngine.Serialization.FormerlySerializedAs("AddActCountButton")]    [UnityEngine.Serialization.FormerlySerializedAs("AddActCountButton")]public Button WhoSewGrassUntold;

    // Start is called before the first frame update
    void Start()
    {
        OvertUntold.onClick.AddListener(() => {
            CloseUIForm(GetType().Name);
        });

        AsianSewGrassUntold.onClick.AddListener(() => {
            AdjustInitManager.Instance.ResetActCount();
        });

        WhoSewGrassUntold.onClick.AddListener(() => {
            AdjustInitManager.Instance.AddActCount("test");
        });
    }

    private void NoteAccreteDawn()
    {
        PurifyMoltDawn.text = AdjustInitManager.Instance.GetAdjustAdid();
        NearlyOnDawn.text = SaveDataManager.GetString(CConfig.sv_LocalServerId);
        ActAccreteDawn.text = AdjustInitManager.Instance._currentCount.ToString();
        PurifyLaceDawn.text = SaveDataManager.GetString("sv_ADJustInitType");
    }

    public override void Display()
    {
        base.Display();
        InvokeRepeating(nameof(NoteAccreteDawn), 0, 0.5f);
    }

    public override void Hidding()
    {
        base.Hidding();
        CancelInvoke(nameof(NoteAccreteDawn));
    }
}
