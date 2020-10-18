﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TankSim.Client.OperatorModules;

namespace TankSim.Client.GUI.OperatorModules
{
    /// <summary>
    /// Interaction logic for GuiGunLoaderCtrl.xaml
    /// </summary>
    [OperatorRole(OperatorRoles.FireControl)]
    public partial class GuiGunLoaderCtrl : UserControl, IOperatorModule
    {
        public GuiGunLoaderCtrl()
        {
            InitializeComponent();
        }

        public void HandleInput(IOperatorInputMsg Input)
        {
            //noop
        }

        public void Dispose()
        {
            //noop
        }
    }
}
