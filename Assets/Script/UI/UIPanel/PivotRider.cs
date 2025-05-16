using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PivotRider : BaseUIForms
{
[UnityEngine.Serialization.FormerlySerializedAs("nextButton")]    [UnityEngine.Serialization.FormerlySerializedAs("nextButton")]public Button FailUntold;
    // Start is called before the first frame update
    void Start()
    {
        FailUntold.onClick.AddListener(() =>
        {
            MessageCenterLogic.GetInstance().Send(CConfig.mg_HomePanelPlayGuide);
            CloseUIForm(GetType().Name);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
