using System;
using System.Collections.Generic;

namespace BalloonsPops
{
    class Balloon
    {
        // Method for generating initial matrix (baloonsFieldMatrix) with random numbers
        static byte[,] GenerateBalloons(byte rows, byte columns)
        {
            // DimitarSD: Defensive programming - need to add validation for method arguments
            byte[,] balloonsMatrix = new byte[rows, columns];
            Random randomNumber = new Random();
            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte numberToInsert = (byte)randomNumber.Next(1, 5);
                    balloonsMatrix[row, column] = numberToInsert;
                }
            }
            return balloonsMatrix;
        }

        static void CheckLeft(byte[,] balloonsMatrix, int row, int column, int searchedItem)
        {
            // DimitarSD: Defensive programming - need to add validation for method arguments
            int newRow = row;
            int newColumn = column - 1;
            try
            {
                if (balloonsMatrix[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix[newRow, newColumn] = 0;
                    CheckLeft(balloonsMatrix, newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void CheckRight(byte[,] balloonsMatrix, int row, int column, int searchedItem)
        {
            // DimitarSD: Defensive programming - need to add validation for method arguments
            int newRow = row;
            int newColumn = column + 1;
            try
            {
                if (balloonsMatrix[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix[newRow, newColumn] = 0;
                    CheckRight(balloonsMatrix, newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void CheckUp(byte[,] balloonsMatrix, int row, int column, int searchedItem)
        {
            // DimitarSD: Defensive programming - need to add validation for method arguments
            int newRow = row + 1;
            int newColumn = column;
            try
            {
                if (balloonsMatrix[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix[newRow, newColumn] = 0;
                    CheckUp(balloonsMatrix, newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        static void CheckDown(byte[,] balloonsMatrix, int row, int column, int searchedItem)
        {
            // DimitarSD: Defensive programming - need to add validation for method arguments
            int newRow = row - 1;
            int newColumn = column;
            try
            {
                if (balloonsMatrix[newRow, newColumn] == searchedItem)
                {
                    balloonsMatrix[newRow, newColumn] = 0;
                    CheckDown(balloonsMatrix, newRow, newColumn, searchedItem);
                }
                else
                {
                    return;
                }
            }
            catch (IndexOutOfRangeException)
            { 
                return; 
            }
        }

        static bool Change(byte[,] matrixToModify, int row, int column)
        {
            if (matrixToModify[row, column] == 0)
            {
                return true;
            }
            
            byte searchedTarget = matrixToModify[row, column];
            matrixToModify[row, column] = 0;

            CheckLeft(matrixToModify, row, column, searchedTarget);
            CheckRight(matrixToModify, row, column, searchedTarget);
            CheckUp(matrixToModify, row, column, searchedTarget);
            CheckDown(matrixToModify, row, column, searchedTarget);

            return false;
        }

        static bool CheckIfWinner(byte[,] baloonsFieldMatrix)
        {
            bool isWinner = true;
            Stack<byte> stack = new Stack<byte>();
            int columnLenght = baloonsFieldMatrix.GetLength(0);
            for (int j = 0; j < baloonsFieldMatrix.GetLength(1); j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (baloonsFieldMatrix[i, j] != 0)
                    {
                        isWinner = false;
                        stack.Push(baloonsFieldMatrix[i, j]);
                    }
                }
                for (int k = columnLenght - 1; (k >= 0); k--)
                {
                    try
                    {
                        baloonsFieldMatrix[k, j] = stack.Pop();
                    }
                    catch (Exception)
                    {
                        baloonsFieldMatrix[k, j] = 0;
                    }
                }
            }
            return isWinner;
        }

        static void SortAndPrintChartFive(string[,] tableToSort)
        {

            List<Rating> chart = new List<Rating>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                chart.Add(new Rating(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));

            }

            chart.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < chart.Count; ++i)
            {
                Rating slot = chart[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.Name, slot.Value, i + 1);
            }
            Console.WriteLine("----------------------------------");


        }

        static void Main(string[] args)
        {
            string[,] topFive = new string[5, 2];
            byte[,] baloonsFieldMatrix = GenerateBalloons(5, 10);

            Console.Write("    ");
            for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1); column++)
            {
                Console.Write(column + " ");
            }

            Console.Write("\n   ");
            for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (byte i = 0; i < baloonsFieldMatrix.GetLongLength(0); i++)
            {
                Console.Write(i + " | ");
                for (byte j = 0; j < baloonsFieldMatrix.GetLongLength(1); j++)
                {
                    if (baloonsFieldMatrix[i, j] == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    Console.Write(baloonsFieldMatrix[i, j] + " ");
                }
                Console.Write("| ");
                Console.WriteLine();
            }

            Console.Write("   ");     //some trinket stuff again
            for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1) * 2 + 1; column++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            string userInput = null;
            int userMoves = 0;
            while (userInput != "EXIT")
            {
                Console.WriteLine("Enter a row and column: ");
                userInput = Console.ReadLine();
                userInput = userInput.ToUpper().Trim();

                switch (userInput)
                {
                    case "RESTART":
                        baloonsFieldMatrix = GenerateBalloons(5, 10);
                        Console.Write("    ");
                        for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1); column++)
                        {
                            Console.Write(column + " ");
                        }

                        Console.Write("\n   ");
                        for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1) * 2 + 1; column++)
                        {
                            Console.Write("-");
                        }

                        Console.WriteLine();

                        for (byte i = 0; i < baloonsFieldMatrix.GetLongLength(0); i++)
                        {
                            Console.Write(i + " | ");
                            for (byte j = 0; j < baloonsFieldMatrix.GetLongLength(1); j++)
                            {
                                if (baloonsFieldMatrix[i, j] == 0)
                                {
                                    Console.Write("  ");
                                    continue;
                                }

                                Console.Write(baloonsFieldMatrix[i, j] + " ");
                            }
                            Console.Write("| ");
                            Console.WriteLine();
                        }

                        Console.Write("   ");     //some trinket stuff again
                        for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1) * 2 + 1; column++)
                        {
                            Console.Write("-");
                        }
                        Console.WriteLine();
                        userMoves = 0;
                        break;

                    case "TOP":
                        SortAndPrintChartFive(topFive);
                        break;

                    default:
                        if ((userInput.Length == 3) && (userInput[0] >= '0' && userInput[0] <= '9') && (userInput[2] >= '0' && userInput[2] <= '9') && (userInput[1] == ' ' || userInput[1] == '.' || userInput[1] == ','))
                        {
                            int userRow, userColumn;
                            userRow = int.Parse(userInput[0].ToString());
                            if (userRow > 4)
                            {
                                Console.WriteLine("Wrong input ! Try Again ! ");
                                continue;
                            }
                            userColumn = int.Parse(userInput[2].ToString());

                            if (Change(baloonsFieldMatrix, userRow, userColumn))
                            {
                                Console.WriteLine("cannot pop missing ballon!");
                                continue;
                            }
                            userMoves++;
                            if (CheckIfWinner(baloonsFieldMatrix))
                            {
                                Console.WriteLine("Gratz ! You completed it in {0} moves.", userMoves);
                                if (topFive.SignIfSkilled(userMoves))
                                {
                                    SortAndPrintChartFive(topFive);
                                }
                                else
                                {
                                    Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
                                }
                                baloonsFieldMatrix = GenerateBalloons(5, 10);
                                userMoves = 0;
                            }
                            Console.Write("    ");
                            for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1); column++)
                            {
                                Console.Write(column + " ");
                            }

                            Console.Write("\n   ");
                            for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1) * 2 + 1; column++)
                            {
                                Console.Write("-");
                            }

                            Console.WriteLine();

                            for (byte i = 0; i < baloonsFieldMatrix.GetLongLength(0); i++)
                            {
                                Console.Write(i + " | ");
                                for (byte j = 0; j < baloonsFieldMatrix.GetLongLength(1); j++)
                                {
                                    if (baloonsFieldMatrix[i, j] == 0)
                                    {
                                        Console.Write("  ");
                                        continue;
                                    }

                                    Console.Write(baloonsFieldMatrix[i, j] + " ");
                                }
                                Console.Write("| ");
                                Console.WriteLine();
                            }

                            Console.Write("   ");     //some trinket stuff again
                            for (byte column = 0; column < baloonsFieldMatrix.GetLongLength(1) * 2 + 1; column++)
                            {
                                Console.Write("-");
                            }
                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong input ! Try Again ! ");
                            break;
                        }


                }
            }
            Console.WriteLine("Good Bye! ");

        }
    }
}


