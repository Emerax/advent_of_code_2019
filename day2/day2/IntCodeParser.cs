using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class IntCodeParser {
    private readonly List<int> program = new List<int>();

    private void Add(int term1Pos, int term2Pos, int sumPos) {
        int term1 = program[term1Pos];
        int term2 = program[term2Pos];

        program[sumPos] = term1 + term2;
    }

    private void Multiply(int factor1Pos, int factor2Pos, int productPos) {
        int factor1 = program[factor1Pos];
        int factor2 = program[factor2Pos];

        program[productPos] = factor1 * factor2;
    }

    public void LoadProgram(string filePath) {
        program.Clear();
        string programString = File.ReadAllText(filePath);
        foreach (string valueString in programString.Split(",")) {
            program.Add(int.Parse(valueString));
        }
    }

    public void LoadProgram(int[] array) {
        program.Clear();
        foreach (int value in array) {
            program.Add(value);
        }
    }

    public void SetNounAndVerb(int noun, int verb) {
        program[1] = noun;
        program[2] = verb;
    }

    public void PrintProgram() {
        StringBuilder sb = new StringBuilder();
        foreach(int value in program) {
            sb.Append(value).Append(",");
        }
        Console.WriteLine($"Program: {sb.ToString()}");
    }

    public int GetOutput(int address) {
        return program[address];
    }

    public void ParseProgram() {
        int programCounter = 0;
        int opCode = program[programCounter];

        while(opCode != 99) {
            switch (opCode) {
                case 1:
                    Add(program[++programCounter], program[++programCounter], program[++programCounter]);
                    break;
                case 2:
                    Multiply(program[++programCounter], program[++programCounter], program[++programCounter]);
                    break;
                default:
                    return;
            }
            opCode = program[++programCounter];
        }
    }
}
