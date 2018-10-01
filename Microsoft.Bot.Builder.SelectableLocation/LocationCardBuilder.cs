namespace Microsoft.Bot.Builder.SelectableLocation
{
    using Microsoft.Bot.Builder.Internals.Fibers;
    using Microsoft.Bot.Connector;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A class for creating location cards.
    /// </summary>
    [Serializable]
    public class LocationCardBuilder 
    {
        private readonly string _apiKey;
       
        public LocationCardBuilder(string apiKey)
        {
            SetField.NotNull(out _apiKey, nameof(apiKey), apiKey);
        }

        /// <summary>
        /// Creates locations hero cards.
        /// </summary>
        /// <param name="locations">List of the locations.</param>
        /// <param name="locationNames">List of strings that can be used as names or labels for the locations.</param>
        /// <param name="locationIds">List of strings that can be used as ids for the locations.</param>
        /// <param name="selectText">Button text.</param>
        /// <returns>The locations card as a list.</returns>
        public IEnumerable<HeroCard> CreateHeroCards(IList<Location> locations, IList<string> locationNames = null, IList<string> locationIds = null, string selectText = "Select")
        {
            var cards = new List<HeroCard>();

            var i = 1;

            foreach (var location in locations)
            {
                var nameString = locationNames == null ? string.Empty : $"{locationNames[i - 1]}: ";
                var locationString = $"{nameString}{location.GetFormattedAddress(",")}";
                var address = locationString;

                var heroCard = new HeroCard
                {
                    Subtitle = address
                };

                if (location.Point != null)
                {
                    var image =
                        new CardImage(
                            url: new BingGeoSpatialService(this._apiKey).GetLocationMapImageUrl(location, i));

                    heroCard.Images = new[] { image };
                    
                }
                if (locationIds != null)
                    heroCard.Buttons = new List<CardAction> { new CardAction(ActionTypes.PostBack, selectText, null, locationIds[i - 1]) };

                cards.Add(heroCard);

                i++;
            }

            return cards;
        }
    }
}