﻿using System.Threading.Tasks;
using Robotize.BLL.Contracts;
using RobotizeFacebook.Services;

namespace Robotize.BLL.Services
{
    public class ServiceWindowsScreen : IServiceWindowsScreen
    {
        public Task<bool> WindowClick(int gridCoordinates)
        {
            return Task.FromResult(true);
        }

        public Task<bool> WindowGrid(GridVisibility gridVisibility)
        {
            const string serviceName = "ScreenTools";
            if (gridVisibility == GridVisibility.OFF) ServiceTask.CloseTask(serviceName);
            else ServiceTask.RunScript(serviceName);
            return Task.FromResult(true);
        }
    }
}
