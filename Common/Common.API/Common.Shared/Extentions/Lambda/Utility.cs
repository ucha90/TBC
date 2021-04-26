﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Shared.Extentions.Lambda
{
    public static class Utility
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        public static Expression<Func<T, bool>> ToSingleExpression<T>(this Expression<Func<T, bool>>[] expressions)
        {
            Expression<Func<T, bool>> singleExpression = expressions[0];
            for (int i = 1; i < expressions.Length; i++)
            {
                singleExpression = singleExpression.And(expressions[i]);
            }
            return singleExpression;
        }
    }
}