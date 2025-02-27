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
    "/" => a / b,
    "^" => Math.Pow(a, b),
      _ => throw new ArgumentException("Invalid operator.")
  };
  private void CalculateTop() {
    if (values.Count < 2) {
      throw new ArgumentException($"Invalid expression: {Equation}");
    }

    var lhs = values.Pop();
    var rhs = values.Pop();
    var lhs = values.Pop();
    values.Push(ApplyOperator(lhs, rhs));
  }
  private static bool HasHigherPrecedence(Token left, Token right) {
    var IsLeftAssociative = (string op) => op != "^";
    var lhs = left.Value;
    var rhs = right.Value;
    return kPrecedence[lhs] > kPrecedence[rhs]
        || (kPrecedence[lhs] == kPrecedence[rhs] && IsLeftAssociative(lhs));
  }
  
  public double Evaluate() {
    Tokenizer.Tokenize(Equation).ForEach((token) => {
      switch (token.Type) {
      case TokenType.Number:
        values.Push(double.Parse(token.Value));
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
    return values.Pop();
  }

}