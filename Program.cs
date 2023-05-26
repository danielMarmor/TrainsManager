// See https://aka.ms/new-console-template for more information
using TrainsManager;

Console.WriteLine("Welcome, Train Manager!");

var train = new Train();

Manager manager = new Manager(train);

const int CABINS_NUM = 10;

while (true)
{
    try
    {
        Console.WriteLine(@$"Operation Options ===>
         0 -Quit
         1- AddCabin,
         2- Remove Cabin,
         3- Start Drive,
         4-Stop Drive,
         5-Post Message,");

        var operation = Console.ReadLine();

        int selectedOperNumber;
        bool isValid = int.TryParse(operation, out selectedOperNumber);
        if (!isValid)
        {
            Console.WriteLine("Please Press a Number!");
            continue;
        }

        switch (selectedOperNumber)
        {
            case (int)ManagerOptions.Quit:
                break;
            case (int)ManagerOptions.AddCabin:
                manager.AddCabin();
                break;
            case (int)ManagerOptions.RemoveCabin:
                manager.RemoveCabin();
                break;
            case (int)ManagerOptions.StartDrive:
                manager.StartMovement();
                break;
            case (int)ManagerOptions.StopDrive:
                manager.StopTrain();
                break;
            case (int)ManagerOptions.PostMessageToPassengers:
                manager.PostMessage($"The Time is {DateTime.Now.ToLongTimeString()}");
                break;
            default:
                Console.WriteLine("Please Press Valid Input");
                break;

        }
        if (selectedOperNumber == (int)ManagerOptions.Quit)
        {
            break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

Console.WriteLine("Thank You!");


