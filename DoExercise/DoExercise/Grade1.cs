using System;
using System.Collections.Generic;
using System.Text;

namespace DoExercise
{
    public class Grade1 : AGrade
    {
        /// <summary>
        /// 动态规划：有多个开始条件，且具有一定的公式
        /// </summary>
        /// <returns></returns>
        public override AGrade Init()
        {
            _dicFunctions.Add("斐波那契数列-递归方式-初级版本", FBNQ_DG_1);
            _dicFunctions.Add("斐波那契数列-递归方式-时间优化（空间变大）", FBNQ_DG_2);
            _dicFunctions.Add("斐波那契数列-动态规划方式", FBNQ_DTGH);
            _dicFunctions.Add("排序-选择排序", PX_XZ);
            _dicFunctions.Add("排序-冒泡排序", PX_MP);
            _dicFunctions.Add("排序-插入排序", PX_CR);
            // _dicFunctions.Add("斐波那契数列-动态规划", FBNQ_DTGH);
            return this;
        }

        public override void ExcuteToOut()
        {
            foreach (var item in _dicFunctions)
            {
                _outSeq.Clear();
                Console.WriteLine($"====={item.Key}=====");
                Console.WriteLine($"{item.Value.Invoke()}");
            }
        }


        #region 斐波那契数列  - 后一个数是前两个数的和

        private string FBNQ_DG_1()
        {
            int n = 10;
            _outSeq.AppendLine($"n={n}");
            fbnq_dg_1(n);
            return _outSeq.ToString();
        }

        private int fbnq_dg_1(int n)
        {
            if (n <= 2)
            {
                _outSeq.Append($"{n},");
                return n;
            }

            var result = fbnq_dg_1(n - 2) + fbnq_dg_1(n - 1);
            _outSeq.Append($"{result},");
            return result;
        }


        private string FBNQ_DG_2()
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int n = 10;
            _outSeq.AppendLine($"n={n}");
            fbnq_dg_2(n, map);
            return _outSeq.ToString();
        }

        private int fbnq_dg_2(int n, Dictionary<int, int> map)
        {
            ///这一步省去了已经计算过的结果，如（f(7)只需要计算一次就行）
            if (map.ContainsKey(n))
            {
                return map[n];
            }

            if (n <= 2)
            {
                _outSeq.Append($"{n},");
                map.Add(n, n);
                return n;
            }

            var result = fbnq_dg_2(n - 2, map) + fbnq_dg_2(n - 1, map);
            map.Add(n, result);
            _outSeq.Append($"{result},");
            return result;
        }


        /// <summary>
        /// 动态规划：一个问题多阶段的计划，并不是动态的变化。一般是基于能写成特定公式的问题
        /// 找到问题的规律然后得到结果
        /// </summary>
        /// <returns></returns>
        private string FBNQ_DTGH()
        {
            int n = 10;

            int number1 = 1;
            int number2 = 2;
            _outSeq.Append($"1,");
            _outSeq.Append($"2,");
            for (int i = 1; i <= n - 2; i++)
            {
                if ((i & 1) == 1)
                {
                    number1 = number1 + number2;
                    _outSeq.Append($"{number1},");
                }
                else
                {
                    number2 = number1 + number2;
                    _outSeq.Append($"{number2},");
                }
            }

            return _outSeq.ToString();
        }

        #endregion

        #region 给一组整数，按照升序排序，使用选择排序，冒泡排序，插入排序或者任何 O(n2) 的排序算法。

        /// <summary>
        /// 选择排序（循环，每次找到后面最小的）
        /// 比冒泡好的地方在于：不是找到小的就交换，而是找到最小的才交换，其余都一样。
        /// </summary>
        /// <returns></returns>
        public string PX_XZ()
        {
            int cacTimes = 0;
            int exchangeTimes = 0;
            int[] px_numbers = {1, 5, 0, 3, 7, 2, 8, 100, 41};
            _outSeq.Append(ToString(px_numbers) + "=>");

            int minIndex = 0;
            for (int i = 0; i < px_numbers.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < px_numbers.Length; j++)
                {
                    cacTimes++;
                    if (px_numbers[j] < px_numbers[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    exchangeTimes++;
                    int temp = px_numbers[minIndex];
                    px_numbers[minIndex] = px_numbers[i];
                    px_numbers[i] = temp;
                }
            }
            //最终结果从小到大

            _outSeq.Append(ToString(px_numbers));
            _outSeq.Append($" 数组长度：{px_numbers.Length} 遍历次数：{cacTimes} 交换次数：{exchangeTimes}");
            return _outSeq.ToString();
            return _outSeq.ToString();
        }

        /// <summary>
        /// 冒泡排序（循环，每次找到最小的那个）
        /// 从第一个元素，对比它后面所有的元素，后面更小的就调换，遍历完毕后，最前面的就是最小的，然后接着从第二个元素...的循环
        /// </summary>
        /// <returns></returns>
        public string PX_MP()
        {
            int cacTimes = 0;
            int exchangeTimes = 0;
            int[] px_numbers = {1, 5, 0, 3, 7, 2, 8, 100, 41};
            _outSeq.Append(ToString(px_numbers) + "=>");
            int temp = 0;
            for (int i = 0; i < px_numbers.Length; i++)
            {
                //这个的每次遍历都让后面最小的移动到了前面
                for (int j = i + 1; j < px_numbers.Length; j++)
                {
                    cacTimes++;
                    //后一个比前一个大就交换
                    if (px_numbers[j] < px_numbers[i])
                    {
                        exchangeTimes++;
                        temp = px_numbers[j];
                        px_numbers[j] = px_numbers[i];
                        px_numbers[i] = temp;
                    }
                }
            }
            //最终结果从小到大

            _outSeq.Append(ToString(px_numbers));
            _outSeq.Append($" 数组长度：{px_numbers.Length} 遍历次数：{cacTimes} 交换次数：{exchangeTimes}");
            return _outSeq.ToString();
        }

        /// <summary>
        /// 插入排序（抽一个空着，后移）
        /// 核心：
        /// 1.抽出i位置的数（A），
        /// 2.判断我所在位置前面一个是否比自己小，
        /// 3.前面数大的话向后移（并不插入），比自己小的停止判断插入这个(A)，特别情况，A是最小的，跳出了循环
        /// 循环123
        /// 优势：本就相对有序的排序速度更快
        /// </summary>
        /// <returns></returns>
        public string PX_CR()
        {
            int cacTimes = 0, exchangeTimes = 0;
            int[] px_numbers = {1, 5, 0, 3, 7, 2, 8, 100, 41};
            _outSeq.Append(ToString(px_numbers) + "=>");

            int cur = 0;
            for (int i = 1; i < px_numbers.Length; i++)
            {
                cur = px_numbers[i];
                //i位置做空取出,与前面的那个对比，再前面对比，大的数向后移动
                int j;
                for (j = i - 1; j >= 0; j--)
                {
                    cacTimes++;
                    if (cur < px_numbers[j])
                    {
                        px_numbers[j + 1] = px_numbers[j];
                    }
                    else
                    {
                        exchangeTimes++;
                        px_numbers[j + 1] = cur;
                        break;
                    }
                }

                //说明到了最前面
                if (j == -1)
                {
                    exchangeTimes++;
                    px_numbers[0] = cur;
                }
            }

            _outSeq.Append(ToString(px_numbers));
            _outSeq.Append($" 数组长度：{px_numbers.Length} 遍历次数：{cacTimes} 交换次数：{exchangeTimes}");
            return _outSeq.ToString();
        }

        #endregion

        private string ToString<T>(T[] objs)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < objs.Length; i++)
            {
                sb.Append($"  {objs[i]}");
            }

            return sb.ToString();
        }
    }
}
