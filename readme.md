# ProCalculator

## Overview

This project, **ProCalculator**, is a simple calculator application implemented in C# as an exercise for the "Algorithms for C# Development" course. It demonstrates the application of fundamental data structures and algorithms for parsing and evaluating arithmetic expressions. The calculator supports basic arithmetic operations (+, -, \*, /, ^), operator precedence, parentheses, and decimal numbers.

## Features

*   **Arithmetic Operations:** Supports addition, subtraction, multiplication, division, and exponentiation.
*   **Operator Precedence:** Implements correct operator precedence using a stack-based approach.
*   **Parentheses:** Handles nested parentheses correctly.
*   **Decimal Numbers:** Supports calculations with decimal numbers.
*   **Error Handling:** Includes error handling for mismatched parentheses, division by zero, and invalid expressions.
*   **Tokenization:** Uses a `Tokenizer` class to convert the input string into a sequence of tokens.
*   **Evaluation:** Employs a stack-based algorithm in the `Calculator` class to evaluate the tokenized expression.

## Design and Implementation

The project consists of the following main components:

*   **`Token.cs`:** Defines the `Token` class, which represents a single token in the expression (e.g., number, operator, parenthesis). It includes the `TokenType` enum to categorize tokens.
*   **`Tokenizer.cs`:** Implements the `Tokenizer` class, responsible for converting the input string into a list of `Token` objects. It identifies numbers, operators, and parentheses, and handles whitespace.
*   **`Calculator.cs`:** Contains the `Calculator` class, which takes an equation as input and evaluates it. It uses two stacks: one for values and one for operators. The `Evaluate` method implements the core algorithm for evaluating the expression based on operator precedence and parentheses.
*   **`CalculatorTests.cs`:** Contains a suite of NUnit tests to verify the correctness of the calculator.

### Data Structures and Algorithms

The implementation utilizes the following data structures and algorithms:

*   **Stack:** Used to manage operators and values during expression evaluation, ensuring correct operator precedence and handling of parentheses.
*   **Dictionary:** The `kPrecedence` dictionary stores the precedence levels of different operators.
*   **Tokenization:** The `Tokenizer` class uses a simple parsing algorithm to break the input string into meaningful tokens.
*   **Reverse Polish Notation (RPN) (Implicit):** While not explicitly converted to RPN, the stack-based evaluation algorithm effectively mimics the behavior of RPN evaluation.

## Course Concepts Demonstrated

This project demonstrates the following concepts from the "Algorithms for C# Development" course:

*   **Data Structures:** Stack, Dictionary
*   **Algorithms:**
    *   Parsing
    *   Stack-based expression evaluation
    *   Operator precedence handling
*   **Object-Oriented Programming:** Encapsulation, Abstraction
*   **Error Handling:** Exception handling
*   **Unit Testing:** NUnit testing

## How to Run the Tests

1.  Clone the repository.
2.  Open the solution (`ProCalculator.sln`) in Visual Studio or another C# IDE.
3.  Build the solution.
4.  Open the Test Explorer in Visual Studio (Test -> Windows -> Test Explorer).
5.  Run all tests.

## License

This project is open-source and available under the [MIT License](LICENSE).

## Author

Anthony Capobianco [\(FullAegis\)](https://github.com/FullAegis).