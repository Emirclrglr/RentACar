﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogQueryResult:BaseEntity
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string CoverImgUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
