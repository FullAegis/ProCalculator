using System.Globalization; // For: CultureInfo.InvariantCulture

namespace ProCalculator;
public class Calculator(string equation) {
  private static readonly Dictionary<string, int> kPrecedence = new() {
    { "+", 0 }, { "-", 0 },
    { "*", 1 }, { "/", 1 },
    { "^", 2 },
  };

  public string Equation { get; set; } = equation;
  private Stack<Token>  operators = new();
  private Stack<double> values = new();
  
  private double ApplyOperator(double a, double b) => operators.Pop().Value switch {
    "+" => a + b,
    "-" => a - b,
    "*" => a * b,
    "/" => (b != 0) ? a / b : throw new DivideByZeroException("Cannot divide by 0"),
    "^" => Math.Pow(a, b),
    _   => throw new ArgumentException("Invalid operator.")
  };
  private void CalculateTop() {
    if (values.Count < 2) {
      throw new ArgumentException($"Invalid expression: {Equation}");
    }

    var rhs = values.Pop();
    var lhs = values.Pop();
    values.Push(ApplyOperator(lhs, rhs));
  }
  private bool LowerPrecedence(Token right) {
    var leftAssociative = (string op) => op != "^";
    var lhs = operators.Peek().Value;
    var rhs = right.Value;
    return kPrecedence[lhs] > kPrecedence[rhs]
        || (kPrecedence[lhs] == kPrecedence[rhs] && leftAssociative(lhs));
  }
  
  public double Evaluate() {
    Tokenizer.Tokenize(Equation).ForEach((token) => {
      switch (token.Type) {
      case TokenType.Number:
        values.Push(double.Parse(token.Value, CultureInfo.InvariantCulture));
        break;
      case TokenType.LeftParenthesis:
        operators.Push(token);
        break;
      case TokenType.RightParenthesis:
        while (operators.Count > 0 && operators.Peek().Type != TokenType.LeftParenthesis) {
          CalculateTop();
        }
        if (operators.Count == 0) {
          throw new ArgumentException("Mismatched parenthesis.");
        }
        operators.Pop(); // Pop '('
        break;
      case TokenType.Operator:
        while (operators.Count > 0 && operators.Peek().Type == TokenType.Operator 
                                   && HasHigherPrecedence(operators.Peek(), token)) {
          CalculateTop();
        }
        operators.Push(token);
        break;
      }  
    });
    
    // Handle remaining operations
    while (operators.Count > 0) {
      if (operators.Peek().Type == TokenType.LeftParenthesis) {
        throw new ArgumentException("Mismatched parentheses");
      }
      CalculateTop();
    }

    if (values.Count != 1) {
      // Only the result should be left on the stack.
      throw new ArgumentException($"Invalid expression: {Equation}");
    }
    
    return values.Pop();
  }
}