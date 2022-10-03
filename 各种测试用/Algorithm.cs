using System.Text;
namespace Yan
{
    /// <summary>
    /// 链表类型，模拟指针
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Algorithm
    {
        //NOTE 关键字文本：TODO HACK NOTE INFO TAG XXX BUG FIXME
        private int len; //全局变量
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
        char[][] boardAllres = null;

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
            ListNode prenode = new ListNode(0);
            ListNode lastnode = prenode;
            while (l1 != null || l2 != null || val != 0)
            {
                val = val + (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
                lastnode.next = new ListNode(val % 10);
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
            ListNode res = new ListNode(0); int i = 0;
            ListNode helpnode = res;
            while (i < help.Count())
            {
                ListNode node = new ListNode(help[i]); i++;
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
            ListNode newHead = new ListNode(-100);
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
        public void L_37_SolveSudoku(char[][] board)
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
        if(x == 0) {
            return 0;
        }
        if(n == 0) {
            return 1;
        }
        long b = n;
        if(b < 0) {
            b = -b;
            x = 1.0/x;
        }

        double ans = 1.0;
        while(b > 0) {
            if(b % 2 == 1) ans *= x;
            x *= x;
            b = b / 2;
        }
        return ans; 
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
                    res = new ListNode(val);
                    last = res;
                }
                else
                {
                    last.next = new ListNode(val);
                    last = last.next;
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