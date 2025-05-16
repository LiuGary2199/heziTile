using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Real : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("test")]    [UnityEngine.Serialization.FormerlySerializedAs("test")]public GameObject Pair;
    private void Awake()
    {
        //GameObject can= Resources.Load("Prefabs/Canvas") as GameObject;
       
    }
    // Start is called before the first frame update
    void Start()
    {       
        UIManager.GetInstance().ShowUIForms("TestPanel");
        Transform Pair= UnityHelper.FindTheChildNode(this.gameObject, "test3");
        Debug.Log("yyyyyyyyy"+Pair.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
