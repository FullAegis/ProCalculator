namespace ProCalculator;
public enum TokenType {
  None = 0,
  Number,
  Operator,
  LeftParenthesis,
  RightParenthesis,
}

public class Token(TokenType type, string value) {
  public TokenType Type { get; set; } = type;
  public string Value { get; } = value;
  public override string ToString() => $"Token : {Type} = {Value};";
  
  public static Token From(string number) => new(TokenType.Number, number);
  public static Token From(char symbol) => symbol switch {
    '(' => new(TokenType.LeftParenthesis, "("),
    ')' => new(TokenType.RightParenthesis, ")"),
    _   => new(TokenType.Operator, symbol.ToString()),
  };
 }