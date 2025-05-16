using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.InputSystem;

public class CommonUtil
{
    public static bool IsApple()
    {
        return true;
        return NetInfoMgr.instance.NetServerData.apple_pie == "apple";
    }
    public static bool IsBgswitch()
    {
        bool isbgswitch = NetInfoMgr.instance.NetServerData.bgswitch == "A";
        if (!isbgswitch)
        {
            PlayerPrefs.SetString(CConfig.sys_Newbg, "aa");
        }
        return isbgswitch;
    }
    public static bool IsEditor()
    {
#if UNITY_EDITOR
        return true;
#else
            return false;
#endif
    }

    /// <summary>
    /// 是否为竖屏
    /// </summary>
    /// <returns></returns>
    public static bool IsPortrait()
    {
        return Screen.height > Screen.width;
    }


}
