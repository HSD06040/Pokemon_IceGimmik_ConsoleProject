# Pokemon_IceGimmik_ConsoleProject
 ConsoleProject

# ❖ 프로젝트 기획
>상 하 좌 우 로 움직이는 콘솔프로젝트를 만드는 과제이다.

일단 난 포켓몬을 매우 좋아하기 때문에 듣자마자 바로 포켓몬 빙판길 기믹이 떠올랐다.
그래서 일단 먼저 어떻게 구성하였냐면

- for문 사용
for 문으로 움직인 방향을 쭉 스캔해서 벽이 있다면 그 벽앞에 Player의 Position은 세팅하는 식으로 하였다.

- 리셋 기능
R을 눌러 리셋가능 하도록 하였다.
(여기서 map을 그냥 받아와서 원래맵에 깊은 복사하는 형식으로 하였는데 이러면 객체 자체가 생성되는 개념이고
이것으로 맵을 그려도 받아온 객체가 아닌 생성된 객체이기에 원래 초기맵을 그대로 복사하지 못한다고 해야하나?
일단 ref로 받아오니 생성개념이 아닌 값할당 개념으로 바뀌어서 맵 초기화가 잘 되었다.)

- 별 먹기
점수 시스템이 있으면 좋겠다고 생각해서 넣었다.

# ❖ 코드
> 객체지향이 아닌 절차지향이라 조금 길 수 있다.

### ✧ 맵
```cs
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
};
```
스테이지를 이런식으로 구현했다. 4개 더있다.
왜 int로 하였냐면 한번 시도 해보고 싶었다.

설명을 하자면
- 0
  빙판이다. 기본적인 땅 이라고 보면된다.
- 1
  벽이다. 플레이어가 넘을 수 없는 곳 이라고 보면된다.

- 2
  클리어 지점이다. 플레이어가 도착해야하는 지점이라고 보면된다.

- 3
  플레이어이다. 플레이어의 위치를 3으로하여 3이 배열에서 이동하면서 DrawMap에서는 3을 플레이어로 그리는 것이다.

- 4
  별이다. 게임을 다 완성 시켰을 때 점수를 넣으면 좋을 것 같아서 별을 넣었다.
  별을 먹을 것인지 빠르게 깰 것인지를 판단하는 재미를 추가 하였다.

- 그 외
  빈 공간이다. 지금은 8로 되어있는데 추후 넣을 기능이 더 있을까봐 일부러 좀 간격을 뛰어뒀다.

### ✧ DrawMap
```cs
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
```
이런 식으로 int 값에 맞는 그림을 그리도록 하였다.

- 이중 for문을 사용하여 한줄 씩 그린다.

- 맵자체는 3차원 배열이라 stageCount에 따라서 맵이 달라진다.

### ✧ Movement
```cs
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
```
방향을 정해주면 그 방향으로 검사하고 벽이 있으면 벽앞에 가는 식으로 구현하였다.
사실 조금 더 생각했으면 간소화가 가능해 보여 나중에 시간이 된다면 다시 볼 예정이다.


### ✧ Input
```cs
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
```
간단하다 Input을 받아 맞는 것을 실행시킨다.

- 여기서 Movement함수들이 쓰인다.

- R을 누르면 게임이 리셋된다.
  
### ✧ 게임루프
```cs
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
```
gameOver가 true가 될때까지 계속 반복한다.

- 콘솔초기화 -> 플레이어세팅 -> 맵그리기 -> 입력받기 -> 클리어판단 이 반복된다.

### ✧ CheckClear
```cs
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

```
클리어를 판단해서 클리어라면 다음 스테이지로 넘어가고 만약 스테이지가 끝났다면 게임을 종료 시킨다.

- 만약 종료 되었다면 총 점수를 별갯수와 이동횟수에 비례하여 계산해 알려준다.
