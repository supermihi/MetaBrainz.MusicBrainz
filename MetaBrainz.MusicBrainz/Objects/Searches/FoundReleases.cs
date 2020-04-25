﻿using System;
using System.Collections.Generic;

using MetaBrainz.MusicBrainz.Interfaces.Entities;
using MetaBrainz.MusicBrainz.Interfaces.Searches;

namespace MetaBrainz.MusicBrainz.Objects.Searches {

  internal sealed class FoundReleases : SearchResults<ISearchResult<IRelease>> {

    public FoundReleases(Query query, string queryString, int? limit = null, int? offset = null)
    : base(query, "release", queryString, limit, offset)
    { }

    public override IReadOnlyList<ISearchResult<IRelease>> Results => this.CurrentResult?.Releases ?? Array.Empty<ISearchResult<IRelease>>();

  }

}
