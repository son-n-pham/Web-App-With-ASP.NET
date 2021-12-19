# Web App With ASP.NET
*This is the summary of CodeCademy's Learning Path of Build Web Apps with ASP.NET Skill Path*

## Introduction

There is a "dot net" confusion (Or at least to me ^^) with the big list of .NET, .NET Framework, .NET Core, dotnet, ASP.NET etc

### What is .NET?
- Formally vs informally:
  - Formally: .NET is an open source developer platform, created by Microsoft, for building various application types with several programming languages such as C#, F#, Visual C++ or Visual Basic
  - Informally: .NET is platform using C#

### Why is .NET including? It is including a bunch of programs that:
- Compile C# code into intruction for computer to understand
- Provide tools to build software such tools for printing text to the screen and finding the current time
- Define a set of data types, ie. text, numbers, dates, ..., to conveniently store info in program

### Versions of .NET: They do the same job but for different operating systems:
- .NET Framework is the original .NET running on only Windows computers.
- .NET Core is the new, cross-platform version running on Windows, MacOS and Linux. Microsoft plans to rename .NET Core to .NET

### How to get .NET
There are 2 main ways:
- Download **Visual Studio**, which is an Integrated Development Environment (IDE). The IDE comes with .NET platform, a code editor and additional tools to write code
- Download **.NET SDK** (Software Development Kit), which comes with .NET platform without IDE. The SDK is accessed via a Command-Line Interface (CLI)

### What about ASP.NET
ASP.NET is the framework on top of .NET platform to build Web App.

## C\# Programming Language

### Data Types and Variables

#### Built-in data types:

![image](https://user-images.githubusercontent.com/79841341/146522415-aa0acbfb-9a3e-4bea-ae09-5e7fb30ab86b.png)

#### Type conversion:
When converting data type, C# check to ensure that we do not lose any data. Therfore, it is automatically convert from int to double, but we will get error to convert from double to int. To avoid such error, we need to have a cast operator.

There are 2 type of conversion:
- Implicit conversion: Happens automatically
- Explicit conversion: 
  - requires a cast operator:
    ```C#
    double myDouble = 3.2;
    // Round myDouble to the nearest whole number by a cast operator
    int myInt = (int)myDouble;
    ```
  - or use built-in method Convert.ToX()
    ```C#
    double myDouble = 3.2;
    // Round myDouble to the near whole number by a built-in method
    int myInt = System.Convert.ToInt32(myDouble);
    ```
    
### Logic and Conditionals

#### If...Else If...Else... Statements

#### Switch Statements

#### Ternary Operators

It is the compact syntax of if...else...

```C#
string color = "blue";
string result = (color=="blue") ? "It is blue" : "It is not blue"; //if the variable color is "blue", result is "It is blue", otherwise result is "It is not blue"
Console.WriteLine(result); //"It is not blue" is printed out in the console
```

### Methods

#### Method Calls and Input

##### Method Overloading: 
- Methods can have the same name, which each of them is called *overload*.
- Overloads have either different parameter types or differnt number of parameters, and they behave differently.
- This is useful when we want the same method behaves differently based on its inputs.
- Example:
  ```C#
  using System;

  namespace MethodOverloading
  {
    class Program
    {
      static void Main(string[] args)
      {
        NamePets("Laika", "Albert");
        NamePets("Mango", "Puddy", "Bucket");
        NamePets();
      }

      static void NamePets(string firstPet="Laikaaaa", string secondPet="Albertttt")
      {
        Console.WriteLine($"Your pets {firstPet} and {secondPet} will be joining your voyage across space!");
      }

      static void NamePets(string firstPet, string secondPet, string thirdPet)
      {
        Console.WriteLine($"Your pets {firstPet}, {secondPet}, and {thirdPet} will be joining your voyage across space!");
      }

      static void NamePets()
      {
        Console.WriteLine("Aw, you have no spacefaring pets :(");
      }
    }
  }
  /* The result in the console is:
  Your pets Laika and Albert will be joining your voyage across space!
  Your pets Mango, Puddy, and Bucket will be joining your voyage across space!
  Aw, you have no spacefaring pets :( */  
  ```
  
#### Method Output

##### out
Method can return only 1 value. In order to return more than one, **out** can be used.
```C#
using System;

namespace OutErrors
{
  class Program
  {
    static void Main(string[] args)
    {
      string statement = "GARRRR";
      bool marker;
      string murmur = Whisper(statement, out marker);
      Console.WriteLine(murmur);
      Console.WriteLine(marker);
    }  
    
    static string Whisper(string phrase, out bool wasWhisperCalled)
    {
      wasWhisperCalled = true;
      return phrase.ToLower();
    }
	} 
}
/* out keyword is used when define Whisper method
The result parameter wasWhispercalled of out is assigned a value inside method
The method Whipser also return a string by its return statement
When calling Whisper method, ie. in Main(), we need to remember to use the "out" keyword

Result of this program:
garrrr
True */
```
##### Expression-Bodied Methods:
Method with a single statement or expression can be written in expression-bodied form.

```C#
static int Add(int x, int y)
{
  return x + y;
}
 
static void PrintUpper(string str)
{
  Console.WriteLine(str.ToUpper());
}
 
// The same methods written in expression-body form.
static int Add(int x, int y) => x + y;
 
static void PrintUpper(string str) => Console.WriteLine(str.ToUpper());
```

##### Method is used as argument and Lambda Expression
Methods can be use as arguments. The below case with Array.Exists() is an example. Array.Exist takes 2 argument, which an array is the first and a method as the second. When running, method is run with each item of the array.

Lambda expression is a block code which can be used as value or expression in other methods.

```C#
int[] numbers = { 3, 10, 4, 6, 8 };

static bool isTen(int n) {
  return n == 10;
}
 
// `Array.Exists` calls the method passed in for every value in `numbers` and returns true if any call returns true.
Array.Exists(numbers, isTen);
 
// Lambda expression is used to replace isTen method
// Typical syntax
// (input-parameters) => { <statements> }
Array.Exists(numbers, (int n) => {
  return n == 10;
});

// We can also write Lambda as below because there is only 1 expression from Lambda
Array.Exists(numbers, (int n) => n==10);

// Or get rid of int as C# implicitly reckon that n should be integer
Array.Exists(number, (n) => n==10);

// Or even get rid of the () as lambda expression has only 1 argument
Array.Exists(number, n => n==10);
```

### Arrays and Loops

#### Arrays

##### Building an Array

One way
```C#
// Initial declaration
int[] plantHeights;

// Assign values to the array
plantHeights = new int[] {3, 4, 5};

// The below will cause an error
// plantHeights = {3, 4, 5};
```

Other way
```C#
int[] plantHeights = new int[] {3, 4, 5};
```

Or
```C#
int[] plantHeights = {3, 4, 5};
```

Or the below will define an array with a fixed length of 5 (have 5 items)
```C#
int[] plantHeights = new int[5];
```

##### Array Built-In Methods
There several methods, ie. Array.Sort(ourArray), Array.IndexOf(ourArray, value), Array.Find(ourArray, predicate). Predicate is a method taking one input and outputting a boolean.
```C#
int[] plantHeights = { 3, 6, 4, 1, 6, 8 };
 
// Find the first occurence of a plant height that is greater than 5 inches
int firstHeight = Array.Find(plantHeights, height => height > 5);
```
 
#### Loops

##### While Loop

```C#
while (condition)
{
  statement;
}
```

##### Do...While Loop

```C#
do
{
  statement;
}
```

##### For Loop

```C#
for (initialization; stopping condition; iteration statement)
{
  statement;
}
```

```C#
for (int i = 0; i < 10; i++)
{
  Console.WriteLine(i);
}
```

##### For Each Loop

```C
foreach (type element in sequence)
{
  statement;
}
```

```C
string[] melody = { "a", "b", "c", "c", "b" };
foreach (string note in melody)
{
  Console.WriteLine(note);
}
```
##### When to use:
- while loops are good when you know your stopping condition, but not when you know how many times you want a program to loop or if you have a specific collection to loop through.
- do...while loops are only necessary if you definitely want something to run once, but then stop if a condition is met.
- for loops are best if you want something to run a specific number of times, rather than given a certain condition.
- foreach loops are the best way to loop over an array, or any other collection.

##### Jump Statements
- break: end the loop
- continue: bypass the rest potions of that round, go back to the top and continue the next round of the loop
- return: if return is used within a loop in a method, it breaks out the loop and returns control to the point in the program where the method was called.
