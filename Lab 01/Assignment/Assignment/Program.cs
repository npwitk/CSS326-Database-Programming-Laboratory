using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nSelect program to run (1-6), or 0 to exit:");
            Console.WriteLine("1. Find Greatest Number");
            Console.WriteLine("2. Sum Odd or Even Numbers");
            Console.WriteLine("3. Array Math Operations");
            Console.WriteLine("4. Calculate Class Average");
            Console.WriteLine("5. Shopping Cart");
            Console.WriteLine("6. Simple Student DBMS");
            Console.Write("Enter choice: ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input, try again.");
                continue;
            }

            switch (choice)
            {
                case 0:
                    running = false;
                    break;
                case 1:
                    RunGreatestNumber();
                    break;
                case 2:
                    RunSumOddEven();
                    break;
                case 3:
                    RunArrayOperations();
                    break;
                case 4:
                    RunClassAverage();
                    break;
                case 5:
                    RunShoppingCart();
                    break;
                case 6:
                    RunStudentDBMS();
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    static void RunGreatestNumber()
    {
        Console.Write("Enter First Number: ");
        string firstNumber = Console.ReadLine();
        int firstNumberInt = Convert.ToInt32(firstNumber);

        Console.Write("Enter Second Number: ");
        string secondNumber = Console.ReadLine();
        int secondNumberInt = Convert.ToInt32(secondNumber);

        int max = (firstNumberInt > secondNumberInt) ? firstNumberInt : secondNumberInt;

        Console.WriteLine($"The greatest number is: {max}");
    }

    static void RunSumOddEven()
    {
        Console.Write("Enter a positive integer: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("The number must be positive.");
            return;
        }

        Console.Write("Sum odd or even numbers? (odd/even): ");
        string choice = Console.ReadLine().ToLower();

        int sum = 0;
        int i = 1;

        if (choice == "odd")
        {
            do
            {
                if (i % 2 != 0)
                {
                    sum += i;
                }
                i++;
            } while (i <= n);

            Console.WriteLine($"Sum of odd numbers up to {n} = {sum}");
        }
        else if (choice == "even")
        {
            do
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
                i++;
            } while (i <= n);

            Console.WriteLine($"Sum of even numbers up to {n} = {sum}");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    static void RunArrayOperations()
    {
        Console.Write("Enter the number of elements in the array: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[n];

        Console.WriteLine($"Enter {n} integer elements:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Element {i + 1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        int sum = numbers.Sum();
        int max = numbers.Max();
        int min = numbers.Min();
        double average = numbers.Average();

        Console.WriteLine($"Sum of elements: {sum}");
        Console.WriteLine($"Maximum element: {max}");
        Console.WriteLine($"Minimum element: {min}");
        Console.WriteLine($"Average of elements: {average}");
    }

    static void RunClassAverage()
    {
        Console.Write("Enter the number of students: ");
        int studentCount = Convert.ToInt32(Console.ReadLine());

        double[] scores = new double[studentCount];

        for (int i = 0; i < studentCount; i++)
        {
            Console.Write($"Enter score for student {i + 1}: ");
            scores[i] = Convert.ToDouble(Console.ReadLine());
        }

        double average = CalculateAverage(scores);
        Console.WriteLine($"Class average: {average}");
        Console.WriteLine($"Class average (Formatted): {average:F2}");
    }

    static double CalculateAverage(double[] scores)
    {
        double sum = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
        }
        return sum / scores.Length;
    }

    static void RunShoppingCart()
    {
        ShoppingCart cart = new ShoppingCart();

        Console.Write("Enter the number of items you want to add: ");
        int itemCount = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < itemCount; i++)
        {
            bool validChoice = false;

            while (!validChoice)
            {
                Console.WriteLine("Select an item to add to the cart:");
                Console.WriteLine("1. Shirt - $25.00");
                Console.WriteLine("2. Jeans - $50.00");
                Console.WriteLine("3. Shoes - $75.00");
                Console.Write("Enter your choice (1-3): ");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    cart.AddItem("Shirt", 25.00);
                    validChoice = true;
                }
                else if (choice == 2)
                {
                    cart.AddItem("Jeans", 50.00);
                    validChoice = true;
                }
                else if (choice == 3)
                {
                    cart.AddItem("Shoes", 75.00);
                    validChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid item. \n");
                }
            }
        }

        cart.DisplayCart();
    }

    static void RunStudentDBMS()
    {
        StudentDBMS db = new StudentDBMS();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nStudent DBMS Menu:");
            Console.WriteLine("1. Add a new student");
            Console.WriteLine("2. Display all students");
            Console.WriteLine("3. Search for a student by ID");
            Console.WriteLine("4. Return to main menu");
            Console.Write("Enter your choice (1-4): ");

            string choiceInput = Console.ReadLine();
            int choice;

            if (!int.TryParse(choiceInput, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter student age: ");
                    string ageInput = Console.ReadLine();
                    int age;

                    if (int.TryParse(ageInput, out age) && age > 0)
                    {
                        db.AddStudent(name, age);
                    }
                    else
                    {
                        Console.WriteLine("Invalid age. Please enter a valid positive number.");
                    }
                    break;

                case 2:
                    db.DisplayAllStudents();
                    break;

                case 3:
                    Console.Write("Enter student ID to search: ");
                    string idInput = Console.ReadLine();
                    int id;

                    if (int.TryParse(idInput, out id) && id > 0)
                    {
                        db.SearchStudentById(id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                    break;

                case 4:
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select from 1 to 4.");
                    break;
            }
        }
    }
}

class ShoppingCart
{
    private List<(string item, double price)> cartItems = new List<(string, double)>();

    public void AddItem(string item, double price)
    {
        cartItems.Add((item, price));
        Console.WriteLine($"{item} added to cart.\n");
    }

    public void DisplayCart()
    {
        Console.WriteLine("Items in your cart:");
        double totalPrice = 0;

        foreach (var (item, price) in cartItems)
        {
            Console.WriteLine($"{item} - ${price:F2}");
            totalPrice += price;
        }

        Console.WriteLine($"Total Price: ${totalPrice:F2}");
    }
}

class Student
{
    public int id;
    public string name;
    public int age;
}

class StudentDBMS
{
    private Student[] students = new Student[100];
    private int counter = 0;

    public void AddStudent(string name, int age)
    {
        Student newStudent = new Student();
        newStudent.id = counter + 1;
        newStudent.name = name;
        newStudent.age = age;

        students[counter] = newStudent;
        counter++;

        Console.WriteLine("Student added successfully!");
    }

    public void DisplayAllStudents()
    {
        if (counter == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("List of Students:");
        for (int i = 0; i < counter; i++)
        {
            Console.WriteLine($"ID: {students[i].id}, Name: {students[i].name}, Age: {students[i].age}");
        }
    }

    public void SearchStudentById(int id)
    {
        for (int i = 0; i < counter; i++)
        {
            if (students[i].id == id)
            {
                Console.WriteLine($"Student found: ID: {students[i].id}, Name: {students[i].name}, Age: {students[i].age}");
                return;
            }
        }
        Console.WriteLine("Student not found.");
    }
}
