using System;
using System.Collections.Generic;
public class Tool {
    static Dictionary<string, object> Dic = new Dictionary<string, object> ();
    static Dictionary<string, object> Dic_ = new Dictionary<string, object> ();
    /// <summary>
    /// 用于保存玩家参数的数据类型
    /// </summary>
    public static PlayerData PD;
    /// <summary>
    /// 用于保存装备参数的数据类型
    /// </summary>
    public static EquipData ED;
    /// <summary>
    /// 
    /// </summary>
    private static String[] P, E = { };
    private static object[] p, e;
    /// <summary>
    /// 传入人物与装备的各项参数并从表中获取对应数值
    /// </summary>
    /// <param name="DM">数据管理对象</param>
    /// <param name="Level">人物等级</param>
    /// <param name="EquipID">物品ID</param>
    public static void SetDicValue (DataManager DM, int Level, int EquipID) {
        PD = DM.getCfgByLevel (Level);
        P = Enum.GetNames (typeof (PlayerDataE));
        p = PD.GetVs ();

        ED = DM.getCfgByID (EquipID);
        E = Enum.GetNames (typeof (EquipDataE));
        e = ED.GetVs ();

        for (int i = 0; i < P.Length; i++)
            Dic.Add (P[i], p[i]);
        for (int i = 0; i < E.Length; i++)
            Dic_.Add (E[i], e[i]);
        Console.Write ("玩家参数: " + PD);
        Console.Write ("装备参数: " + ED);
        Status ();
    }
    /// <summary>
    /// 获取人物对应等级穿着对应装备后的面板参数并打印
    /// </summary>
    public static void Status () {
        #region 弃用部分代码
        /* for (int i = 0; i < P.Length; i++) {
            Dic.TryGetValue (P[i], out var Pvalue);
            Console.Write ("{0} = {1}; ", P[i], Pvalue);
        }
        Console.WriteLine ();
        for (int i = 0; i < E.Length; i++) {
            Dic_.TryGetValue (E[i], out var Evalue);
            Console.Write ("{0} = {1}; ", E[i], Evalue);
        } */
        #endregion
        int[] x = { };
        for (int i = 1; i < P.Length; i++) {
            for (int j = i; j < E.Length; j++) {
                if (P[i] == E[j]) {
                    Dic.TryGetValue (P[i], out var Pvalue);
                    Dic_.TryGetValue (E[j], out var Evalue);
                    int y = Convert.ToInt32 (Pvalue) + Convert.ToInt32 (Evalue);
                    Console.Write ("{0} = {1}, ", P[i], y);
                }
            }
        }
        // Console.WriteLine ();
        // Dic_.TryGetValue ("Name", out var value);
        // Console.Write (value);
    }
}