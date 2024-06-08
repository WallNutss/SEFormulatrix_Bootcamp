// using System;

// public class Coordinate{
//     public int X{get;set;}
//     public int Y{get;set;}
//     public Coordinate(int x, int y){
//         X = x;
//         Y = y;
//     }
//     public override bool Equals(object obj)
//     {
//         if (obj is Coordinate other)
//         {
//             return X == other.X && Y == other.Y;
//         }
//         return false;
//     }

//     public override int GetHashCode()
//     {
//         return HashCode.Combine(X, Y);
//     }
// }


// Console.WriteLine("Hello World");

// Coordinate coord1 = new(1,2);
// Coordinate coord2 = new(1,2);
// Coordinate coord3 = new(3,4);
// Coordinate coord4 = new(2,1);

// List<Coordinate> coordinates = new List<Coordinate>(){coord1,coord2,coord3,coord4};

// foreach(var coord in coordinates){
//     Console.WriteLine($"pos xy : ({coord.X},{coord.Y})");
// } 
// Console.WriteLine("====================");
// List<Coordinate> distinctCoordinates = coordinates.Distinct().ToList();

// foreach(var coord in distinctCoordinates){
//     Console.WriteLine($"pos xy : ({coord.X},{coord.Y})");
// }