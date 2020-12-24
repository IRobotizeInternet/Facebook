﻿using RobotizeLibrary.CustomAttributes;
using RobotizeLibrary.Resources;

namespace RobotizeLibrary.Controls.Grid
{
    public enum RentalType
    {
        [LocalizedDescription(nameof(ResCategory.Apartment_Condo), typeof(ResCategory))]
        Apartment_Condo = 0,
        [LocalizedDescription(nameof(ResCategory.House), typeof(ResCategory))]
        House = 1,
        [LocalizedDescription(nameof(ResCategory.RoomOnly), typeof(ResCategory))]
        RoomOnly = 2,
        [LocalizedDescription(nameof(ResCategory.Townhouse), typeof(ResCategory))]
        Townhouse = 3,
    }
}
