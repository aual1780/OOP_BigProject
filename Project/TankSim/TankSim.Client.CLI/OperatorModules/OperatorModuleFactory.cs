﻿using Microsoft.Extensions.DependencyInjection;
using System;
using TankSim.Client.OperatorModules;

namespace TankSim.Client.CLI.OperatorModules
{
    public class OperatorModuleFactory
    {
        readonly IServiceProvider _serviceProvider;

        public OperatorModuleFactory(IServiceProvider ServiceProvider)
        {
            _serviceProvider = ServiceProvider;
        }

        public IOperatorModuleCollection GetModuleCollection(OperatorRoles Roles)
        {
            //TODO: add all modules
            var collection = new OperatorModuleCollection();
            if((Roles & OperatorRoles.Driver) != 0)
            {
                var driver = ActivatorUtilities.CreateInstance<CliDriver>(_serviceProvider);
                collection.AddModule(driver);
            }
            return collection;
        }
    }
}
