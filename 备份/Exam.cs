using System;
using System.Collections.Generic;
public class Exam {   
    public class MaterialData {       
        public ItemData item;   //合成所需的物品
        public int count;       //合成所需的该物品的数量
        public MaterialData (ItemData item, int count) {
            this.item = item;
            this.count = count;
        }
    }

    public class ItemData {       
        public int id;  //物品 ID
        public int count; //当前拥有的物品数量
        public int costGold; //合成该物品所需的金币
        public List<MaterialData> materialList = new List<MaterialData> (); //合成该物品所需的材料
        public void Add (MaterialData materialData) {
            materialList.Add (materialData);
        }
        public ItemData (int id, int count, int costGold) {
            this.id = id;
            this.count = count;
            this.costGold = costGold;
        }
    }

        /// <summary>
        /// 计算用 totalGold 金币最多可以合成的 item 装备的数量
        /// </summary>
        /// <param name="item">要合成的装备</param>
        /// <param name="totalGold">拥有的金币</param>
        /// <returns>可合成的 item 装备的最大数量</returns>
    public int Run (ItemData item, int totalGold) {
        int num = decide (item, totalGold);
        return num;
    }
    /// <summary>
    ///  判断函数
    /// </summary>
    private int decide (ItemData item, int totalGold) {
        float x = item.materialList[0].item.count / item.materialList[0].count;
        float y = item.materialList[1].item.count / item.materialList[1].count;
        float z = totalGold / item.costGold;
        int a = (int) MathF.Floor (x);
        int b = (int) MathF.Floor (y);
        int c = (int) MathF.Floor (z);
        int[] arr = { a, b, c };
        if (a != 0 && b != 0 && c != 0) {
            int d = Findmin (arr);
            return d;
        } else {
            return 0;
        }
    }
    private int Findmin (int[] x) {
        int min = x[0];
        for (int i = 0; i < x.Length; i++) {
            if (min > x[i]) {
                min = x[i];
            }
        }
        return min;
    }
}