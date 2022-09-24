using System.Collections;
public enum PlayerDataE {
    Level,
    ATK,
    MTK,
    DEF,
    MDF,
    SPD
}
public enum EquipDataE {
    ID,
    Name,
    ATK,
    MTK,
    DEF,
    MDF,
    SPD,
    EFF
}
public class PlayerData {
    public int Level { get; set; }
    public int ATK { get; set; }
    public int MTK { get; set; }
    public int DEF { get; set; }
    public int MDF { get; set; }
    public int SPD { get; set; }
    public override string ToString () {
        return $"Level = " + Level + ", ATK = " + ATK + ", MTK = " + MTK + ", DEF = " + DEF + ", MDF = " + MDF + ", SPD = " + SPD + "\n";
    }
    public object[] GetVs () {
        object[] a = { Level, ATK, MTK, DEF, MDF, SPD };
        return a;
    }
}
public class EquipData {
    public int ID { get; set; }
    public string Name { get; set; }
    public int ATK { get; set; }
    public int MTK { get; set; }
    public int DEF { get; set; }
    public int MDF { get; set; }
    public int SPD { get; set; }
    public string EFF { get; set; }
    public override string ToString () {
        return $"ID = " + ID + ", Name = " + Name + ", ATK = " + ATK + ", MTK = " + MTK + ", DEF = " + DEF + ", MDF = " + MDF + ", SPD = " + SPD + ", EFF = " + EFF + "\n";
    }
    public object[] GetVs () {
        object[] a = { ID, Name, ATK, MTK, DEF, MDF, SPD, EFF };
        return a;
    }
}