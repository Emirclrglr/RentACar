﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class UpdateTagCloudCommand:BaseEntity, IRequest
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
