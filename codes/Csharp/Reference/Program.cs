using System;

namespace RoverControlCenter
{
  class Program
  {
    static void Main(string[] args)
    {
        // Both MoonRover and MarsRover inherit Rover. Because of that, we can create
        // an array to store inherited objects MoonRover and MarRover
        MoonRover lunokhod = new MoonRover("Lunokhod 1", 1970);
        MoonRover apollo = new MoonRover("Apollo 15", 1971);
        MarsRover sojourner = new MarsRover("Sojourner", 1997);
        Satellite sputnik = new Satellite("Sputnik", 1957);

        // Array of Rover objects    
        Rover[] allRovers = {lunokhod, apollo};

        DirectAll(allRovers);

        // Manage all space probes including rovers and satellites by creating another array.
        // All of those classes are inherited from Object superclass
        Object[] allProbes = {lunokhod, apollo, sojourner, sputnik};

        // Loop and print GetType() of each item
        foreach (Object probe in allProbes)
        {
            Console.WriteLine(probe.GetType());

            // The below GetInfo() will give error as Object does not have GetInfo method
            //Console.WriteLine(probe.GetInfo());
        }

        // Having Object array to manage all probes are not the good option.
        // Other ways are to have superclass Probe or interface IDirectable.
        // The 1st option of superclass requires either remove methods in inherited class
        // or keep the methods but with override keyword.
        // The 2nd option of interface is better as we just need to createthe interface
        // and then we get Rover and Satellite classes to implement that interface.
        // Now we can create IDirectable array to store all probes
        IDirectable[] newAllProbes = {lunokhod, apollo, sojourner, sputnik};
        DirectAll(newAllProbes);
    }

    public static void DirectAll(Rover[] rovers)
    {
        // Loop each item in rovers arrary
        foreach (Rover rover in rovers)
        {
            //GetInfo, Explore and Collect are methods of MoonRover and MarsRover inherited from superclass Rover
            Console.WriteLine(rover.GetInfo());
            Console.WriteLine(rover.Explore());
            Console.WriteLine(rover.Collect());
        }
    }

    public static void DirectAll(IDirectable[] probes)
    {
        // Loop each item in rovers arrary
        foreach (IDirectable probe in probes)
        {
            //GetInfo, Explore and Collect are methods of MoonRover and MarsRover inherited from superclass Rover
            Console.WriteLine(probe.GetInfo());
            Console.WriteLine(probe.Explore());
            Console.WriteLine(probe.Collect());
        }
    }
  }
}
