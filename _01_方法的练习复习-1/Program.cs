using System;

namespace _01_方法的练习复习_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *     题目：
             *     1、用方法实现 就字符串中中最长的字符串
             *     2、用方法实现，计算一个整型数组的平均值，保留两位有效数字
             *     难点：保留小数方法--->先转化为格式化字符串、在重新转为数字 如：
             *     double avg2 = double.Parse(3.465.ToString("0.00"));
             *     3、写一个方法，判断用户输入的数字是不是质数，输入不是数字泽要求用户重新输入
             *     4、接收输入并判断等级，显示出来 判断依据为等级={优 90-100 良 80-89）
             *     5、手写方法，将字符串数组反转
             * 
             * 
             * 
             */

            #region 题目一：调用方法实现获得字符串数组中的最长字符串
            //// 题目一：调用方法实现获得字符串数组中的最长字符串
            //string[] names = { "马龙", "迈克尔乔丹", "雷吉米勒", "蒂姆邓肯", "科比布莱恩特" };

            //Console.Write("名字：");
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.Write("{0} ", names[i]);
            //}
            //Console.Write("\n最长的名字是：{0}", GetLongestString(names));
            //Console.ReadKey(); 
            #endregion

            #region 题目二  用方法实现，计算一个整型数组的平均值，保留两位有效数字

            //int[] nums = { 1, 2, 7 };
            //double avg = GetAvg(nums);
            //// 保留两位效数 占位符和这个保留位数时都会四舍五入
            //avg = double.Parse(avg.ToString("0.00"));
            //double avg2 = double.Parse(3.465.ToString("0.00"));
            //Console.WriteLine(avg);
            //Console.WriteLine(avg2);
            //Console.ReadKey();

            #endregion

            #region 题目三 写一个方法，判断用户输入的数字是不是质数，输入不是数字则要求用户重新输入

            //while (true)
            //{
            //    Console.WriteLine("请输入一个数字");
            //    string str = Console.ReadLine();
            //    int num;
            //    bool isOk = int.TryParse(str, out num);
            //    if (isOk)
            //    {
            //        Console.WriteLine(IsPrime(num) ? "{0}是质数，请按任意键继续" : "{0}不是质数，请按任意键继续", num);
            //        Console.ReadKey();
            //    }
            //    else if (str == "Exit" || str == "exit")
            //    {
            //        Console.WriteLine("结束完成！");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("输入的不是一个数字，请重新输入");
            //    }    
            //}

            #endregion

            #region 题目四 接收输入并判断等级，显示出来 判断依据为等级={优 90-100 良 80-89）

            //int grade = GetNumber("成绩");
            //Console.WriteLine("你的成绩是{0}分，评级为{1}", grade, GetLevel(grade));
            //Console.ReadKey();

            #endregion

            #region 题目五 手写方法，将字符串数组反转

            string[] strs = { "中国", "美国", "巴西", "澳大利亚", "加拿大" };
            Console.WriteLine(ArrayToString(ReverseArray(strs)));
            Console.ReadLine();

            #endregion


        }

        /// <summary>
        /// 获取字符串数组中的最长字符串
        /// </summary>
        /// <param name="strs">字符串数组</param>
        /// <returns>返回的最长字符串</returns>
        public static string GetLongestString(string[] strs)
        {
            string maxString = strs[0];
            for (int i = 0; i < strs.Length; i++)
            {
                maxString = maxString.Length > strs[i].Length ? maxString : strs[i];
            }

            return maxString;
        }

        public static double GetAvg(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum * 1.0 / nums.Length;
        }

        /// <summary>
        /// 得到用户输入的一个数，如果用户输入的不是数字，则要求重新输入，直到输入的是数字为止
        /// </summary>
        /// <returns>转换后用户输入的数字</returns>
        public static int GetNumber()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("请输入一个数");
                    return int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("输入的不是一个数，请重新输入");
                }
            }
        }

        /// <summary>
        /// 用户指定输入的数字名，得到用户输入的一个数，如果用户输入的不是数字，则要求重新输入，直到输入的是数字为止
        /// </summary>
        /// <param name="numName">用户指定输入的数字名</param>
        /// <returns>返回转换后的数字</returns>
        public static int GetNumber(string numName)
        {
            if (numName == null || numName == "")
            {
                return GetNumber();
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("请输入{0}", numName);
                    return int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("{0}输入不正确，请重新输入", numName);
                }
            }
        }

        /// <summary>
        /// 用户定制输入信息以及错误提示信息，得到用户输入的一个数，如果用户输入的不是数字，则要求重新输入，直到输入的是数字为止
        /// </summary>
        /// <param name="inputMsg">输入信息</param>
        /// <param name="errMsg">错误提示信息</param>
        /// <returns>返回转换的值</returns>
        public static int GetNumber(string inputMsg, string errMsg)
        {
            if (inputMsg == null || inputMsg == "")
            {
                return GetNumber();
            }

            while (true)
            {
                try
                {
                    Console.WriteLine(inputMsg);
                    return int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(errMsg);
                }

            }
        }

        /// <summary>
        /// 给定一个整数，判断是不是一个质数
        /// </summary>
        /// <param name="num">要判断的整数</param>
        /// <returns>返回是不是质数</returns>
        public static bool IsPrime(int num)
        {
            if (num == 2)   // 可以被二整除且不等于二
            {
                return true;
            }
            else
            {
                if (num % 2 == 0 || num < 2)   // 能被二整除或小于二的都不是质数
                {
                    return false;
                }
                else
                {
                    // 给不能被2整除非质数准备的
                    for (int i = num; i <= (num + 1) / 2; i++)   // 不能被2整除的话，加一除二，只需要比较一半就行
                    {
                        if (num % i == 0)   // 在循环取余的时候，如果由任何一个可以整除，则不是质数，返回false，判断结束
                        {
                            return false;   // 给非质数准备的
                        }
                    }
                }
            }

            return true;   // 说明是质数，给不是2的质数准备的
        }

        /// <summary>
        /// 根据成绩获得评级
        /// </summary>
        /// <param name="grade">成绩</param>
        /// <returns>返回的评级</returns>
        public static string GetLevel(int grade)
        {
            switch (grade / 10)
            {
                case 10:
                case 9:
                    return "优";
                case 8:
                    return "良";
                case 7:
                    return "中";
                case 6:
                    return "差";
                default:
                    return "不及格";
            }
        }

        /// <summary>
        /// 字符串数组的反转
        /// </summary>
        /// <param name="strs">要反转的字符串</param>
        public static string[] ReverseArray(string[] strs)
        {
            for (int i = 0; i < strs.Length / 2; i++)
            {
                string temp = strs[i];
                strs[i] = strs[strs.Length - 1 - i];
                strs[strs.Length - 1 - i] = temp;
            }
            return strs;
        }

        /// <summary>
        /// 不带分隔符（默认空格隔开的）数组转换字符串
        /// </summary>
        /// <param name="strs">要转换的数组</param>
        /// <returns>转换后的字符串</returns>
        public static string ArrayToString(string[] strs)
        {
            string str = "";
            for (int i = 0; i < strs.Length - 1; i++)
            {
                str += strs[i] + " ";
            }
            str += strs[strs.Length - 1];
            return str;
        }

        /// <summary>
        /// 带有数组转换字符串
        /// </summary>
        /// <param name="strs">要转换的数组</param>
        /// <param name="separator">分隔符</param>
        /// <returns>转换后的字符串</returns>
        public static string ArrayToString(string strs, string separator)
        {
            if (separator == null)
            {
                separator = "";
            }

            string str = "";
            for (int i = 0; i < strs.Length - 1; i++)
            {
                str += strs[i] + separator;
            }
            str += strs[strs.Length];
            return str;
        }
    }
}
