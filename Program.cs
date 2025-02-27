namespace ProCalculator;

class Program {
  private static string Prompt(string prompt) {
    Console.Write(prompt);
    return Console.ReadLine() ?? string.Empty;
  }

  public static void Main(string[] args) {
    var input = Prompt("Please enter an equation: ");
    var calc = new Calculator(input);
    Console.WriteLine($"Result of {calc.Equation}: {calc.Evaluate()}");
  }
}