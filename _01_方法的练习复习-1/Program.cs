using System;

namespace _01_方法的练习复习_1
{
    class Program
    {
        public static double _PI = 3.14;
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
             *     6、写一个方法，用来计算圆的面积和周长 面积是：PI*R*R   周长是2*PI*R  R为double类型
             *     7、计算任意多个数间的最大值（利用params)
             *     8、通过冒泡排序对整数数组进行排序（加一个参数，为正升序，为负降序）
             *     9、将一个字符串数组输出为|分割形式（用方法来实现）
             *  
             */

            #region 题目一 调用方法实现获得字符串数组中的最长字符串
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

            //string[] strs = { "中国", "美国", "巴西", "澳大利亚", "加拿大" };
            //Console.WriteLine(ArrayToString(ReverseArray(strs), null));
            //Console.ReadLine();

            #endregion

            #region 题目六 写一个方法，用来计算圆的面积和周长 面积是：PI*R*R   周长是2*PI*R  R为double类型

            //double r = GetDouble("圆的半径");
            //double perimeter, area;
            //GetPerimeArea(r, out perimeter, out area);
            //perimeter = double.Parse(perimeter.ToString("0.00"));
            //area = double.Parse(area.ToString("0.00"));
            //Console.WriteLine("半径为{0}的圆的周长为{1}，面积为{2}", r, perimeter, area);
            //Console.ReadKey();

            #endregion

            #region 题目七 计算任意多个数间的最大值（利用params)

            //double max = KeepDecimal(GetMaxValue(10, 25, 3.15, 78.56, 59.3, 82.5,98.568), 2);
            //Console.WriteLine("最大值为（保留两位小数）：{0}", max);
            //Console.ReadKey();

            #endregion

            #region 题目八 通过冒泡排序对整数数组进行排序（加一个参数，为正升序，为负降序）

            //int[] nums = { 1, 3, 5, 7, 90, 2, 4, 6, 8, 10 };
            //Console.WriteLine("要排序的数组：{0}", ArrayToString(nums));
            //Console.WriteLine("排序后的数组：{0}", ArrayToString(ArraySort(nums,1)));
            //Console.ReadKey();


            #endregion

            #region 题目九 将一个字符串数组输出为|分割形式（用方法来实现）

            //string[] names = { "梅西", "卡卡", "郑大世" };
            //Console.WriteLine("原姓名数组：{0}",ArrayToString(names));
            //Console.WriteLine("形式输出后数组：{0}", ArrayToString(names,"|"));
            //Console.ReadKey();

            int[] nums = { 1,6,3,8,9};
            Console.WriteLine("原姓名数组：{0}", ArrayToString(nums));
            Console.WriteLine("形式输出后数组：{0}", ArrayToString(nums, " | "));
            Console.ReadKey();

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

        /// <summary>
        /// 获得数组内所有值的平均数
        /// </summary>
        /// <param name="nums">要求平均数的数组</param>
        /// <returns>返回平均数</returns>
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
        /// 提示用户输入数字，将输入的数字转化为double类型
        /// </summary>
        /// <returns>返回用户输入的数</returns>
        public static double GetDouble()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("请输入一个数");
                    return double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("输入的不是一个数，请重新输入");
                }
            }
        }

        /// <summary>
        ///  根据用户输入的名字，定值提示，提示用户输入数字，将输入的数字转化为double类型
        /// </summary>
        /// <param name="numName">用户输入的名字</param>
        /// <returns>返回的输入数字</returns>
        public static double GetDouble(string numName)
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
                    return double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("{0}输入不正确，请重新输入", numName);
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
        /// 字符串数组的反转
        /// </summary>
        /// <param name="strs">要反转的字符串</param>
        public static int[] ReverseArray(int[] nums)
        {
            for (int i = 0; i < nums.Length / 2; i++)
            {
                nums[i] = nums[i] - nums[nums.Length - 1 - i];
                nums[nums.Length - 1 - i] = nums[i] + nums[nums.Length - 1 - i];
                nums[i] = nums[nums.Length - 1 - i]- nums[i];
            }
            return nums;
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
        /// 不带分隔符（默认空格隔开的）数组转换字符串
        /// </summary>
        /// <param name="strs">要转换的数组</param>
        /// <returns>转换后的字符串</returns>
        public static string ArrayToString(int[] nums)
        {
            string str = "";
            for (int i = 0; i < nums.Length - 1; i++)
            {
                str += nums[i] + " ";
            }
            str += nums[nums.Length - 1];
            return str;
        }

        /// <summary>
        /// 带有数组转换字符串
        /// </summary>
        /// <param name="strs">要转换的数组</param>
        /// <param name="separator">分隔符</param>
        /// <returns>转换后的字符串</returns>
        public static string ArrayToString(string[] strs, string separator)
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
            str += strs[strs.Length - 1];
            return str;
        }

        /// <summary>
        /// 带有数组转换字符串
        /// </summary>
        /// <param name="strs">要转换的数组</param>
        /// <param name="separator">分隔符</param>
        /// <returns>转换后的字符串</returns>
        public static string ArrayToString(int[] nums, string separator)
        {
            if (separator == null)
            {
                separator = "";
            }

            string str = "";
            for (int i = 0; i < nums.Length - 1; i++)
            {
                str += nums[i] + separator;
            }
            str += nums[nums.Length - 1];
            return str;
        }

        /// <summary>
        /// 计算圆的周长和面积，并返回
        /// </summary>
        /// <param name="r">圆的半径</param>
        /// <param name="perimeter">返回的周长</param>
        /// <param name="area">返回的面积</param>
        public static void GetPerimeArea(double r, out double perimeter, out double area)
        {
            perimeter = 2 * _PI * r;
            area = _PI * r * r;
        }

        /// <summary>
        /// 获得参数列表中的最大值
        /// </summary>
        /// <param name="nums">参数列表</param>
        /// <returns>返回的最大值</returns>
        public static double GetMaxValue(params double[] nums)
        {
            double maxValue = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                maxValue = maxValue > nums[i] ? maxValue : nums[i];
            }
            return maxValue;
        }

        /// <summary>
        /// 保留小数位，如果保留小数位小于等于0，则不保留小数  符合四舍五入规则
        /// </summary>
        /// <param name="num">要保留小数的值</param>
        /// <param name="keeps">保留的位数</param>
        /// <returns>返回保留后的数</returns>
        public static double KeepDecimal(double num, int keeps)
        {
            string str = "0.";
            if (keeps <= 0)   // 如果保留的位数小于等于0，则
            {
                str = "0";
            }
            else
            {
                for (int i = 0; i < keeps; i++)
                {
                    str += "0";
                }
            }
            num = double.Parse(num.ToString(str));
            return num;
        }

        /// <summary>
        /// 数组的冒泡排序
        /// </summary>
        /// <param name="nums">要排序的数组</param>
        /// <returns>排好序的数组</returns>
        public static int[] ArraySort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])   // 升序排序 如果前一个大于后一个 则交换
                    {
                        // 不借助第三方变量进行数据交换
                        nums[i] = nums[i] - nums[j];
                        nums[j] = nums[i] + nums[j];
                        nums[i] = nums[j] - nums[i];
                    }

                }
            }
            return nums;
        }

        /// <summary>
        /// 对数组进行排序（rule为0或者正数升序，为负数降序）
        /// </summary>
        /// <param name="nums">要排序的数组</param>
        /// <param name="rule">排序的规则</param>
        /// <returns>返回排序后的数组</returns>
        public static int[] ArraySort(int[] nums, int rule)
        {
            // 如果规则大于等于0，则进行升序排序
            if (rule >= 0)
            {
                return ArraySort(nums);
            }
            else  // 如果规则小于0，则进行降序排序
            {
                return ReverseArray(ArraySort(nums));
            }
        }
    }
}
