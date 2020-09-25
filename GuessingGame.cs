using System;

namespace GuessingGame
{
  class Program
  {
    static int max;
    static int min;
    static Random rnd = new Random();
    static int numberToGuess;
    static int guess;
    static int tries;
    static bool wantsToReplay;
    static bool isEasyMode;

    static void Main()
    {
      Console.WriteLine("Hello, welcome to the guessing game !");
      do
      {
        Console.WriteLine("Do you want to enable the easy mode (displays the boundaries each time you make a guess) ? Y(es)/N(o)");
        isEasyMode = shouldEnableEasyMode();
        askNumber();
        setNumberToGuess();
        do
        {
          if (isEasyMode)
          {
            Console.WriteLine("Number to find is between {0} and {1}", min, max);
          }
          makeGuess();
          checkGuess();
        } while (guess != numberToGuess);
        Console.WriteLine("You found it in {0} {1}! Congrats !", tries, tries > 1 ? "tries" : "try");
        replay();
      } while (wantsToReplay);
    }

    static void setNumberToGuess()
    {
      if (min > max)
      {
        int goodMin = max;
        int goodMax = min;
        min = goodMin;
        max = goodMax;
        Console.WriteLine("Ok... now make a guess between {0} and {1} ! 😉", min, max);
        Console.WriteLine("Did you really think i was gonna let you screw things up ...? 😂");
      }
      else
      {
      Console.WriteLine("Ok, now make a guess between {0} and {1} !", min, max);
      }

      numberToGuess = rnd.Next(min, max);
    }

    static public void askNumber()
    {
      Console.Write("Please choose a minimum number : ");
      min = checkNumberInt(true);
      Console.Write("Please choose a maximum number : ");
      max = checkNumberInt(false);
    }
    static public int checkNumberInt(bool isMin)
    {
      string userResponse;
      do
      {
        try
        {
          userResponse = Console.ReadLine();
          var number = Convert.ToInt32(userResponse);
          if (number.GetType() == typeof(int))
          {
            Console.WriteLine("Ok, so you chose {0} as a {1}...", number, isMin ? "minimum" : "maximum");
            return number;
          }
        }
        catch (System.Exception)
        {
          Console.WriteLine("Not an integer please retry...");
          Console.WriteLine("Please choose a valid INTEGER {0} minimum number : ", isMin ? "minimum" : "maximum");
        }
      } while (true);
    }
    static public void makeGuess ()
    {
      int userAnswer;
      do
      {
        try
        {
          Console.Write("Make guess : ");
          userAnswer = Convert.ToInt32(Console.ReadLine());
          if (userAnswer.GetType() == typeof(int))
          {
            guess = userAnswer;
            break;
          }
        }
        catch (System.Exception)
        {
        Console.WriteLine("Number is not a valid integer, either too large or too small ! Please retry.");
        }
      }
      while (true);

      if (guess > max || guess < min)
      {
        tries--;
        Console.WriteLine("Wow! Seems like we're out of boundaries...");
        Console.WriteLine("Not counting this try... please retry.");
      }
    }

    static void checkGuess()
    {
      tries++;
      if (guess > numberToGuess) {
        if (guess <= max)
        {
          max = guess;
        }
        Console.WriteLine("Way too high..");
      }
      else if (guess < numberToGuess)
      {
        if (guess >= min)
        {
          min = guess;
        }
        Console.WriteLine("More than that...");
      }
    }
    static bool shouldEnableEasyMode()
    {
      string userAnswer = Console.ReadLine();
      if (userAnswer.ToLower() == "N".ToLower() || userAnswer.ToLower() == "No".ToLower())
      {
        return false;
      } else if (userAnswer.ToLower() == "Y".ToLower() || userAnswer.ToLower() == "Yes".ToLower())
      {
        return true;
      }
      Console.WriteLine("I did not get that... Enabling easy mode as a default.");
      return true;
    }
    static void replay ()
    {
      do
      {
        Console.WriteLine("Do you want to replay ? Y(es)/N(o)");
        string userAnswer = Console.ReadLine();
        if (userAnswer.ToLower() == "Y".ToLower() || userAnswer.ToLower() == "Yes".ToLower())
        {
          wantsToReplay = true;
          tries = 0;
          break;
        }
        else if (userAnswer.ToLower() == "N".ToLower() || userAnswer.ToLower() == "No".ToLower())
        {
          wantsToReplay = false;
          Console.WriteLine("Ok ! 😉");
          Console.WriteLine("Maybe next time ! Bye bye !");
          break;
        }
        else
        {
          System.Console.WriteLine("I did not get that...");
        }
      } while (true);
    }
  }
}
