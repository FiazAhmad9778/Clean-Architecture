using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using iHakeem.SharedKernal.AutoMapper;

namespace iHakeem.SharedKernal.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> Map<TSource, TDestination, TMember, TSourceMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, TMember>> destinationExpression,
            Expression<Func<TSource, TSourceMember>> sourceExpression)
        {
            return mappingExpression.ForMember(destinationExpression, o => o.MapFrom(sourceExpression));
        }

        public static IMappingExpression<TEntity, TEntity> Map<TEntity, TMember>(
            this IMappingExpression<TEntity, TEntity> mappingExpression,
            Expression<Func<TEntity, TMember>> memberExpression)
        {
            return mappingExpression.ForMember(memberExpression, o => o.MapFrom(memberExpression));
        }

        public static void IgnoreAllOther<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            mappingExpression.ForAllOtherMembers(m => m.Ignore());
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            params Expression<Func<TDestination, object>>[] destinationExpression)
        {
            var expr = mappingExpression;
            foreach (var expression in destinationExpression)
            {
                expr = mappingExpression.ForMember(expression, o => o.Ignore());
            }

            return expr;
        }
        public static TResult MergeInto<TResult>(this IMapper mapper, object item1, object item2)
        {
            return mapper.Map(item2, mapper.Map<TResult>(item1));
        }

        public static TResult MergeInto<TResult>(this IMapper mapper, params object[] objects)
        {
            var res = mapper.Map<TResult>(objects.First());
            return objects.Skip(1).Aggregate(res, (r, obj) => mapper.Map(obj, r));
        }
    }
}
