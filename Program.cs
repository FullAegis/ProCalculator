using System;

class Program {

  
  private Stack<Operators> operators;
  private Stack<double> numbers;
  
  private static string Prompt(string prompt) {
    Console.Write(prompt);
    return Console.ReadLine() ?? string.Empty;
  }
  
  public static void Main (string[] args) {
    var input = Prompt("Please enter an equation: ");
    
    
  }
}

