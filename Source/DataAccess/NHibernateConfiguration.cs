using System;
using System.Reflection;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using NHibernate.Util;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.DataAccess
{
    public class NHibernateConfiguration : DefaultAutomappingConfiguration
    {
        public override bool IsId(Member member)
        {
            return member.Name == "ID";
        }

        public override bool IsComponent(Type type)
        {
            return !type.HasProperty("Id");
        }

        public override bool ShouldMap(Type type)
        {
            if (type == typeof (Area)) return false;


            if (type.Namespace != typeof(Entity).Namespace)
                return false;

            return base.ShouldMap(type);
        }

        public override bool ShouldMap(Member member)
        {
            var prop = member.MemberInfo as PropertyInfo;

            if (prop != null && !prop.CanWrite)
                return false;

            return base.ShouldMap(member);
        }
    }
}
