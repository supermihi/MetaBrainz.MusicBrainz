﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;
using MetaBrainz.MusicBrainz.Interfaces.Entities;
using MetaBrainz.MusicBrainz.Objects.Entities;

namespace MetaBrainz.MusicBrainz.Objects.Browses {

  internal sealed class BrowseReleases : BrowseResults<IRelease, BrowseReleases.JSON> {

    public BrowseReleases(Query query, string extra, int? limit = null, int? offset = null)
    : base(query, "release", null, extra, limit, offset) {
    }

    public override IReadOnlyList<IRelease> Results => this.CurrentResult?.Results ?? Array.Empty<IRelease>();

    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public sealed class JSON : ResultObject {

      [JsonPropertyName("releases")]
      public Release[]? Results { get; set; }

      [JsonPropertyName("release-count")]
      public override int Count { get; set; }

      [JsonPropertyName("release-offset")]
      public override int Offset { get; set; }

    }

  }

}
