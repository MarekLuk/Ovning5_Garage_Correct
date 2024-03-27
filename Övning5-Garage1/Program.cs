using Övning5_Garage1.Interface;
using Övning5_Garage1.Garage;
using Övning5_Garage1;


namespace Övning5_Garage1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUI uiComponent = new UI();
            GarageHandler garageHandler = new GarageHandler();
            Manager manager = new Manager(uiComponent, garageHandler);
            
            try
            {
                manager.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred{ex.Message}. Please try again.");
           
            }
        }
    }
}
