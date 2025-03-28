﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Commands.AboutCommands
{
    public class UpdateAboutCommand:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
