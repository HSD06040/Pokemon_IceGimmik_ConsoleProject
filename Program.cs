namespace Project
{
    internal class Program
    {
        #region Value
        static bool gameOver;
        static bool isPlaying = false;

        static PlayerPos playerPos;

        static int[,,] maps;
        static int[,,] originalMaps;

        static int totalMoveCount = 0;
        static int moveCount = 0;
        static int stageCount = 0;
        static int[] stageMinMove;
        static int[] starMinMove;
        static int totalStarCount = 0;
        static int starCount = 0;
        #endregion


        struct PlayerPos
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            originalMaps = new int[,,]
            {
                {
                   // 1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16
            /*1*/    {1, 1, 1, 1, 1, 1, 1, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8},
            /*2*/    {1, 0, 0, 0, 1, 1, 1, 1, 8, 8, 8, 8, 8, 8, 8, 8, 8},
            /*3*/    {1, 3, 4, 4, 1, 1, 1, 1, 8, 8, 8, 8, 8, 8, 8, 8, 8},
            /*4*/    {1, 0, 0, 0, 4, 0, 0, 1, 1, 8, 8, 8, 8, 8, 8, 8, 8},
            /*5*/    {1, 1, 0, 0, 0, 0, 0, 1, 1, 8, 8, 8, 8, 8, 8, 8, 8},
            /*6*/    {1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 8, 8, 8, 8, 8, 8},
            /*7*/    {1, 1, 1, 1, 0, 0, 0, 0, 0, 2, 1, 8, 8, 8, 8, 8, 8},
            /*8*/    {8, 8, 8, 1, 0, 0, 0, 0, 0, 2, 1, 8, 8, 8, 8, 8, 8},
            /*9*/    {8, 8, 8, 1, 0, 0, 0, 0, 4, 2, 1, 8, 8, 8, 8, 8, 8},
            /*10*/   {8, 8, 8, 1, 1, 1, 1, 1, 1, 1, 1, 8, 8, 8, 8, 8, 8},
            /*11*/   {8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8},
            /*12*/   {8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8},
            /*13*/   {8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8},
            /*14*/   {8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8},
            /*15*/   {8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8}
                },
                {
                   // 1  2  3  4  8  6  7  8  9 10 11 12 13 14 18 16
            /*1*/    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8},
            /*2*/    {1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 8},
            /*3*/    {1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 8},
            /*4*/    {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 0, 0, 0, 1, 8},
            /*5*/    {1, 4, 1, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 8},
            /*6*/    {1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 8},
            /*7*/    {1, 0, 0, 0, 0, 1, 0, 4, 0, 0, 0, 0, 0, 0, 1, 1, 8},
            /*8*/    {1, 0, 0, 0, 0, 0, 0, 1, 0, 4, 0, 0, 0, 4, 2, 1, 8},
            /*9*/    {1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 2, 1, 8},
            /*10*/   {1, 0, 4, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 1, 1, 8},
            /*11*/   {1, 0, 0, 0, 0, 0, 4, 0, 1, 0, 0, 0, 0, 0, 0, 1, 8},
            /*12*/   {1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 4, 0, 0, 4, 1, 8},
            /*13*/   {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 8},
            /*14*/   {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1, 8},
            /*15*/   {8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 1, 1, 1, 8}
                },
                {
                   // 1  2  3  4  8  6  7  8  9 10 11 12 13 14 18 16
            /*1*/    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8},
            /*2*/    {1, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 8},
            /*3*/    {1, 0, 0, 1, 0, 4, 0, 0, 1, 0, 0, 0, 0, 0, 4, 1, 8},
            /*4*/    {1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 8},
            /*5*/    {1, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 0, 0, 1, 0, 1, 8},
            /*6*/    {1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 8},
            /*7*/    {1, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 1, 1, 8},
            /*8*/    {1, 0, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 8},
            /*9*/    {1, 1, 0, 0, 0, 0, 4, 0, 1, 0, 0, 1, 0, 0, 0, 1, 8},
            /*10*/   {1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 4, 0, 0, 1, 8},
            /*11*/   {1, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 1, 0, 1, 8},
            /*12*/   {1, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1, 1},
            /*13*/   {1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 4, 0, 0, 4, 0, 2, 1},
            /*14*/   {1, 3, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1},
            /*15*/   {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8}
                },
                {
                   // 1  2  3  4  8  6  7  8  9 10 11 12 13 14 18 16
            /*1*/    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8},
            /*2*/    {1, 3, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1, 0, 0, 0, 1, 8},
            /*3*/    {1, 0, 0, 0, 0, 0, 1, 4, 0, 0, 0, 0, 0, 1, 0, 1, 8},
            /*4*/    {1, 0, 1, 0, 0, 0, 4, 0, 1, 0, 1, 0, 4, 0, 0, 1, 8},
            /*5*/    {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 8},
            /*6*/    {1, 0, 4, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 4, 1, 8},
            /*7*/    {1, 1, 0, 4, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0, 0, 1, 8},
            /*8*/    {1, 0, 0, 0, 1, 0, 0, 0, 4, 0, 0, 1, 0, 1, 0, 1, 8},
            /*9*/    {1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 4, 0, 0, 0, 1, 8},
            /*10*/   {1, 0, 0, 1, 0, 0, 4, 0, 0, 0, 0, 0, 1, 0, 0, 1, 8},
            /*11*/   {1, 0, 0, 4, 0, 0, 0, 4, 1, 4, 0, 0, 0, 1, 0, 1, 1},
            /*12*/   {1, 0, 0, 4, 0, 1, 0, 4, 0, 0, 0, 0, 0, 0, 0, 2, 1},
            /*13*/   {1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 4, 1, 1},
            /*14*/   {1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 4, 1, 0, 0, 0, 1, 8},
            /*15*/   {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8}
                },
                {
                   // 1  2  3  4  8  6  7  8  9 10 11 12 13 14 18 16
            /*1*/    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8},
            /*2*/    {1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 4, 4, 4, 1, 8},
            /*3*/    {1, 4, 1, 4, 4, 1, 0, 4, 1, 4, 4, 4, 4, 1, 4, 1, 8},
            /*4*/    {1, 4, 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 8},
            /*5*/    {1, 4, 4, 4, 4, 4, 4, 1, 4, 4, 4, 1, 4, 4, 4, 1, 8},
            /*6*/    {1, 4, 4, 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 1, 8},
            /*7*/    {1, 4, 4, 4, 4, 4, 4, 4, 1, 4, 1, 4, 4, 4, 4, 1, 8},
            /*8*/    {1, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 4, 4, 1, 8},
            /*9*/    {1, 4, 4, 4, 4, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 8},
            /*10*/   {1, 4, 4, 4, 4, 4, 4, 4, 4, 1, 4, 4, 4, 1, 0, 1, 8},
            /*11*/   {1, 4, 4, 1, 4, 4, 4, 1, 4, 4, 4, 1, 4, 4, 4, 1, 8},
            /*12*/   {1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 1, 1},
            /*13*/   {1, 4, 4, 4, 1, 4, 4, 4, 4, 4, 1, 4, 4, 4, 4, 2, 1},
            /*14*/   {1, 4, 4, 4, 4, 4, 1, 4, 4, 4, 4, 4, 1, 4, 4, 1, 1},
            /*15*/   {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8}
                }
            };

            maps = (int[,,])originalMaps.Clone();

            PlayerPos[] spawnPos = new PlayerPos[]
            {
                new PlayerPos{ x= 1, y= 2 },
                new PlayerPos{ x= 14, y = 13},
                new PlayerPos{ x = 1, y = 13},
                new PlayerPos{ x= 1, y= 1},
                new PlayerPos{ x = 1, y = 13}
            };

            stageMinMove = new int[]
            {
                5,
                16,
                1,
                1,
                1
            };

            starMinMove = new int[]
            {
                8,
                1,
                1,
                1,
                1
            };

            Console.WriteLine("\n이 게임은 포켓몬 빙판 기믹에 영감을 받아 만들어 졌습니다.\n");
            Console.WriteLine("별을 먹으면 점수가 오릅니다. \n\n하지만 이동 횟수도 점수에 영향이 가기에 빠르게 깨시는 걸 추천드립니다.");
            Console.WriteLine("\n제작자가 이 게임을 잘 못해서 최소 클리어 횟수가 1이면 신경쓰지 않으셔도 됩니다.");
            Console.WriteLine("\n\n시작하시려면 아무키나 누르세요.");
            Console.ReadKey();

            while (!gameOver)
            {
                if (!isPlaying)
                {
                    Start(spawnPos[stageCount]);
                    isPlaying = true;
                }

                Console.Clear();
                DrawUI();
                SetupPlayerPos(maps);
                DrawMap(maps);
                Input(ref maps);
                CheckGameClear(maps);
            }
        }

        private static void DrawUI()
        {
            Console.WriteLine($"리셋하기 : [ R ] 버튼 클릭");
            Console.WriteLine($"현재 스테이지 : {stageCount + 1}");
            Console.WriteLine($"이동 횟수 / 최소 클리어 이동 횟수: {moveCount} / {stageMinMove[stageCount]}");
            Console.WriteLine($"별을 다 먹으려면 움직여야하는 최소 횟수 : {moveCount} / {starMinMove[stageCount]}");
            Console.WriteLine($"현재 별 갯수 : {starCount}");
        }

        static void CheckGameClear(int[,,] maps)
        {
            if (maps[stageCount,playerPos.y, playerPos.x] == 2)
            {
                Console.Clear();
                DrawUI();
                SetupPlayerPos(maps);
                DrawMap(maps);
                Console.WriteLine($"{stageCount+1} 스테이지 클리어!!!!!!!!!");

                stageCount++;

                if (stageCount >= maps.GetLength(0))
                {
                    totalMoveCount += moveCount;

                    Console.WriteLine("\n----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\n준비된 스테이지가 모두 끝났습니다!");
                    Console.WriteLine("\n----------------결과----------------");
                    Console.WriteLine($"\n총 움직인 횟수 : {totalMoveCount}");
                    Console.WriteLine($"\n총 먹은 별 갯수 : {starCount}");
                    Console.WriteLine($"\n최종 점수 : {(totalStarCount * 100) / totalMoveCount}");
                    Console.WriteLine("\n----------------------------------------------------------------------------------------------");
                    Console.WriteLine("\n ");

                    gameOver = true;
                }
                else
                {
                    totalStarCount += starCount;
                    totalMoveCount += moveCount;
                    Console.WriteLine($"\n{stageCount + 1} 스테이지를 시작하시려면 아무키나 누르세요.");
                    Console.ReadKey();

                    ResetGame(ref maps);
                }
            }
        }

        static void Start(PlayerPos playerSpawnPos)
        {
            playerPos.x = playerSpawnPos.x;
            playerPos.y = playerSpawnPos.y;
        }

        static void Input(ref int[,,] maps)
        {
            ConsoleKey input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    MoveUpDown(1, maps);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    MoveUpDown(-1, maps);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    MoveLeftRight(1,maps);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    MoveLeftRight(-1,maps);
                    break;
                case ConsoleKey.R:
                    ResetGame(ref maps);
                    break;   
            }
        }

        static void ResetGame(ref int[,,] maps)
        {
            moveCount = 0;
            starCount = 0;
            maps[stageCount,playerPos.y,playerPos.x] = 0;
            isPlaying = false;

            maps = (int[,,])originalMaps.Clone();

            DrawMap(maps);
        }
        static void MoveUpDown(int vector , int[,,] map)
        {
            moveCount++;
            {
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    if (vector > 0)
                    {
                        if (map[stageCount, playerPos.y - i, playerPos.x] == 1)
                        {
                            map[stageCount, playerPos.y, playerPos.x] = 0;
                            playerPos.y = playerPos.y - i + 1;
                            return;
                        }
                        else if (map[stageCount, playerPos.y - i, playerPos.x] == 4)
                        {
                            map[stageCount, playerPos.y - i, playerPos.x] = 0;
                            starCount++;
                        }
                    } 
                    else

                    {
                        if (map[stageCount, playerPos.y + i, playerPos.x] == 1)
                        {
                            map[stageCount, playerPos.y, playerPos.x] = 0;
                            playerPos.y = playerPos.y + i - 1;
                            return;
                        }
                        else if (map[stageCount, playerPos.y + i, playerPos.x] == 4)
                        {
                            map[stageCount, playerPos.y + i, playerPos.x] = 0;
                            starCount++;
                        }
                    }
                }
            }
        }
        static void MoveLeftRight(int vector ,int[,,] map)
        {
            moveCount++;

            for (int i = 0; i < map.GetLength(1); i++)
            {
                if (vector > 0)
                {
                    if (map[stageCount, playerPos.y, playerPos.x + i] == 1)
                    {
                        map[stageCount, playerPos.y, playerPos.x] = 0;
                        playerPos.x = playerPos.x + i - 1;
                        return;
                    }
                    else if (map[stageCount,playerPos.y,playerPos.x + i] == 4)
                    {
                        map[stageCount, playerPos.y, playerPos.x + i] = 0;
                        starCount++;
                    }
                }
                else
                {
                    if (map[stageCount, playerPos.y, playerPos.x - i] == 1)
                    {
                        map[stageCount, playerPos.y, playerPos.x] = 0;
                        playerPos.x = playerPos.x - i + 1;
                        return;
                    }
                    else if (map[stageCount, playerPos.y, playerPos.x - i] == 4)
                    {
                        map[stageCount, playerPos.y, playerPos.x - i] = 0;
                        starCount++;
                    }
                }
            }
        }

        static void DrawMap(int[,,] mapTile)
        {
            for (int i = 0; i < mapTile.GetLength(1); i++)
            {
                for (int j = 0; j < mapTile.GetLength(2); j++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    switch (mapTile[stageCount,i, j])
                    {
                        case 0:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("  ");
                            break;
                        case 1:
                            Console.Write("■");
                            break;
                        case 2:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("◎");
                            break;
                        case 3:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("◆");
                            break;
                        case 4:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write("★");
                            break;
                        case 5:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("●");
                            break;
                        case 6:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("○");
                            break;
                        default:
                            Console.Write("  ");
                            break;
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void SetupPlayerPos(int[,,] maps)
        {
            maps[stageCount, playerPos.y, playerPos.x] = 3;
        }

        static void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow + timeSpan;

            while (dateTimeNow <= dateTimeAdd)
            {
                dateTimeNow = DateTime.Now;
            }
            return;
        }

    }
}
