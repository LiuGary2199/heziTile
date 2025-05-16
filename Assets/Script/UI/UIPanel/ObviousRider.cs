using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObviousRider : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("newImage")]    [UnityEngine.Serialization.FormerlySerializedAs("newImage")]public GameObject PpmNomad;
[UnityEngine.Serialization.FormerlySerializedAs("sliderImage")]
[UnityEngine.Serialization.FormerlySerializedAs("sliderImage")]    public Image TavernNomad;
[UnityEngine.Serialization.FormerlySerializedAs("progressText")]    [UnityEngine.Serialization.FormerlySerializedAs("progressText")]public Text ImmatureDawn;
    // Start is called before the first frame update
    void Start()
    {
        PpmNomad.SetActive(!PlayerPrefs.HasKey(CConfig.sys_Newbg));
        TavernNomad.fillAmount = 0;
        ImmatureDawn.text = "0%";
        if (!PlayerPrefs.HasKey(CConfig.sys_language))
        {
            SaveDataManager.SetString(CConfig.sys_language, I2.Loc.LocalizationManager.CurrentLanguage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TavernNomad.fillAmount <= 0.8f || NetInfoMgr.instance.ready)
        {
            TavernNomad.fillAmount += Time.deltaTime / 3f;
            ImmatureDawn.text = (int)(TavernNomad.fillAmount * 100) + "%";
            if (TavernNomad.fillAmount >= 1)
            {
                Destroy(transform.parent.gameObject);
                Dire.instance.FirnTour();
            }
        }
    }
}
