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

        public string PX_XZ()
        {
            return _outSeq.ToString();
        }

        public string PX_MP()
        {
            return _outSeq.ToString();
        }

        public string PX_CR()
        {
            return _outSeq.ToString();
        }

        #endregion
    }
}
