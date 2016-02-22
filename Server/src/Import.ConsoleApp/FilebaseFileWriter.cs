using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Humanizer;
using Newtonsoft.Json;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories;

namespace ScotlandsMountains.Import.ConsoleApp
{
    public static class FilebaseFileWriter
    {
        public static void Write(EntityFactory entityFactory, string firebaseJsonPath)
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            
            using(JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.Formatting = Formatting.Indented;
                jsonWriter.WriteStartObject();
                WriteEntities(entityFactory, jsonWriter);
                jsonWriter.WriteEndObject();
            }

            using (var streamWriter = new StreamWriter(firebaseJsonPath))
                streamWriter.WriteLine(sb.ToString());
        }

        private static void WriteEntities(EntityFactory entityFactory, JsonWriter jsonWriter)
        {
            var writer = new Writer(jsonWriter, entityFactory);
            writer.WriteSections();
            writer.Islands();
            writer.Counties();
            writer.TopologicalSections();
            writer.Maps();
            writer.Classifications();
            writer.Mountains();
        }

        private class Writer
        {
            public Writer(JsonWriter writer, EntityFactory entityFactory)
            {
                _writer = writer;
                _entityFactory = entityFactory;
            }

            public void WriteSections()
            {
                WriteMountainContainerCollection(
                    entityFactory => entityFactory.Sections,
                    sectionCollection =>
                    {
                        WriteProperty(sectionCollection, section => section.Code);
                        WriteProperty(sectionCollection, section => section.Name);
                    });
            }

            public void Islands()
            {
                WriteMountainContainerCollection(
                    entityFactory => entityFactory.Islands,
                    islandCollection =>
                    {
                        WriteProperty(islandCollection, island => island.Name);
                    });
            }

            public void Counties()
            {
                WriteMountainContainerCollection(
                    entityFactory => entityFactory.Counties,
                    countyCollection =>
                    {
                        WriteProperty(countyCollection, county => county.Name);
                    });
            }

            public void TopologicalSections()
            {
                WriteMountainContainerCollection(
                    entityFactory => entityFactory.TopologicalSections,
                    topologicalSectionCollection =>
                    {
                        WriteProperty(topologicalSectionCollection, topologicalSection => topologicalSection.Code);
                        WriteProperty(topologicalSectionCollection, topologicalSection => topologicalSection.Name);
                    });
            }

            public void Maps()
            {
                WriteMountainContainerCollection(
                    entityFactory => entityFactory.Maps,
                    mapCollection =>
                    {
                        WriteProperty(mapCollection, map => map.Code);
                        WriteProperty(mapCollection, map => map.Name);
                        WriteProperty(mapCollection, map => map.Publisher);
                        WriteProperty(mapCollection, map => map.Series);
                        WriteProperty(mapCollection, map => map.Scale);
                        WriteProperty(mapCollection, map => map.Isbn);
                    });
            }

            public void Classifications()
            {
                WriteMountainContainerCollection(entityFactory => entityFactory.Classifications, x =>
                {
                    WriteProperty(x, y => y.Name);
                });
            }

            public void Mountains()
            {
                _writer.WritePropertyName(MountainsPropertyName);
                _writer.WriteStartObject();
                foreach (var mountain in _entityFactory.Mountains)
                {
                    _writer.WritePropertyName(mountain.Key);

                    _writer.WriteStartObject();

                    WriteProperty(mountain, x => x.DobihId);
                    WriteProperty(mountain, x => x.Name);
                    WriteProperty(mountain, x => x.SummitFeature);
                    WriteProperty(mountain, x => x.SummitObservations);

                    WriteValueTypeProperty(mountain, x => x.Height);
                    WriteValueTypeProperty(mountain, x => x.Location);
                    WriteValueTypeProperty(mountain, x => x.Prominence);

                    WriteContainerKey(mountain, x => x.Section);
                    WriteContainerKey(mountain, x => x.Island);
                    WriteContainerKey(mountain, x => x.TopologicalSection);

                    WriteContainerKeys(mountain, x => x.Counties);
                    WriteContainerKeys(mountain, x => x.Maps);
                    WriteContainerKeys(mountain, x => x.Classifications);

                    _writer.WriteEndObject();
                }
                _writer.WriteEndObject();


            }

            private void WriteMountainContainerCollection<T>(Expression<Func<EntityFactory, IEnumerable<T>>> expression, Action<T> writeProperties)
                where T : MountainContainer
            {
                var body = expression.Body as MemberExpression;
                var propertyInfo = body.Member as PropertyInfo;
                _writer.WritePropertyName(propertyInfo.Name.Camelize());
                _writer.WriteStartObject();

                foreach (var item in (IEnumerable<T>)propertyInfo.GetValue(_entityFactory))
                {
                    _writer.WritePropertyName(item.Key);
                    _writer.WriteStartObject();
                    writeProperties(item);
                    WriteMountains(item);
                    _writer.WriteEndObject();
                }

                _writer.WriteEndObject();
            }

            private void WriteProperty<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> expression)
            {
                var body = expression.Body as MemberExpression;
                var propertyInfo = body.Member as PropertyInfo;
                _writer.WritePropertyName(propertyInfo.Name.Camelize());
                _writer.WriteValue(propertyInfo.GetValue(entity));
            }

            private void WriteValueTypeProperty<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> expression)
            {
                var body = expression.Body as MemberExpression;
                var propertyInfo = body.Member as PropertyInfo;
                _writer.WritePropertyName(propertyInfo.Name.Camelize());
                _writer.WriteRawValue(JsonConvert.SerializeObject(propertyInfo.GetValue(entity), Formatting.Indented));
            }

            private void WriteMountains(MountainContainer container)
            {
                _writer.WritePropertyName(MountainsPropertyName);
                _writer.WriteStartObject();
                foreach (var mountain in container.Mountains)
                {
                    _writer.WritePropertyName(mountain.Key);
                    _writer.WriteValue(true);
                }
                _writer.WriteEndObject();
            }

            private void WriteContainerKey<T>(Mountain mountain, Expression<Func<Mountain, T>> expression) where T : MountainContainer
            {
                var body = expression.Body as MemberExpression;
                var propertyInfo = body.Member as PropertyInfo;
                _writer.WritePropertyName(propertyInfo.Name.Camelize());

                var value = propertyInfo.GetValue(mountain) as MountainContainer;
                if (value != null)
                    _writer.WriteValue(value.Key);
                else
                    _writer.WriteNull();
            }

            private void WriteContainerKeys<T>(Mountain mountain, Expression<Func<Mountain, IEnumerable<T>>> expression) where T : MountainContainer
            {
                var body = expression.Body as MemberExpression;
                var propertyInfo = body.Member as PropertyInfo;
                _writer.WritePropertyName(propertyInfo.Name.Camelize());

                _writer.WriteStartObject();
                foreach (var item in propertyInfo.GetValue(mountain) as IEnumerable<MountainContainer>)
                {
                    _writer.WritePropertyName(item.Key);
                    _writer.WriteValue(true);
                }
                _writer.WriteEndObject();
            }

            private const string MountainsPropertyName = "mountains";
            private readonly JsonWriter _writer;
            private readonly EntityFactory _entityFactory;
        }
    }
}
