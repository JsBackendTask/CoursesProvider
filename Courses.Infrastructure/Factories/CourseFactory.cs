using Azure.Core;
using Courses.Infrastructure.Data.Entities;
using Courses.Infrastructure.Models;

namespace Courses.Infrastructure.Factories;

public static class CourseFactory
{
    public static CourseEntity Create(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            ImageUri = request.ImageUri,
            ImageHeaderUri = request.ImageHeaderUri,
            IsBestSeller = request.IsBestSeller,
            IsDigital = request.IsDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInProcent = request.LikesInProcent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(author => new AuthorEntity
            {
                Name = author.Name,
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                Currency = request.Prices.Currency,
                CurrentPrice = request.Prices.CurrentPrice,
                DiscountPrice = request.Prices.DiscountPrice,
            },
            Content = request.Content == null ? null : new ContentEntity
            {
                Description = request.Content.Description,
                Includes = request.Content.Includes,
                ProgramDetails = request.Content.ProgramDetails?.Select(programDetail => new ProgramDetailItemEntity
                {
                    Id = programDetail.Id,
                    Title = programDetail.Title,
                    Description = programDetail.Description,
                }).ToList(),
            }
        };
    }
    public static CourseEntity Update(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            ImageUri = request.ImageUri,
            ImageHeaderUri = request.ImageHeaderUri,
            IsBestSeller = request.IsBestSeller,
            IsDigital = request.IsDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInProcent = request.LikesInProcent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(author => new AuthorEntity
            {
                Name = author.Name,
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                Currency = request.Prices.Currency,
                CurrentPrice = request.Prices.CurrentPrice,
                DiscountPrice = request.Prices.DiscountPrice,
            },
            Content = request.Content == null ? null : new ContentEntity
            {
                Description = request.Content.Description,
                Includes = request.Content.Includes,
                ProgramDetails = request.Content.ProgramDetails?.Select(programDetail => new ProgramDetailItemEntity
                {
                    Id = programDetail.Id,
                    Title = programDetail.Title,
                    Description = programDetail.Description,
                }).ToList(),
            }
        };
    }
    public static Course Create(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            ImageUri = entity.ImageUri,
            ImageHeaderUri = entity.ImageHeaderUri,
            IsBestSeller = entity.IsBestSeller,
            IsDigital = entity.IsDigital,
            Categories = entity.Categories,
            Title = entity.Title,
            Ingress = entity.Ingress,
            StarRating = entity.StarRating,
            Reviews = entity.Reviews,
            LikesInProcent = entity.LikesInProcent,
            Likes = entity.Likes,
            Hours = entity.Hours,
            Authors = entity.Authors?.Select(author => new Author
            {
                Name = author.Name,
            }).ToList(),
            Prices = entity.Prices == null ? null : new Prices
            {
                Currency = entity.Prices.Currency,
                CurrentPrice = entity.Prices.CurrentPrice,
                DiscountPrice = entity.Prices.DiscountPrice,
            },
            Content = entity.Content == null ? null : new Content
            {
                Description = entity.Content.Description,
                Includes = entity.Content.Includes,
                ProgramDetails = entity.Content.ProgramDetails?.Select(programDetail => new ProgramDetailItem
                {
                    Id = programDetail.Id,
                    Title = programDetail.Title,
                    Description = programDetail.Description,
                }).ToList(),
            }
        };
    }
}
