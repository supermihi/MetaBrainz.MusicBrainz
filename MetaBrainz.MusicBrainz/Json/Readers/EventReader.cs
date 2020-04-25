using System;
using System.Collections.Generic;
using System.Text.Json;

using MetaBrainz.Common.Json;
using MetaBrainz.Common.Json.Converters;
using MetaBrainz.MusicBrainz.Interfaces.Entities;
using MetaBrainz.MusicBrainz.Objects.Entities;

namespace MetaBrainz.MusicBrainz.Json.Readers {

  internal sealed class EventReader : ObjectReader<Event> {

    public static readonly EventReader Instance = new EventReader();

    protected override Event ReadObjectContents(ref Utf8JsonReader reader, JsonSerializerOptions options) {
      IReadOnlyList<IAlias>? aliases = null;
      string? annotation = null;
      var cancelled = false;
      string? disambiguation = null;
      IReadOnlyList<IGenre>? genres = null;
      Guid? id = null;
      ILifeSpan? lifeSpan = null;
      string? name = null;
      IRating? rating = null;
      IReadOnlyList<IRelationship>? relations = null;
      string? setlist = null;
      IReadOnlyList<ITag>? tags = null;
      string? time = null;
      string? type = null;
      Guid? typeId = null;
      IReadOnlyList<IGenre>? userGenres = null;
      IRating? userRating = null;
      IReadOnlyList<ITag>? userTags = null;
      Dictionary<string, object?>? rest = null;
      while (reader.TokenType == JsonTokenType.PropertyName) {
        var prop = reader.GetString();
        try {
          reader.Read();
          switch (prop) {
            case "aliases":
              aliases = reader.ReadList(AliasReader.Instance, options);
              break;
            case "annotation":
              annotation = reader.GetString();
              break;
            case "cancelled":
              cancelled = reader.GetOptionalBoolean() ?? false;
              break;
            case "disambiguation":
              disambiguation = reader.GetString();
              break;
            case "genres":
              genres = reader.ReadList(GenreReader.Instance, options);
              break;
            case "id":
              id = reader.GetGuid();
              break;
            case "life-span":
              lifeSpan = reader.GetObject(LifeSpanReader.Instance, options);
              break;
            case "name":
              name = reader.GetString();
              break;
            case "rating":
              rating = reader.GetObject(RatingReader.Instance, options);
              break;
            case "relations":
              relations = reader.ReadList(RelationshipReader.Instance, options);
              break;
            case "setlist":
              setlist = reader.GetString();
              break;
            case "tags":
              tags = reader.ReadList(TagReader.Instance, options);
              break;
            case "time":
              time = reader.GetString();
              break;
            case "type":
              type = reader.GetString();
              break;
            case "type-id":
              typeId = reader.GetOptionalGuid();
              break;
            case "user-genres":
              userGenres = reader.ReadList(GenreReader.Instance, options);
              break;
            case "user-rating":
              userRating = reader.GetObject(RatingReader.Instance, options);
              break;
            case "user-tags":
              userTags = reader.ReadList(TagReader.Instance, options);
              break;
            default:
              rest ??= new Dictionary<string, object?>();
              rest[prop] = reader.GetOptionalObject(options);
              break;
          }
        }
        catch (Exception e) {
          throw new JsonException($"Failed to deserialize the '{prop}' property.", e);
        }
        reader.Read();
      }
      if (!id.HasValue)
        throw new JsonException("Expected property 'id' not found or null.");
      return new Event(id.Value) {
        Aliases = aliases,
        Annotation = annotation,
        Cancelled = cancelled,
        Disambiguation = disambiguation,
        Genres = genres,
        LifeSpan = lifeSpan,
        Name = name,
        Rating = rating,
        Relationships = relations,
        Setlist = setlist,
        Tags = tags,
        Time = time,
        Type = type,
        TypeId = typeId,
        UnhandledProperties = rest,
        UserGenres = userGenres,
        UserRating = userRating,
        UserTags = userTags,
      };
    }

  }

}
