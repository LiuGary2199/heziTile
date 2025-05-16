using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestRailFinBoston : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("ID")]    [UnityEngine.Serialization.FormerlySerializedAs("ID")]public int ID;
[UnityEngine.Serialization.FormerlySerializedAs("Btn")]
[UnityEngine.Serialization.FormerlySerializedAs("Btn")]    public Button Fin;
[UnityEngine.Serialization.FormerlySerializedAs("RefreshGameInfo")]    [UnityEngine.Serialization.FormerlySerializedAs("RefreshGameInfo")]public Action<int> MeetingDireGate;
    
    // Start is called before the first frame update
    void Start()
    {
        Fin.onClick.AddListener(SpeedFin);
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpeedFin()
    {
        //Debug.LogError("id == " + ID);
        //RefreshGameInfo?.Invoke(ID);
    }
    
}
