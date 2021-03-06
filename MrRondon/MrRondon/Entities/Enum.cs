﻿using MrRondon.Helpers;

namespace MrRondon.Entities
{
    public enum ContactType
    {
        [EnumValueData(Description = "Telefone")]
        Telephone = 1,
        [EnumValueData(Description = "Celular")]
        Cellphone = 2,
        [EnumValueData(Description = "Email")]
        Email = 3
    }
}