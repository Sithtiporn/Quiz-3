class Program {
    static void Main(string[] args) {
        Console.Write("Enter number of stalls: ");
        int numStalls = int.Parse(Console.ReadLine());
        bool[] stalls = new bool[numStalls + 1];
        
        while (true) {
            Console.Write("Enter stall numbers to reserve (separated by a space): ");
            string[] input = Console.ReadLine().Split(' ');
            int stall1 = int.Parse(input[0]);
            int stall2 = int.Parse(input[1]);

            if (stall1 <= 0 || stall2 <= 0) { 
                break;
            }
            else if (stall1 == stall2) {
                if (stalls[stall1]) {
                    Console.WriteLine("The stall is reserved.");
                }
                else {
                    stalls[stall1] = true;
                    Console.WriteLine("Stall {0} is reserved.", stall1);
                }
            }
            else { 
                int start = Math.Min(stall1, stall2);
                int end = Math.Max(stall1, stall2);

                bool canReserve = true;
                for (int i = start; i <= end; i++) { 
                    if (stalls[i]) {
                        Console.WriteLine("The stall is reserved.");
                        canReserve = false;
                        break;
                    }
                }

                if (canReserve) { 
                    for (int i = start; i <= end; i++) {
                        stalls[i] = true;
                    }
                    Console.WriteLine("Stalls {0} to {1} are reserved.", start, end);
                }
                else { 
                    continue;
                }

                bool hasEntranceSpace = false;
                for (int i = 1; i < numStalls; i++) {
                    if (!stalls[i] && !stalls[i+1]) {
                        hasEntranceSpace = true;
                        break;
                    }
                }

                if (!hasEntranceSpace) { 
                    Console.WriteLine("The entrance can't be reserved.");
                    for (int i = 1; i <= numStalls; i++) {
                        stalls[i] = false; 
                    }
                }
            }
        }
    }
}
