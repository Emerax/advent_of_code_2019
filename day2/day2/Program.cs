using System;

namespace day2 {
    class Program {
        private static readonly string filePath = "C:\\Users\\enaar\\advent_of_code_2019\\day2\\program.txt";
        private static readonly int soughtResult = 19690720;

        static void Main(string[] args) {
            IntCodeParser parser = new IntCodeParser();

            //Part1(parser);
            Part2(parser);
        }

        static void Part2(IntCodeParser parser) {
            for(int noun = 0; noun <= 99; ++noun) {
                for(int verb = 0; verb <= 99; ++verb) {
                    parser.LoadProgram(filePath);
                    parser.SetNounAndVerb(noun, verb);
                    parser.ParseProgram();
                    Console.WriteLine($"Noun: {noun}, Verb: {verb}, Output: {parser.GetOutput(0)}");
                    if(parser.GetOutput(0) == soughtResult) {
                        Console.WriteLine($"Found {soughtResult}! Noun: {noun}, verb: {verb}. Answer is: {100 * noun + verb}");
                        return;
                    }
                }
            }
        }

        static void Part1(IntCodeParser parser) {
            parser.LoadProgram(filePath);
            parser.SetNounAndVerb(12, 2);
            parser.ParseProgram();
            parser.PrintProgram();
        }
    }
}
