﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand:BaseEntity
    {
        public RemoveContactCommand(int id)
        {
            Id = id;
        }
    }
}
