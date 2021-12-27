using System;

namespace RoverControlCenter
{
  class Program
  {
    static void Main(string[] args)
    {
      MoonRover lunokhod = new MoonRover("Lunokhod 1", 1970);
      MoonRover apollo = new MoonRover("Apollo 15", 1971);
      MarsRover sojourner = new MarsRover("Sojourner", 1997);
      Satellite sputnik = new Satellite("Sputnik", 1957);

      Rover[] allRovers = {lunokhod, apollo};

      lunokhod.GetInfo();

      DirectAll(allRovers);
  		
    }

    public static void DirectAll(Rover[] rovers)
    {
      foreach (Rover rover in rovers)
      {
        rover.GetInfo();
        rover.Explore();
        rover.Collect();
      }
    }
  }
}
