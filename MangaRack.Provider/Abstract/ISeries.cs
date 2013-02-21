﻿// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MangaRack.Provider {
	/// <summary>
	/// Represents a series.
	/// </summary>
	public interface ISeries : IDisposable {
		/// <summary>
		/// Contains each artist.
		/// </summary>
		IEnumerable<string> Artists { get; }

		/// <summary>
		/// Contains each author.
		/// </summary>
		IEnumerable<string> Authors { get; }

		/// <summary>
		/// Contains each chapter.
		/// </summary>
		IEnumerable<IChapter> Chapters { get; }

		/// <summary>
		/// Contains each genre.
		/// </summary>
		IEnumerable<string> Genres { get; }

		/// <summary>
		/// Contains the preview image.
		/// </summary>
		Bitmap PreviewImage { get; }

		/// <summary>
		/// Contains the unique identifier.
		/// </summary>
		string UniqueIdentifier { get; }

		/// <summary>
		/// Contains the summary.
		/// </summary>
		string Summary { get; }

		/// <summary>
		/// Contains the title.
		/// </summary>
		string Title { get; }
	}
}