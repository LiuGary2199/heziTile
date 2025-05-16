using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestWeldRider : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("CLoseBtn")]    [UnityEngine.Serialization.FormerlySerializedAs("CLoseBtn")]public Button CYelpFin;
    // Start is called before the first frame update
    void Start()
    {
        CYelpFin.onClick.AddListener(OvertFinSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OvertFinSpeed()
    {
        gameObject.SetActive(false);
    }
}
