namespace AdventOfCode2022
{
    public class AdventDay5
    {
        public static void MoveCratesReverseOrder()
        {
            string input = File.ReadAllText("AdventDay5\\input5.txt");
            string[] inputArray = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] startingPositions = inputArray[0].Split("\r\n");
            string[] moves = inputArray[1].Split("\r\n");
            int[][] parsedMoves = new int[moves.Length][];

            Stack<char>[] currentStack = new Stack<char>[9];
            for (int i = 0; i < currentStack.Length; i++)
                currentStack[i] = new Stack<char>();

            //read string to array of stacks
            for (int row = startingPositions.Length - 2; row >= 0; row--)
            {
                int stack = 0;
                for (int column = 1; column <= 33; column += 4, stack += 1)
                {
                    if (startingPositions[row][column] != ' ')
                    {
                        currentStack[stack].Push(startingPositions[row][column]);
                    }
                }
            }

            //parse input into ints
            for (int i = 0; i < moves.Length; i++)
            {
                parsedMoves[i] = moves[i].Split(new string[] { "move ", " from ", " to " }, 3, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            //perform moves
            for (int move = 0; move < moves.Length; move++)
            {
                for (int j = 0; j < parsedMoves[move][0]; j++)
                {
                    currentStack[parsedMoves[move][2] - 1].Push(currentStack[parsedMoves[move][1] - 1].Pop());
                }
            }

            Console.Write("Day 5 part 1: ");
            for (int i = 0; i < currentStack.Length; i++)
            {
                Console.Write(currentStack[i].Pop());
            }
            Console.WriteLine();
        }

        public static void moveCratesSameOrder()
        {
            string input = File.ReadAllText("AdventDay5\\input5.txt");
            string[] inputArray = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] startingPositions = inputArray[0].Split("\r\n");
            string[] moves = inputArray[1].Split("\r\n");
            int[][] parsedMoves = new int[moves.Length][];

            Stack<char>[] currentStack = new Stack<char>[9];
            for (int i = 0; i < currentStack.Length; i++)
                currentStack[i] = new Stack<char>();

            //read string to array of stacks
            for (int row = startingPositions.Length - 2; row >= 0; row--)
            {
                int stack = 0;
                for (int column = 1; column <= 33; column += 4, stack += 1)
                {
                    if (startingPositions[row][column] != ' ')
                    {
                        currentStack[stack].Push(startingPositions[row][column]);
                    }
                }
            }

            //parse input into ints
            for (int i = 0; i < moves.Length; i++)
            {
                parsedMoves[i] = moves[i].Split(new string[] { "move ", " from ", " to " }, 3, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            //perform moves
            for (int move = 0; move < moves.Length; move++)
            {
                Stack<char> tempStack = new Stack<char>();
                for (int j = 0; j < parsedMoves[move][0]; j++)
                {
                    tempStack.Push(currentStack[parsedMoves[move][1] - 1].Pop());
                }

                for (int j = 0; j < parsedMoves[move][0]; j++)
                {
                    currentStack[parsedMoves[move][2] - 1].Push(tempStack.Pop());
                }
            }

            Console.Write("Day 5 part 2: ");
            for (int i = 0; i < currentStack.Length; i++)
            {
                Console.Write(currentStack[i].Pop());
            }
            Console.WriteLine();
        }
    }
}
