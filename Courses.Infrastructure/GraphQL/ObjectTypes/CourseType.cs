﻿using Courses.Infrastructure.Data.Entities;

namespace Courses.Infrastructure.GraphQL.ObjectTypes;

public class CourseType : ObjectType<CourseEntity>
{
    protected override void Configure(IObjectTypeDescriptor<CourseEntity> descriptor)
    {
        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.ImageUri).Type<StringType>();
        descriptor.Field(x => x.ImageHeaderUri).Type<StringType>();
        descriptor.Field(x => x.IsBestSeller).Type<BooleanType>();
        descriptor.Field(x => x.IsDigital).Type<BooleanType>();
        descriptor.Field(x => x.Categories).Type<ListType<StringType>>();
        descriptor.Field(x => x.Title).Type<StringType>();
        descriptor.Field(x => x.Ingress).Type<StringType>();
        descriptor.Field(x => x.StarRating).Type<DecimalType>();
        descriptor.Field(x => x.Reviews).Type<StringType>();
        descriptor.Field(x => x.LikesInProcent).Type<StringType>();
        descriptor.Field(x => x.Likes).Type<StringType>();
        descriptor.Field(x => x.Hours).Type<StringType>();
        descriptor.Field(x => x.Authors).Type<ListType<AuthorType>>();
        descriptor.Field(x => x.Prices).Type<PricesType>();
        descriptor.Field(x => x.Content).Type<ContentType>();
    }
}

public class AuthorType : ObjectType<AuthorEntity>
{
    protected override void Configure(IObjectTypeDescriptor<AuthorEntity> descriptor)
    {
        descriptor.Field(x => x.Name).Type<StringType>();
    }
}

public class PricesType : ObjectType<PricesEntity>
{
    protected override void Configure(IObjectTypeDescriptor<PricesEntity> descriptor)
    {
        descriptor.Field(x => x.Currency).Type<StringType>();
        descriptor.Field(x => x.CurrentPrice).Type<DecimalType>();
        descriptor.Field(x => x.DiscountPrice).Type<DecimalType>();
    }
}

public class ContentType : ObjectType<ContentEntity>
{
    protected override void Configure(IObjectTypeDescriptor<ContentEntity> descriptor)
    {
        descriptor.Field(x => x.Description).Type<StringType>();
        descriptor.Field(x => x.Includes).Type<ListType<StringType>>();
        descriptor.Field(x => x.ProgramDetails).Type<ListType<ProgramDetailItemType>>();
    }
}

public class ProgramDetailItemType : ObjectType<ProgramDetailItemEntity>
{
    protected override void Configure(IObjectTypeDescriptor<ProgramDetailItemEntity> descriptor)
    {
        descriptor.Field(x => x.Id).Type<IntType>();
        descriptor.Field(x => x.Title).Type<StringType>();
        descriptor.Field(x => x.Description).Type<StringType>();
    }
}

