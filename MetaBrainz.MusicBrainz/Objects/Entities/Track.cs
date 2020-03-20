﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using JetBrains.Annotations;

using MetaBrainz.Common.Json;
using MetaBrainz.MusicBrainz.Interfaces.Entities;

namespace MetaBrainz.MusicBrainz.Objects.Entities {

  [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
  internal sealed class Track : JsonBasedObject, ITrack {

    [JsonPropertyName("id")]
    public Guid MbId { get; set; }

    [JsonPropertyName("artist-credit")]
    public IReadOnlyList<INameCredit>? ArtistCredit { get; set; }

    [JsonPropertyName("length")]
    public int? Length { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("position")]
    public int? Position { get; set; }

    [JsonPropertyName("recording")]
    public IRecording? Recording { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    public override string ToString() {
      var text = string.Empty;
      if (this.Number != null)
        text += $"{this.Number}. ";
      if (this.ArtistCredit != null) {
        foreach (var nc in this.ArtistCredit)
          text += nc.ToString();
        text += " / ";
      }
      text += this.Title;
      if (this.Length.HasValue) {
        var ts = new TimeSpan(0, 0, 0, 0, this.Length.Value);
        text += $" ({ts:g})";
      }
      return text;
    }

  }

}
