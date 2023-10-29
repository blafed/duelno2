using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

namespace Duelno.Api
{
    class CustomJsonContractResolver : DefaultContractResolver
    {
        public static CustomJsonContractResolver singleton = new CustomJsonContractResolver();

        public CustomJsonContractResolver()
        {
            DefaultMembersSearchFlags |= BindingFlags.NonPublic;
        }
        protected override JsonContract CreateContract(Type objectType)
        {
            return base.CreateContract(objectType);
        }


        protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            //ignore all readonly-properties (which has  getter but no setter)

            if (!property.Writable)
            {
                property.Ignored = true;
            }
            if (property.AttributeProvider != null)
            {
            }


            //if (property.AttributeProvider.GetAttributes ( typeof ( JsonIgnoreAttribute ), true ).Count > 0
            //    ||
            //    property.AttributeProvider.GetAttributes ( typeof ( System.Text.Json.Serialization.JsonIgnoreAttribute), true).Count > 0
            //    ) {
            //    property.Ignored = true;
            //}   

            return property;
        }
    }


    static class CustomJsonSettings
    {
        public static JsonSerializerSettings singleton = new JsonSerializerSettings
        {
            ContractResolver = CustomJsonContractResolver.singleton,
        };

        public static void AssignTo(JsonSerializerSettings other)
        {
            other.ContractResolver = singleton.ContractResolver;
            other.Converters = new List<JsonConverter>(singleton.Converters);
        }
    }
}