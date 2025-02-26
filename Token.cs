namespace ProCalculator;
public enum TokenType {
  Number,
  Operator,
  LeftParenthesis,
  RightParenthesis,
}

public class Token(TokenType type, string value) {
  public TokenType Type { get; set; } = type;
  public string Value { get; } = value;
  public override string ToString() => $"Token : {Type} = {Value};";
  
  public static Token From(string number) => new Token(TokenType.Number, number);
  public static Token From(char symbol) => symbol switch {
    '(' => new Token(TokenType.LeftParenthesis, "("),
    ')' => new Token(TokenType.RightParenthesis, ")"),
      _ => new Token(TokenType.Operator, symbol.ToString()),
  };
 }