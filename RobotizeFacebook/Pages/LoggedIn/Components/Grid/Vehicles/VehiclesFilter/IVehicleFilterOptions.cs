﻿
namespace RobotizeFacebook.Pages.LoggedIn
{
    public interface IVehicleFilterOptions : 
        IVehicleSort,
        IPrice,
        IVehicleType,
        IYear,
        IVehicleMake,
        IVehicleModel,
        IVehicleBodyStyle,
        IMileage,
        IVehicleExteriorColor,
        IVehicleInteriorColor,
        IVehicleTransmissionType
    {
    }
}
