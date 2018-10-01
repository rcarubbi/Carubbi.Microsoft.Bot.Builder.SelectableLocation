﻿using Microsoft.Bot.Connector;

namespace Microsoft.Bot.Builder.SelectableLocation
{
    using System.Linq;

    /// <summary>
    /// Extensions for <see cref="Place"/>
    /// </summary>
    internal static class LocationExtensions
    {
        internal static string GetFormattedAddress(this Location location, string separator)
        {
            if (location?.Address == null)
            {
                return null;
            }

            return string.Join(separator, new[]
            {
                location.Address.AddressLine,
                location.Address.Locality,
                location.Address.AdminDistrict,
                location.Address.PostalCode,
                location.Address.CountryRegion
            }.Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}
