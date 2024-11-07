// Christopher Hercules, 11/6/2024, lab 8 

    {
      // Clear the console screen
        Console.Clear();

        // Introduction
        Console.WriteLine("This program demonstrates the solution to several Project Euler problems.\n");

        // Menu
        Console.WriteLine("1) Multiples of 3 or 5");
        Console.WriteLine("2) Sum Square Difference");
        Console.WriteLine("3) Largest Prime Factor");
        Console.WriteLine("4) Largest Palindrome Product");
        Console.WriteLine("\nPlease select a problem (1-4):");

        // Read user input
        string? input = Console.ReadLine();
        int choice;

        // Validate user input
        if (int.TryParse(input, out choice))
        {
            // Switch statement to handle the user choice
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nMultiples of 3 or 5:");
                    Console.WriteLine("Find the sum of all multiples of 3 or 5 below 1000.");
                    PromptForAnswer(MultiplesOf3Or5(1000).ToString());
                    break;
                case 2:
                    Console.WriteLine("\nSum Square Difference:");
                    Console.WriteLine("Find the difference between the sum of the squares and the square of the sum of the first 100 natural numbers.");
                    PromptForAnswer(SumSquareDifference(100).ToString());
                    break;
                case 3:
                    Console.WriteLine("\nLargest Prime Factor:");
                    Console.WriteLine("Find the largest prime factor of the number 600851475143.");
                    PromptForAnswer(LargestPrimeFactor(600851475143).ToString());
                    break;
                case 4:
                    Console.WriteLine("\nLargest Palindrome Product:");
                    Console.WriteLine("Find the largest palindrome made from the product of two 3-digit numbers.");
                    PromptForAnswer(LargestPalindromeProduct().ToString());
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a number between 1 and 4.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    // Method to prompt the user to enter their answer and check if it's correct
     static void PromptForAnswer(string correctAnswer)
    {
        bool correct = false;
        while (!correct)
        {
            Console.Write("\nPlease enter your answer: ");
            string userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput)) 
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            if (userInput == correctAnswer)
            {
                Console.WriteLine("Good job!");
                correct = true;
            }
            else
            {
                Console.WriteLine("Incorrect. Please try again.");
            }
        }
    }

    // Problem 1: Multiples of 3 or 5
    static int MultiplesOf3Or5(int limit)
    {
        int sum = 0;
        for (int i = 0; i < limit; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }
        return sum;
    }

    // Problem 2: Sum Square Difference
    static int SumSquareDifference(int n)
    {
        int sumOfSquares = 0;
        int squareOfSum = 0;

        for (int i = 1; i <= n; i++)
        {
            sumOfSquares += i * i;
            squareOfSum += i;
        }

        squareOfSum = squareOfSum * squareOfSum;
        return squareOfSum - sumOfSquares;
    }

    // Problem 3: Largest Prime Factor
    static long LargestPrimeFactor(long number)
    {
        long maxPrime = -1;

        // Remove factors of 2
        while (number % 2 == 0)
        {
            maxPrime = 2;
            number /= 2;
        }

        // Check for odd factors
        for (long i = 3; i * i <= number; i += 2)
        {
            while (number % i == 0)
            {
                maxPrime = i;
                number /= i;
            }
        }

        // If number is still greater than 2, it's prime
        if (number > 2)
        {
            maxPrime = number;
        }

        return maxPrime;
    }

    // Problem 4: Largest Palindrome Product
    static int LargestPalindromeProduct()
    {
        int largestPalindrome = 0;

        for (int i = 999; i >= 100; i--)
        {
            for (int j = i; j >= 100; j--)
            {
                int product = i * j;
                if (IsPalindrome(product) && product > largestPalindrome)
                {
                    largestPalindrome = product;
                }
            }
        }

        return largestPalindrome;
    }

    // Helper function to check if a number is a palindrome
    static bool IsPalindrome(int number)
    {
        int original = number;
        int reversed = 0;

        while (number > 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }

        return original == reversed;
    }

