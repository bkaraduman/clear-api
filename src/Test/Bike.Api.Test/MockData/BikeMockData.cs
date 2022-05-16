using Bike.Common.Models.ResponseModels;
using System.Collections.Generic;

namespace Bike.Api.Test.MockData
{
    public static class BikeMockData
    {
        public static BikeModels GetBikes()
        {
            return new BikeModels
            {
                Bikes = new List<BikeDetailModels>
                    {
                        new BikeDetailModels
                        {
                            DateStolen=1651096800,
                            FrameColors=new List<string>
                            {
                                "Black",
                                "Blue",
                                "Red"
                            },
                            Id=1280586,
                            LargeImg="https://cdn.bikeindex.org/uploads/bike/1280586/large_bike-index-bike-image-1280586.jpg",
                            ManufacturerName="Altec",
                            IsStockImg=false,
                            Serial="2018532919",
                            Status="stolen",
                            Stolen=true,
                            StolenCoordinates=new List<double>
                            {
                                52.37,
                                4.9
                            },
                            Thumb="https://files.bikeindex.org/uploads/Pu/561559/small_948BD107-450D-4B26-8745-C157B9D97445.jpeg",
                            Title="Altec 2018532919",
                            Url= "https://bikeindex.org/bikes/1280586",
                            Year=2018
                        },
                        new BikeDetailModels
                        {
                            DateStolen=1650374063,
                            FrameColors=new List<string>
                            {
                                "Silver"
                            },
                            Id=1053012,
                            LargeImg="https://cdn.bikeindex.org/uploads/bike/1280586/large_bike-index-bike-image-1280586.jpg",
                            ManufacturerName="Rad Power Bikes",
                            IsStockImg=false,
                            Serial="vp1l20v1215",
                            Status="stolen",
                            Stolen=true,
                            StolenCoordinates=new List<double>
                            {
                                52.37,
                                4.9
                            },
                            Thumb="https://files.bikeindex.org/uploads/Pu/561559/small_948BD107-450D-4B26-8745-C157B9D97445.jpeg",
                            Title="2021 Rad Power Bikes",
                            Url= "https://bikeindex.org/bikes/1053012",
                            Year=2021
                        },
                    }
            };
        }
    }
}
