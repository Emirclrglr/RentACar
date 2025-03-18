using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities;
using RentACar.Domain.Entities.Common;

namespace RentACar.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogByIdWithAuthorQueryResult : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public string CoverImgUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
    }
}
