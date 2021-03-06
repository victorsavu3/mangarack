﻿// ======================================================================
// This source code form is subject to the terms of the Mozilla Public
// License, version 2.0. If a copy of the MPL was not distributed with 
// this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// ======================================================================
using System.Text.RegularExpressions;

namespace MangaRack.Provider.MangaFox {
	/// <summary>
	/// Represents a MangaFox provider.
	/// </summary>
	sealed class Provider : IProvider {
		#region IProvider:Methods
		/// <summary>
		/// Open a series.
		/// </summary>
		/// <param name="UniqueIdentifier">The unique identifier.</param>
		public ISeries Open(string UniqueIdentifier) {
			// Check if the unique identifier can be handled.
			if (Regex.Match(UniqueIdentifier, @"^http://mangafox\.(com|me)/manga/(.*)/$", RegexOptions.IgnoreCase).Success) {
				// Initialize a new instance of the Series class.
				return new Series(UniqueIdentifier);
			}
			// Return null.
			return null;
		}

		/// <summary>
		/// Search series.
		/// </summary>
		/// <param name="Input">The input.</param>
		public ISearch Search(string Input) {
			// Initialize a new instance of the Search class.
			return new Search(Input);
		}
		#endregion

		#region IProvider:Properties
		/// <summary>
		/// Contains the unique identifier.
		/// </summary>
		public string UniqueIdentifier {
			get {
				// Return the unique identifier.
				return "MangaFox";
			}
		}
		#endregion
	}
}