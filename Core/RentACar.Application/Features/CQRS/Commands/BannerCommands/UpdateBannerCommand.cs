﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateBannerCommand:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoURL { get; set; }
    }
}
