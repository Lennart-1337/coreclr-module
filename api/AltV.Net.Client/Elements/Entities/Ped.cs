﻿using AltV.Net.CApi;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Net.Client.Elements.Entities;

public class Ped : Entity, IPed
{
    private static IntPtr GetEntityPointer(ICore core, IntPtr pedNativePointer)
    {
        unsafe
        {
            return core.Library.Shared.Ped_GetEntity(pedNativePointer);
        }
    }

    public IntPtr PedNativePointer { get; private set; }
    public override IntPtr NativePointer => PedNativePointer;

    public Ped(ICore core, IntPtr vehiclePointer, uint id) : base(core, GetEntityPointer(core, vehiclePointer), id, BaseObjectType.Ped)
    {
        PedNativePointer = vehiclePointer;
    }

    public ushort Armour
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Ped_GetArmour(PedNativePointer);
            }
        }
    }

    public ushort Health
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Ped_GetHealth(PedNativePointer);
            }
        }
    }

    public ushort MaxHealth
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Ped_GetMaxHealth(PedNativePointer);
            }
        }
    }

    public uint CurrentWeapon
    {
        get
        {
            unsafe
            {
                CheckIfEntityExistsOrCached();
                return Core.Library.Shared.Ped_GetCurrentWeapon(PedNativePointer);
            }
        }
    }
}