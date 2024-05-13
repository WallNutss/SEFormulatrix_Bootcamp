// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;
namespace Exceptions;
					
public class Program
{
	public static void Main()
	{
		try{
            Console.WriteLine(ExceptionMaker.NotFiniteNumberExc());
        }catch(Exception e){
            Console.WriteLine(e);
        }
	}
}
