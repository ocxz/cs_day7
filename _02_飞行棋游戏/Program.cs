using System;

namespace _02_飞行棋游戏
{
    class Program
    {

        public static int[] _Maps = new int[100];  // 地图数组 用静态字段模拟全局变量
        public static int[] _PlayerPos = new int[2];  // 两个玩家的坐标 用静态字段模拟全局变量
        public static string _playerOneName = "";
        public static string _playerTwoName = "";
        public static int _turn = 1;      // 记录轮到谁接下来操作
        public static int _winner = 0;     // 0都还没赢，1玩家一赢了，2玩家二赢了
        public static bool _playerOneTurn = true;
        public static string playerOne = "程";
        public static string playerTwo = "邓";
        static void Main(string[] args)
        {
            if (StartGameOrNot())
            {
                InputPlayerName();
                InitailMap();
                LaunchFrame();
                Console.ReadKey();
            }
            else
            {
                Console.ReadKey();
            }
        }


        /// <summary>
        /// 画游戏头
        /// </summary>
        public static void GameShow()
        {
            //Console.BackgroundColor = ConsoleColor.Blue;   // 背景色
            Console.ForegroundColor = ConsoleColor.Yellow;   // 前景色 字体颜色
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****.Net基础学习之飞行棋****");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*****************************");
        }

        /// <summary>
        /// 用户输入，是否开始游戏
        /// </summary>
        /// <returns>返回是否开始游戏</returns>
        public static bool StartGameOrNot()
        {
            GameShow();   // 画游戏头
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("       选择是否开始游戏     ");
            while (true)
            {
                Console.Write("请选择是否开始游戏 yes/no：");
                string answer = Console.ReadLine();
                if (answer == "yes" || answer == "y")
                {
                    return true;
                }
                else if (answer == "no" || answer == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("选择输入有误，请重新输入");
                }
            }
        }

        /// <summary>
        /// 提示用户输入个人信息
        /// </summary>
        public static void InputPlayerName()
        {
            Console.Clear();        // 清屏
            GameShow();   // 画游戏头
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("请输入玩家个人信息\n");

            Console.Write("请输入玩家A的名字：");
            _playerOneName = Console.ReadLine();

            while (true)
            {
                Console.Write("请输入玩家B的名字：");
                _playerTwoName = Console.ReadLine();

                if (SetPlayerName(_playerOneName, _playerTwoName, out playerOne, out playerTwo))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("玩家二名字输入错误，请重新输入");
                }
            }

        }

        /// <summary>
        /// 开始游戏
        /// </summary>
        public static void StartGame()
        {
            Console.Clear();
            GameShow();   // 画游戏头
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  开始游戏 \n");
            Console.WriteLine("玩家A：{0}--->{1}", _playerOneName, playerOne);
            Console.WriteLine("玩家B：{0}--->{1}", _playerTwoName, playerTwo);
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("游戏说明：");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("幸运转盘 ⊙  ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("地雷 ☆  ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("暂停 ▲  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("传送门 卐");
            Console.WriteLine("\n");
        }

        /// <summary>
        /// 启动游戏窗口，需要时常刷新
        /// </summary>
        public static void LaunchFrame()
        {
            Console.Clear();    // 清理窗口
            StartGame();      // 开始游戏
            DrawMap();    // 画地图
        }


        /// <summary>
        /// 初始化地图
        /// </summary>
        public static void InitailMap()
        {
            // 遍历特殊数组，填充到地图数组中
            // maps：特殊数组
            // value：填充的值
            void FillMaps(int[] maps, int value)
            {
                for (int i = 0; i < maps.Length; i++)   // 循环特殊数组
                {
                    _Maps[maps[i]] = value;   // 填充值
                }
            }
            int[] luckturn = { 6, 23, 40, 55, 69, 83 };   // 幸运轮盘  ✿
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };   // 地雷☆
            int[] pause = { 9, 27, 60, 93 };   // 暂停 ▶
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };   // 传送门 卐

            // 将所有特殊数组填充到地图中，此时_Maps有五个类型的值：0、1、2、3、4分别代表不同类别
            FillMaps(luckturn, 1);
            FillMaps(landMine, 2);
            FillMaps(pause, 3);
            FillMaps(timeTunnel, 4);

            // 将玩家一（5）、玩家二（6）加入到地图中
            for (int i = 0; i < _PlayerPos.Length; i++)
            {
                _PlayerPos[i] = _PlayerPos[i] < 0 ? 0 : _PlayerPos[i];   // 如果玩家的坐标小于0则置为0
                _Maps[_PlayerPos[i]] = 5 + i;    // 5代表玩家一、6代表玩家二
            }
        }

        /// <summary>
        /// 根据画值来画物件0-->□ 1-->⊙ ☆ ▲ 卐 玩家一 玩家二
        /// </summary>
        /// <param name="drawKey">画值</param>
        public static void DrawObject(int drawKey)
        {
            // 画玩家
            void DrawPlayer(int key)
            {
                if (_PlayerPos[0] == _PlayerPos[1])   // 玩家和玩家二重合 <>表示两个玩家
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("<>");
                }
                else   // 不重合，根据key画 
                {
                    switch (key)
                    {
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(playerOne);
                            break;
                        case 6:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(playerTwo);
                            break;
                    }
                }
            }

            // 根据画值选择画的对象
            switch (drawKey)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("□");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("⊙");
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("☆");
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("▲");
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("卐");
                    break;
                default:    // 5、6 画玩家
                    DrawPlayer(drawKey);
                    break;
            }
        }

        /// <summary>
        /// 画地图
        /// </summary>
        public static void DrawMap()
        {
            // 画游戏图的开始 choice控制画头画尾
            // 如果choice大于等于0画头
            // 如果choice小于等于0画尾
            void DrawStartOrEnd(int choice)
            {
                if (choice >= 0)   // 如果choice大于等于0画头
                {
                    if (_Maps[0] == 0)   // 没人占头
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("始");
                    }
                    else   // 有人了，那就画玩家
                    {
                        DrawObject(_Maps[0]);
                    }
                }
                else   // 如果choice小于等于0画尾
                {
                    if (_Maps[99] == 0)    // 没人占尾
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("终");
                    }
                    else    // 有人了，那就画玩家
                    {
                        DrawObject(_Maps[99]);
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }

            }

            // 画空格
            // SpaceCount连续空格数量
            // spaceKind空格种类 大于等于0 为英文半角空格 小于0为英文全角空格
            string DrawSpace(int SpaceCount, int spaceKind)
            {
                string space = spaceKind >= 0 ? " " : "　";   // 用来存储空格
                string result = ""; // 用来存储结果
                for (int i = 0; i < SpaceCount; i++)
                {
                    result += space;
                }
                Console.Write(result);
                return result;
            }

            // 画头
            DrawStartOrEnd(1);
            // 从第二个开始画 第一个已经画好了  最后一个也不画 由画尾的方法画
            for (int i = 1; i < 99; i++)
            {
                #region 35-37特殊换行
                if (i == 35 || i == 70)
                {
                    Console.WriteLine();  // 换行
                }
                #endregion

                if (i >= 30 && i <= 34)   // 画左边为空的几行
                {
                    Console.WriteLine();  // 换行
                    DrawSpace(29, -1);   // 用英文全角画29个空格
                    DrawObject(_Maps[i]);
                }
                else if (i >= 35 && i <= 64)   // 中间倒着的一行
                {
                    DrawObject(_Maps[99 - i]);
                }
                else if (i >= 65 && i <= 69)   // 画右边为空的几行
                {
                    Console.WriteLine();  // 换行
                    DrawObject(_Maps[i]);
                    DrawSpace(29, -1);   // 用英文全角画29个空格
                }
                else
                {
                    DrawObject(_Maps[i]);   // 画正常的
                }
            }

            // 画尾
            DrawStartOrEnd(-1);
        }

        /// <summary>
        /// 设置游戏名（简称）
        /// </summary>
        /// <param name="playerOneName">第一个玩家的名字</param>
        /// <param name="playerTwoName">第二个玩家的名字</param>
        /// <param name="playerOne">多余返回的第一个玩家游戏名</param>
        /// <param name="playerTwo">多余返回的第二个玩家游戏名</param>
        /// <returns>返回是否设置成功</returns>
        public static bool SetPlayerName(string playerOneName, string playerTwoName, out string playerOne, out string playerTwo)
        {

            // 如果名字第一个字不同，则取第一个字 返回设置成功
            if (playerOneName.Substring(0, 1) != playerTwoName.Substring(0, 1))
            {
                playerOne = playerOneName.Substring(0, 1);
                playerTwo = playerTwoName.Substring(0, 1);
                return true;   // 返回设置成功
            }
            else   // 如果名字第一个字相同，最后一个字不同，则取最后一个 返回设置成功
            {
                playerOne = playerOneName.Substring(playerOneName.Length - 1, 1);
                playerTwo = playerTwoName.Substring(playerTwoName.Length - 1, 1);
                return playerOne != playerTwo;
            }
        }

        public static void PlayGame()
        {

            Random r = new Random();
            RoPaSc(r);    // 石头剪刀布判断谁先手            
            while (_winner == 0)    // 都还没赢
            {
                LaunchFrame();   // 重置窗口

            }

        }


        /// <summary>
        /// 石头剪刀布，设置谁先手 1 石头 2 剪刀  3 布
        /// </summary>
        public static void RoPaSc(Random r)
        {
            // 赢了的结果值
            void Win(string wn, int wr, string fn, int fr, string[] strs)
            {
                Console.WriteLine("{0}出了{1}，{2}出了{3}  {4}赢了  {5}先手。（请按任意键进入下一步）",
    wn, strs[wr], fn, strs[fr], wn, wn);
                Console.ReadKey();
            }

            string[] rules = { "石头", "剪刀", "布" };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n谁先手？按任意键进行石头剪刀布");
            Console.ReadKey();

            while (true)
            {
                int rOne = r.Next(0, 3);
                int rTow = r.Next(0, 3);
                if (rOne == rTow)    // 平局
                {
                    Console.WriteLine("{0}出了{1}，{2}也出了{3}  平局（请按任意键继续石头剪刀布）",
                        playerOne, rules[rOne], playerTwo, rules[rTow]);
                    Console.ReadKey();
                    continue;   // 结束本次循环，进入下一轮
                }

                if (rOne == 0)    // 玩家一出了石头
                {
                    // 判断第二个是不是出来剪刀，如果是则_turn=1，否则_turn=2
                    _turn = rTow == 1 ? 1 : 2;
                    if (_turn == 1)    // 玩家一赢了
                    {
                        Win(playerOne, rOne, playerTwo, rTow, rules);
                        return;
                    }
                    else
                    {
                        Win(playerTwo, rTow, playerOne, rOne, rules);
                        return;
                    }
                }
                else if (rOne == 1)   // 玩家一出了剪刀
                {
                    // 判断第二个出的是不是 布 出布玩家一赢
                    _turn = rTow == 2 ? 1 : 2;
                    if (_turn == 1)    // 玩家一赢了
                    {
                        Win(playerOne, rOne, playerTwo, rTow, rules);
                        return;
                    }
                    else
                    {
                        Win(playerTwo, rTow, playerOne, rOne, rules);
                        return;
                    }
                }
                else     // 玩家一出来布 
                {
                    // 判断第二个出的是不是石头 如果是 则赢
                    _turn = rTow == 0 ? 1 : 2;

                    if (_turn == 1)    // 玩家一赢了
                    {
                        Win(playerOne, rOne, playerTwo, rTow, rules);
                        return;
                    }
                    else
                    {
                        Win(playerTwo, rTow, playerOne, rOne, rules);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 扔色子，1-6
        /// </summary>
        public static void ThrowASieve()
        {
            if (_turn == 1)   // 轮到玩家一扔色子了
            {
                Console.WriteLine("现在轮到{0}扔色子了，请按任意键，开始扔色子", playerOne);
            }
        }

        /// <summary>
        /// 改变后调用的方法（参数：改变者 1玩家一，2玩家二）
        /// </summary>
        /// <param name="playerKey">改变者</param>
        /// <param name="changeStep">改变步数</param>
        public static void ChangeStep(int playerKey, int changeStep)
        {
            _Maps[_PlayerPos[playerKey - 1]] = 0;     // 改变前，将原来的位置重置为方块
            _PlayerPos[playerKey - 1] += changeStep;   // 改变后的位置
            _PlayerPos[playerKey - 1] = _PlayerPos[playerKey - 1]<0?0:_PlayerPos[playerKey - 1];  // 小于0则置为0
            _PlayerPos[playerKey - 1] = _PlayerPos[playerKey - 1]>99?99:_PlayerPos[playerKey - 1];  // 小于99则置为99

            if (changeStep < 0)   // 往后退
            {
                Console.Write("退了{0}步", -changeStep);
            }
            else
            {
                Console.Write("进了{0}步", changeStep);
            }

            if(_PlayerPos[playerKey - 1] == 0)
            {
                Console.Write(",回到起点");
            }
            else if(_PlayerPos[playerKey - 1] == 99)
            {
                _winner = playerKey;
                Console.Write(",到达终点");
            }
        }
    }
}
