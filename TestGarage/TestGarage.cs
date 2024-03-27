using Xunit;
using Övning5_Garage1;
using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Övning5_Garage1.Vehicles;
using Övning5_Garage1.Garage;



namespace TestGarage
{
    public class GarageTest
    {

        [Fact]
        public void AddItem_AddVehicle_VehicledAdded()
        {
            //Arrange
            var garage = new Garage<Bus>(1);
            var bus = new Bus("WER123", "Red", 6, 50);

            //Act
            bool result = garage.AddItem(bus);

            //Assert        
            Assert.Equal(1, garage.NumberOfVehiclesInParking);
        }


        [Fact]
        public void AddItem_ShouldBeNotPossibleToAddVehicle_GaarageIsFull()
        {
        //Arrange
        var garage = new Garage<Bus>(1);
        var bus = new Bus("WER123", "Red", 6, 50);
         garage.AddItem(bus);        
         var bus2 = new Bus("TTT123", "Red", 8, 70);

         //Act
        bool result = garage.AddItem(bus2);

        //Assert        
        Assert.False(result);
        Assert.Equal(1, garage.NumberOfVehiclesInParking);   
        }

    

        [Fact]
        public void RemoveItem_RemoveVehicle_WhenVehicleExist()
        {
             //arange
             var garage=new Garage<Bus>(1);
             var bus = new Bus("WER123", "Red", 6, 50);
            garage.AddItem(bus);


            //act
            bool result = garage.RemoveItem(0);

            //assert

            Assert.True(result);
            Assert.Equal(0, garage.NumberOfVehiclesInParking);

        }


        [Fact]
        public void RemoveItem_RemoveVehicle_WhenVehicleNotExist()
        {
            //arange
            var garage = new Garage<Bus>(1);
          


            //act
            bool result = garage.RemoveItem(0);

            //assert

            Assert.False(result);
            Assert.Equal(0, garage.NumberOfVehiclesInParking);

        }

     
    }
}