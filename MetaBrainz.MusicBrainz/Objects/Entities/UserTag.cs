﻿using System.Text.Json.Serialization;

using JetBrains.Annotations;

using MetaBrainz.Common.Json;
using MetaBrainz.MusicBrainz.Interfaces.Entities;

namespace MetaBrainz.MusicBrainz.Objects.Entities {

  [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
  internal sealed class UserTag : JsonBasedObject, IUserTag {

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    public override string ToString() => this.Name ?? "";

  }

}
