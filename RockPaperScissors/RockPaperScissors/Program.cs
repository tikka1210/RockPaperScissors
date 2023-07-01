using System;
using System.Threading;
using static System.Console;

namespace RockPaperScissors
{
    public enum RockPaperScissorsType
    {
        가위 = 1,
        바위,
        보자기,
    }

    class Program
    {
        static void Battle()
        {
            int enemy = 0; // 적 변수
            int player = 0; //플레이어 변수
            int ctn = 0; //이어하기 변수 컨티뉴의 줄임말

            while (true) //반복문
            {
                Clear(); //콘솔창 클리어
                enemy = RandomValue(); //랜덤 한 값을 적 변수에 넣기
                WriteLine("가위바위보 게임\n1.가위\n2.바위\n3.보자기\n숫자로 입력해주세요.");

                if (!int.TryParse(ReadLine(), out player)) //잘못 입력 했을 시
                {
                    WriteLine("잘못 입력했습니다.\n숫자로 입력해주세요.");
                    Thread.Sleep(1000); //몇초 기다리기 (1000당 1초)
                    continue;
                }
                else if (!(player <= 3 || player >= 1))
                {
                    WriteLine("범위가 잘못 됐습니다.");
                    Thread.Sleep(1000);
                    continue;
                }

                Clear();

                Thread.Sleep(400); 
                Clear();
                if (player == enemy) //비길 시
                {
                    WriteLine($"당신은 {(RockPaperScissorsType)player} 컴퓨터는 {(RockPaperScissorsType)enemy} 이므로"); //나와 컴퓨터가 고른 값
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("비겼습니다");
                }
                else if ((player == 1 && enemy == 3) || (player == 2 && enemy == 1) || (player == 3 && enemy == 2)) //이길 시
                {
                    WriteLine($"당신은 {(RockPaperScissorsType)player} 컴퓨터는 {(RockPaperScissorsType)enemy} 이므로");
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("당신이 이겼습니다!");
                }
                else if ((player == 3 && enemy == 1) || (player == 1 && enemy == 2) || (player == 2 && enemy == 3)) //질 시
                {
                    WriteLine($"당신은 {(RockPaperScissorsType)player} 컴퓨터는 {(RockPaperScissorsType)enemy} 이므로");
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("당신이 졌습니다!");
                }

                ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2500);

                Clear();
                WriteLine("계속 하시겠습니까?\n1.네\n2.아니요");
                if (!int.TryParse(ReadLine(), out ctn))
                {
                    WriteLine("잘못 입력했습니다.\n숫자로 입력해주세요.");
                    Thread.Sleep(1000);
                    continue;
                }
                else if (ctn == 1)
                {
                    Clear();
                    WriteLine("다시 시작 합니다.");
                    Thread.Sleep(1000);
                    continue;
                }
                else if (ctn == 2)
                {
                    Clear();
                    Environment.Exit(0);
                }
                else
                {
                    Clear();
                    WriteLine("범위가 잘못 되었습니다.");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }

        /// <summary>
        /// 랜덤 하게 하나의 값을 고르는 메서드 (1 ~ 3 중)
        /// </summary>
        /// <returns>랜덤 하게 한 값을 고르고 (1 ~ 3 중) 그 값을 리턴</returns>
        static int RandomValue()
        {
            Random random = new Random();
            return random.Next(1, 3 + 1);
        }

        /// <summary>
        /// 콘솔창에 출력
        /// </summary>
        static void Main(string[] args)
        {
            Battle(); //배틀 메서드
        }
    }
}
