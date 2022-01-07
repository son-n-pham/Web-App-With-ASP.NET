# Web App With ASP.NET
*This is the summary of CodeCademy's Learning Path of Build Web Apps with ASP.NET Skill Path*

## Introduction

There is a "dot net" confusion (Or at least to me ^^) with the big list of .NET, .NET Framework, .NET Core, dotnet, ASP.NET etc

### What is .NET?
- Formally vs informally:
  - Formally: .NET is an open source developer platform, created by Microsoft, for building various application types with several programming languages such as C#, F#, Visual C++ or Visual Basic
  - Informally: .NET is platform using C#

### What is .NET including? It is including a bunch of programs that:
- Compile C# code into instruction for computer to understand
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
ASP.NET is the framework on top of .NET platform to build **web app** and **web service**. Some tools included in ASP.NET are:
- A base framework to process web request in C# or F#
- A front-end syntax, called Razor, for building dynamic web pages using C#
- Library for common web pattern, ie. Model View Controller (MVC)
- Authentication system with libraries, a database, and template pages for handling logins
- Editor extensions to provide syntax highlighting, code completion and other functionality specifically for developing web pages

There are various architectures (or pattern) to build ASP.NET web apps. We focus on Razor Pages architecture using MVC. Every page from the Razor architecture is represented by 2 files:
- A view page, which displays information
- A page model, which handles the accessing and processing of information

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

### Classes and Objects
What to remember:
- Declare class: class Program {}
- Initiate object from class, we cannot initiate static class
- Field, constructor, constructor overloading, properties, method
- static

Below codes have all of the above:
```C#
// These codes to create class Forest
using System;

namespace StaticMembers
{
  class Forest
  {
    // FIELDS
    
    public int age;
    private string biome;
    private static int forestsCreated;
    private static string treeFacts;
    
    // CONSTRUCTORS
    
    public Forest(string name, string biome)
    {
      this.Name = name;
      this.Biome = biome;
      Age = 0;
      ForestsCreated++;
    }
    
    public Forest(string name) : this(name, "Unknown")
    { }
    
    */ The above 2 constructors can be replaced by the below
    public Forest(string name, string biome="Unknown")
    {
      this.Name = name;
      this.Biome = biome;
      Age = 0;
      ForestsCreated++;
    }
    */
    
    // This static constructor to assign value to treeFacts and ForestsCreated static fields which is applied to class Forest.
    // Only static constructor or method can handle static fields, properties
    // Static constructor is run before an object is made or before a static member is accessed.
    
    static Forest()
    {
      treeFacts = "Forests provide a diversity of ecosystem services including:\r\n  aiding in regulating climate.\r\n  purifying water.\r\n  mitigating natural hazards such as floods.\n";
      ForestsCreated = 0;
      
    }
    
    // PROPERTIES
    
    public string Name
    { get; set; }
    
    public int Trees
    { get; set; }
    
    // Validate input
    public string Biome
    {
      get { return biome; }
      set
      {
        if (value == "Tropical" ||
            value == "Temperate" ||
            value == "Boreal")
        {
          biome = value;
        }
        else
        {
          biome = "Unknown";
        }
      }
    }
    
    // Do not allow outsider to set age field
    public int Age
    { 
      get { return age; }
      private set { age = value; }
    }
    
    // Static properties
    public static int ForestsCreated
    {
      get { return forestsCreated; }
      private set { forestsCreated = value; }
    }
    
    // Static properties
    public static string TreeFacts
    {
      get { return treeFacts; }
    }
    
    // METHODS
     
    public int Grow()
    {
      Trees += 30;
      Age += 1;
      return Trees;
    }
    
    public int Burn()
    {
      Trees -= 20;
      Age += 1;
      return Trees;
    }
    
    // Static method to handle static field TreeFacts
    public static void PrintTreeFacts()
    {
      Console.WriteLine(TreeFacts);
    }
    
  }

}
```

The Program is calling the above Forest class as below
```C#
using System;

namespace StaticMembers
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(Forest.ForestsCreated);
      Forest f1 = new Forest("name1");
      Forest f2 = new Forest("name2");
      Console.WriteLine(Forest.ForestsCreated);
    }
  }
}
```

### Interface
- Interface is used to ensure certain functionality across multiple class
- A class can implement multiple interfaces
- We can face the issue of code duplications if various class have the exactly the same methods from interface. This can be resolved with inheritance

Example codes:

IAutomobile interface stored in IAutomobile.cs
```C#
using System;

namespace LearnInterfaces
{
  interface IAutomobile
  {
    string LicensePlate { get; }
    double Speed { get; }
    int Wheels { get; }
    void Honk();
  }
}
```

Sedan class, stored in Sedan.cs, implement the IAutomobile. Besides the properties and method in the interface, Sedan class has its own methods of SpeedUp and SlowDown.
```C#
using System;

namespace LearnInterfaces
{
  class Sedan : IAutomobile
  {
    public string LicensePlate
    { get; }

    public double Speed
    { get; private set; }

    public int Wheels
    { get; }
    
    public Sedan(double speed)
    {
      Speed = speed;
      LicensePlate = Tools.GenerateLicensePlate();
      Wheels = 4;
    }
    
    public void Honk()
    {
      Console.WriteLine("HONK!");
    }
    
    public void SpeedUp()
    {
      Speed += 5;
    }

    public void SlowDown()
    {
      Speed -= 5;
    }
  }
}
```

### Inheritance
- Inheritance helps to avoid code duplication in multiple classes
- In inheritance, we have superclasss (or base class) and subclass (or derived class). We can access superclass by **base**.
- private keyword limit the access from outer class, including subclasses. In order for subclass to access, protected (instead of private) keyword can be used.
- When subclass inherits the superclass, parameteredless constructor of superclass will be implicitly called for the constructor in superclass. To avoid that unclear, we can explicitly define the constructor in the superclass.
- Subclasses can override the method of superclass by virtual (in superclass) and override (in subclass). Other option is to use just the **new** keyword in subclass, which is actually create the new method in subclass and hide the same method from superclass.
- If superclass has methods methods which will certainly be used differently from subclasses, **abstract** keyword can be used with that method. Once a method is with abstract, abstract needs to be used with that class. The class becomes an abstract class, which cannot be instantiated.

Example:
Abstract class Vehicle
```C#
using System;

namespace LearnInheritance
{
  abstract class Vehicle
  {
    public string LicensePlate
    { get; private set; }

    // Protected keyword is used to allow subclass to set the property, but
    // the property is still inaccessible by other classes
    public double Speed
    { get; protected set; }

    public int Wheels
    { get; protected set; }

    // Explicitly define the constructor
    public Vehicle(double speed)
    {
      Speed = speed;
      LicensePlate = Tools.GenerateLicensePlate();
    }

    public virtual void SpeedUp()
    {
      Speed += 5;
    }

    public virtual void SlowDown()
    {
      Speed -= 5;
    }
    
    // virtual keyword is used to allow subclass to override it
    public virtual void Honk()
    {
      Console.WriteLine("HONK!");
    }

    // Abstract method Describe. Because of this, this class has to be an abstract class
    public abstract string Describe();

  }
}
```

Bicycle is inheriting Vehicle superclass
```C#
using System;

namespace LearnInheritance
{
  class Bicycle : Vehicle
  {
    // Subclass' constructor. The keyword base is used
    public Bicycle(double speed) : base(speed)
    {
      Wheels = 2;
    }

    // override method, which has virtual keyword in the superclass
    public override void SpeedUp()
    {
      Speed += 5;
      
      if (Speed > 15)
      {
        Speed = 15;
      }
    }

    // override method, which has virtual keyword in the superclass
    public override void SlowDown()
    {
      Speed -= 5;

      if (Speed < 0)
      {
        Speed = 0;
      }
    }

    // override is used to define the abstract method Describe
    public override string Describe()
    {
      return $"This Bicycle is moving on {Wheels} wheels at {Speed} km/h, with license plate {LicensePlate}.";
    }

  }
}
```

### References
- Reference types: These do nothold values but refer to a location in memory where values are. Classes are reference types
- Value types: "primitive" data type, ie. int, double, bool. char

Below picture is an example of reference and value types. diss1 and diss2 are reference types while num is value type.
![image](https://user-images.githubusercontent.com/79841341/146958564-23311a13-a8f9-4607-8edf-34bea4f2b5d8.png)

### Lists

Comparison between Array and List
Array | List
-- | --
Have litmited length |  Have unlimited length
Can only edit one element at a time |  Have handy methods to work with multiple elements at a time

List is in a group of classes called generic colletion. To use list, the below code will need to be added in the beginnig of the C# file.
```C#
using System.Collections.Generic
```

List can be created as empty lists or with components.
```C#
// Create empty list
List<int> count = new List<int>();

// Create list with components
List<int> someNumber = new List<int>{1, 2, 4};
```

Why we do not use list instead of array all the time?
- List is actually array behind the scene
- If list get longers, C# compiler construct the new array and copy all elements to there.
- Thus array is faster and should be used if we know the pre-determined number of elements.

### LINQ

Example code to introduce LINQ

```C#
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnLinq
{
  class Program
  {
    static void Main()
    {
      List<string> heroes = new List<string> { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };
      
      // Approach 1: without LINQ
      List<string> longLoudHeroes = new List<string>();
      
      foreach (string hero in heroes)
      {
        if (hero.Length > 6)
        {
          string formatted = hero.ToUpper();
          longLoudHeroes.Add(formatted);
        }
      }
      
      // Approach 2: with LINQ with query syntax similar to SQL
      var longLoudHeroes2 = from h in heroes
            where h.Length > 6
            select h.ToUpper();
	    
	    
      // Approach 3: with LINQ with method syntax
      var longLoudHeroes3 = heroes
            .Where(h => h.Length > 6)
            .Select(h => h.ToUpper());
      
      // Printing...
      Console.WriteLine("Your long loud heroes are...");
      
      foreach (string hero in longLoudHeroes2)
      {
        Console.WriteLine(hero);
      }
    }
  }
}

//LINQ returns either a single value or an object of type IEnumerable<Type>. IEnumberable<Type> works similar to list, which we can loop
//through or check length with Count(). As the returned type from LINQ is unknown, LINQ allows us to use **var** keyword, and C#
//compiler will take care of determining the correct types.
```

## ASP.NET

### Razor Page Syntax

With Razor page, everything related to a specific page is in one place, they include:
- Pages, referred as "view pages", have cshtml extension, ie. Home.cshtml. We can write C# code together with HTML.
- PageModels, referred as "model pages", have cshtml.cs extension, ie. Home.cshtml.cs. Pagemodels handle the logic of what users interact with.

There is a direct link between the URL of a webpage and the physical file location of that page in the server.
- The URL: https://LearnRazorPages.com/Home/Welcome will use **Welcome.cshtml** file in the **/Home** folder of the root **Pages** folder.

  ![image](https://user-images.githubusercontent.com/79841341/147898424-2f0d7cba-3da1-44d2-8837-73344024a486.png)
  
#### Structure of Razor View Page

A page needs to have **@page** on the first line to be the view page file.

There are couple of ways to write C# in Razor Page:

```C#
// C# code with one line and no space
<h1>@DateTime.Now.ToShortDateString()</h1>

// C# code needs spaces
<h1>Last week this time @(DateTime.Now - TimeSpan.FromDays(7))<p>

// C# code need more than one line or need to declare variables. Variables can only be declared by this way.
@{
  int num1 = 6;
  int num2 =9
  int result = num1 + num2;
}
```
#### Working with the Page Model

The 2nd line in the view model needs to have @model PageModel to use the PageModel of that view. Below is the example code.

Page Model file index.cshtml.cs contains PizzaModel class. 
- OnGet() method will be run automatically when the webpage is opened.
- ViewData is used to transfer data from Page Model to Page View. ViewData is of type ViewDataDictionary acting as a generic dictionary.

```C#
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnASP.Pages
{
    public class PizzaModel: PageModel
    {
        public double PizzaTotal(string pizzaType)
        {
            Dictionary<string, double> PizzaCost = new Dictionary<string, double>
            {
                {"Cheese", 10.00 },
                {"Pepperoni", 11.00 },
                {"Vegeterian", 12.00 },
            };

            return PizzaCost[pizzaType];
        }

        public string Customer { get; set; }
        public string Order { get; set; }
        public bool ExtraCheese { get; set; }
        public double Total { get; set; }

        public void OnGet()
        {
            Customer = "Son Pham";
            Order = "Cheese";
            ExtraCheese = false;
            Total = PizzaTotal(Order);
            ViewData["Delivery"] = "Pick-up";
            ViewData["AmountOfPizza"] = 7;
        }
    }
}
```

The page view file index.cshtml has the below code. **@model PizzaModel** is in line 2 of the file.

```C#
@page
@model PizzaModel
@{
    ViewData["Title"] = "Home page";
}


<h1 class="text-center">My Pizza</h1>

<div class="card mx-auto" style="width: 18rem;">
    <div class="card-body">
        <h4 class="card-title text-center">Confirm Your Order</h4>
        <br>
        <h5>Pizza for: @Model.Customer</h5>
        <h5>Order: @Model.Order</h5>
        <h5>Extra Cheese: @Model.ExtraCheese</h5>
        <h5>Delivery: @ViewData["Delivery"]</h5>
        <h5>Amount of Pizza: @ViewData["AmountOfPizza"]</h5>
        <h5>Total: $@String.Format("{0:0.00}", Model.Total * System.Convert.ToDouble(ViewData["AmountOfPizza"]))</h5>
    </div>
</div>
```
And here is the result in the web browser.

![image](https://user-images.githubusercontent.com/79841341/147913242-9749dec3-cd43-48eb-b4dc-0e0b101ea30a.png)

#### Sharing Pages

Sharing pages can be used to render sharing contents of webpages, including title, header, footer etc. ASP.NET specifies the location of main layout page in the **\_ViewStart.cshtml** file, which is under /Pages folder. The content of that page looks like:

```C#
@{
  Layout = "_Layout";
}
```

The **\_Layout** file is the **\_Layout.cshtml** file in the /Pages/Shared folder. Inside \_Layout.cshtml, there is a method called **@RenderBody()** within the \<body\> tag, which is the place rendering the content of Page View files using the shared \_Layout.cshtml file.

#### Working with ViewImports

On top of sharing laouts is the \_ViewImports.cshtml which is available globally in all pages and take care of imports for all pages. There are 3 most commons in that file:
- @namespace
- @using
- @addTagHelpers

```C#
// using is to import namespace for all pages
@using LearnASP

// Namespaces helps us organize our code into group by giving them some context. In this case, it is declaring the root of our Pages
@namespace LearnASP.Pages

// Give access to Tage Helpers
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

#### Using Partials

We can use Partial files to reuse it in our Pages to avoid DRY (Don't Repeat Yourself).
- Partial files are placed in /Pages/Shared folder
- Partial files start with "\_" as tradition, ie. \_MyPartial.cshtml
- To call the partial file, we use the below syntax
  ```html
  <partial name="_PartialName" />
  ```
- Keyword "for" or "model" can be used to pass info to Partial files. Below is an example: 
  - Partial file \Link.cshtml use model "string"
  
    ![image](https://user-images.githubusercontent.com/79841341/148182702-3ff44c5c-8885-4739-a2aa-5705b3dee52a.png)
  
  - index.cshtml employ \_Link.cshtml with input info @Model.LinkedInUserName (which is son-n-pham) from its page model index.cshtml.cs

    ![image](https://user-images.githubusercontent.com/79841341/148183060-b35e0893-7da5-4b47-b1bb-dd8fccf9ad57.png)
    
    ![image](https://user-images.githubusercontent.com/79841341/148183218-037cff33-2384-497f-85eb-06aad4c73007.png)

#### More on Page Model - OnGet and OnPost handler methods:

##### OnGet

##### OnPost

OnPost is used to post info from the browser. Posted info is usually from forms. Below is the example of the form syntax in Page View and OnPost method in the Page Model respectively.

```C#
<form method="post">
    <div class="form-group">
	<label for="Title">Title</label>
	<input type="text" class="form-control" id="Title" name="Title" placeholder="Title" />
    </div>
    <div class="form-group">
	<label for="Date">Date</label>
	<input type="date" class="form-control" id="Date" name="Date">
    </div>
    <div class="form-group">
	<label for="Body">Your post</label>
	<textarea class="form-control" id="Body" name="Body" rows="3"></textarea>
    </div>
    <button type="submit" class="btn" id="submit">Submit</button>
</form>
```

The below OnPost method assign info from forms to properties Title, Date and Body

```C#
public void OnPost(string title, DateTime date, string body)
{
    Title = title;
    Date = date;
    Body = body;
}
```

##### Model Binding with OnPost

In theory, model binding can be used with both OnPost and OnGet; however, it is recommended for using with only OnPost for security reason as security is built against posted info to protect the system.

To activate model binding, we just need to have **[BindProperty]"** on top of properties in Page Model. We just need to ensure that the property names in page model matched with name in the form. Thanks to the model binding, OnPost method can be kept empty.

View page:

![image](https://user-images.githubusercontent.com/79841341/148187709-29307894-8fc6-498b-b61e-45ef080ace7f.png)

Model page:

![image](https://user-images.githubusercontent.com/79841341/148187788-6fc3d9c0-ee17-446a-9065-6b2355584823.png)

![image](https://user-images.githubusercontent.com/79841341/148187840-71dd1d8b-4bc5-4629-b2ac-218e254e70cd.png)

##### asp-for

asp-for is the Input Tag Helper allowing us to create form easily by replacing both name and id in input of the form to shorten the syntax:

```C#
<form>
  <input type="text" name="Author" id="Author">
</form>
```

Above syntax in View Page can be changed to:

```C#
<form>
  <input type="text" asp-for="Author">
</form>
```

##### a tag with asp-page and asp-route-{value}

asp-page and asp-route-{value} can be used with Anchor Tag a:
- asp-page: set the href to a specific page
- asp-route-{value}:
  - Add route values to href

	```C#
	<a asp-page="./Authors" asp-route-fullname="Son Pham">Son</a>
	```

	is equivalent to the below a tag with href

	```C#
	<a href="./Authors?fullname=Son+Pham">Son</a>
	```

  - And also is able to send the value to OnGet method in Page Model

	```C#
	public void OnGet(string fullname){}
	```

##### OnGetAsync() and OnPostAsync()

asynchronous operations is to allow computer to move on while that operation is still ongoing. To have asynchronous OnGet and OnPost, we need to do the below:
- Converting "public void OnGet()" to "public async Task OnGetAsync()". Changing the method name is optional but recommended.
- Using "using" keyword with disposible variable inside
- Using "await" keyword with the synchronous operation.

Below is the example, which computer can move on when the file storage.txt is read and its contect is assigned to variable content.

```C#
public async Task OnGetAsync()
{
  if (System.IO.File.Exists("storage.txt"))
  {
    using (StreamReader reader = System.IO.File.OpenText("storage.txt"))
    {
      string content = await reader.ReadtoEndAsync();
    }
  }
}
```

#### Routing

By default, each page's URL is defined by its filename. When using "@page" on the first line of of View Page, the page URL is following the default:
- index.cshtml has the URL of locahost:8000
- privacy.cshtml has the URL of localhost:8000/privacy

If we want privacy.cshtml has the URL of "localhost:8000/pirates", we can use **@page "/pirates"**. If we use **@page "pirates"**, the URL of the page is "localhost:8000/privacy/pirates". This can be used to shorten the URL if the View Page is placed deep inside the folder structure.

When the URL has parameter, the parameter is from the OnGet in the Model Page. That parameter can be generated from asp-page and asp-route-{value} as mentioned previously.

![image](https://user-images.githubusercontent.com/79841341/148227221-de4ac4a6-1184-4e89-8ab5-9a7ad5f3acd5.png)

We can make the link of the resulted page to be better, whose href="./Author/Son+Pham, by using **@page /Authors/{fullname}**.
- To improve further, we can set fullname to be optional with **@page /Authors/{fullname?}**.
  - As the result, the OnGet() in the Model Page needs to be updated as the below example:
    ```C#
    public void OnGet(string? fullname)
    {
      if String.IsNullOrEmpty(fullname) // Check if the fullname has value
      {
        fullname = "son Pham"; // It is empty or null, thus set its value to Son Pham
      } else
      {
        fullName = fullname.Value; // Set the value of fullName, which will be sent to PageView to generate the desire URL
      }
    }
    ```
- We can also set constraint on the parameter to ensure correct parameter is inserted to avoid our program to be broken. This is done by having **@page /Authors/{fullname: string?}**

#### Redirection

To redirect, our method needs to return an object implementing IActionResult interface
- RedirectToPage is one method. The slash / makes the path relative to **Pages** folder. Without folder, the path will relative to the curren t page. RedirectToPage produces HTTP status code of 302. The below example always redirect the webpage to Pages/Checkout.cshtml
  ```C#
  public IActionResult OnPost()
  {
    return RedirectToPage("/Checkout");
  }
  ```

- Page(): Below are leading our webpage to the same current page.
  ```C#
  public IActionResult OnGet()
  {
    return Page();
  }
  
  // or
  
  public void OnGet() {}
  ```
  
- NotFound() returns to 404-not-found page
  ```C#
  public IActionResult OnPost(string username)
	{
	  if (username == "Machiavelli")
	  {
	    return NotFound();
	  }

	  return Page();
	}
  ```
  
- Async redirect. Below syntax is used
  ```C#
  public async Task<IActionResult> OnGetAsync() { }
  ```

### Database

#### Data Models

##### Add Data Models

- Models are C# classes defining engity structure.
- Those classes are with names representing entities
- Model is manually created in Visual Studio. Below is an example of the model Country

![image](https://user-images.githubusercontent.com/79841341/148529098-2cc5d163-8dcf-479d-985b-712b49290f65.png)
