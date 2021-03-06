﻿using System;
using MessagePack;
using TIPC.Core.Tools;

namespace TankSim.OperatorCmds
{
    /// <summary>
    /// Channel command - fire control operation
    /// </summary>
    [MessagePackObject]
    public sealed class GunLoaderCmd
    {
        /// <summary>
        /// Static immutable load primary weapon command
        /// </summary>
        public static GunLoaderCmd Load { get; } = new GunLoaderCmd(GunLoaderType.Load);
        /// <summary>
        /// Static immutable cycle ammo type command
        /// </summary>
        public static GunLoaderCmd CycleAmmoType { get; } = new GunLoaderCmd(GunLoaderType.CycleAmmoType);


        /// <summary>
        /// Loader type
        /// </summary>
        [Key(0)]
        public GunLoaderType LoaderType { get; private set; }

        /// <summary>
        /// Command creation time
        /// </summary>
        [Key(1)]
        public DateTime InitTime { get; private set; } = HighResolutionDateTime.UtcNow;

        /// <summary>
        /// Create new instance
        /// </summary>
        /// <param name="LoaderType">Gun loader operation type</param>
        public GunLoaderCmd(GunLoaderType LoaderType)
        {
            this.LoaderType = LoaderType;
        }
    }
}
