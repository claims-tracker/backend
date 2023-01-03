using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace CT.Host.Backend.OpenApi
{
    /// <summary>
    /// Extensions methods for xml doc files
    /// </summary>
    public static class XmlDocHelper
    {
        #region Public Methods

        /// <summary>
        /// Get the xml element representing the member
        /// </summary>
        /// <param name="membersRoot"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static XElement GetDocMember(XElement membersRoot, MemberInfo member)
        {
            string memberId = GetMemberId(member);

            return membersRoot
                .Elements("member")
                .FirstOrDefault(e => e.Attribute("name")?.Value == memberId);
        }

        /// <summary>
        /// Get the xml element representing the member
        /// </summary>
        /// <param name="membersRoot"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static XElement GetTypeMember(XElement membersRoot, TypeInfo member)
        {
            string memberId = GetMemberId(member);

            return membersRoot
                .Elements("member")
                .FirstOrDefault(e => e.Attribute("name")?.Value == memberId);
        }

        /// <summary>
        /// Find the XML documentation files for a given assembly
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static FileInfo GetXmlDocFile(Assembly assembly, CultureInfo culture = null)
        {
            var fileName = Path.GetFileNameWithoutExtension(assembly.Location) + ".xml";

            return EnumeratePossibleXmlDocumentationLocation(assembly, culture ?? CultureInfo.CurrentCulture)
                       .Select(directory => Path.Combine(directory, fileName))
                       .Select(filePath => new FileInfo(filePath))
                       .FirstOrDefault(file => file.Exists);
        }

        #endregion Public Methods

        #region Private Methods

        private static IEnumerable<string> EnumeratePossibleXmlDocumentationLocation(Assembly assembly, CultureInfo culture)
        {
            var currentCulture = culture;

            var locations = new[]
            {
                new FileInfo(assembly.Location)?.Directory?.FullName,
                AppContext.BaseDirectory
            };

            foreach (var location in locations)
            {
                while (currentCulture.Name != CultureInfo.InvariantCulture.Name)
                {
                    yield return Path.Combine(location, currentCulture.Name);
                    currentCulture = currentCulture.Parent;
                }

                yield return Path.Combine(location, String.Empty);
            }
        }

        private static string GetMemberFullName(MemberInfo member)
        {
            var memberScope = "";

            if (member.DeclaringType != null)
                memberScope = GetMemberFullName(member.DeclaringType);
            else if (member is Type type)
                memberScope = type.Namespace;

            return $"{memberScope}.{member.Name}";
        }

        private static string GetMemberId(MemberInfo member)
        {
            var memberKindPrefix = GetMemberPrefix(member);
            var memberName = GetMemberFullName(member);

            return $"{memberKindPrefix}:{memberName}";
        }

        private static char GetMemberPrefix(MemberInfo member)
        {
            var typeName = member.GetType().Name;

            switch (typeName)
            {
                case "MdFieldInfo": return 'F';

                default:
                    return typeName.Replace("Runtime", "")[0];
            }
        }

        #endregion Private Methods
    }

    /// <summary>
    /// Add enum description to swagger gen files
    /// </summary>
    public class EnumDescriptorSchemaFilter : ISchemaFilter
    {
        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            var typeInfo = context.Type.GetTypeInfo();

            if (typeInfo.IsEnum)
            {
                schema.Description = BuildDescription(typeInfo);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static string BuildDescription(TypeInfo typeInfo)
        {
            var docMembers = LoadXmlMembers(typeInfo);
            if (docMembers == null)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();

            var docMember = XmlDocHelper.GetTypeMember(docMembers, typeInfo);
            if (docMember != null)
            {
                stringBuilder.AppendLine(docMember.Value.Trim());
            }
            stringBuilder.AppendLine();

            BuildMembersDescription(typeInfo, stringBuilder, docMembers);

            return stringBuilder.ToString();
        }

        private static void BuildMembersDescription(TypeInfo typeInfo, StringBuilder stringBuilder, XElement docMembers)
        {
            var enumValues = Enum.GetValues(typeInfo);

            for (int i = 0; i < enumValues.Length; i++)
            {
                var enumValue = enumValues.GetValue(i);
                var member = typeInfo.GetMember(enumValue.ToString()).Single();
                var docMember = XmlDocHelper.GetDocMember(docMembers, member);
                if (docMember != null)
                {
                    string description = docMember.Value.Trim();

                    stringBuilder.AppendFormat("* **{0}** - {1}", (int)enumValue, description);
                    stringBuilder.AppendLine();
                }
            }
        }

        private static XElement LoadXmlMembers(TypeInfo typeInfo)
        {
            var file = XmlDocHelper.GetXmlDocFile(typeInfo.Assembly);
            if (file != null)
            {
                var docXml = XDocument.Load(file.FullName);
                var xmlRoot = docXml.Root;

                if (xmlRoot == null)
                {
                    return null;
                }

                return xmlRoot.Element("members");
            }
            return null;
        }

        #endregion Private Methods
    }
}