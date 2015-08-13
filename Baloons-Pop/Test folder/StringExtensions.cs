using System;

namespace BalloonsPops
{
    public static class StringExtensions
    {
        //public override string ToString()
        //{
        //    return string.Format("");
        //}

        public static bool CheckIfOneOfBestTopFiveScores(this string[,] topFiveChart, int userMoves)
        {
            bool isTopFivePlayer = false;
            int worstMovesCountInTopFiveChart = 0;
            int worstMovesChartPosition = 0;
            for (int i = 0; i < 5; i++)
            {
                if (topFiveChart[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string tempUserName = Console.ReadLine();
                    topFiveChart[i, 0] = userMoves.ToString();
                    topFiveChart[i, 1] = tempUserName;
                    isTopFivePlayer = true;
                    break;
                }
            }
            if (isTopFivePlayer == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(topFiveChart[i, 0]) > worstMovesCountInTopFiveChart)
                    {
                        worstMovesChartPosition = i;
                        worstMovesCountInTopFiveChart = int.Parse(topFiveChart[i, 0]);
                    }
                }
            }
            if (userMoves < worstMovesCountInTopFiveChart && isTopFivePlayer == false)
            {
                Console.WriteLine("Type in your name.");
                string tempUserName = Console.ReadLine();
                topFiveChart[worstMovesChartPosition, 0] = userMoves.ToString();
                topFiveChart[worstMovesChartPosition, 1] = tempUserName;
                isTopFivePlayer = true;
            }
            return isTopFivePlayer;
        }
    }
}