using System.Text;
using System.Text.RegularExpressions;
namespace Yan
{
    /// <summary>
    /// 链表类型，模拟指针
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val, ListNode? next)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Node
    {
        public int val;
        public Node? left;
        public Node? right;
        public Node? next;
        public Node() { }
        public Node(int _val)
        {
            val = _val;
        }
        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    public class Node2
    {
        public int val;
        public IList<Node2> neighbors;

        public Node2()
        {
            val = 0;
            neighbors = new List<Node2>();
        }

        public Node2(int _val)
        {
            val = _val;
            neighbors = new List<Node2>();
        }

        public Node2(int _val, List<Node2> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    public class Algorithm
    {
        //NOTE 关键字文本：TODO HACK NOTE INFO TAG XXX BUG FIXME
        private int len; //全局变量
        int maxSum = int.MinValue;//最小整数
        /// <summary>
        /// 于L_37_SolveSudoku中调用
        /// </summary>
        List<Dictionary<int, bool>> liCol = new List<Dictionary<int, bool>>();
        /// <summary>
        /// 于L_37_SolveSudoku中调用
        /// </summary>
        List<Dictionary<int, bool>> liRow = new List<Dictionary<int, bool>>();
        /// <summary>
        /// 于L_37_SolveSudoku中调用
        /// </summary>
        List<Dictionary<int, bool>> liBox = new List<Dictionary<int, bool>>();
        /// <summary>
        /// 于L_37_SolveSudoku中调用
        /// </summary>
        char[][]? boardAllres = null;
        /// <summary>
        /// 于L_79_Exist中调用
        /// </summary>
        int[][] direction = new int[][] { new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 } };

        /// <summary>
        /// 于L_65_IsNumber调用
        /// </summary>
        private static Regex pattern = new Regex(@"^\s*[+-]?(?:\d+|(?=\.\d))(?:\.\d*)?(?:e[+-]?\d+)?\s*$");

        /// <summary>
        ///  1+2+3+....+n的递归算法
        /// </summary>
        public int process1(int i)
        {
            //计算1+2+3+4+...+i的值
            if (i == 0) return 1;
            if (i == 1) return 1;
            return process1(i - 2) + process1(i - 1);
        }
        /// <summary>
        /// 1+2+3+....+n的非递归算法
        /// </summary>
        public int process2(int i)
        {
            //计算1+2+3+4+...+i的值
            if (i == 0) return 0;
            return process2(i - 1) + i;
        }
        /// <summary>
        /// 1-2+3-4+5-....+n的非递归算法
        /// </summary>
        public int process0(int isum, int itype)
        {
            int sum = 0;
            for (int i = 1; i <= isum; i++)
            {
                if (itype == 1)
                {
                    if (i % 2 != 0)
                    {
                        sum += i;
                    }
                    else
                    {
                        sum += (-1) * i;
                    }
                }
                else
                {
                    sum += i;
                }
            }
            return sum;
        }
        /// <summary>
        /// 冒泡 平均时间复杂度：O(n²) 空间复杂度：O(1) 不占用额外内存 稳定
        /// </summary>
        public int[] BubbleSort(int[] a)
        {
            if (a.Length == 0) return a;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1 - i; j++)
                {
                    if (a[j + 1] < a[j])
                    {
                        Swap(ref a[j + 1], ref a[j]);
                    }
                }
            }
            Console.WriteLine("冒泡排序");
            return a;
        }
        /// <summary>
        /// 选择排序 平均时间复杂度：O(n²) 空间复杂度：O(1) 不占用额外内存 不稳定
        /// </summary>
        public int[] SelectionSort(int[] a)
        {
            if (a.Length == 0) return a;
            for (int i = 0; i < a.Length; i++)
            {
                int minIndex = i;
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] < a[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(ref a[minIndex], ref a[i]);
            }
            Console.WriteLine("选择排序");
            return a;
        }
        /// <summary>
        /// 插入排序 平均时间复杂度：O(n²) 空间复杂度：O(1) 不占用额外内存 稳定
        /// </summary>
        public int[] InsertionSort(int[] a)
        {
            if (a.Length == 0) return a;
            int current;
            for (int i = 0; i < a.Length - 1; i++)
            {
                current = a[i + 1];
                int preIndex = i;
                while (preIndex >= 0 && current < a[preIndex])
                {
                    a[preIndex + 1] = a[preIndex];
                    preIndex--;
                }
                a[preIndex + 1] = current;
            }
            Console.WriteLine("插入排序");
            return a;
        }
        /// <summary>
        /// 希尔排序 平均时间复杂度：O(n log n) 空间复杂度：O(1) 不占用额外内存 不稳定
        /// </summary>
        public int[] LengthShellSort(int[] a)
        {
            int len = a.Length;
            int temp, gap = len / 2;
            while (gap > 0)
            {
                for (int i = gap; i < len; i++)
                {
                    temp = a[i];
                    int preIndex = i - gap;
                    while (preIndex >= 0 && a[preIndex] > temp)
                    {
                        a[preIndex + gap] = a[preIndex];
                        preIndex -= gap;
                    }
                    a[preIndex + gap] = temp;
                }
                gap /= 2;
            }
            Console.WriteLine("希尔排序");
            return a;
        }
        /// <summary>
        /// 归并排序 平均时间复杂度：O(n log n) 空间复杂度：O(n) 占用额外内存 稳定
        /// </summary>
        public int[] MergeSort(int[] a)
        {
            if (a.Length < 2) return a;
            int mid = a.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[a.Length - mid];
            left = Copy(a, 0, mid);
            right = Copy(a, mid, a.Length);
            return Merge(MergeSort(left), MergeSort(right));
        }
        /// <summary>
        /// 快速排序 平均时间复杂度：O(n log n) 空间复杂度：O(log n) 不占用额外内存 不稳定
        /// </summary>
        /// <param name="start">开始</param>
        /// <param name="end">结束(长度-1)</param>
        /// <returns></returns>
        public int[]? QuickSort(int[] a, int start, int end)
        {
            if (a.Length < 1 || start < 0 || end >= a.Length || start > end) return null;
            int smallIndex = partition(a, start, end);
            if (smallIndex > start)
            {
                QuickSort(a, start, smallIndex - 1);
            }
            if (smallIndex < end)
            {
                QuickSort(a, smallIndex + 1, end);
            }
            Console.WriteLine("快速排序");
            return a;
        }
        /// <summary>
        /// 堆排序 平均时间复杂度：O(n log n) 空间复杂度：O(1) 不占用额外内存 不稳定
        /// </summary>
        public int[] HeapSort(int[] a)
        {
            len = a.Length - 1;
            for (int i = len; i >= 0; i--)
            {
                buildMaxHeap(a, i);
                Swap(ref a[0], ref a[i]);
            }
            Console.WriteLine("堆排序");
            return a;
        }
        /// <summary>
        /// 计数排序 平均时间复杂度：O(n + k) 空间复杂度：O(k) 占用额外内存 稳定
        /// </summary>
        /* 
        1计数排序是一种非常快捷的 稳定性强 的排序方法，时间复杂度O(n+k),其中n为要排序的数的个数，k为要排序的数的最大值。
        2计数排序对一定量的整数排序时候的速度非常快，一般快于其他排序算法，只限于整数进行排序。
        3计数排序是消耗空间复杂度来获取快捷的排序方法，其空间复杂度为O(K) 同理K为要排序的最大值。 */
        public int[] CcountingSort(int[] a)
        {
            //1.得到数列的最大值
            int Max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > Max)
                {
                    Max = a[i];
                }
            }
            //2.根据数列最大值确定统计数组的长度
            int[] newa = new int[Max + 1];
            //3.遍历数列，填充统计数组
            for (int i = 0; i < a.Length; i++)
            {
                newa[a[i]]++;
            }
            //4.遍历统计数组，输出结果
            int index = 0;
            for (int i = 0; i < newa.Length; i++)
            {
                for (int j = 0; j < newa[i]; j++)
                {
                    a[index++] = i;
                }
            }
            Console.Write("计数排序");
            return newa;
        }
        /// <summary>
        /// 基数排序 平均时间复杂度：O(n * k) 空间复杂度：O(n + k) 占用额外内存 稳定
        /// </summary>
        /// <param name="digit">基数大小，为方便保险一般设为10</param>
        public int[] RadixSort(int[] ArrayToSort, int digit)
        {
            for (int k = 1; k <= digit; k++)
            {
                int[] tmpArray = new int[ArrayToSort.Length];
                int[] tmpCountingSortArray = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int i = 0; i < ArrayToSort.Length; i++)
                {
                    int tmpSplitDigit = ArrayToSort[i] / (int)Math.Pow(10, k - 1) - (ArrayToSort[i] / (int)Math.Pow(10, k)) * 10;
                    tmpCountingSortArray[tmpSplitDigit] += 1;
                }
                for (int m = 1; m < 10; m++)
                {
                    tmpCountingSortArray[m] += tmpCountingSortArray[m - 1];
                }
                for (int n = ArrayToSort.Length - 1; n >= 0; n--)
                {
                    int tmpSplitDigit = ArrayToSort[n] / (int)Math.Pow(10, k - 1) - (ArrayToSort[n] / (int)Math.Pow(10, k)) * 10;
                    tmpArray[tmpCountingSortArray[tmpSplitDigit] - 1] = ArrayToSort[n];
                    tmpCountingSortArray[tmpSplitDigit] -= 1;
                }
                for (int p = 0; p < ArrayToSort.Length; p++)
                {
                    ArrayToSort[p] = tmpArray[p];
                }
            }
            Console.WriteLine("基数排序");
            return ArrayToSort;
        }
        /// <summary>
        /// 桶排序 平均时间复杂度：O(n + k) 空间复杂度：O(n + k) 占用额外内存 稳定
        /// </summary>
        /// <param name="bucketSize">桶（可理解为一个范围区间）的大小,数值越大可储存的范围越大，数字也会越多</param>
        public int[] BucketSort(int[] array, int bucketSize)
        {
            /* 创建bucket时，在二维中增加一组标识位，其中bucket[x, 0]表示这一维所包含的数字的个数
            通过这样的技巧可以少写很多代码 */
            int[,] bucket = new int[bucketSize, array.Length + 1];
            foreach (var num in array)
            {
                int bit = num;
                bucket[bit, (int)++bucket[bit, 0]] = num;
            }
            //为桶里的每一行使用插入排序
            for (int j = 0; j < bucketSize; j++)
            {
                //为桶里的行创建新的数组后使用插入排序
                int[] insertion = new int[(int)bucket[j, 0]];
                for (int k = 0; k < insertion.Length; k++)
                {
                    insertion[k] = bucket[j, k + 1];
                }
                //插入排序
                InsertionSort(insertion);
                //把排好序的结果回写到桶里
                for (int k = 0; k < insertion.Length; k++)
                {
                    bucket[j, k + 1] = insertion[k];
                }
            }
            //将所有桶里的数据回写到原数组中
            for (int count = 0, j = 0; j < bucketSize; j++)
            {
                for (int k = 1; k <= bucket[j, 0]; k++)
                {
                    array[count++] = bucket[j, k];
                }
            }
            Console.WriteLine("桶排序");
            return array;
        }
        /// <summary>
        /// 段语句反向输出，以空格为分割
        /// </summary>
        /// <param name="str">需要反向输出的字符串</param>
        /// <returns></returns>
        public string Reverse(string str)
        {
            string[] arr = str.Split(' ');
            string res = "";
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                res += arr[i];
                if (i > 0)
                    res += " ";
            }
            return res;
        }
        /// <summary>
        /// 单词反向输出
        /// </summary>
        /// <param name="str">输入单词</param>
        public string reverseWords(string s)
        {
            string temp = "";
            for (int x = s.Length - 1; x >= 0; x--)
            {
                temp += s[x];
            }
            return temp;
        }
        /// <summary>
        /// leetcode第1题，两数之和。
        /// 链接：https://leetcode-cn.com/problems/two-sum/solution/leetcode-1-two-sum-liang-shu-zhi-he-c-ha-xi-biao-d/
        /// </summary>
        /// <param name="nums">数据源数组</param>
        /// <param name="target">相加目标值</param>
        /// <returns></returns>
        public int[] L_1_twoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = i + 1; j < nums.Length; ++j)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[0];
        }
        /// <summary>
        /// leetcode第2题，两数相加
        /// 链接：https://leetcode-cn.com/problems/add-two-numbers/solution/cjie-ti-de-wan-zheng-dai-ma-bao-gua-sheng-cheng-ce/
        /// </summary>
        /// <returns></returns>
        public ListNode? L_2_AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            int val = 0;
            ListNode prenode = new ListNode(0, null);
            ListNode lastnode = prenode;
            while (l1 != null || l2 != null || val != 0)
            {
                val = val + (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
                lastnode.next = new ListNode(val % 10, null);
                lastnode = lastnode.next;
                val = val / 10;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }
            return prenode.next;
        }
        /// <summary>
        /// leetcode第3题，无重复字符的最长子串
        /// 链接：https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/solution/wu-zhong-fu-zi-fu-de-zui-chang-zi-chuan-w5ifk/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int L_3_LengthOfLongestSubstring(string s)
        {
            if (s.Length < 2) return s.Length;
            var left = 0;
            var right = 0;
            var maxlen = 0;
            var charSet = new HashSet<char>();
            while (right < s.Length)
            {
                if (charSet.Contains(s[right]) == false)
                {
                    charSet.Add(s[right++]);
                    maxlen = Math.Max(maxlen, right - left);
                }
                else
                {
                    charSet.Remove(s[left++]);
                }
            }
            return maxlen;
        }
        /// <summary>
        /// leetcode第4题，寻找两个正序数组的中位数
        /// 链接：https://leetcode-cn.com/problems/median-of-two-sorted-arrays/solution/cban-guan-fang-jie-fa-by-shadowrabbit/
        /// </summary>
        /// <returns></returns>
        public double L_4_FindMedianSortedArrays(int[] A, int[] B)
        {
            //确保A长度小于等于B
            if (A.Length > B.Length)
            {
                int[] temp = A;
                A = B;
                B = temp;
            }
            int iStart = 0;
            int iEnd = A.Length;
            //正常范围内
            while (iStart <= iEnd)
            {
                int i = (iStart + iEnd) / 2;
                /* 取中间索引 二分查找法
                在索引i位置将A切为两半,A左半部分长度为i,右半部分为A.length-i;
                在索引j位置将B切为两半,B左半部分长度为j,右半部分长度为B.length-j;
                将A左半部分与B左半部分相加,A右半部分与B右半部分相加 有i+j=A.length-i+B.length-j 或A.length-i+B.length-j+1;
                整合得到j的表达式 */
                int j = (A.Length + B.Length + 1 - 2 * i) / 2;
                /* 找到中位数时存在以下不等式关系
                此时i偏小 继续二分查找并增大i */
                if (i < iEnd && B[j - 1] > A[i])
                {
                    iStart = i + 1;
                }
                //i偏大
                else if (i > iStart && A[i - 1] > B[j])
                {
                    iEnd = i - 1;
                }
                //满足条件
                else
                {
                    //边界值
                    int maxLeft = 0;
                    if (i == 0)
                    {
                        maxLeft = B[j - 1];
                    }
                    else if (j == 0)
                    {
                        maxLeft = A[i - 1];
                    }
                    else
                    {
                        maxLeft = Math.Max(A[i - 1], B[j - 1]);
                    }
                    //奇数情况
                    if ((A.Length + B.Length) % 2 == 1)
                    {
                        return maxLeft;
                    }
                    //边界值
                    int minRight = 0;
                    if (i == A.Length)
                    {
                        minRight = B[j];
                    }
                    else if (j == B.Length)
                    {
                        minRight = A[i];
                    }
                    else
                    {
                        minRight = Math.Min(B[j], A[i]);
                    }
                    //偶数情况
                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }
        /// <summary>
        /// leetcode第5题，最长回文子串
        /// 链接：https://leetcode-cn.com/problems/longest-palindromic-substring/solution/leetcode-5-longest-palindromic-substring-zui-chang/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string L_5_LongestPalindrome(string s)
        {
            int n = s.Length;
            bool[,] P = new bool[n, n];
            string result = "";
            //遍历所有的长度
            for (int len = 1; len <= n; len++)
            {
                for (int start = 0; start < n; start++)
                {
                    int end = start + len - 1;
                    if (end >= n) //下标已经越界，结束本次循环
                        break;
                    //长度为 1 和 2 的单独判断下
                    P[start, end] = (len == 1 || len == 2 || P[start + 1, end - 1]) && s[start] == s[end];
                    if (P[start, end] && len > result.Length)
                    {
                        result = s.Substring(start, len);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// leetcode第6题，Z字形变换
        /// 链接：https://leetcode-cn.com/problems/zigzag-conversion/solution/guan-fang-an-xing-pai-xu-jie-fa-cban-tong-su-yi-do/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string L_6_Convert(string s, int numRows)
        {
            if (numRows == 1) return s;//如果行数为一，直接返回字符串

            List<StringBuilder> sbList = new List<StringBuilder>();
            //为了防止字符串长度小于行数的特殊情况， 取行数和s的长度中最小的来初始化list.
            for (int i = 0; i < Math.Min(s.Length, numRows); i++)
            {
                StringBuilder sb = new StringBuilder();
                sbList.Add(sb);
            }

            int currRow = 0;//当前的行数
            bool goDown = false;//z字形 行进的方向
            //遍历s，将s[i]添加到合适的行里
            for (int i = 0; i < s.Length; i++)
            {
                sbList[currRow].Append(s[i]);
                //如果当前行数为第一行或最后一行，z字形 行进的方向应该改变，所以给goDowm取反
                if (currRow == 0 || currRow == numRows - 1) goDown = !goDown;

                //将当前行currRow+1或-1，保证下次循环可将数据存到正确的行里
                currRow += goDown ? 1 : -1;
            }
            //到此，sbList[0]中存的为z字形排列的第一行数据，sbList[1]中存的为z字形排列的第二行数据，以此类推。。。将所有拼接，即为结果
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < sbList.Count; i++)
            {
                result.Append(sbList[i]);
            }
            return result.ToString();
        }
        /// <summary>
        /// leetcode第7题，整数反转
        /// 链接：https://leetcode-cn.com/problems/reverse-integer/solution/zheng-shu-fan-zhuan-by-leetcode-solution-bccn/
        /// </summary>
        /// <param name="x">需要反转的数</param>
        public int L_7_Reverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                if (rev < int.MinValue / 10 || rev > int.MaxValue / 10)
                {
                    return 0;
                }
                int digit = x % 10;
                x /= 10;
                rev = rev * 10 + digit;
            }
            return rev;
        }
        /// <summary>
        /// leetcode第8题，字符串转换整数
        /// 链接：https://leetcode-cn.com/problems/string-to-integer-atoi/solution/c-zi-fu-chuan-zhuan-huan-zheng-shu-atoi-37m21/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int L_8_MyAtoi(string s)
        {
            // 为空直接返回
            if (s.Length == 0) return 0;
            // 正负号
            int plus = 1;
            // 结果
            int result = 0;
            // 去空格
            if (s[0] == ' ')
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] != ' ')
                    {
                        s = s[i..s.Length];
                        break;
                    }
                }
            }
            // 判断正负号
            if (s[0] == '-')
            {
                plus = -1;
                s = s[1..s.Length];
            }
            else if (s[0] == '+') s = s[1..s.Length];
            // 逐位判断
            for (int i = 0; i < s.Length; i++)
            {
                // 数字
                if (s[i] >= '0' && s[i] <= '9')
                {
                    // 判断是否溢出
                    if (plus == 1)
                    {
                        if (result > int.MaxValue / 10) return int.MaxValue;
                        if (result == int.MaxValue / 10 && s[i] >= '7') return int.MaxValue;
                    }
                    else
                    {
                        if (result > int.MaxValue / 10) return int.MinValue;
                        if (result == int.MaxValue / 10 && s[i] >= '8') return int.MinValue;
                    }
                    // 更新结果
                    result = result * 10 + (s[i] - '0');
                }
                // 非数字，直接返回结果
                else return result * plus;
            }
            // 判断完毕，返回结果
            return result * plus;
        }
        /// <summary>
        /// leetcode第9题，判断回文数
        /// 链接：https://leetcode-cn.com/problems/palindrome-number/solution/hui-wen-shu-by-leetcode-solution/
        /// </summary>
        /// <param name="x">需要判断的数字</param>
        public bool L_9_IsPalindrome(int x)
        {
            /* 特殊情况：
            如上所述，当 x < 0 时，x 不是回文数。
            同样地，如果数字的最后一位是 0，为了使该数字为回文，
            则其第一位数字也应该是 0
            只有 0 满足这一属性 */
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            /* 当数字长度为奇数时，我们可以通过 revertedNumber/10 去除处于中位的数字。
            例如，当输入为 12321 时，在 while 循环的末尾我们可以得到 x = 12，revertedNumber = 123，
            由于处于中位的数字不影响回文（它总是与自己相等），所以我们可以简单地将其去除。 */
            return x == revertedNumber || x == revertedNumber / 10;
        }
        /// <summary>
        /// leetcode第10题，正则表达式匹配
        /// 链接：https://leetcode-cn.com/problems/regular-expression-matching/solution/dp-gong-zuo-yi-hou-huan-yao-ji-xu-shua-by-mitty/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool L_10_IsMatch(string s, string p)
        {
            if (s == null || p == null) return false;

            bool[,] dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;

            for (int i = 1; i <= p.Length; ++i)
            {
                if (p[i - 1] == '*' && dp[0, i - 2])
                {
                    dp[0, i] = true;
                }
            }

            for (int i = 1; i <= s.Length; ++i)
            {
                for (int j = 1; j <= p.Length; ++j)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        if (p[j - 2] != s[i - 1] && p[j - 2] != '.')
                        {
                            dp[i, j] = dp[i, j - 2];
                        }
                        else
                        {
                            dp[i, j] = (dp[i, j - 2] || dp[i, j - 1] || dp[i - 1, j]);
                        }
                    }
                }
            }
            return dp[s.Length, p.Length];
        }
        /// <summary>
        /// leetcode第14题，最长公共前缀
        /// </summary>
        /// <param name="strs">字符串数组</param>
        public String L_14_LongestCommonPrefix(String[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "啥玩意都没有";
            }
            //找到最短元素
            String shortstr = strs[0];
            for (int x = 0; x < strs.Length; x++)
            {
                if (strs[x].Length < shortstr.Length)
                {
                    shortstr = strs[x];
                }
            }
            int length = shortstr.Length;
            int count = shortstr.Length;
            for (int i = 0; i < length; i++)
            {
                string c = shortstr.Substring(i, 1);
                for (int j = 1; j < count - 1; j++)
                {
                    if (i == strs[j].Length || strs[j].Substring(i, 1) != c)
                    {
                        return shortstr.Substring(0, i);
                    }
                }
            }
            return shortstr;
        }
        /// <summary>
        /// leetcode第20题，有效括号
        /// </summary>
        /// <param name="s">传入范围仅限大中小括号</param>
        public bool L_20_IsValid(string s)
        {
            if (s == "" || s == null) return false;
            // 反着的原因是，进入栈的值必须为左边括号，这样可以判断出栈的值与当前dic的值是否相等
            Dictionary<char, char> dic = new Dictionary<char, char> { { ']', '[' }, { ')', '(' }, { '}', '{' } };
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (dic.ContainsKey(c))
                {
                    // 栈为空时说明第一个字符为右括号
                    if (stack.Count == 0) return false;
                    // 出栈的值与当前dic的值不相等就返回 false
                    if (stack.Pop() != dic[c]) return false;
                }
                else
                    stack.Push(c);
            }

            return stack.Count == 0 ? true : false;
        }
        /// <summary>
        /// leetcode第21题，合并两个有序链表
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode? L_21_MergeTwoLists(ListNode? l1, ListNode? l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val < l2.val)
            {
                l1.next = L_21_MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = L_21_MergeTwoLists(l1, l2.next);
                return l2;
            }
        }
        /// <summary>
        /// leetcode第22题，括号生成
        /// </summary>
        /// <param name="n">代表生成括号的对数</param>
        public IList<string> L_22_GenerateParenthesis(int n)
        {
            return Enumerable.Range(Enumerable.Range(0, n).Aggregate(0, (acc, i) => acc |= 1 << (2 * i + 1)),
                      n == 0 ? 0 : (1 << 2 * n) - (1 << n) - Enumerable.Range(0, n).Aggregate(0, (acc, i) => acc |= 1 << (2 * i + 1)) + 1)
                  .Where(num => Enumerable.Range(0, 2 * n).Aggregate(0, (last, i) => last < 0 ? last : last + ((num >> i & 1) == 0 ? 1 : -1), value => value == 0))
                  .Select(num => Convert.ToString(num, 2).Replace('1', '(').Replace('0', ')')).ToList();
        }
        /// <summary>
        /// leetcode第23题，合并K个升序链表
        /// 链接：https://leetcode-cn.com/problems/merge-k-sorted-lists/solution/si-wei-jian-dan-shi-jian-ting-kuai-by-17ji-ke-1zho/
        /// </summary>
        public ListNode? L_23_MergeKLists(ListNode[] lists)
        {
            List<int> help = new List<int>();
            for (int j = 0; j < lists.Length; j++)
            {
                ListNode? ans = lists[j];
                while (ans != null)
                {
                    help.Add(ans.val);
                    ans = ans.next;
                }
            }
            help.Sort();
            ListNode res = new ListNode(0, null); int i = 0;
            ListNode helpnode = res;
            while (i < help.Count())
            {
                ListNode node = new ListNode(help[i], null); i++;
                helpnode.next = node; helpnode = helpnode.next;
            }
            return res.next;
        }
        /// <summary>
        /// leetcode第24题，两两交换链表中的节点
        /// 链接：https://leetcode-cn.com/problems/swap-nodes-in-pairs/solution/csan-zhi-zhen-hua-dong-jie-jue-by-wa-li-xiong/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode? L_24_SwapPairs(ListNode head)
        {
            if (head == null) return null;
            ListNode newHead = new ListNode(-100, null);
            newHead.next = head;
            ListNode first = newHead;
            ListNode second = head;
            ListNode? third = head.next;
            while (third != null && first != null && second != null)
            {
                ListNode node = second;
                node.next = third.next!;
                first.next = third;
                third.next = node;
                first = node;
                second = node.next;
                if (second == null) break;
                third = node.next.next;
            }
            return newHead.next;
        }
        /// <summary>
        /// leetcode第25题，K个一组翻转列表
        /// 链接：https://leetcode-cn.com/problems/reverse-nodes-in-k-group/solution/cdi-gui-by-c7wwmd0j8s/
        /// </summary>
        /// <param name="head">传入需要操作的数组</param>
        /// <param name="k">需要反转的组长度</param>
        /// <returns></returns>
        public ListNode? L_25_ReverseKGroup(ListNode? head, int k)
        {
            List<ListNode> list = new List<ListNode>();
            ListNode? p = head;
            for (int i = 0; i < k; i++)
            {
                if (head == null) { return p; }
                list.Add(head);
                head = head.next;
            }
            for (int i = 1; i < k; i++)
            {
                list[i].next = list[i - 1];
            }
            list[0].next = L_25_ReverseKGroup(head, k);
            return list[k - 1];
        }
        /// <summary>
        /// leetcode第26题，删除有序数组中的重复项
        /// 链接：https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/solution/kuai-man-zhi-zhen-26-shan-chu-you-xu-shu-8v6r/
        /// </summary>
        /// <param name="nums">传入需要操作的数组</param>
        /// <returns>移除重复项后的数组</returns>
        public int L_26_RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) { return 0; }
            int slow = 0, fast = 1;
            while (fast < nums.Length)
            {
                if (nums[fast] != nums[slow])
                {
                    slow = slow + 1;
                    nums[slow] = nums[fast];
                }
                fast = fast + 1;
            }
            return slow + 1;
        }
        /// <summary>
        /// leetcode第27题，移除元素
        /// 链接：https://leetcode-cn.com/problems/remove-element/solution/c-100zui-jian-dan-de-fang-fa-by-v_chung-7itt/
        /// /// </summary>
        /// <param name="nums">传入需要操作的数组</param>
        /// <param name="val">需要移除的元素数值</param>
        /// <returns>移除数值完毕的数组</returns>
        public int L_27_RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != val)
                    nums[count++] = nums[i];
            return count;
        }
        /// <summary>
        /// leetcode第28题，找出字符串中第一个匹配项的下标(此为KMP算法版本)
        /// https://leetcode.cn/problems/find-the-index-of-the-first-occurrence-in-a-string/solution/c-kmp-xi-wang-wo-jiang-ming-bai-liao-kmpsuan-fa-by/
        /// </summary>
        /// <param name="haystack">可能包含needle的字符串</param>
        /// <param name="needle">需要寻找的目标字符串</param>
        /// <returns>匹配项下表，若是返回-1则表示没有出现</returns>
        public int L_28_FindNeedleFromhaystack(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
            {
                return 0;
            }
            if (needle.Length > haystack.Length || string.IsNullOrEmpty(haystack))
            {
                return 1;
            }
            return KMP(haystack, needle);
        }
        /// <summary>
        /// leetcode第29题，两数相除
        /// https://leetcode.cn/problems/divide-two-integers/solution/liang-shu-xiang-chu-by-leetcode-solution-5hic/
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int L_29_DivideTwonumbers(int dividend, int divisor)
        {
            if (dividend == int.MinValue)
            {
                if (divisor == 1)
                {
                    return int.MinValue;
                }
                if (divisor == -1)
                {
                    return int.MaxValue;
                }
            }
            // 考虑除数为最小值的情况
            if (divisor == int.MinValue)
            {
                return dividend == int.MinValue ? 1 : 0;
            }
            // 考虑被除数为 0 的情况
            if (dividend == 0)
            {
                return 0;
            }

            // 一般情况，使用二分查找
            // 将所有的正数取相反数，这样就只需要考虑一种情况
            bool rev = false;
            if (dividend > 0)
            {
                dividend = -dividend;
                rev = !rev;
            }
            if (divisor > 0)
            {
                divisor = -divisor;
                rev = !rev;
            }

            int left = 1, right = int.MaxValue, ans = 0;
            while (left <= right)
            {
                // 注意溢出，并且不能使用除法
                int mid = left + ((right - left) >> 1);
                bool check = quickAdd(divisor, mid, dividend);
                if (check)
                {
                    ans = mid;
                    // 注意溢出
                    if (mid == int.MaxValue)
                    {
                        break;
                    }
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return rev ? -ans : ans;
        }
        /// <summary>
        /// leetcode第30题，串联所有单词的字串
        /// https://leetcode.cn/problems/substring-with-concatenation-of-all-words/solution/chuan-lian-suo-you-dan-ci-de-zi-chuan-by-244a/
        /// </summary>
        /// <returns></returns>
        public IList<int> L_30_FindSubstring(string s, string[] words)
        {
            IList<int> res = new List<int>();
            int m = words.Length, n = words[0].Length, ls = s.Length;
            for (int i = 0; i < n; i++)
            {
                if (i + m * n > ls)
                {
                    break;
                }
                Dictionary<string, int> differ = new Dictionary<string, int>();
                for (int j = 0; j < m; j++)
                {
                    string word = s.Substring(i + j * n, n);
                    if (!differ.ContainsKey(word))
                    {
                        differ.Add(word, 0);
                    }
                    differ[word]++;
                }
                foreach (string word in words)
                {
                    if (!differ.ContainsKey(word))
                    {
                        differ.Add(word, 0);
                    }
                    differ[word]--;
                    if (differ[word] == 0)
                    {
                        differ.Remove(word);
                    }
                }
                for (int start = i; start < ls - m * n + 1; start += n)
                {
                    if (start != i)
                    {
                        string word = s.Substring(start + (m - 1) * n, n);
                        if (!differ.ContainsKey(word))
                        {
                            differ.Add(word, 0);
                        }
                        differ[word]++;
                        if (differ[word] == 0)
                        {
                            differ.Remove(word);
                        }
                        word = s.Substring(start - n, n);
                        if (!differ.ContainsKey(word))
                        {
                            differ.Add(word, 0);
                        }
                        differ[word]--;
                        if (differ[word] == 0)
                        {
                            differ.Remove(word);
                        }
                    }
                    if (differ.Count == 0)
                    {
                        res.Add(start);
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// leetcode第31题，下一个排列
        /// https://leetcode.cn/problems/next-permutation/solution/shuang-zhi-zhen-by-qiu-xing-chen-gpzp/
        /// </summary>
        public void L_31_NextPermutation(int[] nums)
        {
            int n = nums.Length;
            //排除特殊情况
            if (n <= 1) return;
            //双指针
            int left = n - 2;
            int right = n - 1;
            //翻转最小字串
            while (right - left < n)
            {
                for (int i = right; i > left; i--)
                {
                    //查询字符串是否可以翻转
                    if (nums[i] > nums[left])
                    {
                        //翻转left,i指针
                        Swap(ref nums[i], ref nums[left]);
                        //翻转left指针后所有项
                        for (int j = left + 1; j <= left + (right - left + 1) / 2; j++)
                        {
                            Swap(ref nums[j], ref nums[right - j + left + 1]);
                        }
                        return;
                    }
                }
                left--;
            }
            //数组顺序翻转数组
            for (int i = 0; i < n / 2; i++)
            {
                Swap(ref nums[i], ref nums[n - 1 - i]);
            }
            return;
        }
        /// <summary>
        /// leetcode第32题，最长有效括号
        /// https://leetcode.cn/problems/longest-valid-parentheses/solution/zhan-shuang-duan-dui-lie-linkedlist-by-h-1aj7/
        /// </summary>
        /// <param name="s"></param>
        public int L_32_LongestValidParentheses(string s)
        {
            int ans = 0;
            var stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') stack.Push(i);
                else
                {
                    stack.Pop();
                    if (stack.Count == 0) stack.Push(i);
                    else ans = Math.Max(ans, i - stack.Peek());
                }
            }
            return ans;
        }
        /// <summary>
        /// leetcode第33题，搜索旋转排序数组
        /// https://leetcode.cn/problems/search-in-rotated-sorted-array/solution/er-fen-cha-zhao-shuang-bai-by-qiu-xing-c-yx6e/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int L_33_SearchRotatesortarray(int[] nums, int target)
        {
            int ans;
            int n = nums.Length;
            //排除特殊情况
            if (n == 0) return -1;
            if (n == 1 && nums[0] == target) return 0;
            else if (n == 1 && nums[0] != target) return -1;
            //左右指针寻找连接点
            int mid = 0;
            while (mid < n - 1)
            {
                if (nums[mid] < nums[mid + 1]) mid++; else break;
            }
            ans = target > nums[0] ? Binarysearch(nums, target, 0, mid) : ans = Binarysearch(nums, target, mid + 1, n - 1);
            return ans;
        }
        /// <summary>
        /// leetcode第34题，在排序数组中查找元素的第一个和最后一个位置
        /// https://leetcode.cn/problems/find-first-and-last-position-of-element-in-sorted-array/solution/34-zai-pai-xu-shu-zu-zhong-cha-zhao-yuan-ldva/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns>如果数组中不存在目标值 target，返回 [-1, -1]</returns>
        public int[] L_34_SearchRange(int[] nums, int target)
        {
            int[] re = { -1, -1 };
            int i = 0;
            int le = nums.Length;
            for (; i < le; i++)
            {
                if (nums[i] == target)
                {
                    re[1] = i;
                    if (re[0] == -1) re[0] = i;
                }
            }
            return re;
        }
        /// <summary>
        /// leetcode第35题，搜索插入位置
        /// https://leetcode.cn/problems/search-insert-position/solution/35sou-suo-cha-ru-wei-zhi-xiao-bai-yi-don-tnsm/
        /// </summary>
        /// <returns>插入位置下标</returns>
        public int L_35_SearchInsert(int[] nums, int target)
        {
            //设最左边下标为0，最右边下标为数组长度-1
            int low = 0, high = nums.Length - 1;
            //声明一个存储中间值的变量
            int mid = 0;
            //如果左小于等于右，持续循环
            while (low <= high)
            {
                //求low到high的中间值；
                mid = (high - low) / 2 + low;
                //判断是否与target相等;
                if (nums[mid] == target)
                {
                    //找到则返回数组下标
                    return mid;
                }
                //如果判断中间值比target要小，那就证明target在中间值的右边
                else if (nums[mid] < target)
                {
                    //把high移动到中间值后一位，然后继续循环查找
                    low = mid + 1;
                }
                //如果判断中间值比target要大，那就证明target在中间值的左边
                else
                {
                    //把high移动到中间值前一位，然后继续循环查找
                    high = mid - 1;
                }
            }
            //上面循环没有找到target，但中间值是最靠近target的数的。
            //判断相近数的大小，然后返回插入的下标
            if (target > nums[mid])
            {
                return mid + 1;
            }
            else
            {
                return mid;
            }
        }
        /// <summary>
        /// leetcode第36题，有效的数独
        /// https://leetcode.cn/problems/valid-sudoku/solution/can-kao-guan-fang-da-an-jin-xing-liao-yi-ge-you-hu/
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool L_36_IsValidSudoku(char[][] board)
        {
            Dictionary<int, int>[] X = new Dictionary<int, int>[9];
            //X轴上每一行的dictionary必须全部用上。
            for (int i = 0; i < 9; i++)
            {
                X[i] = new Dictionary<int, int>();
                //实例化每一行的dictionary
            }
            for (int i = 0; i < 3; i++)
            //因为一“宫”占三行，而九行就有三“宫”，所以需要用一个变量来控制重新实例化Dictionary
            {
                Dictionary<int, int>[] B = new Dictionary<int, int>[3];
                //B代表每一个“宫”，而遍历的每一行只经过三个“宫”
                for (int j = 0; j < 3; j++)
                {
                    B[j] = new Dictionary<int, int>();
                    //遍历实例化
                }
                for (int i1 = 0; i1 < 3; i1++)//
                {
                    int i_k = i * 3 + i1;//i_k控制遍历的行

                    Dictionary<int, int> Y = new Dictionary<int, int>();
                    //遍历的Y轴只需要一个Dictionary
                    for (int i2 = 0; i2 < 9; i2++)//i2控制遍历的列
                    {
                        if (board[i_k][i2] != '.')
                        {
                            if (Y.ContainsKey(board[i_k][i2]) ||
                                X[i2].ContainsKey(board[i_k][i2]) ||
                                B[i2 / 3].ContainsKey(board[i_k][i2]))
                                return false;
                            //如果在dictionary当中找到相同的数字，return false

                            Y.Add(board[i_k][i2], 0);//X Dic 添加
                            X[i2].Add(board[i_k][i2], 0);//Y Dic 添加
                            B[i2 / 3].Add(board[i_k][i2], 0);//B Dic 添加
                            //反之添加进来
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// leetcode第37题，解数独
        /// https://leetcode.cn/problems/sudoku-solver/solution/jie-shu-du-by-inhero/
        /// </summary>
        /// <param name="board"></param>
        public void L_37_SolveSudoku(char[][]? board)
        {
            //判断一共有多少个数字
            int hasNumCount = 0;
            Dictionary<int, bool> dicAllTemp = new Dictionary<int, bool>();
            //创建一个键值对集合存储数字是否出现过 
            for (int i = 1; i <= 9; i++)
            {
                dicAllTemp.Add(i, false);
            }
            for (int i = 0; i < 9; i++)
            {
                //存储对应的九列
                liCol.Add(new Dictionary<int, bool>(dicAllTemp));
                //存储对应的九行
                liRow.Add(new Dictionary<int, bool>(dicAllTemp));
                //存储对应的九个3*3格子
                liBox.Add(new Dictionary<int, bool>(dicAllTemp));
            }
            //遍历整个集合 将已出现的数字赋值为true 
            if (board != null)
            {
                for (int i = 0; i < board.Length; i++)
                {
                    for (int j = 0; j < board[0].Length; j++)
                    {
                        if (board[i][j] != '.')
                        {
                            int temp = board[i][j] - 48;
                            liRow[i][temp] = true;
                            liCol[j][temp] = true;
                            int count = (i / 3) * 3 + j / 3;
                            liBox[count][temp] = true;
                            hasNumCount++;
                        }
                    }
                }
                Recursive(board, hasNumCount, 0, 0);
                board = boardAllres;
            }
        }
        /// <summary>
        /// leetcode第38题，外观数列
        /// https://leetcode.cn/problems/count-and-say/solution/wai-guan-shu-lie-by-leetcode-solution-9rt8/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string L_38_CountAndSay(int n)
        {
            string str = "1";
            for (int i = 2; i <= n; ++i)
            {
                StringBuilder sb = new StringBuilder();
                int start = 0;
                int pos = 0;

                while (pos < str.Length)
                {
                    while (pos < str.Length && str[pos] == str[start])
                    {
                        pos++;
                    }
                    sb.Append(pos - start).Append(str[start]);
                    start = pos;
                }
                str = sb.ToString();
            }

            return str;
        }
        /// <summary>
        /// leetcode第39题，组合总和
        /// https://leetcode.cn/problems/combination-sum/solution/39-zu-he-zong-he-c-hui-su-by-kas233-jqy5/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> L_39_CombinationSum(int[] candidates, int target)
        {
            var res = new List<IList<int>>();
            // 排序
            var candidateList = candidates.ToList();
            candidateList.Sort();
            Backtrack(candidateList.ToArray(), target, new List<int>(), 0, 0, res);
            return res;
        }
        /// <summary>
        /// leetcode第40题，组合总和2
        /// https://leetcode.cn/problems/combination-sum-ii/solution/40-zu-he-zong-he-ii-c-hui-su-jian-zhi-by-dlht/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> L_40_CombinationSum2(int[] candidates, int target)
        {
            var res = new List<IList<int>>();
            // 排序，为剪枝做准备
            var candidateList = candidates.ToList();
            candidateList.Sort();
            Backtrack(candidateList.ToArray(), target, new List<int>(), 0, res);
            return res;
        }
        /// <summary>
        /// leetcode第41题，缺失的第一个正数
        /// https://leetcode.cn/problems/first-missing-positive/solution/by-nostalgic-davinciuey-3b4m/
        /// </summary>
        /// <param name="nums">未排序的整数数组</param>
        /// <returns></returns>
        public int L_41_FirstMissingPositive(int[] nums)
        {
            var li = new List<int>(nums).Where(c => c > 0).ToList();
            if (li.Count < 1) { return 1; }
            li.Sort();
            if (li.First() > 1)
            {
                return 1;
            }
            for (int i = 0; i < li.Count - 1; i++)
            {
                var c = li[i + 1] - li[i];
                if (c > 1)
                {
                    return li[i] + 1;
                }
            }
            return li[li.Count - 1] + 1;
        }
        /// <summary>
        /// leetcode第42题，接雨水
        /// https://leetcode.cn/problems/trapping-rain-water/solution/fang-zhan-de-ao-xing-shui-chi-ji-suan-by-nsmild/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int L_42_Trap(int[] height)
        {
            if (null == height || height.Length == 0) return 0;
            int totals = 0;

            // 单调栈就是比普通的栈多一个性质，即维护一个栈内元素单调
            // 使用栈来存储每个可能接到雨水的格子的索引值！！！
            Stack<int> stacks = new Stack<int>();

            for (int i = 0; i < height.Length; i++)
            {
                while (stacks.Count > 0 && height[i] > height[stacks.Peek()])
                {
                    // 弹出当前比height[i]小的栈顶
                    int top = stacks.Pop();

                    // 如果栈顶元素一直相等，那么全都pop出去，只留第一个，这个思路相对来说简单好理解一点，类似一直就计算凹槽里的水
                    while (stacks.Count > 0 && height[stacks.Peek()] == height[top])
                    {
                        stacks.Pop();
                    }

                    // 如果为空的话，说明左边留不住水，没有形成凹型
                    if (stacks.Count > 0)
                    {
                        int stackTop = stacks.Peek();
                        // stackTop此时指向的是此次接住的雨水的左边界的位置。右边界是当前的柱体，即i
                        // Math.min(height[stackTop], height[i]) 是左右柱子高度的min，减去height[curIdx]就是雨水的高度

                        // i - stackTop - 1 是雨水的宽度

                        // 计算雨水
                        // 接住雨水的量的高度是栈顶元素和左右两边形成的高度差的min。宽度是1
                        int distance = i - stackTop - 1;
                        totals += distance * (Math.Min(height[stackTop], height[i]) - height[top]);
                    }
                }

                stacks.Push(i);
            }
            return totals;
        }
        /// <summary>
        /// leetcode第43题，字符串相乘
        /// https://leetcode.cn/problems/multiply-strings/solution/cban-ben-shu-shi-cheng-fa-by-wq9b5mehup/
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string L_43_Multiply(string num1, string num2)
        {
            StringBuilder sum = new StringBuilder(new string('0', num1.Length + num2.Length));
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int next = sum[i + j + 1] - '0' + (num1[i] - '0') * (num2[j] - '0');
                    sum[i + j + 1] = (char)(next % 10 + '0');
                    sum[i + j] += (char)(next / 10);
                }
            }
            string res = sum.ToString().TrimStart('0');
            return res.Length == 0 ? "0" : res;
        }
        /// <summary>
        /// leetcode第44题，通配符匹配
        /// https://leetcode.cn/problems/wildcard-matching/solution/shuang-zhi-zhen-jie-fa-qing-xi-yi-dong-by-xiao-yao/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool L_44_IsMatch(string s, string p)
        {
            int i = 0;//指向字符串s
            int j = 0;//指向字符串p
            int startPos = -1;//记录星号的位置
            int match = -1;//用于匹配星号
            while (i < s.Length)
            {
                //表示相同或者p中为?
                if (j < p.Length && (s[i] == p[j] || p[j] == '?'))
                {
                    i++;
                    j++;
                }
                //匹配到了星号，记录下的位置
                else if (j < p.Length && p[j] == '*')
                {
                    startPos = j;
                    match = i;
                    j = startPos + 1;
                }
                //以上都没有匹配到，回到星号所在的位置，往后再次匹配
                else if (startPos != -1)
                {
                    match++;
                    i = match;
                    j = startPos + 1;
                }
                else
                {
                    return false;
                }
            }
            //去除多余的星号
            while (j < p.Length && p[j] == '*') j++;
            return j == p.Length;
        }
        /// <summary>
        /// leetcode第45题，跳跃游戏Ⅱ
        /// https://leetcode.cn/problems/jump-game-ii/solution/-tiao-yue-you-xi-ii-by-hareyukai/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int L_45_Jump(int[] nums)
        {
            int steps = 0, end = 0, maxPos = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                maxPos = Math.Max(maxPos, nums[i] + i);
                if (i == end)
                {
                    end = maxPos;
                    ++steps;
                }
            }
            return steps;
        }
        /// <summary>
        /// leetcode第46题，全排序
        /// https://leetcode.cn/problems/permutations/solution/by-adoring-nightingaledgj-ynhr/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> L_46_Permute(int[] nums)
        {
            List<List<int>> GetAnswer(int dimension)
            {
                List<List<int>> answer = new();
                if (dimension == 1)
                {
                    answer.Add(new List<int> { nums[0] });
                    return answer;
                }
                if (dimension == 2)
                {
                    answer.Add(new List<int> { nums[0], nums[1] });
                    answer.Add(new List<int> { nums[1], nums[0] });
                    return answer;
                }
                answer = GetAnswer(dimension - 1);
                answer.ForEach(i => i.Add(nums[dimension - 1]));//每个后面新增元素
                                                                //深拷贝
                List<List<int>> ansi = answer.Select(i => i.ToArray().ToList()).ToList();
                for (int j = 0; j < dimension - 1; j++)
                {
                    //深拷贝
                    List<List<int>> ansj = ansi.Select(i => i.ToArray().ToList()).ToList();
                    ansj.ForEach(i =>
                    {
                        i[i.IndexOf(nums[j])] = nums[dimension - 1];
                        i[^1] = nums[j];//等效于i[i.Length-1] = nums[j]
                    });
                    answer.AddRange(ansj);
                }
                return answer;
            }
            List<IList<int>> ans = new();
            GetAnswer(nums.Length).ForEach(i => ans.Add(i));
            return ans;
        }
        /// <summary>
        /// leetcode第47题，全排列Ⅱ
        /// https://leetcode.cn/problems/permutations-ii/solution/yan-du-you-xian-bian-li-by-jian-chi-3/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> L_47_PermuteUnique(int[] nums)
        {
            //DFS
            Queue<List<int>> container = new Queue<List<int>>();
            Queue<List<int>> usedIndex = new Queue<List<int>>();

            container.Enqueue(new List<int>());
            usedIndex.Enqueue(new List<int>());
            Array.Sort(nums);

            //一共需要执行的层数
            for (int layer = 0; layer < nums.Length; layer++)
            {
                //记录容器当前层的数据个数
                int cnt = container.Count;
                for (int i = 0; i < cnt; i++)
                {
                    var data = container.Dequeue();
                    var used = usedIndex.Dequeue();
                    int lastUse = -11;
                    for (int j = 0; j < nums.Length; j++)
                    {
                        //查找当前数字是否使用过
                        if (!used.Contains(j) && lastUse != nums[j])
                        {
                            //如果没有就复制前面层的所有数字并加入这个特殊数字
                            var temp = new List<int>(data);
                            var tempIndex = new List<int>(used);
                            temp.Add(nums[j]);
                            tempIndex.Add(j);
                            lastUse = nums[j];
                            container.Enqueue(temp);
                            usedIndex.Enqueue(tempIndex);
                        }
                    }
                }
            }
            List<IList<int>> res = new List<IList<int>>(container);
            return res;
        }
        /// <summary>
        /// leetcode第48题，旋转图像
        /// https://leetcode.cn/problems/rotate-image/solution/shang-xia-fan-zhuan-dui-jiao-xian-fan-zhuan-by-mit/
        /// </summary>
        /// <param name="matrix"></param>
        public void L_48_Rotate(int[][] matrix)
        {
            /*
            简单思路：

            1。先上下反转
            2。再对角色反转

            经如： 
            1，2，3
            4，5，6
            7，8，9

            上下反转不是i和n-i-1两行交换，比如：长度是4，那么就是1和2交换，2和3交换，交换的次数是n/2次
            只有3行（奇数）行时，中行那一行可以不变，比如上面1-9，[4,5,6]是不需要交换的！


            */

            if (matrix == null || matrix.Length <= 0 || matrix[0].Length <= 0) return;
            int N = matrix.Length;
            for (int j = 0; j < N; ++j)
            {
                for (int i = 0; i < N / 2; ++i)
                {
                    // var t = matrix[i];
                    // matrix[i] = matrix[N - i - 1];
                    // matrix[N - i - 1] = t;
                    //Swap(matrix[i][j], matrix[N - i - 1][j]);
                    Swap(ref matrix[i][j], ref matrix[N - i - 1][j]);
                }
            }
            //对角线反转
            for (int j = 1; j < N; ++j)
            {
                for (int i = 0; i < j; ++i)
                {
                    // var t = matrix[i][j];
                    // matrix[i][j] = matrix[j][i];
                    // matrix[j][i] = t;
                    Swap(ref matrix[i][j], ref matrix[j][i]);
                }
            }
        }
        /// <summary>
        /// leetcode第49题，字母异位词分组
        /// https://leetcode.cn/problems/group-anagrams/solution/jie-by-long-yu-8-8zd0/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> L_49_GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();
            IList<IList<string>> res = new List<IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] a = strs[i].ToArray();
                Array.Sort(a);
                string str = String.Join("", a.Select(x => x.ToString()).ToArray());
                if (dic.ContainsKey(str))
                {
                    dic[str].Add(strs[i]);
                }
                else
                {
                    dic[str] = new List<string> { strs[i] };
                }

            }
            foreach (var item in dic.Keys)
            {
                res.Add(dic[item]);
            }
            return res;
        }
        /// <summary>
        /// leetcode第50题，POW(X,N)即X的N次方
        /// https://leetcode.cn/problems/powx-n/solution/powx-n-fen-zhi-di-gui-yu-die-dai-by-da-za-cao/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double L_50_MyPow(double x, int n)
        {
            /*
            分治
            pow(x, n):
                x^(n/2) * x^(n/2)       n 为偶数
                x * x^(n/2) * x^(n/2)   n 为奇数
        */
            if (x == 0)
            {
                return 0;
            }
            if (n == 0)
            {
                return 1;
            }
            long b = n;
            if (b < 0)
            {
                b = -b;
                x = 1.0 / x;
            }

            double ans = 1.0;
            while (b > 0)
            {
                if (b % 2 == 1) ans *= x;
                x *= x;
                b = b / 2;
            }
            return ans;
        }
        /// <summary>
        /// leetcode第51题，N皇后
        /// https://leetcode.cn/problems/n-queens/solution/c-po-su-de-de-di-gui-by-wei-shou-shou-er-v/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<string>> L_51_SolveNQueens(int n)
        {
            int[][] cb = new int[n][];
            for (int i = 0; i < n; i++) cb[i] = new int[n];
            var result = new List<IList<string>>();
            TryDown(cb, 0);
            return result;
            void TryDown(int[]?[] tcb, int y)
            {
                //递归终止
                if (y >= n) //把二维数组转换为字符数组
                    result.Add(tcb.Select(a => new string(a?.Select(
                        b => b == 0 ? 'Q' : '.').ToArray())).ToList());
                else
                    for (int i = 0; i < n; i++)
                        if (tcb != null)
                        {
                            if (tcb[y]?[i] == 0)
                            {
                                int[]?[] ccb = tcb.Select(a => a?.Clone() as int[]).ToArray();
                                Down(ccb, y, i);//落子
                                TryDown(ccb, y + 1);//逐行遍历可落子点
                            }
                        }
            }
        }
        /// <summary>
        /// leetcode第52题，N皇后Ⅱ
        /// https://leetcode.cn/problems/n-queens-ii/solution/wei-yun-suan-by-anlll-8b32/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int L_52_TotalNQueens(int n)
        {
            if (n < 1) return 0;
            DFS(0, 0, 0, 0, n);
            return len;
        }
        /// <summary>
        /// leetcode第53题，最大子序和
        /// https://leetcode.cn/problems/maximum-subarray/solution/zui-da-zi-xu-he-by-leetcode-solution/
        /// </summary>
        /// <returns></returns>
        public int L_53_MaxSubArray(int[] nums)
        {
            int pre = 0, maxAns = nums[0];
            foreach (int x in nums)
            {
                pre = Math.Max(pre + x, x);
                maxAns = Math.Max(maxAns, pre);
            }
            return maxAns;
        }
        /// <summary>
        /// leetcode第54题，螺旋矩阵
        /// https://leetcode.cn/problems/spiral-matrix/solution/xun-huan-bian-li-by-qiu-xing-chen-lfyn/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> L_54_SpiralOrder(int[][] matrix)
        {
            IList<int> ans = new List<int>();
            int row = matrix[0].Length;
            int col = matrix.Length;
            int count = 0;
            //循环内部索引
            int x = 0;
            int y = 0;
            string way = "left";
            //开始循环遍历索取元素
            while (count < row * col)
            {
                ans.Add(matrix[x][y]);
                matrix[x][y] = int.MaxValue;
                count++;
                switch (way)
                {
                    //向右取值条件
                    case "left":
                        if (y == row - 1 || matrix[x][y + 1] == int.MaxValue) { way = "down"; x++; }
                        else y++;
                        break;
                    //向下取值条件
                    case "down":
                        if (x == col - 1 || matrix[x + 1][y] == int.MaxValue) { way = "right"; y--; }
                        else x++;
                        break;
                    //向左取值条件
                    case "right":
                        if (y == 0 || matrix[x][y - 1] == int.MaxValue) { way = "up"; x--; }
                        else y--;
                        break;
                    //向上取值条件
                    case "up":
                        if (x == 0 || matrix[x - 1][y] == int.MaxValue) { way = "left"; y++; }
                        else x--;
                        break;
                }
            }
            return ans;
        }
        /// <summary>
        /// leetcode第55题，跳跃游戏
        /// https://leetcode.cn/problems/jump-game/solution/tan-xin-mei-ci-ji-lu-neng-gou-da-dao-de-zui-yuan-w/
        /// </summary>
        /// <returns></returns>
        public bool L_55_CanJump(int[] nums)
        {
            if (nums == null || nums.Length <= 0) return false;

            /*

            每一次计算当前数字所能达到的最远距离，由下标+值组成

            如果max < i，说明当前最大值，到不了i这个位置，那么后面就不需要判断了

            最后返回 true 即可，因为中间 i > max 不成立，就说明整个数组遍历一次，都通过了

            比如：[3,2,1,0,4]

            0 + 3 = 3 max = 3
            1 + 2 = 3 max = 3
            2 + 1 = 3 max = 3
            3 + 0 = 3 max = 3
            到达4时，4 > max 返回false

            [2,3,1,1,4]

            0 + 2 = 2 max = 2
            1 + 3 = 4 max = 4
            2 + 1 = 3 max = 4
            3 + 1 = 4 max = 4
            最后一步，4 > max ? 不成立，循环结束，返回true

            */

            int max = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (i > max) return false;
                max = Math.Max(max, i + nums[i]);
            }
            return true;
        }
        /// <summary>
        /// leetcode第56题，合并区间
        /// https://leetcode.cn/problems/merge-intervals/solution/he-bing-qu-jian-qu-jian-zuo-bian-jie-pai-xu-bian-l/
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] L_56_Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return intervals;
            }
            /*基于每个区间左边界完成数组排序，保证区间左边界越小的越靠近左边。*/
            intervals = intervals.OrderBy(p => p[0]).ToArray();
            /*遍历数组，比较相邻区间是否能合并。如果左区间的右边界不小于右区间的左边界，则左右区间可以合并。*/
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < intervals.Length - 1; i++)
            {
                /*
                左区间的右边界不小于右区间的左边界，则区间可以合并。将右区间作为合并后结果，
                则更新右区间的左边界为左区间的左边界。
                */
                if (intervals[i][1] >= intervals[i + 1][0])
                {
                    intervals[i + 1][0] = intervals[i][0];
                    /*左区间的右边界不小于右区间的右边界，则右区间的右边界更新为左区间的右边界。*/
                    if (intervals[i][1] >= intervals[i + 1][1])
                    {
                        intervals[i + 1][1] = intervals[i][1];
                    }
                }
                /*左区间的右边界小于右区间的左边界，则左区间不能与右区间合并，将左区间添加到结果数组中。*/
                else
                {
                    list.Add(intervals[i]);
                }
            }
            /*将数组中最后一个元素添加到结果中。*/
            list.Add(intervals[intervals.Length - 1]);

            int[][] result = list.ToArray();
            return result;
        }
        /// <summary>
        /// leetcode第57题，插入区间
        /// https://leetcode.cn/problems/insert-interval/solution/c-bian-yu-li-jie-de-fang-fa-zhi-xing-yong-shi-300-/
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        public int[][] L_57_Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0) return new int[][] { new int[] { newInterval[0], newInterval[1] } };
            int n = intervals.Length;
            //用left和right记录新区间的左端和右端
            int left = newInterval[0];
            int right = newInterval[1];
            bool isTrue = false;
            List<int[]> resultList = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                //找到left存在于原数组的哪个区间中，将左端对其。
                //left = 原属组区间的左端
                //可能right也在此区间，所以不continue
                if (left >= intervals[i][0] && left <= intervals[i][1])
                {
                    left = intervals[i][0];
                }
                //找到right在原数组的哪个区间中，右端对其。
                if (right >= intervals[i][0] && right <= intervals[i][1])
                {
                    right = intervals[i][1];
                    continue;
                }
                //原数组的区间在新区间内，直接continue，不做记录。
                if (intervals[i][0] > left && intervals[i][0] < right)
                {
                    continue;
                }
                //新区间之后的所有区间，记录进list中
                //第一次需要将新区间合并后的区间记录下来。
                if (intervals[i][0] > right)
                {
                    if (!isTrue)
                    {
                        resultList.Add(new int[] { left, right });
                        isTrue = true;
                    }
                    resultList.Add(new int[] { intervals[i][0], intervals[i][1] });
                    continue;
                }
                //新区间之前的所有区间，记录进list中
                if (intervals[i][1] < left)
                {
                    resultList.Add(new int[] { intervals[i][0], intervals[i][1] });
                    continue;
                }
            }
            //若没有新区间之后的区间，
            //将合并后的新区间加到list中
            if (!isTrue)
            {
                resultList.Add(new int[] { left, right });
                isTrue = true;
            }
            return resultList.ToArray();
        }
        /// <summary>
        /// leetcode第58题，最后一个单词的长度
        /// https://leetcode.cn/problems/length-of-last-word/solution/zui-hou-yi-ge-dan-ci-de-chang-du-by-leet-51ih/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int L_58_LengthOfLastWord(string s)
        {
            int index = s.Length - 1;
            while (s[index] == ' ')
            {
                index--;
            }
            int wordLength = 0;
            while (index >= 0 && s[index] != ' ')
            {
                wordLength++;
                index--;
            }
            return wordLength;
        }
        /// <summary>
        /// leetcode第59题，螺旋矩阵Ⅱ
        /// https://leetcode.cn/problems/spiral-matrix-ii/solution/jian-dan-zhi-jie-by-nice-chebyshev7ep-5as2/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] L_59_GenerateMatrix(int n)
        {
            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new int[n];
            }
            int lC = n;//剩余列长度
            int hC = n;//剩余行长度
            int l = 0;//当前的列位置
            int h = 0;//当前的行位置
            int num = 1;//该位置上的数字
            while (lC > 0 && hC > 0)
            {
                for (int i = 0; i < lC; i++, l++, num++)//从第一行开始从左往右放数字
                {
                    res[h][l] = num;
                }
                l--;//调整下一个位置
                h++;
                hC--;
                if (hC == 0)//判断结束，总行数和总列数一样，而列数先减少，所以剩余行数会比剩余列数快减少至0
                {
                    break;
                }
                for (int i = 0; i < hC; i++, h++, num++)//从最后一列开始从上到下放数字
                {
                    res[h][l] = num;
                }
                h--;
                l--;
                lC--;
                for (int i = 0; i < lC; i++, l--, num++)
                {
                    res[h][l] = num;
                }
                l++;
                h--;
                hC--;
                if (hC == 0)
                {
                    break;
                }
                for (int i = 0; i < hC; i++, h--, num++)
                {
                    res[h][l] = num;
                }
                h++;
                l++;
                lC--;
            }
            return res;
        }
        /// <summary>
        /// leetcode第60题，排序序列
        /// https://leetcode.cn/problems/permutation-sequence/solution/shu-xue-jie-fa-by-qiu-xing-chen-lpxl/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string L_60_GetPermutation(int n, int k)
        {
            string str = "";
            int nNum = 1;
            List<int> nList = new List<int>();
            k--;
            for (int i = 1; i <= n; i++)
            {
                nNum *= i;
                nList.Add(i);
            }
            while (n > 0)
            {
                nNum /= n;
                //加入第N位字母
                str += nList[k / nNum].ToString();
                //列表移除第N位字母
                nList.RemoveAt(k / nNum);
                //取余剩下多少位
                k %= nNum;
                //计数器减减
                n--;
            }
            return str;
        }
        /// <summary>
        /// leetcode第61题，旋转链表
        /// https://leetcode.cn/problems/rotate-list/solution/by-persona-xi-6tbt/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode? L_61_RotateRight(ListNode? head, int k)
        {
            if (head == null || k == 0)
                return head;
            ListNode cur = head;
            ListNode? pre = null;
            int count = 1;
            while (cur.next != null)
            {
                cur = cur.next;
                count++;
            }
            if (k >= count)
            {
                k %= count;
            }
            cur.next = head;
            while (count - k > 0)
            {
                pre = head;
                if (head != null)
                {
                    head = head.next;
                }
                count--;
            }
            if (pre != null)
            {
                pre.next = null;
            }
            return head;
        }
        /// <summary>
        /// leetcode第62题，不同路径
        /// https://leetcode.cn/problems/unique-paths/solution/c-dong-tai-gui-hua-by-jian-wei-z-beb0/
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int L_62_UniquePaths(int m, int n)
        {
            ///  1、创建 1*n 维 数组 dp，代表第一行 全部为1
            int[] dp = new int[n];
            Array.Fill(dp, 1);

            /// 2、loop i列 -> （1, m） dp[j] += dp[j-1]
            for (int i = 1; i < m; i++)
                for (int j = 1; j < n; j++)
                    dp[j] += dp[j - 1];

            /// 3、输出 dp[n-1]
            return dp[n - 1];
        }
        /// <summary>
        /// leetcode第63题，不同路径Ⅱ
        /// https://leetcode.cn/problems/unique-paths-ii/solution/dong-tai-gui-hua-by-qiu-xing-chen-4vr1/
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int L_63_UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            //初始化动态规划数组
            int m = obstacleGrid.GetLength(0);
            int n = obstacleGrid[0].Length;
            int[,] ans = new int[m, n];

            //对第一行进行操作赋值
            for (int i = 0; i < n; i++)
            {
                if (obstacleGrid[0][i] == 1)
                {
                    for (int j = i; j < n; j++)
                    {
                        ans[0, j] = 0;
                    }
                    break;
                }
                else ans[0, i] = 1;
            }
            //对第一列进行操作赋值
            for (int i = 0; i < m; i++)
            {
                if (obstacleGrid[i][0] == 1)
                {
                    for (int j = i; j < m; j++)
                    {
                        ans[j, 0] = 0;
                    }
                    break;
                }
                else ans[i, 0] = 1;
            }
            //填充整体矩阵
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    ans[i, j] = obstacleGrid[i][j] == 1 ? 0 : ans[i, j - 1] + ans[i - 1, j];
                }
            }
            return ans[m - 1, n - 1];
        }
        /// <summary>
        /// leetcode第64题，最小路径和
        /// https://leetcode.cn/problems/minimum-path-sum/solution/zui-xiao-lu-jing-he-dong-tai-gui-hua-you-0n6d/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int L_64_MinPathSum(int[][] grid)
        {
            int[] minValue = new int[grid[0].Length]; //状态数组
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[0].Length; ++j)
                {
                    if (i == 0 && j == 0)
                    { //首元素
                        minValue[j] = grid[0][0];
                    }
                    else if (i == 0 && j != 0)
                    { //顶边缘
                        minValue[j] = minValue[j - 1] + grid[i][j];
                    }
                    else if (i != 0 && j == 0)
                    { //左边缘
                        minValue[j] += grid[i][j];
                    }
                    else
                    {
                        minValue[j] = Math.Min(minValue[j], minValue[j - 1]) + grid[i][j];
                    }
                }
            }
            return minValue[minValue.Length - 1];
        }
        /// <summary>
        /// leetcode第65题，有效数字
        /// https://leetcode.cn/problems/valid-number/solution/zheng-ze-biao-da-shi-jie-da-by-dremoralord/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool L_65_IsNumber(string s)
        {
            return pattern.IsMatch(s);
        }
        /// <summary>
        /// leetcode第66题，加一
        /// https://leetcode.cn/problems/plus-one/solution/jia-yi-by-leetcode-solution-2hor/
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] L_66_PlusOne(int[] digits)
        {
            int n = digits.Length;
            for (int i = n - 1; i >= 0; --i)
            {
                if (digits[i] != 9)
                {
                    ++digits[i];
                    for (int j = i + 1; j < n; ++j)
                    {
                        digits[j] = 0;
                    }
                    return digits;
                }
            }

            // digits 中所有的元素均为 9
            int[] ans = new int[n + 1];
            ans[0] = 1;
            return ans;
        }
        /// <summary>
        /// leetcode第67题，二进制求和
        /// https://leetcode.cn/problems/add-binary/solution/c-wo-xi-huan-de-fang-fa-by-wuhazjc-6i2m/
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string L_67_AddBinary(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return string.Empty;
            var result = new Stack<char>();
            int sum = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;

            while (i >= 0 || j >= 0)
            {
                sum += i >= 0 ? a[i--] - '0' : 0;
                sum += j >= 0 ? b[j--] - '0' : 0;
                result.Push((sum % 2 == 0) ? '0' : '1');
                //右移一位，留下进位位。
                sum >>= 1;
            }
            if (sum == 1) result.Push('1');
            //倒序输出 栈后进先出
            return new string(result.ToArray());
        }
        /// <summary>
        /// leetcode第68题，文本左右对齐
        /// https://leetcode.cn/problems/text-justification/solution/cshi-jian-chao-guo-100-by-qiu-xing-chen-6n9i/
        /// </summary>
        /// <param name="words"></param>
        /// <param name="maxWidth"></param>
        /// <returns></returns>
        public IList<string> L_68_FullJustify(string[] words, int maxWidth)
        {
            //定义相应的变量
            int n = words.Length;
            int[] nList = new int[n];
            IList<string> ans = new List<string>();
            //统计所有字符串长度
            for (int i = 0; i < n; i++)
            {
                nList[i] = words[i].Length;
            }
            //遍历长度数组进行分组
            int start = 0;
            int sLen = 0;
            for (int i = 0; i < n; i++)
            {
                sLen += nList[i] + 1;
                //如果加入当前字符后长度刚好符合则进行排列
                if (sLen == maxWidth || sLen - 1 == maxWidth)
                {
                    ans.Add(Rank(words, start, i, nList, maxWidth));
                    start = i + 1;
                    sLen = 0;
                }
                //如果加入当前字符串后长度超出则对[start,end-1]进行排列
                else if (sLen - 1 > maxWidth)
                {
                    ans.Add(Rank(words, start, i - 1, nList, maxWidth));
                    start = i;
                    sLen = nList[i] + 1;
                }
            }
            //对于最后一行元素
            if (sLen != 0)
            {
                ans.Add(Rank(words, start, n - 1, nList, maxWidth, true));
            }
            return ans;
        }
        /// <summary>
        /// leetcode第69题，X的平方根
        /// https://leetcode.cn/problems/sqrtx/solution/69xde-ping-fang-gen-sui-ran-si-lu-jian-d-jdbk/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int L_69_MySqrt(int x)
        {
            //如果mid*mid<=x，且(mid+1)*(mid+1)>x，mid即为目标
            if (x < 2) return x;//0,1
            int left = 1;
            int right = x / 2;
            while (left < right)//细节
            {
                int mid = left + (right + 1 - left) / 2;//细节：向上取整避免死循环
                if (mid > x / mid) //细节：避免溢出 mid*mid>x的话，mid值过大
                    right = mid - 1;//mid值比平方根大
                else
                    left = mid;//细节：mid已经向上取整了，left会变大，所以这里不会死循环
            }
            return left;

        }
        /// <summary>
        /// leetcode第70题，爬楼梯
        /// https://leetcode.cn/problems/climbing-stairs/solution/huan-cun-di-gui-fa-he-dong-tai-gui-hua-f-r4vq/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int L_70_ClimbStairs(int n)
        {
            if (n < 3) return n;
            int i = 3, f1 = 1, f2 = 2, f3 = f1 + f2;
            while (i <= n)
            {
                f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
                i++;
            }
            return f3;
        }
        /// <summary>
        /// leetcode第71题，简化路径
        /// https://leetcode.cn/problems/simplify-path/solution/jian-hua-lu-jing-by-leetcode-solution-aucq/
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string L_71_SimplifyPath(string path)
        {
            string[] names = path.Split("/");
            IList<string> stack = new List<string>();
            foreach (string name in names)
            {
                if ("..".Equals(name))
                {
                    if (stack.Count > 0)
                    {
                        stack.RemoveAt(stack.Count - 1);
                    }
                }
                else if (name.Length > 0 && !".".Equals(name))
                {
                    stack.Add(name);
                }
            }
            StringBuilder ans = new StringBuilder();
            if (stack.Count == 0)
            {
                ans.Append('/');
            }
            else
            {
                foreach (string name in stack)
                {
                    ans.Append('/');
                    ans.Append(name);
                }
            }
            return ans.ToString();
        }
        /// <summary>
        /// leetcode第72题，编辑距离
        /// https://leetcode.cn/problems/edit-distance/solution/cshuang-99-by-jaden-6-l170/
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int L_72_MinDistance(string word1, string word2)
        {
            int[] dp = new int[word2.Length + 1];
            for (int i = 0; i <= word1.Length; i++)
            {
                int leftUp = dp[0];
                dp[0] = i;
                for (int j = 1; j <= word2.Length; j++)
                {
                    if (i == 0) dp[j] = j;
                    else (dp[j], leftUp) = (Math.Min(Math.Min(dp[j] + 1, dp[j - 1] + 1), leftUp + (word1[i - 1] == word2[j - 1] ? 0 : 1)), dp[j]);
                }
            }
            return dp[word2.Length];
        }
        /// <summary>
        /// leetcode第73题，矩阵置零
        /// https://leetcode.cn/problems/set-matrix-zeroes/solution/ju-zhen-zhi-ling-by-leetcode-solution-9ll7/
        /// </summary>
        /// <param name="matrix"></param>
        public void L_73_SetZeroes(int[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            bool[] row = new bool[m];
            bool[] col = new bool[n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = col[j] = true;
                    }
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (row[i] || col[j])
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
        /// <summary>
        /// leetcode第74题，搜索二维矩阵
        /// https://leetcode.cn/problems/search-a-2d-matrix/solution/74-sou-suo-er-wei-ju-zhen-by-hello-world-f00t/
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool L_74_SearchMatrix(int[][] matrix, int target)
        {
            // 找到k 使得matrix[k][0] <= target < matrix[k+1][0]
            // 升序数组中找<=target的最大索引
            var left = 0;
            var right = matrix.Length - 1;
            while (left < right)
            {
                var half = (left + right + 1) / 2;
                if (matrix[half][0] > target)
                {
                    // k < half => 查询[left, half - 1]
                    right = half - 1;
                }
                else
                {
                    // k >= half 查询[half, right]
                    left = half;
                }
            }
            var k = left;
            // 找到l 使得matrix[k][l] == target
            left = 0;
            right = matrix[k].Length - 1;
            while (left < right)
            {
                var half = (left + right) / 2;
                if (matrix[k][half] < target)
                {
                    left = half + 1;
                }
                else
                {
                    right = half;
                }
            }
            return matrix[k][left] == target;
        }
        /// <summary>
        /// leetcode第75题，颜色分类
        /// https://leetcode.cn/problems/sort-colors/solution/75-yan-se-fen-lei-by-haiyuecsdn-90jr/
        /// </summary>
        /// <param name="nums"></param>
        public void L_75_SortColors(int[] nums)
        {
            int[] count = new int[3];
            foreach (var i in nums)
            {
                count[i]++;
            }
            int k = 0;
            //共有n种数
            for (int i = 0; i < count.Length; i++)
            {
                //每种数有m个
                for (int j = 0; j < count[i]; j++)
                    nums[k++] = i;
            }
        }
        /// <summary>
        /// leetcode第76题，最小覆盖字串
        /// https://leetcode.cn/problems/minimum-window-substring/solution/yi-ci-bian-li-c-nei-cun-xiao-hao-268-mb-ji-bai-lia/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public string L_76_MinWindow(string s, string t)
        {
            Dictionary<char, List<int>> dicT = new Dictionary<char, List<int>>();
            string res = s + "end";

            for (var i = 0; i < t.Length; i++)
            {
                if (!dicT.ContainsKey(t[i]))
                    dicT.Add(t[i], new List<int>() { 1 });
                else
                    dicT[t[i]][0] += 1;
            }


            for (var j = 0; j < s.Length; j++)
            {
                if (dicT.ContainsKey(s[j]))
                {
                    dicT[s[j]].Add(j);

                    var fullhead = j;
                    foreach (var item in dicT)
                    {
                        if (item.Value.Count() <= item.Value[0])
                        {
                            fullhead = -1;
                            break;
                        }
                        else
                            fullhead = Math.Min(item.Value[item.Value.Count() - item.Value[0]], fullhead);
                    }

                    if (fullhead != -1 && res.Length > j - fullhead + 1)
                        res = s.Substring(fullhead, j - fullhead + 1);
                }
            }

            if (res.Length <= s.Length)
                return res;
            else
                return "";
        }
        /// <summary>
        /// leetcode第77题，组合
        /// https://leetcode.cn/problems/combinations/solution/dfs-by-vic56/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> L_77_Combine(int n, int k)
        {
            var res = new List<IList<int>>();
            recruion(1, n, k, new int[k], res);
            return res;
        }
        /// <summary>
        /// leetcode第78题，子集
        /// https://leetcode.cn/problems/subsets/solution/dfs-with-c-by-shou-zhong-guo-guang-2-2qi0/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> L_78_Subsets(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            List<int> track = new List<int>();
            void BackTrack(int start)
            {
                res.Add(new List<int>(track));
                for (int i = start; i < nums.Length; i++)
                {
                    track.Add(nums[i]);
                    BackTrack(i + 1);
                    track.RemoveAt(track.Count - 1);
                }
            }
            BackTrack(0);
            return res;
        }
        /// <summary>
        /// leetcode第79题，单词搜索
        /// https://leetcode.cn/problems/word-search/solution/79-dan-ci-sou-suo-c-by-kas233-km6s/
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool L_79_Exist(char[][] board, string word)
        {
            var temp = string.Empty;
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    var vis = new bool[board.Length, board[0].Length];
                    if (DFS(board, word, vis, i, j, temp))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// leetcode第80题，删除有序数组中的重复项Ⅱ
        /// https://leetcode.cn/problems/remove-duplicates-from-sorted-array-ii/solution/tong-guo-xie-dai-ma-fang-fa-jie-jue-dai-ma-suo-nen/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int L_80_RemoveDuplicates(int[] nums)
        {
            //乱七八糟的优化
            if (nums.Length <= 2)
                return nums.Length; ;
            //此变量代表着循环中最近出现的数字的下标（……甲、[乙]、乙、丙…… 或 ……甲、乙、[乙]、丙……）
            int lastNumberIndex = 1;
            for (int i = 2; i < nums.Length; i++)
            {
                //判断当前循环下所取得的值是否为第二次重复出现的数字
                if (nums[i] == nums[lastNumberIndex] && nums[lastNumberIndex] != nums[lastNumberIndex - 1])
                {
                    lastNumberIndex++;
                    nums[lastNumberIndex] = nums[i];
                }
                else if (nums[i] != nums[lastNumberIndex])//如果这是不同于最近所出现的数字，即新数字，则在最近排序的数字后一位赋值为当前数字。注意 ++lastNumberIndex 已将 lastNumberIndex 的值更新
                    nums[++lastNumberIndex] = nums[i]; ;
            }
            //最后一步，返回结果。由于数组长度大于数组最后一个索引值一个一，所以采用“所得下标值加一”的方法返回符合要求的数
            return ++lastNumberIndex;
        }
        /// <summary>
        /// leetcode第81题，搜索旋转排序数组Ⅱ
        /// https://leetcode.cn/problems/search-in-rotated-sorted-array-ii/solution/100-by-lan-tian-zhi-yue-5i35/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool L_81_Search(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (target == nums[i])
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// leetcode第82题，删除排序链表中的重复元素Ⅱ
        /// https://leetcode.cn/problems/remove-duplicates-from-sorted-list-ii/solution/shuang-zhi-zhen-by-bu-yao-xiong-xiong-da-2ov2/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode L_82_DeleteDuplicates(ListNode head)
        {
            //双指针法
            ListNode preHead = new ListNode(-1, null);
            preHead.next = head;
            ListNode pre = preHead;
            while (pre.next != null)
            {
                ListNode? curr = pre.next;
                while (curr != null && pre.next.val == curr.val)
                {
                    curr = curr.next;
                }
                //不删除的情况，curr处的节点无重复，即该段节点只有一个
                if (pre.next.next == curr) pre = pre.next;
                else pre.next = curr;
            }
            return preHead.next;
        }
        /// <summary>
        /// leetcode第83题，删除排序链表中的重复元素
        /// https://leetcode.cn/problems/remove-duplicates-from-sorted-list/solution/c-solution-by-suncj550/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode? L_83_DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var rememberTop = head;
            var next = head.next;
            while (head != null && head.next != null)
            {
                if (head.next.val == head.val)
                {
                    next = head.next.next;
                    head.next = next;
                }
                else
                {
                    head = head.next;
                    next = head.next;
                }
            }
            return rememberTop;
        }
        /// <summary>
        /// leetcode第84题，柱状图中最大的矩形
        /// https://leetcode.cn/problems/largest-rectangle-in-histogram/solution/84-zhu-zhuang-tu-zhong-zui-da-de-ju-xing-r4uu/
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public int L_84_LargestRectangleArea(int[] heights)
        {
            int len = heights.Length;
            // 特判
            if (len == 0)
            {
                return 0;
            }

            int ans = 0;
            for (int i = 0; i < len; i++)
            {

                // 找左边最后 1 个大于等于 heights[i] 的下标
                int left = i;
                int curHeight = heights[i];
                while (left > 0 && heights[left - 1] >= curHeight)
                {
                    left--;
                }

                // 找右边最后 1 个大于等于 heights[i] 的索引
                int right = i;
                while (right < len - 1 && heights[right + 1] >= curHeight)
                {
                    right++;
                }

                int width = right - left + 1;
                ans = Math.Max(ans, width * curHeight);
            }
            return ans;
        }
        /// <summary>
        /// leetcode第85题，最大矩形
        /// https://leetcode.cn/problems/maximal-rectangle/solution/ctrlcvde-xian-yu-bao-li-jie-fa-by-0zufqi-podt/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int L_85_MaximalRectangle(char[][] matrix)
        {
            int m = matrix.Length;
            if (m == 0) return 0;
            int n = matrix[0].Length;
            int[,] cube = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        cube[i, j] = j == 0 ? 1 : cube[i, j - 1] + 1;
                    }
                }
            }
            int res = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int w = cube[i, j];
                    for (int k = i; k >= 0; k--)
                    {
                        if (cube[k, j] == 0) break;
                        w = w < cube[k, j] ? w : cube[k, j];
                        res = Math.Max(res, (i - k + 1) * w);
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// leetcode第86题，分隔链表
        /// https://leetcode.cn/problems/partition-list/solution/by-pan-pan-sn-dol3/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public ListNode? L_86_Partition(ListNode? head, int x)
        {
            ListNode? tempA = null;
            ListNode? tempB = null;

            while (head != null)
            {
                if (head.val >= x)
                    tempA = new ListNode(head.val, tempA);//存大于等于x的数放A组
                else tempB = new ListNode(head.val, tempB);//小于x的数放B组
                head = head.next;
            }

            ListNode? res = null;//合并，链表顺序刚好相反，先A后B
            while (tempA != null)
            {
                res = new ListNode(tempA.val, res);
                tempA = tempA.next;
            }

            while (tempB != null)
            {
                res = new ListNode(tempB.val, res);
                tempB = tempB.next;
            }
            return res;
        }
        /// <summary>
        /// leetcode第87题，扰乱字符串
        /// https://leetcode.cn/problems/scramble-string/solution/qu-jian-dp-by-kang-kang-49-n2t3/
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public bool L_87_IsScramble(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }
            int n = s1.Length;
            bool[,,] dp = new bool[n, n, n];//[s1子串起点下标，s2子串起点下标，字串长度（0表示长度1）]
            //初始化DP
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j, 0] = s1[i] == s2[j];
                }
            }
            for (int l = 1; l < n; l++)
            {
                for (int i = 0; i < n - l; i++)
                {
                    for (int j = 0; j < n - l; j++)
                    {
                        for (int w = 1; w < l + 1; w++)
                        {
                            dp[i, j, l] |= dp[i, j, w - 1] && dp[i + w, j + w, l - w];
                            dp[i, j, l] |= dp[i, j + l - w + 1, w - 1] && dp[i + w, j, l - w];
                            if (dp[i, j, l])
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return dp[0, 0, n - 1];
        }
        /// <summary>
        /// leetcode第88题，合并两个有序数组
        /// https://leetcode.cn/problems/merge-sorted-array/solution/shuang-zhi-zhen-vs-xian-he-bing-hou-pai-xu-by-toma/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void L_88_Merge(int[] nums1, int m, int[] nums2, int n)
        {
            // 备份nums1中的m个元素
            int[] temp = new int[m];
            for (int i = 0; i < m; i++)
            {
                temp[i] = nums1[i];
            }
            // 用于遍历temp和num2
            int index1 = 0;
            int index2 = 0;

            for (int j = 0; j < nums1.Length; j++)
            {
                // 比较后将较小的放入nums1中
                if (index1 <= m - 1 && index2 <= n - 1)
                {
                    if (temp[index1] > nums2[index2])
                    {
                        nums1[j] = nums2[index2];
                        index2++;
                    }
                    else
                    {
                        nums1[j] = temp[index1];
                        index1++;
                    }
                    // 若其中一个已全部放入，将另一个剩余的元素依次放入
                }
                else
                {
                    if (index1 == m && index2 <= n - 1)
                    {
                        nums1[j] = nums2[index2];
                        index2++;
                    }
                    if (index2 == n && index1 <= m - 1)
                    {
                        nums1[j] = temp[index1];
                        index1++;
                    }
                }
            }
        }
        /// <summary>
        /// leetcode第89题，格雷编码
        /// https://leetcode.cn/problems/gray-code/solution/ge-lei-bian-ma-by-leetcode-solution-cqi7/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> L_89_GrayCode(int n)
        {
            IList<int> ret = new List<int>();
            ret.Add(0);
            for (int i = 1; i <= n; i++)
            {
                int m = ret.Count;
                for (int j = m - 1; j >= 0; j--)
                {
                    ret.Add(ret[j] | (1 << (i - 1)));
                }
            }
            return ret;
        }
        /// <summary>
        /// leetcode第90题，子集Ⅱ
        /// https://leetcode.cn/problems/subsets-ii/solution/zi-ji-ii-by-a-liang-3a/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> L_90_SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> list = new List<IList<int>>();
            list.Add(new List<int>());
            List<int> l = new List<int>();

            int lastpos = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                int count = list.Count;
                int start = 0;
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    start = lastpos;
                }
                for (int j = start; j < count; j++)
                {
                    List<int> ll = new List<int>();
                    for (int r = 0; r < list.ElementAt(j).Count; r++)
                    {
                        ll.Add(list.ElementAt(j).ElementAt(r));
                    }
                    ll.Add(nums[i]);
                    list.Add(ll);
                }
                lastpos = count;
            }
            return list;
        }
        /// <summary>
        /// leetcode第91题，解码方法
        /// https://leetcode.cn/problems/decode-ways/solution/c-wan-zheng-zhu-shi-ban-by-vay0vagzkx-xol9/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int L_91_NumDecodings(string s)
        {
            if (s[0] == '0') return 0;//很明显，如果首位为0，则无法解码

            //dp[-1] = dp[0] = 1,解释dp[0]=1好理解，一个!0数字就只有1种解法；
            /*
             * dp[-1]=1直接看很难理解；但是可以推算，比如第2位为0，那么第1位只能为1或2才能解码，因为dp[i]=dp[i-2],
             *此时，应该只有1种解法，即dp[1]=1,所以dp[1]=dp[-1]=1。或者可以理解为没有元素时只有一种解法，那就是没有解法。（玄学，个人理解）
             */
            int pre = 1, curr = 1;
            for (int i = 1; i < s.Length; i++)
            {
                int tmp = curr;//记录当前解法数量
                if (s[i] == '0')//如果当前为0，则前一个数字必须为1或2，否则无法解码（如00,30等），返回0
                {
                    //dp[i]=dp[i-2];解释第i-1位和第i位必须看做一个整体才能解码，故解码方法和第i-2位的解码方法相同
                    if (s[i - 1] == '1' || s[i - 1] == '2')
                        curr = pre;
                    else return 0;
                }
                //如果前1位为1，则dp[i]=dp[i-1]+dp[i-2]; 解释：s[i-1]和s[i]分开译码为dp[i-1]；合在一起译码为dp[i-2]
                //或者如果前1位为2，且当前位为1-6 ，则dp[i]=dp[i-1]+dp[i-2]; 解释同上
                else if (s[i - 1] == '1' || (s[i - 1] == '2' && '1' <= s[i] && s[i] <= '6'))
                {
                    curr = curr + pre;
                }
                pre = tmp;
            }
            return curr;
        }
        /// <summary>
        /// leetcode第92题，反转链表Ⅱ
        /// https://leetcode.cn/problems/reverse-linked-list-ii/solution/shuang-bai-tong-guo-by-mo-chi-2e-25vj/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public ListNode? L_92_ReverseBetween(ListNode head, int left, int right)
        {
            int count = 1;
            if (head == null || head.next == null)
            {
                return head;
            }
            //申请个虚拟头结点,这样能保证如果left等于1的时候和等于其他的时候操作时一样的
            ListNode dummy = new ListNode(0, null);
            dummy.next = head;
            //出来后cur指向第left-1个节点  count==left
            ListNode? cur = dummy, left1, left2, temp;
            while (count < left)
            {
                if (cur != null)
                {
                    cur = cur.next;
                    count++;
                }
            }
            if (cur != null && cur.next != null)
            {
                left1 = cur; //这个是第left-1个节点
                left2 = cur.next; //这个是第left个节点
                cur = cur.next;
                temp = cur.next;
                //出来后count==right temp指向第right+1个元素,cur指向第right个元素
                while (count < right)
                {
                    //定义临时变量保存temp,以便给cur赋值,他就是下一步cur的位置
                    ListNode? zhong = temp;
                    //temp更新为下一个节点
                    if (temp != null)
                    {
                        temp = temp.next;
                    }
                    //让没更新的temp位置节点指向没更新的cur
                    if (zhong != null)
                    {
                        zhong.next = cur;
                    }
                    //cur更新为原来cur的下一位,即zhong,不能用cur=cur.next;因为后面的时候cur.next被改变了,第一次交换时候可以用,,因为你没更新left2的指向呢..
                    cur = zhong;
                    //count++;
                    count++;
                }
                //让反转后的链表和不需要反转的链表连接起来..
                if (left1 != null && left2 != null)
                {
                    left1.next = cur;
                    left2.next = temp;
                }
            }
            return dummy.next;
        }
        /// <summary>
        /// leetcode第93题，复原IP地址
        /// https://leetcode.cn/problems/restore-ip-addresses/solution/yi-ge-xia-wu-you-mei-liao-by-jian-chi-3/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<string> L_93_RestoreIpAddresses(string s)
        {
            //从s.Length个数字里面选四个位置
            List<string> res = new List<string>();
            if (s.Length > 12) return res;

            List<int> data = new List<int>();
            StringBuilder builder = new StringBuilder();
            Find(0, 4);
            return res;

            void AddData()
            {
                foreach (var p in data)
                {
                    builder.Append(p);
                    builder.Append('.');
                }
                builder.Remove(builder.Length - 1, 1);
                res.Add(builder.ToString());
                builder.Clear();
            }
            void Find(int index, int count)
            {
                if (count == 0)
                {
                    if (index == s.Length)
                    {
                        AddData();
                    }
                    return;
                }

                if (index >= s.Length) { return; }
                int val = 0;
                if (s[index] == '0')
                {
                    data.Add(0);
                    Find(index + 1, count - 1);
                    data.RemoveAt(data.Count - 1);
                }
                else
                {
                    int lowVal = Math.Min(index + 3, s.Length);
                    for (int i = index; i < lowVal; i++)
                    {
                        val = val * 10 + (s[i] - '0');
                        if (val <= 255)
                        {
                            data.Add(val);
                            Find(i + 1, count - 1);
                            data.RemoveAt(data.Count - 1);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// leetcode第94题，二叉树的中序遍历
        /// https://leetcode.cn/problems/binary-tree-inorder-traversal/solution/er-cha-shu-zhong-xu-bian-li-by-jin-li-er-qnac/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> L_94_InorderTraversal(TreeNode? root)
        {
            List<int> list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count != 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                list.Add(root.val);
                root = root.right;
            }
            return list;
        }
        /// <summary>
        /// leetcode第95题，不同的二叉搜索树Ⅱ
        /// https://leetcode.cn/problems/unique-binary-search-trees-ii/solution/tong-guo-shen-du-you-xian-sou-suo-sheng-cheng-bu-t/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<TreeNode> L_95_GenerateTrees(int n)
        {
            IList<TreeNode> ret = new List<TreeNode>();
            if (n == 0)
                return ret;
            int[] arr = new int[n];   //arr存储当前数字序列
            bool[] flag = new bool[n + 1]; //存储当前数字是否有被使用
            DFS(arr, 0, n, flag, ret);
            return ret;
        }
        /// <summary>
        /// leetcode第96题，不同的二叉搜索树
        /// https://leetcode.cn/problems/unique-binary-search-trees/solution/by-trophy-1-0u4f/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int L_96_NumTrees(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 1;
            //将1至n分别作为根结点时的数量累加即为结果 dp[n]
            for (int i = 1; i <= n; i++)
            {
                // 将除去根结点之外的（n-1）个子节点做排列组合
                for (int j = 0; j < i; j++)
                {
                    dp[i] += dp[j] * dp[i - j - 1];
                }
            }
            return dp[n];
        }
        /// <summary>
        /// leetcode第97题，交错字符串
        /// https://leetcode.cn/problems/interleaving-string/solution/jian-dan-ming-liao-de-jie-fa-by-magicalc-ubyl/
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool L_97_IsInterleave(string s1, string s2, string s3)
        {
            int m = s1.Length, n = s2.Length;
            if (s3.Length != n + m)
                return false;
            bool[,] dp = new bool[m + 1, n + 1];
            //初始化 dp
            dp[0, 0] = true;// 0 个元素必然可以构成 0 个元素
            for (int i = 0; i < n; i++)
                dp[0, i + 1] = dp[0, i] && s2[i] == s3[i];
            for (int i = 0; i < m; i++)
                dp[i + 1, 0] = dp[i, 0] && s1[i] == s3[i];
            int cur;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    cur = i + j + 1;
                    dp[i + 1, j + 1] = (dp[i + 1, j] && s2[j] == s3[cur]) ||
                                        (dp[i, j + 1] && s1[i] == s3[cur]);
                }
            return dp[m, n];
        }
        /// <summary>
        /// leetcode第98题，验证二叉搜索树
        /// https://leetcode.cn/problems/validate-binary-search-tree/solution/98-yan-zheng-er-cha-sou-suo-shu-c-by-kas-bybz/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool L_98_IsValidBST(TreeNode? root)
        {
            var stack = new Stack<TreeNode>();
            var inorder = long.MinValue;
            while (stack.Count > 0 || root != null)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (root.val <= inorder)
                    return false;
                inorder = root.val;
                root = root.right;
            }
            return true;
        }
        /// <summary>
        /// leetcode第99题，恢复二叉搜索树
        /// https://leetcode.cn/problems/recover-binary-search-tree/solution/by-davecano-2-4pqq/
        /// </summary>
        /// <param name="root"></param>
        public void L_99_RecoverTree(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode? prev = null;
            TreeNode? swap1 = null;
            TreeNode? nextSwap1 = null;
            TreeNode? swap2 = null;
            TreeNode? node = root;
            while (stack.Count > 0 || node != null)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                node = stack.Pop();
                if (prev != null && prev.val > node.val)
                {
                    if (swap1 == null)
                    {
                        swap1 = prev;
                        nextSwap1 = node;
                    }
                    else if (swap2 == null)
                    {
                        swap2 = node;
                        break;
                    }
                }
                prev = node;
                node = node.right;
            }
            if (swap2 == null) Swap(ref swap1, ref nextSwap1);
            else Swap(ref swap1, ref swap2);
        }
        /// <summary>
        /// leetcode第100题，相同的树
        /// https://leetcode.cn/problems/same-tree/solution/xiang-tong-de-shu-by-yicheng2020/
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool L_100_IsSameTree(TreeNode? p, TreeNode? q)
        {
            //递归终止情况1：p, q都是null
            if (p == null && q == null)
            {
                return true;
            }
            //递归终止情况2：p, q中有一个为空，或者是p, q的节点值不等
            else if (p == null || q == null || p.val != q.val)
            {
                return false;
            }
            else
            {
                //递归看左子树是否相同
                bool isLeftSameTree = L_100_IsSameTree(p.left, q.left);
                //递归看右子树是否相同
                bool isRightSameTree = L_100_IsSameTree(p.right, q.right);
                return isLeftSameTree && isRightSameTree;
            }
        }
        /// <summary>
        /// leetcode第101题，对称二叉树
        /// https://leetcode.cn/problems/symmetric-tree/solution/dui-cheng-er-cha-shu-dui-lie-by-jin-li-e-twh1/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool? L_101_IsSymmetric(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode? left, right;
            left = root.left;
            right = root.right;
            if (root == null || (left == null && right == null)) return true;
            if (left != null && right != null)
            {
                queue.Enqueue(left);
                queue.Enqueue(right);
            }
            while (queue.Count() != 0)
            {
                left = queue.Dequeue();
                right = queue.Dequeue();
                if (left == null && right == null)
                {
                    continue;
                }
                if ((left == null || right == null) || (left.val != right.val))
                {
                    return false;
                }
                if (left.left != null && right.right != null && left.right != null && right.left != null)
                {
                    queue.Enqueue(left.left);
                    queue.Enqueue(right.right);
                    queue.Enqueue(left.right);
                    queue.Enqueue(right.left);
                }
            }
            return true;
        }
        /// <summary>
        /// leetcode第102题，二叉树的层序遍历
        /// https://leetcode.cn/problems/binary-tree-level-order-traversal/solution/bfsmo-ban-dan-dui-lie-bei-jiu-wan-liao-by-mitty/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> L_102_LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null) return result;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var list = new List<int>();
                int count = queue.Count;
                for (int i = 0; i < count; ++i)
                {
                    var node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                result.Add(list);
            }
            return result;
        }
        /// <summary>
        /// leetcode第103题，二叉树的锯齿形层序遍历
        /// https://leetcode.cn/problems/binary-tree-zigzag-level-order-traversal/solution/by-pan-pan-sn-bdgx/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> L_103_ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null) return res;//没有元素直接返回空集合
            List<int> subList;
            bool reverse = false;//翻转，还是不翻转
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int count = queue.Count;//上一层级元素个数
                subList = new List<int>();
                while (count > 0)
                {
                    TreeNode pre = queue.Dequeue();
                    subList.Add(pre.val);
                    if (pre.left != null)
                        queue.Enqueue(pre.left);
                    if (pre.right != null)
                        queue.Enqueue(pre.right);
                    count--;//维护上一层级元素个数
                }
                if (reverse)//要么顺序翻转，要么不翻转
                    subList.Reverse();
                reverse = !reverse;//上次翻转了，下次不翻转
                res.Add(subList);
            }
            return res;
        }
        /// <summary>
        /// leetcode第104题，二叉树的最大深度
        /// https://leetcode.cn/problems/maximum-depth-of-binary-tree/solution/er-cha-shu-de-zui-da-shen-du-by-yicheng2020/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int L_104_MaxDepth(TreeNode root)
        {
            int result = 0;
            //队列用来放每一层不为null的节点
            Queue<TreeNode> queue = new Queue<TreeNode>();
            //用来临时存放每次更新queue前的上一层所有节点
            Queue<TreeNode> tempQueue = new Queue<TreeNode>();
            if (root != null)
            {
                queue.Enqueue(root);
            }
            while (queue.Count > 0)
            {
                while (queue.Count > 0)
                {
                    tempQueue.Enqueue(queue.Dequeue());
                }
                result++;
                while (tempQueue.Count > 0)
                {
                    //tempQueue不为空则将下一层的节点放入队列
                    var element = tempQueue.Dequeue();
                    if (element.left != null)
                    {
                        queue.Enqueue(element.left);
                    }
                    if (element.right != null)
                    {
                        queue.Enqueue(element.right);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// leetcode第105题，从前序与中序遍历序列构造二叉树
        /// https://leetcode.cn/problems/construct-binary-tree-from-preorder-and-inorder-traversal/solution/can-kao-guan-fang-jie-da-by-xiao-yao-23/
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode? L_105_BuildTree(int[] preorder, int[] inorder)
        {
            Dictionary<int, int> h = new Dictionary<int, int>();
            for (int i = 0; i < inorder.Length; i++)
            {
                h.Add(inorder[i], i);
            }
            return BuildTree(preorder, 0, preorder.Length - 1, 0, inorder.Length - 1, h);
        }
        /// <summary>
        /// leetcode第106题，从中序与后续遍历序列构造二叉树
        /// https://leetcode.cn/problems/construct-binary-tree-from-inorder-and-postorder-traversal/solution/cong-zhong-xu-yu-hou-xu-bian-li-lie-biao-3ev9/
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode? L_106_BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0) return null;
            int root = postorder[postorder.Length - 1];

            var rootIndexInInorderArray = 0;
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == root) rootIndexInInorderArray = i;
            }
            var rootNode = new TreeNode(root);
            int[] inorderLeft = new int[0], inorderRight = new int[0];
            int[] postorderLeft = new int[0], postorderRight = new int[0];

            if (rootIndexInInorderArray != 0)
            {
                inorderLeft = inorder[0..rootIndexInInorderArray];
                postorderLeft = postorder[0..rootIndexInInorderArray];
            }
            if (rootIndexInInorderArray != inorder.Length - 1)
            {
                inorderRight = inorder[(rootIndexInInorderArray + 1)..inorder.Length];
                postorderRight = postorder[rootIndexInInorderArray..(postorder.Length - 1)];
            }
            rootNode.left = L_106_BuildTree(inorderLeft, postorderLeft);
            rootNode.right = L_106_BuildTree(inorderRight, postorderRight);
            return rootNode;
        }
        /// <summary>
        /// leetcode第107题，二叉树的层序遍历Ⅱ
        /// https://leetcode.cn/problems/binary-tree-level-order-traversal-ii/solution/er-cha-shu-de-ceng-ci-bian-li-ii-by-yicheng2020/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> L_107_LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            //队列用来放每一层不为null的节点
            Queue<TreeNode> queue = new Queue<TreeNode>();
            //用来临时存放每次更新queue前的上一层所有节点
            Queue<TreeNode> tempQueue = new Queue<TreeNode>();

            if (root != null)
            {
                queue.Enqueue(root);
            }
            while (queue.Count > 0)
            {
                var list = new List<int>();
                while (queue.Count > 0)
                {
                    var element = queue.Dequeue();
                    //逐个添加该层节点
                    list.Add(element.val);
                    tempQueue.Enqueue(element);
                }
                result.Add(list);
                while (tempQueue.Count > 0)
                {
                    //放入下一层不为空的节点
                    var element = tempQueue.Dequeue();
                    if (element.left != null)
                    {
                        queue.Enqueue(element.left);
                    }
                    if (element.right != null)
                    {
                        queue.Enqueue(element.right);
                    }
                }
            }
            return result.Reverse().ToList();
        }
        /// <summary>
        /// leetcode第108题，将有序数组转换为二叉搜索树
        /// https://leetcode.cn/problems/convert-sorted-array-to-binary-search-tree/solution/jiang-you-xu-shu-zu-zhuan-huan-wei-er-cha-sou-s-33/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode? L_108_SortedArrayToBST(int[] nums)
        {
            return Helper(nums, 0, nums.Length - 1);
        }
        /// <summary>
        /// leetcode第109题，有序链表转换二叉搜索树
        /// https://leetcode.cn/problems/convert-sorted-list-to-binary-search-tree/solution/109-you-xu-lian-biao-zhuan-huan-er-cha-sou-suo--17/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public TreeNode? L_109_SortedListToBST(ListNode? head)
        {
            // 快慢指针：先找到中间节点，然后左右两边的链表作为左右子树，直到链表只有一个节点。
            if (head == null || head.next == null)
            {
                return null;
            }
            ListNode? fast = head, slow = head, pre = null;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                pre = slow;
                if (slow != null) slow = slow.next;
            }
            TreeNode? root = null;
            if (slow != null) root = new TreeNode(slow.val);
            if (pre != null) pre.next = null;    // 把链表一分为二
            if (root != null && slow != null)
            {
                root.left = L_109_SortedListToBST(head);
                root.right = L_109_SortedListToBST(slow.next);
            }
            return root;
        }
        /// <summary>
        /// leetcode第110题，平衡二叉树
        /// https://leetcode.cn/problems/balanced-binary-tree/solution/zi-ding-xiang-xia-by-zyc-1r-53ca/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool L_110_IsBalanced(TreeNode? root)
        {
            if (root == null)
                return true;
            else
                return Math.Abs(Height(root.left) - Height(root.right)) <= 1 && L_110_IsBalanced(root.left) && L_110_IsBalanced(root.right);
        }
        /// <summary>
        /// leetcode第111题，二叉树最小深度
        /// https://leetcode.cn/problems/minimum-depth-of-binary-tree/solution/can-kao-jing-xuan-ti-jie-xie-de-cdai-ma-zhe-ti-dfs/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int L_111_MinDepth(TreeNode? root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            int left = L_111_MinDepth(root.left);
            int right = L_111_MinDepth(root.right);
            if (root.left == null || root.right == null)
            {
                return left + right + 1;
            }
            return Math.Min(left, right) + 1;
        }
        /// <summary>
        /// leetcode第112题，路径总和
        /// https://leetcode.cn/problems/path-sum/solution/112-lu-jing-zong-he-by-stormsunshine-s3yd/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public bool L_112_HasPathSum(TreeNode? root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return targetSum == root.val;
            }
            return L_112_HasPathSum(root.left, targetSum - root.val) || L_112_HasPathSum(root.right, targetSum - root.val);
        }
        /// <summary>
        /// leetcode第113题，路径总和Ⅱ
        /// https://leetcode.cn/problems/path-sum-ii/solution/bfssi-lu-xiao-lu-wei-bi-zui-gao-dan-shi-si-lu-ying/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public IList<IList<int>> L_113_PathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return new List<IList<int>>(0);

            var result = new List<IList<int>>();
            var bfs = new Queue<TreeNode[]>();
            bfs.Enqueue(new TreeNode[1]
            {
                root
            });

            while (bfs.Count > 0)
            {
                var current = bfs.Dequeue();
                var currLast = current.Last();
                var _sum = current.Select(x => x.val).Sum();
                if (targetSum == _sum && currLast.left == null && currLast.right == null)
                {
                    result.Add(current.Select(x => x.val).ToList());
                }
                else
                {
                    if (currLast.left != null)
                    {
                        var _nexts = new TreeNode[current.Length + 1];
                        for (var i = 0; i < current.Length; i++)
                        {
                            _nexts[i] = current[i];
                        }
                        _nexts[_nexts.Length - 1] = currLast.left;
                        bfs.Enqueue(_nexts);
                    }
                    if (currLast.right != null)
                    {
                        var _nexts = new TreeNode[current.Length + 1];
                        for (var i = 0; i < current.Length; i++)
                        {
                            _nexts[i] = current[i];
                        }
                        _nexts[_nexts.Length - 1] = currLast.right;
                        bfs.Enqueue(_nexts);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// leetcode第114题，二叉树展开为链表
        /// https://leetcode.cn/problems/flatten-binary-tree-to-linked-list/solution/by-dhsgd-32y0/
        /// </summary>
        /// <param name="root"></param>
        public void L_114_Flatten(TreeNode? root)
        {
            if (root == null) return;
            //函数定义为把root 为根的二叉树拉成链表
            L_114_Flatten(root.left);
            L_114_Flatten(root.right);
            TreeNode? left = root.left;
            TreeNode? right = root.right;
            root.left = null;
            root.right = left;
            TreeNode p = root;
            while (p.right != null)
            {
                p = p.right;
            }
            p.right = right;
        }
        /// <summary>
        /// leetcode第115题，不同的子序列
        /// https://leetcode.cn/problems/distinct-subsequences/solution/c-dp-by-99de-shou-su-jia-shang-1de-yun-q-4947/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int L_115_NumDistinct(string s, string t)
        {
            int[,] dp = new int[s.Length + 1, t.Length + 1];
            for (int i = 0; i <= s.Length; i++)
                dp[i, 0] = 1;
            for (int i = 1; i < s.Length + 1; i++)
            {
                for (int j = 1; j < t.Length + 1; j++)
                {
                    if (s[i - 1] == t[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                    else dp[i, j] = dp[i - 1, j];
                }
            }
            return dp[s.Length, t.Length];
        }
        /// <summary>
        /// leetcode第116题，填充每个节点的下一个右侧节点指针
        /// https://leetcode.cn/problems/populating-next-right-pointers-in-each-node/solution/by-stormsunshine-6wrw/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node? L_116_Connect(Node root)
        {
            if (root == null)
            {
                return root;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Node node = queue.Dequeue();
                    if (i < size - 1)
                    {
                        node.next = queue.Peek();
                    }
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }
            return root;
        }
        /// <summary>
        /// leetcode第117题，填充每个节点的下一个右侧节点指针Ⅱ
        /// https://leetcode.cn/problems/populating-next-right-pointers-in-each-node-ii/solution/117-tian-chong-mei-ge-jie-dian-de-xia-yi-b0n0/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node? L_117_Connect(Node root)
        {
            if (root == null)
            {
                return root;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Node node = queue.Dequeue();
                    if (i < size - 1)
                    {
                        node.next = queue.Peek();
                    }
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }
            return root;
        }
        /// <summary>
        /// leetcode第118题，杨辉三角
        /// https://leetcode.cn/problems/pascals-triangle/solution/118-yang-hui-san-jiao-by-myg-u-850j/
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> L_118_Generate(int numRows)
        {
            var result = new int[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                result[i] = new int[i + 1];
                //最前和最后都是1
                result[i][0] = 1;
                result[i][i] = 1;
                //[1] 0
                //[1,1] 1
                //[1,2,1] 2
                //[1,3,3,1] 3
                //[1,4,6,4,1] 4
                for (int j = 1; j < i; j++)
                {
                    //其他等于上一行[i-1] 和 [i] 的和
                    result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
                }
            }
            return result.ToArray();
        }
        /// <summary>
        /// leetcode第118题，杨辉三角Ⅱ
        /// https://leetcode.cn/problems/pascals-triangle-ii/solution/22824-by-noslotus-0ubm/
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> L_119_GetRow(int rowIndex)
        {
            List<int> t = new List<int>() { 1 };
            if (rowIndex == 0) return t;
            for (int i = 0; i < rowIndex; i++)
            {
                t.Add(1);
                for (int j = i; j > 0; j--)
                {
                    t[j] += t[j - 1];
                }
            }
            return t;
        }
        /// <summary>
        /// leetcode第120题，三角形最小路径和
        /// https://leetcode.cn/problems/triangle/solution/guan-fang-ti-jie-java-c-by-zhaohyan22-k9ks/
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int L_120_MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1) return triangle[0][0];
            int n = triangle.Count;
            int[,] dp = new int[n, n];
            dp[0, 0] = triangle[0][0];
            for (int i = 1; i < n; ++i)
            {
                dp[i, 0] = dp[i - 1, 0] + triangle[i][0];
                // 当 j=i 时，f[i-1][j] 没有意义，因此j < i
                for (int j = 1; j < i; ++j)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j - 1], dp[i - 1, j]) + triangle[i][j];
                }
                dp[i, i] = dp[i - 1, i - 1] + triangle[i][i];
            }
            // Finding the minimum
            int ans = dp[n - 1, 0];
            for (int k = 1; k < n; ++k)
            {
                ans = Math.Min(ans, dp[n - 1, k]);
            }
            return ans;
        }
        /// <summary>
        /// leetcode第121题，买卖股票的最佳时机
        /// https://leetcode.cn/problems/best-time-to-buy-and-sell-stock/solution/by-hua-gao-xgwx/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int L_121_MaxProfit(int[] prices)
        {
            int minprice = prices[0];
            int maxProfit = 0;
            foreach (int price in prices)
            {
                if (price < minprice)
                {
                    minprice = price;
                }
                else if (price - minprice > maxProfit)
                {
                    maxProfit = price - minprice;
                }
            }
            return maxProfit;
        }
        /// <summary>
        /// leetcode第122题，买卖股票的最佳时机Ⅱ
        /// https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-ii/solution/mai-mai-gu-piao-de-zui-jia-shi-ji-ii-c-by-transong/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int L_122_MaxProfit(int[] prices)
        {
            var profit = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }
            return profit;
        }
        /// <summary>
        /// leetcode第123题，买卖股票的最佳时机Ⅲ
        /// https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-iii/solution/c-by-anlll-4ybj/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int L_123_MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int[,,] dp = new int[n, 2, 3];
            dp[0, 0, 0] = 0;
            dp[0, 1, 0] = -prices[0];
            int ans = 0;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (i < j) continue;
                    if (j == 0)
                        dp[i, 0, j] = dp[i - 1, 0, j];
                    else
                        dp[i, 0, j] = Math.Max(dp[i - 1, 0, j], dp[i - 1, 1, j - 1] + prices[i]);
                    if (i == j)
                        dp[i, 1, j] = -prices[i];
                    else
                        dp[i, 1, j] = Math.Max(dp[i - 1, 1, j], dp[i - 1, 0, j] - prices[i]);
                }
            }
            for (int j = 0; j <= 2; j++)
            {
                ans = Math.Max(ans, dp[n - 1, 0, j]);
            }
            return ans;
        }
        /// <summary>
        /// leetcode第124题，二叉树中的最大路径和
        /// https://leetcode.cn/problems/binary-tree-maximum-path-sum/solution/er-cha-shu-zhong-de-zui-da-lu-jing-he-by-leetcode-/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int L_124_MaxPathSum(TreeNode root)
        {
            MaxGain(root);
            return maxSum;
        }
        /// <summary>
        /// leetcode第125题，验证回文串
        /// https://leetcode.cn/problems/valid-palindrome/solution/by-stormsunshine-2y6d/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool L_125_IsPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }
                while (left < right && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
        /// <summary>
        /// leetcode第126题，单词接龙Ⅱ
        /// https://leetcode.cn/problems/word-ladder-ii/solution/yan-du-you-xian-jian-zhi-by-wu-ming-c8v-6ecp/
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public IList<IList<string>> L_126_FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var result = new List<IList<string>>();
            var words = new HashSet<string>(wordList);
            if (!words.Contains(endWord))
            {
                return result;
            }
            var wl = beginWord.Length - 1;
            var que = new Queue<List<string>>();
            que.Enqueue(new List<string> { beginWord });
            while (result.Count == 0 && que.Count > 0)
            {
                var ignoreList = new List<string>();
                for (int k = que.Count; k > 0; k--)
                {
                    var list = que.Dequeue();
                    var arr = list[list.Count - 1].ToArray();
                    for (int i = wl; i >= 0; i--)
                    {
                        var orignal = arr[i];
                        for (char ch = 'a'; ch <= 'z'; ch++)
                        {
                            if (ch == orignal)
                            {
                                continue;
                            }
                            arr[i] = ch;
                            var next = string.Join("", arr);
                            if (words.Contains(next) && !list.Contains(next))
                            {
                                if (next == endWord)
                                {
                                    list.Add(next);
                                    result.Add(list);
                                }
                                else
                                {
                                    var t = list.ToList();
                                    t.Add(next);
                                    que.Enqueue(t);
                                    ignoreList.Add(next);
                                }
                            }
                        }
                        arr[i] = orignal;
                    }
                }
                //剪枝
                foreach (var item in ignoreList)
                {
                    words.Remove(item);
                }
            }
            return result;
        }
        /// <summary>
        /// leetcode第127题，单词接龙
        /// https://leetcode.cn/problems/word-ladder/solution/by-stormsunshine-xvro/
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int L_127_LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            ISet<string> wordSet = new HashSet<string>();
            foreach (string word in wordList)
            {
                wordSet.Add(word);
            }
            if (!wordSet.Contains(endWord))
            {
                return 0;
            }
            len = beginWord.Length;
            ISet<string> visited = new HashSet<string>();
            visited.Add(beginWord);
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            int wordCount = 0;
            while (queue.Count > 0)
            {
                wordCount++;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    string word = queue.Dequeue();
                    if (word.Equals(endWord))
                    {
                        return wordCount;
                    }
                    IList<string> adjacentWords = GetAdjacentWords(word);
                    foreach (string adjacent in adjacentWords)
                    {
                        if (wordSet.Contains(adjacent) && visited.Add(adjacent))
                        {
                            queue.Enqueue(adjacent);
                        }
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// leetcode第128题，最长连续序列
        /// https://leetcode.cn/problems/longest-consecutive-sequence/solution/by-stormsunshine-2e55/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int L_128_LongestConsecutive(int[] nums)
        {
            ISet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                set.Add(num);
            }
            int maxLength = 0;
            foreach (int num in set)
            {
                if (set.Contains(num - 1))
                {
                    continue;
                }
                int maxNum = num;
                while (set.Contains(maxNum + 1))
                {
                    maxNum++;
                }
                maxLength = Math.Max(maxLength, maxNum - num + 1);
            }
            return maxLength;
        }
        /// <summary>
        /// leetcode第129题，求根节点到叶节点数字之和
        /// https://leetcode.cn/problems/sum-root-to-leaf-numbers/solution/po-su-ru-he-zai-sou-suo-de-guo-cheng-zhong-qiu-jie/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int L_129_SumNumbers(TreeNode? root)
        {
            if (root is null) return 0;
            if (root.left is null && root.right is null) return len * 10 + root.val; // 找到叶子节点

            len = len * 10 + root.val;
            int res = L_129_SumNumbers(root.left) + L_129_SumNumbers(root.right);
            len /= 10; // 撤销
            return res;
        }
        /// <summary>
        /// leetcode第130题，被围绕的区域
        /// https://leetcode.cn/problems/surrounded-regions/solution/su-hui-cong-zhi-dao-zu-qie-chang-by-shou-5o8o/
        /// </summary>
        /// <param name="board"></param>
        public void L_130_Solve(char[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;
            void DFS(int i, int j)
            {
                if (i < 0 || i >= m || j < 0 || j >= n) return;
                if (board[i][j] != 'O') return;
                board[i][j] = '#';
                DFS(i + 1, j);
                DFS(i, j + 1);
                DFS(i - 1, j);
                DFS(i, j - 1);
            }
            for (int i = 0; i < m; i++)
            {
                DFS(i, 0); DFS(i, n - 1);
            }
            for (int i = 0; i < n; i++)
            {
                DFS(0, i); DFS(m - 1, i);
            }
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (board[i][j] == '#')
                        board[i][j] = 'O';
        }
        /// <summary>
        /// leetcode第131题，分割回文串
        /// https://leetcode.cn/problems/palindrome-partitioning/solution/c-by-miaomiaomiaomiao-cq31/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> L_131_Partition(string s)
        {
            int n = s.Length;
            var dp = new Boolean[n][];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = new Boolean[n];
            for (int y = 0; y < dp.Length; y++)
                for (int x = 0; x < dp.Length; x++)
                    if (y >= x)
                        dp[y][x] = true;
            for (int y = dp.Length - 1; y >= 0; y--)
                for (int x = dp.Length - 1; x >= 0; x--)
                {
                    if (y >= x) continue;
                    dp[y][x] = (s[x] == s[y] && dp[y + 1][x - 1]);
                }
            var result = new List<IList<string>>();
            var lists = DFS(dp, s, 0);
            result.AddRange(lists);
            return result;
        }
        /// <summary>
        /// leetcode第132题，分割回文串Ⅱ
        /// https://leetcode.cn/problems/palindrome-partitioning-ii/solution/by-dreamy-lehmannggf-7uww/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int L_132_MinCut(string s)
        {
            int n = s.Length;
            int[] cut = new int[n + 1];

            //赋初值，最多的情况是按单个字符切分, cut[0]设为-1
            for (int i = 0; i <= n; i++) cut[i] = i - 1;

            for (int i = 0; i < n; i++)
            {
                //以i为中心扩展，回文串字符数为奇数
                for (int j = 0; i - j >= 0 && i + j < n && s[i - j] == s[i + j]; j++)
                {
                    //当s[i-j]到s[i+j]是个回文字符串时 cut[i - j] + 1 是 cut[i + j + 1] 的候选之一
                    cut[i + j + 1] = Math.Min(cut[i + j + 1], cut[i - j] + 1);
                }
                //以i和i+1之间的间隔为中心扩展，回文串字符数为偶数
                for (int j = 0; i - j >= 0 && i + 1 + j < n && s[i - j] == s[i + 1 + j]; j++)
                {
                    cut[i + j + 2] = Math.Min(cut[i + j + 2], cut[i - j] + 1);
                }
            }
            return cut[n];
        }
        /// <summary>
        /// leetcode第133题，克隆图
        /// https://leetcode.cn/problems/clone-graph/solution/by-stormsunshine-9rhg/
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node2 L_133_CloneGraph(Node2 node)
        {
            if (node == null)
            {
                return null;
            }
            IDictionary<Node2, Node2> cloneDictionary = new Dictionary<Node2, Node2>();
            cloneDictionary.Add(node, new Node2(node.val));
            Queue<Node2> queue = new Queue<Node2>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                Node2 original = queue.Dequeue();
                Node2 cloned = cloneDictionary[original];
                IList<Node2> originalNeighbors = original.neighbors;
                IList<Node2> clonedNeighbors = cloned.neighbors;
                foreach (Node2 originalNeighbor in originalNeighbors)
                {
                    if (!cloneDictionary.ContainsKey(originalNeighbor))
                    {
                        cloneDictionary.Add(originalNeighbor, new Node2(originalNeighbor.val));
                        queue.Enqueue(originalNeighbor);
                    }
                    clonedNeighbors.Add(cloneDictionary[originalNeighbor]);
                }
            }
            return cloneDictionary[node];
        }
        /// <summary>
        /// leetcode第134题，加油站
        /// https://leetcode.cn/problems/gas-station/solution/by-iceream-c91i/
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int L_134_CanCompleteCircuit(int[] gas, int[] cost)
        {
            int min = gas[0]; //先定义最小含油量为未出发时
            int sum = 0; //定义当前含油量
            int index = 0; //定义含油量最低时候的索引值
            for (int i = 0; i < gas.Length; i++)
            {
                sum += (gas[i] - cost[i]); //更新含油量
                if (sum <= min) index = i; //令index为最小含油量处的索引
                min = Math.Min(min, sum);  // 更新最小含油量

            }
            if (sum < 0) return -1; //can not get
            if (min >= 0) return 0; // can get
            return index + 1; //其实上面不用那个return 0 ，习惯
        }
        /// <summary>
        /// leetcode第135题，分发糖果
        /// https://leetcode.cn/problems/candy/solution/jie-by-long-yu-8-ddh8/
        /// </summary>
        /// <param name="ratings"></param>
        /// <returns></returns>
        public int L_135_Candy(int[] ratings)
        {
            //从左到右，从右到左两次遍历
            //以[1 3 2 1 1 2 1]为例
            int n = ratings.Length;
            int[] left = new int[n];//定义数组存储第一次遍历结果，left下标和ratings的下标一致
            for (int i = 0; i < n; i++)
            {
                if (i > 0 && ratings[i] > ratings[i - 1])//判断i与前i-1的值，i>i-1，left[i]就等于left[i-1]的值+1，
                {
                    left[i] = left[i - 1] + 1;
                }
                else//如果小于，left[i]置为1
                {
                    left[i] = 1;
                }
            }//最后结果为left[1,2,1,1,1,2,1]

            int right = 0, ret = 0;//从右到左遍历
            for (int i = n - 1; i >= 0; i--)
            {
                if (i < n - 1 && ratings[i] > ratings[i + 1])//判断i与i+1的值，
                {
                    right++;//i的值>i+1的值，right+1;
                }
                else
                {
                    right = 1;//right置为1
                }
                //从右到左
                //right   1,3,2,1,1,2,1
                //left    1,2,1,1,1,2,1
                //结果    1,3,2,1,1,2,1
                ret += Math.Max(left[i], right);
            }
            return ret;
        }
        
        
        //TODO待添加算法处
        /// <summary>
        /// 斐波那契(迭代法)
        /// </summary>
        public ulong F1(int number)
        {
            if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                return F1(number - 1) + F1(number - 2);
            }
        }
        /// <summary>
        /// 斐波那契(直接法)
        /// </summary>
        public ulong F2(int number)
        {
            ulong a = 1, b = 1;
            if (number == 1 || number == 2)
            {
                return 1;
            }
            else
            {
                for (int i = 3; i <= number; i++)
                {
                    ulong c = a + b;
                    b = a;
                    a = c;
                }
                return a;
            }
        }
        /// <summary>
        /// 斐波那契(矩阵法)
        /// </summary>
        public ulong F3(int n)
        {
            ulong[,] a = new ulong[2, 2] { { 1, 1 }, { 1, 0 } };
            ulong[,] b = MatirxPower(a, n);
            return b[1, 0];
        }
        /// <summary>
        /// 斐波那契(通项公式法)
        /// </summary>
        public double F4(int n)
        {
            double sqrt = Math.Sqrt(5);
            return (1 / sqrt * (Math.Pow((1 + sqrt) / 2, n) - Math.Pow((1 - sqrt) / 2, n)));
        }
        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns>如果目标值存在返回下标，否则返回 -1</returns>
        public int Binarysearch(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (right - left) / 2 + left;
                int num = nums[mid];
                if (num == target)
                {
                    return mid;
                }
                else if (num > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;
        }
        /// <summary>
        /// 复制一段任意类型的数组值到另一数组
        /// </summary>
        /// <param name="orign">数据来源</param>
        /// <param name="from">复制参数的初始下标</param>
        /// <param name="to">复制参数的终点下标(不包括该下标的值)</param>
        public T[] Copy<T>(T[] orign, int from, int to)
        {
            if (from >= to || to > orign.Length) throw new Exception("超出索引");
            T[] targeta = new T[to - from];
            int index = 0;
            for (int i = from; i < to; i++)
            {
                targeta[index++] = orign[i];
            }
            return targeta;
        }
        /// <summary>
        /// 同类型参数交换
        /// </summary>
        public void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        /// <summary>
        /// 创建ListNode
        /// </summary>
        /// <returns></returns>
        public ListNode? generateList(int[] vals)
        {
            ListNode? res = null;
            ListNode? last = null;
            foreach (var val in vals)
            {
                if (res is null)
                {
                    res = new ListNode(val, null);
                    last = res;
                }
                else
                {
                    if (last != null)
                    {
                        last.next = new ListNode(val, null);
                        last = last.next;
                    }
                }
            }
            return res;
        }
        public void printList(ListNode? l)
        {
            while (l != null)
            {
                Console.Write($"{l.val}, ");
                l = l.next;
            }
            Console.WriteLine("");
        }


        /// <summary>
        /// 于L_127_LadderLength中调用
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private IList<string> GetAdjacentWords(string word)
        {
            IList<string> adjacentWords = new List<string>();
            char[] arr = word.ToCharArray();
            for (int i = 0; i < len; i++)
            {
                char original = arr[i];
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (c == original)
                    {
                        continue;
                    }
                    arr[i] = c;
                    adjacentWords.Add(new string(arr));
                }
                arr[i] = original;
            }
            return adjacentWords;
        }
        /// <summary>
        /// 于L_124_MaxPathSum中调用
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private int MaxGain(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            // 递归计算左右子节点的最大贡献值
            // 只有在最大贡献值大于 0 时，才会选取对应子节点
            int leftGain = Math.Max(MaxGain(node.left), 0);
            int rightGain = Math.Max(MaxGain(node.right), 0);

            // 节点的最大路径和取决于该节点的值与该节点的左右子节点的最大贡献值
            int priceNewpath = node.val + leftGain + rightGain;

            // 更新答案
            maxSum = Math.Max(maxSum, priceNewpath);

            // 返回节点的最大贡献值
            return node.val + Math.Max(leftGain, rightGain);
        }
        /// <summary>
        /// 于L_110_IsBalanced中调用
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int Height(TreeNode? root)
        {
            if (root == null)
                return 0;
            else
                return Math.Max(Height(root.left), Height(root.right)) + 1;
        }
        /// <summary>
        /// 于L_108_SortedArrayToBST中调用
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private TreeNode? Helper(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null;
            }
            // 总是选择中间位置左边的数字作为根节点
            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = Helper(nums, left, mid - 1);
            root.right = Helper(nums, mid + 1, right);
            return root;
        }
        /// <summary>
        /// 于L_105_BuildTree中调用
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="htInorder"></param>
        /// <param name="preStart"></param>
        /// <param name="inStart"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private TreeNode? BuildTree(int[] preorder, int preleft, int preright, int inleft, int inright, Dictionary<int, int> h)
        {
            if (preleft > preright || inleft > inright)
            {
                return null;
            }
            int rootval = preorder[preleft];
            int pindex = h[rootval];
            TreeNode root = new TreeNode(rootval);
            root.left = BuildTree(preorder, preleft + 1, pindex + preleft - inleft, inleft, pindex - 1, h);
            root.right = BuildTree(preorder, pindex + preleft - inleft + 1, preright, pindex + 1, inright, h);
            return root;
        }
        /// <summary>
        /// 于L_77_Combine中调用
        /// </summary>
        /// <param name="start"></param>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="item"></param>
        /// <param name="res"></param>
        private void recruion(int start, int n, int k, int[] item, IList<IList<int>> res)
        {
            if (k == 0)
            {
                res.Add(item.ToList());
                return;
            }
            for (var i = start; i <= n - k + 1; i++)
            {
                item[item.Length - k] = i;
                recruion(i + 1, n, k - 1, item, res);
            }
        }
        /// <summary>
        /// 于L_68_FullJustify中调用，对序列进行排序
        /// </summary>
        private string Rank(string[] words, int start, int end, int[] nList, int maxvalue, bool last = false)
        {
            string ans = "";
            if (last)
            {
                for (int i = start; i < end; i++)
                {
                    ans += words[i] + " ";
                }
                ans += words[end];
                //对于最后一行补空格
                while (ans.Length != maxvalue)
                {
                    ans += " ";
                }
            }
            //不是最后一行则进行相应排序方法
            else
            {
                //统计字符串个数,长度
                int n = end - start + 1;

                //如果n==1
                if (n == 1)
                {
                    ans = words[start];
                    while (ans.Length != maxvalue)
                    {
                        ans += " ";
                    }
                    return ans;
                }

                int nums = 0;
                for (int i = start; i <= end; i++)
                {
                    nums += nList[i];
                }
                //计算间隔
                int k = maxvalue - nums;
                //平均间隔
                int meank = k / Math.Max((n - 1), 1);
                string x = "";
                for (int i = 0; i < meank; i++)
                {
                    x += " ";
                }
                int upk = k % Math.Max((n - 1), 1);
                for (int i = 0; i < n; i++)
                {
                    if (i < upk)
                    {
                        ans += words[i + start] + x + " ";
                    }
                    else if (i >= upk && i < n - 1)
                    {
                        ans += words[i + start] + x;
                    }
                    else
                    {
                        ans += words[i + start];
                    }
                }
            }
            return ans;
        }
        /// <summary>
        /// 于L_131_Partition中调用
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="s"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private List<List<string>> DFS(bool[][] dp, string s, int startIndex)
        {
            var results = new List<List<string>>();
            if (s.Length - startIndex == 1)
            {
                var list = new List<string>();
                list.Add(s.Substring(startIndex, 1));
                results.Add(list);
                return results;
            }
            if (s.Length - startIndex < 1)
            {
                var list = new List<string>();
                results.Add(list);
                return results;
            }

            for (int i = startIndex; i < s.Length; i++)
            {
                if (dp[startIndex][i])
                {
                    String str = s.Substring(startIndex, i - startIndex + 1);
                    var lists = DFS(dp, s, i + 1);
                    foreach (var list in lists)
                    {
                        list.Insert(0, str);
                    }
                    results.AddRange(lists);
                }
            }

            return results;
        }
        /// <summary>
        /// 于L_52_TotalNQueens中调用
        /// </summary>
        private void DFS(int row, int col, int pie, int na, int n)
        {
            if (row >= n)
            {
                len++;
                return;
            }
            // 得到空位.
            int bits = (~(col | pie | na)) & ((1 << n) - 1);
            while (bits > 0)
            {
                // 得到1个空位.
                int p = bits & (-bits);
                DFS(row + 1, col | p, (pie | p) << 1, (na | p) >> 1, n);
                // 去掉最后一位的1.
                bits = bits & (bits - 1);
            }
        }
        /// <summary>
        /// 于L_79_Exist中调用
        /// </summary>
        private bool DFS(char[][] board, string word, bool[,] vis, int i, int j, string temp)
        {
            if (i < 0 || i == board.Length || j < 0 || j == board[0].Length || word[temp.Length] != board[i][j] || vis[i, j])
                return false;
            temp += board[i][j];
            vis[i, j] = true;
            if (temp.Length == word.Length)
                return true;
            for (int k = 0; k < direction.Length; k++)
            {
                if (DFS(board, word, vis, i + direction[k][0], j + direction[k][1], temp))
                    return true;
            }
            vis[i, j] = false;
            return false;
        }
        /// <summary>
        /// 于L_95_GenerateTrees中调用
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="deep"></param>
        /// <param name="n"></param>
        /// <param name="flag"></param>
        /// <param name="ret"></param>
        private void DFS(int[] arr, int deep, int n, bool[] flag, IList<TreeNode> ret)
        {
            if (deep == n)
            {
                TreeNode node;
                TreeNode Head = new TreeNode();
                Head.val = arr[0];
                int k;
                for (int i = 0; i < n; ++i)
                {
                    k = 0;  //k=0初始状态 因为213和231相同，所以这里要做一个判断
                            //一个数字后面的数字必须是比它小的都在比它大的的数字前面
                            //或者是只允许一种类型的数字存在
                            //k = 0时，当前数都比他小 
                            //k = 1时，已经有数字比当前数字大了
                            //这里需要数字序列的每一位都满足这个条件才不会产生重复
                    for (int j = i + 1; j < n; ++j)
                    {
                        if (k == 0 && arr[j] < arr[i])
                            k = 1;
                        else if (k == 1 && arr[j] > arr[i])
                            return;
                    }
                }
                for (int i = 1; i < n; ++i)   //通过循环对当前数字序列建树
                {
                    node = Head;
                    while (node != null)
                    {
                        if (node.val > arr[i])     //往左子树方向插入
                        {
                            if (node.left == null)
                            {
                                node.left = new TreeNode(arr[i]);
                                break;
                            }
                            else
                                node = node.left;
                        }
                        if (node.val < arr[i])    //往右子树方向插入
                        {
                            if (node.right == null)
                            {
                                node.right = new TreeNode(arr[i]);
                                break;
                            }
                            else
                                node = node.right;
                        }
                    }
                }
                ret.Add(Head);
                return;
            }
            for (int i = 1; i <= n; ++i)
            {
                if (flag[i] == false)     //深搜，如果当前数字没被使用过就加进去
                {
                    flag[i] = true;
                    arr[deep] = i;
                    DFS(arr, deep + 1, n, flag, ret);  //深度加一
                    flag[i] = false;
                }
            }
        }
        /// <summary>
        /// 落子，于L_50_SolveNQueens方法中调用
        /// </summary>
        /// <param name="cb"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void Down(int[][] cb, int y, int x)
        {
            int len = cb.GetLength(0);
            for (int i = 0; i < len; i++)
            {
                cb[y][i] = 1;
                cb[i][x] = 1;
                if (x + i < len && y + i < len) cb[y + i][x + i] = 1;
                if (x + i < len && y - i >= 0) cb[y - i][x + i] = 1;
                if (x - i >= 0 && y - i >= 0) cb[y - i][x - i] = 1;
                if (x - i >= 0 && y + i < len) cb[y + i][x - i] = 1;
            }
            cb[y][x] = 0;//将落子点置为0,方便后续遍历得到皇后的位置
        }
        /// <summary>
        /// 于L_39_CombinationSum中调用
        /// </summary>
        /// <param name="candidates">整数数组</param>
        /// <param name="target">目标整数</param>
        /// <param name="temp">临时列表</param>
        /// <param name="sum">列表中的整数和</param>
        /// <param name="i">索引</param>
        /// <param name="res">结果集</param>
        private void Backtrack(int[] candidates, int target, List<int> temp, int sum, int i, IList<IList<int>> res)
        {
            // 当前值可以重复被选取，从索引i开始遍历
            for (int j = i; j < candidates.Length; j++)
            {
                // 临时列表中加入对应索引j的值
                temp.Add(candidates[j]);
                // 累计和
                sum += candidates[j];
                // 大于等于目标值时，后续循环只会使和更大，处理后可以直接结束循环
                if (sum >= target)
                {
                    // 满足和等于目标值加入结果集
                    if (sum == target)
                        res.Add(temp.ToArray());
                    // 临时列表回溯，并跳出循环
                    temp.RemoveAt(temp.Count - 1);
                    break;
                }
                else
                {
                    // 当和小于目标值时，继续递归进行累计，注意因为同一数字可重复使用所以索引传入j
                    Backtrack(candidates, target, temp, sum, j, res);
                    // 临时列表回溯
                    temp.RemoveAt(temp.Count - 1);
                    // 减去对应值
                    sum -= candidates[j];
                }
            }
        }
        /// <summary>
        /// 于L_40_CombinationSum2调用
        /// </summary>
        /// <param name="candidates">整数数组</param>
        /// <param name="target">目标整数</param>
        /// <param name="temp">临时列表</param>
        /// <param name="i">索引</param>
        /// <param name="res">结果集</param>
        private void Backtrack(int[] candidates, int target, List<int> temp, int i, IList<IList<int>> res)
        {
            if (target == 0)
                res.Add(temp.ToArray());
            else if (target > 0)
                for (int j = i; j < candidates.Length; j++)
                {
                    // 剪枝，当j不是循环中第一个值，且当前值等于前一个值时，重复，去除
                    if (j > i && candidates[j] == candidates[j - 1])
                        continue;
                    temp.Add(candidates[j]);
                    target -= candidates[j];
                    Backtrack(candidates, target, temp, j + 1, res);
                    temp.RemoveAt(temp.Count - 1);
                    target += candidates[j];
                }
        }
        /// <summary>
        /// 于L_37_SolveSudoku中调用
        /// </summary>
        private bool Recursive(char[][] board, int hasNumCount, int i, int j)
        {
            //81个数字代表已经填满了 直接返回结果
            if (hasNumCount == 81)
            {
                boardAllres = board;
                return true;
            }
            for (; i < board.Length; i++)
            {
                for (j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        //查出该行对应的所有未使用的数字 一次遍历填入
                        List<int> liRes = liRow[i].Where(e => e.Value == false).Select(e => e.Key).ToList();
                        foreach (var item in liRes)
                        {
                            //判读位于那个格子 
                            int count = (i / 3) * 3 + j / 3;
                            if (liCol[j][item] == false && liBox[count][item] == false && liRow[i][item] == false)
                            {
                                //总数+1 对应的位置赋值为true
                                hasNumCount++;
                                liRow[i][item] = true;
                                liCol[j][item] = true;
                                liBox[count][item] = true;
                                //之所以加48为了将数字转为char类型存进去
                                board[i][j] = (char)(item + 48);
                                //递归 存在不符合就返回 结果为true只有一种情况 那就是已经完成了
                                if (Recursive(board, hasNumCount, i, 0))
                                {
                                    return true;
                                }
                                //不符合 将操作撤回到之前 
                                hasNumCount--;
                                board[i][j] = '.';
                                liRow[i][item] = false;
                                liCol[j][item] = false;
                                liBox[count][item] = false;
                            }
                        }
                        return false;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 重载二分查找，于L_33_SearchRotatesortarray中调用
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int Binarysearch(int[] nums, int target, int start, int end)
        {
            if (start > end) return -1;
            int mid = (start + end) / 2;
            if (nums[mid] == target) return mid;
            if (nums[mid] > target) end = mid - 1; else start = mid + 1;
            return Binarysearch(nums, target, start, end);
        }
        /// <summary>
        /// 于F3方法内部调用
        /// </summary>
        private ulong[,] MatirxPower(ulong[,] a, int n)
        {
            if (n == 1) { return a; }
            else if (n == 2) { return MatirxMultiplication(a, a); }
            else if (n % 2 == 0)
            {
                ulong[,] temp = MatirxPower(a, n / 2);
                return MatirxMultiplication(temp, temp);
            }
            else
            {
                ulong[,] temp = MatirxPower(a, n / 2);
                return MatirxMultiplication(MatirxMultiplication(temp, temp), a);
            }
        }
        /// <summary>
        /// 于MatirxPower方法内部调用
        /// </summary>
        private ulong[,] MatirxMultiplication(ulong[,] a, ulong[,] b)
        {
            ulong[,] c = new ulong[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }
        /// <summary>
        /// 于堆排序中引用，用于创建最大堆
        /// </summary>
        private void buildMaxHeap(int[] a, int heapSize)
        {
            int parser = (int)Math.Floor((double)((heapSize + 1) / 2 - 1));
            for (int i = parser; i >= 0; i--)
            {
                adjustHeap(a, i, heapSize);
            }
        }
        /// <summary>
        /// 为需要排序的需俩种逐个添加参数，并判断左右堆与父级堆的参数大小
        /// </summary>
        private void adjustHeap(int[] a, int i, int heapSize)
        {
            var maxIndex = i;
            var Left = 2 * i + 1;
            var Right = 2 * (i + 1);
            if (Left <= heapSize && a[i] < a[Left])
            {
                maxIndex = Left;
            }
            if (Right <= heapSize && a[maxIndex] < a[Right])
            {
                maxIndex = Right;
            }
            if (maxIndex != i)
            {
                Swap(ref a[maxIndex], ref a[i]);
            }
        }
        /// <summary>
        /// 于Quicksort方法引用，
        /// </summary>
        private int partition(int[] a, int start, int end)
        {
            Random R = new Random();
            int pivot = (int)(start + R.Next(1) * (end - start + 1));
            int smallIndex = start - 1;
            Swap(ref a[pivot], ref a[end]);
            for (int i = start; i <= end; i++)
            {
                if (a[i] <= a[end])
                {
                    smallIndex++;
                    if (i > smallIndex)
                    {
                        Swap(ref a[i], ref a[smallIndex]);
                    }
                }
            }
            return smallIndex;
        }
        /// <summary>
        /// 归并排序中引用
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            for (int index = 0, i = 0, j = 0; index < result.Length; index++)
            {
                if (i >= left.Length)
                {
                    result[index] = right[j++];
                }
                else if (j >= right.Length)
                {
                    result[index] = left[i++];
                }
                else if (left[i] > right[j])
                {
                    result[index] = right[j++];
                }
                else
                {
                    result[index] = left[i++];
                }
            }
            // Console.WriteLine ("归并排序");
            return result;
        }
        /// <summary>
        /// 于L_28_FindNeedleFromhaystack方法中调用，KMP算法本体
        /// </summary>
        private int KMP(string haystack, string needle)
        {
            int[] next = GetNext(needle);
            int i = 0;
            int j = 0;
            while (i < haystack.Length)
            {
                if (haystack[i] == needle[j])
                {
                    j++;
                    i++;
                }
                if (j == needle.Length)
                {
                    return i - j;
                }
                else if (i < haystack.Length && haystack[i] != needle[j])
                {
                    if (j != 0)
                        j = next[j - 1];
                    else
                        i++;
                }

            }
            return -1;
        }
        /// <summary>
        /// 于KMP方法中调用，根据传入字符串获取数组下一元素值
        /// </summary>
        private int[] GetNext(string str)
        {
            int[] next = new int[str.Length];
            next[0] = 0;
            int i = 1;
            int j = 0;
            while (i < str.Length)
            {
                if (str[i] == str[j])
                {
                    j++;
                    next[i] = j;
                    i++;
                }
                else
                {
                    if (j == 0)
                    {
                        next[i] = 0;
                        i++;
                    }
                    else
                    {
                        j = next[j - 1];
                    }
                }
            }
            return next;
        }
        /// <summary>
        /// 于L_29_DivideTwonumbers方法中调用
        /// </summary>
        /// <param name="y">负数</param>
        /// <param name="z">正数</param>
        /// <param name="x">负数</param>
        /// <returns>判断 z * y >= x 是否成立</returns>
        private bool quickAdd(int y, int z, int x)
        {
            int result = 0, add = y;
            while (z != 0)
            {
                if ((z & 1) != 0)
                {
                    // 需要保证 result + add >= x
                    if (result < x - add)
                    {
                        return false;
                    }
                    result += add;
                }
                if (z != 1)
                {
                    // 需要保证 add + add >= x
                    if (add < x - add)
                    {
                        return false;
                    }
                    add += add;
                }
                // 不能使用除法
                z >>= 1;
            }
            return true;
        }

    }
}