using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateUtil
{
    //public static long Current()
    //{
    //    return GetTimestamp(DateTime.Now);
    //}

    public static long GetTimestamp(DateTime datetime)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
        long timeStamp = (long)(datetime - startTime).TotalMilliseconds; // 相差毫秒数
        return timeStamp / 1000;
    }

    /// <summary>
    /// 日期格式化
    /// "" : 2022/7/22 11:18:14
    /// "d" : 2022/7/22
    /// "g" : 2022/7/22 11:23
    /// "G" : 2022/7/22 11:23:05
    /// "T" : 11:23:05
    /// "u" : 2022-07-22 11:23:05Z
    /// "s" : 2022-07-22T11:23:05
    /// </summary>
    /// <param name="time"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static string DateTimeFormat(DateTime dt, string format)
    {
        return dt.ToString(format);
    }

    public static DateTime SecondsToDateTime(long seconds)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
        return startTime.AddSeconds(seconds);
    }

    /// <summary>
    /// 秒转化为 时:分:秒 格式
    /// </summary>
    /// <param name="totalTime"></param>
    /// <param name="connector"></param>
    /// <returns></returns>
    public static string SecondsFormat(long totalTime, string connector = ":")
    {
        int seconds = Mathf.Max((int)(totalTime % 60), 0);
        int minutes = Mathf.Max((int)(totalTime / 60) % 60, 0);
        int hours = Mathf.Max((int)(totalTime / 3600), 0);

        string hoursStr = hours >= 10 ? hours.ToString() : "0" + hours;
        string minutesStr = minutes >= 10 ? minutes.ToString() : "0" + minutes;
        string secondsStr = seconds >= 10 ? seconds.ToString() : "0" + seconds;

        return hoursStr + connector + minutesStr + connector + secondsStr;
    }

    public static long Current()
    {
        return GetTimestamp(DateTime.Now);
    }


    //public static long[] StartAndEndPointTime(DateTime now)
   // {
        //long nowTicks = TicksToSeconds(now.Ticks);  // 当前时间
        //long startTicks = TicksToSeconds(DateTime.Today.Ticks); // 当日零点时间

        //int initSeconds = (int)(nowTicks - startTicks);
        ////if (PlayerPrefs.HasKey(SOHOShopConst.sv_InitSeconds))
        ////{
        ////    initSeconds = SaveDataManager.GetInt(SOHOShopConst.sv_InitSeconds);
        ////}
        ////else
        ////{
        ////    SaveDataManager.SetInt(SOHOShopConst.sv_InitSeconds, initSeconds);
        ////}


        //DateTime today = DateTime.Today.AddDays(-1).AddSeconds(initSeconds);
        //startTicks = TicksToSeconds(today.Ticks);

        //int interval = SOHOShopDataManager.instance.shopJson.cash_withdraw_time;
        //int pointCount = 2 * 24 * 60 * 60 / interval;
        //for (int i = 0; i < pointCount; i++)
        //{
        //    if (nowTicks >= startTicks + interval * i && nowTicks < startTicks + interval * (i + 1))
        //    {
        //        return new long[] { startTicks + interval * i, startTicks + interval * (i + 1) };
        //    }
        //}
        //return new long[] { startTicks, startTicks + interval };
   // }

    //public static long[] StartAndEndPointTimeOfNow()
    //{
    //    return StartAndEndPointTime(DateTime.Now);
    //}


    public static long TicksToSeconds(long ticks)
    {
        return ticks / 10000000;
    }

    public static DateTime SecondsToDateTimeOld(long seconds)
    {
        return new DateTime(seconds * 10000000);
    }

}
