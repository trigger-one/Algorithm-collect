using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class DataManager
{
    Dictionary<int, PlayerData> dic = new Dictionary<int, PlayerData>(); //玩家参数，等级为索引
    Dictionary<int, EquipData> dic_equip = new Dictionary<int, EquipData>(); //装备参数，装备ID为索引
    public DataManager()
    {
        InitPlayerData(typeof(PlayerData));
        InitEquipData(typeof(EquipData));
    }
    /// <summary>
    /// 创建玩家参数表
    /// </summary>
    public void InitPlayerData(Type type)
    {
        StreamReader F = new StreamReader("Excel/玩家配置表.csv");
        string readStr = F.ReadToEnd();
        string[] arrRow = readStr.Split('\n');
        string[] arrName = arrRow[1].Split(',');
        for (int i = 2; i < arrRow.Length; i++)
        {
            string str_Row = arrRow[i];
            if (str_Row.Length == 0) return;
            string[] str_value = str_Row.Split(',');
            PlayerData cfg = Activator.CreateInstance(type) as PlayerData;
            for (int j = 0; j < arrName.Length - 1; j++)
            {
                string propName = arrName[j];
                if (str_value[j] == null) str_value[j] = "0";
                string propValue = str_value[j];
                SetPropertyValue(cfg, propName, propValue);
            }
            dic[cfg.Level] = cfg;
        }
    }
    /// <summary>
    /// 创建装备参数表
    /// </summary>
    public void InitEquipData(Type type)
    {
        StreamReader F = new StreamReader("Excel/道具列表.csv");
        string readStr = F.ReadToEnd();
        string[] arrRow = readStr.Split('\n');
        string[] arrName = arrRow[1].Split(',');
        for (int i = 2; i < arrRow.Length; i++)
        {
            string str_Row = arrRow[i];
            if (str_Row.Length == 0) return;
            string[] str_value = str_Row.Split(',');
            EquipData cfg = Activator.CreateInstance(type) as EquipData;
            for (int j = 0; j < arrName.Length - 1; j++)
            {
                string propName = arrName[j];
                if (str_value[j] == null) str_value[j] = "0";
                string propValue = str_value[j];
                SetPropertyValue(cfg, propName, propValue);
            }
            dic_equip[cfg.ID] = cfg;
        }
    }
    /// <summary>
    /// 通过反射设置参数
    /// </summary>
    public static void SetPropertyValue(object obj, string propName, string PropValue)
    {
        if (obj == null || string.IsNullOrEmpty(propName) || string.IsNullOrEmpty(PropValue)) throw new NullReferenceException();
        Type cfgType = obj.GetType();
        PropertyInfo propertyInfo = cfgType.GetProperty(propName);
        if (propertyInfo == null) throw new NullReferenceException();
        Type propType = propertyInfo.PropertyType;
        object obj_value = Convert.ChangeType(PropValue, propType);
        propertyInfo.SetValue(obj, obj_value);
    }
    public PlayerData getCfgByLevel(int Level)
    {
        if (dic.ContainsKey(Level))
        {
            return dic[Level];
        }
        return null;
    }
    public EquipData getCfgByID(int ID)
    {
        if (dic.ContainsKey(ID))
        {
            return dic_equip[ID];
        }
        return null;
    }
}