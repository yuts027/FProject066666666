using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FProjectCamping.Common
{
    public static class CommonExtensions
    {
        /// <summary>
        /// 列舉數值 to 列舉項目
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T StringToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// 列舉數值 to 列舉項目
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T IntToEnum<T>(this int value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString());
        }

        /// <summary>
        /// 列舉 to 數值, ex: 0, 1, 2
        /// </summary>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        public static string Value(this System.Enum enumObj)
        {
            return enumObj.ToString("d");
        }

        /// <summary>
        /// 列舉 to 整數, ex: 0, 1, 2
        /// </summary>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        public static int Int(this System.Enum enumObj)
        {
            return Convert.ToInt32(enumObj);
        }

        /// <summary>
        /// A generic extension method that aids in reflecting
        /// and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
}