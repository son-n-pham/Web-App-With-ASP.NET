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

### Versions of .NET: They do the same job but for different operating system:
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
