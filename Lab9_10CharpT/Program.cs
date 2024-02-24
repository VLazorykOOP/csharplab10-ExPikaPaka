using Lab9_10CharpT;
using System;
using System.Collections;
using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Lab9_10CSharpT {
    internal class Program {
        static void Main(string[] args) {
            int number = 1;

            while (number != 0) {
                Console.Write("Input task number [1-2], [0] to exit: ");

                try {
                    string? input = Console.ReadLine();

                    if (input != null) {
                        number = int.Parse(input);

                        switch (number) {
                            case 0:
                                return;

                            case 1:
                                task1(); // Testing task 1
                                break;

                            case 2:
                                task2(); // Testing task
                                break;

                            default:
                                break;
                        }
                    } else {
                        Console.WriteLine("Nothing provided. Exiting...");
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }

                Console.WriteLine();
            }
        }



        static void task1() {
            Console.WriteLine("|===~        Testing task 1.1        ~===|");

            // Creating wrong shape rectangle
            try { 
                Console.WriteLine("Creating wrong shape rectangle:");
                Lab9_10CharpT.Rectangle invalidRectangle = new Lab9_10CharpT.Rectangle(-5, 10);

            } catch (InvalidRectangleException ex) {
                Console.WriteLine($" Invalid rectangle: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($" An error occurred: {ex.Message}");
            }
            Console.WriteLine();


            // Creating DivideByZeroException
            try { 
                Console.WriteLine("Creating DivideByZero exception:");
                int a = 0;
                int b = 4;
                int c = b / a;

            } catch (DivideByZeroException ex) {
                Console.WriteLine($" Exception: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($" An error occurred: {ex.Message}");
            }
            Console.WriteLine();


            // Creating IndexOutOfRangeException
            try {
                Console.WriteLine("Creating IndexOutOfRange exception:");
                int[] arr = new int[2];
                int c = arr[3];

            } catch (IndexOutOfRangeException ex) {
                Console.WriteLine($" Exception: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($" An error occurred: {ex.Message}");
            }
            Console.WriteLine();


            // Creating OutOfMemoryException
            try {
                Console.WriteLine("Creating OutOfMemory exception:");
                int hugeAmount = int.MaxValue - 1;
                int[] arr = new int[hugeAmount];

            } catch (OutOfMemoryException ex) {
                Console.WriteLine($" Exception: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($" An error occurred: {ex.Message}");
            }
            Console.WriteLine();


            // Creating ArrayTypeMismatchException
            try {
                Console.WriteLine("Creating ArrayTypeMismatch exception:");
                string[] names = { "Dog", "Cat", "Fish" };
                Object[] objs = (Object[])names;

                Object obj = (Object)13;
                objs[2] = obj;

            } catch (ArrayTypeMismatchException ex) {
                Console.WriteLine($" Exception: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($" An error occurred: {ex.Message}");
            }
            Console.WriteLine();

            // Creating InvalidCastException
            try {
                Console.WriteLine("Creating InvalidCast exception:");
                IConvertible conv = true;
                Char ch = conv.ToChar(null);

            } catch (InvalidCastException ex) {
                Console.WriteLine($" Exception: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($" An error occurred: {ex.Message}");
            }
            Console.WriteLine();

            // Creating OverflowException
            try {
                Console.WriteLine("Creating Overflow exception:");
                int a = int.MaxValue;
                int b = 1;
                int result = checked(a + b);

            } catch (OverflowException ex) {
                Console.WriteLine($" Exception: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($" An error occurred: {ex.Message}");
            }
            Console.WriteLine();


            // Creating StackOverflowException
            try {
                Console.WriteLine("Creating StackOverflow exception:");
                
                void func() {
                   func();
                }

                //func();

                throw new StackOverflowException();

            } catch (StackOverflowException ex) {
                Console.WriteLine($" Exception: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($" An error occurred: {ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine();
        }

        static void task2() {
            Console.WriteLine("|===~        Testing task 2.1        ~===|");

            void f() {
                City city = new City();
                city.CrimeReported += (sender, e) =>
                {
                    Console.WriteLine($"Crime reported at {e.Location}: {e.Description}");
                };

                city.ReportCrime("Main Street", "Theft");
            }
            Task t = new Task(f);
            t.Start();
            Console.WriteLine("Text for paralel computation check");

            t.Wait();
            Console.WriteLine();
        }

    }
}




