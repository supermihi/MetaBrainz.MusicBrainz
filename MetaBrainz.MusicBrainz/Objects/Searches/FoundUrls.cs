﻿using System;
using System.Collections.Generic;

using MetaBrainz.MusicBrainz.Interfaces.Entities;
using MetaBrainz.MusicBrainz.Interfaces.Searches;

namespace MetaBrainz.MusicBrainz.Objects.Searches {

  internal sealed class FoundUrls : SearchResults<ISearchResult<IUrl>> {

    public FoundUrls(Query query, string queryString, int? limit = null, int? offset = null)
    : base(query, "url", queryString, limit, offset)
    { }

    public override IReadOnlyList<ISearchResult<IUrl>> Results => this.CurrentResult?.Urls ?? Array.Empty<ISearchResult<IUrl>>();

  }

}
