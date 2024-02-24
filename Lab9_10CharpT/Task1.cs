using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT {

    public class InvalidRectangleException : Exception {
        public InvalidRectangleException(string message) : base(message) {
        }
    }

    public interface IFigure : IComparable<IFigure> {
        double CalculateArea();
        double CalculatePerimeter();
        void DisplayInfo();
    }

    public class Rectangle : IFigure {
        public double Width {
            get { 
                return Width; 
            }
            set {
                if (value <= 0)
                    throw new InvalidRectangleException("Width must be a positive number.");
                Width = value;
            }
        }

        public double Height {
            get {
                return Height;
            }
            set {
                if (value <= 0)
                    throw new InvalidRectangleException("Height must be a positive number.");
                Height = value;
            }
        }

        public Rectangle(double width, double height) {
            Width = width;
            Height = height;
        }

        public double CalculateArea() {
            return Width * Height;
        }

        public double CalculatePerimeter() {
            return 2 * (Width + Height);
        }

        public void DisplayInfo() {
            Console.WriteLine($"Rectangle: Width = {Width}, Height = {Height}");
            Console.WriteLine($"Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
        }

        public int CompareTo(IFigure other) {
            double thisArea = this.CalculateArea();
            double otherArea = other.CalculateArea();
            return thisArea.CompareTo(otherArea);
        }
    }

    public class Circle : IFigure {
        public double Radius { get; set; }

        public Circle(double radius) {
            Radius = radius;
        }

        public double CalculateArea() {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter() {
            return 2 * Math.PI * Radius;
        }

        public void DisplayInfo() {
            Console.WriteLine($"Circle: Radius = {Radius}");
            Console.WriteLine($"Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
        }

        public int CompareTo(IFigure other) {
            double thisArea = this.CalculateArea();
            double otherArea = other.CalculateArea();
            return thisArea.CompareTo(otherArea);
        }
    }

    public class Triangle : IFigure {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC) {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea() {
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public double CalculatePerimeter() {
            return SideA + SideB + SideC;
        }

        public void DisplayInfo() {
            Console.WriteLine($"Triangle: SideA = {SideA}, SideB = {SideB}, SideC = {SideC}");
            Console.WriteLine($"Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}");
        }

        public int CompareTo(IFigure other) {
            double thisArea = this.CalculateArea();
            double otherArea = other.CalculateArea();
            return thisArea.CompareTo(otherArea);
        }
    }
}
