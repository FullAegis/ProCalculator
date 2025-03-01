using System.Buffers; // For SearchValues
using System.Text;    // For StringBuilder

namespace ProCalculator;
public static class Tokenizer {
  private static bool IsOperator(char c) => SearchValues.Create("()^*/+-").Contains(c);
  
  public static List<Token> Tokenize(string input) {
    var tokens = new List<Token>();
    var number = new StringBuilder();
    
    TokenType LastTokenType() => tokens.DefaultIfEmpty(new(TokenType.Operator, "")).Last().Type;
    foreach (var c in input) {
      if (char.IsDigit(c) || c == '.') {
        number.Append(c);
      } else {
        if (number.Length > 0) {
          tokens.Add(Token.From(number: number.ToString()));
          number.Clear();
        }
        
        if (IsOperator(c)) {
          if (c == '-' && lastTokenType() == TokenType.Operator) {
            number.Append('-');
          } else {
            tokens.Add(Token.From(symbol: c));
          }
        } else if (!char.IsWhiteSpace(c)) {
          throw new ArgumentOutOfRangeException($"invalid token: '{c}'");
        }
      }
    }

    if (number.Length > 0) tokens.Add(Token.From(number: number.ToString()));
    return tokens;
  }
}