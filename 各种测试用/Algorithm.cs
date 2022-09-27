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
        public ListNode(int val = 0, ListNode? next = null)
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
        public int[] bubbleSort(int[] a)
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
        public int[] selectionSort(int[] a)
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
        public int[] insertionSort(int[] a)
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
        public int[] lengthShellSort(int[] a)
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
        public int[] mergeSort(int[] a)
        {
            if (a.Length < 2) return a;
            int mid = a.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[a.Length - mid];
            left = Copy(a, 0, mid);
            right = Copy(a, mid, a.Length);
            return Merge(mergeSort(left), mergeSort(right));
        }
        /// <summary>
        /// 快速排序 平均时间复杂度：O(n log n) 空间复杂度：O(log n) 不占用额外内存 不稳定
        /// </summary>
        /// <param name="start">开始</param>
        /// <param name="end">结束(长度-1)</param>
        /// <returns></returns>
        public int[]? quickSort(int[] a, int start, int end)
        {
            if (a.Length < 1 || start < 0 || end >= a.Length || start > end) return null;
            int smallIndex = partition(a, start, end);
            if (smallIndex > start)
            {
                quickSort(a, start, smallIndex - 1);
            }
            if (smallIndex < end)
            {
                quickSort(a, smallIndex + 1, end);
            }
            Console.WriteLine("快速排序");
            return a;
        }
        /// <summary>
        /// 堆排序 平均时间复杂度：O(n log n) 空间复杂度：O(1) 不占用额外内存 不稳定
        /// </summary>
        public int[] heapSort(int[] a)
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
        public int[] countingSort(int[] a)
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
        public int[] radixSort(int[] ArrayToSort, int digit)
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
        public int[] bucketSort(int[] array, int bucketSize)
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
                insertionSort(insertion);
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
        public bool L_9_isPalindrome(int x)
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
        public String L_14_longestCommonPrefix(String[] strs)
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
            ListNode? second = head;
            ListNode? third = head.next;
            while (third != null && first != null && second != null)
            {
                ListNode node = second;
                node.next = third.next;
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
    }
}