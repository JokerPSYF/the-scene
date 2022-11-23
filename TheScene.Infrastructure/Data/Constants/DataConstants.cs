namespace TheScene.Infrastructure.Data.Constants
{
    /// <summary>
    /// Data constats of all properties of entities.
    /// </summary>
    public static class DataConstants
    {
        /// <summary>
        /// This is a default error message
        /// </summary>
        public const string LengthErrorMessage = "The length of {0} has to be between {2} and {1}";

        /// <summary>
        /// Data Constants for 'Genre' entity
        /// </summary>
        public static class GenreConstants
        {
            /// <summary>
            /// Name maximum lentgth constant
            /// </summary>
            public const int MaxName = 20;
        }

        /// <summary>
        /// Data Constants for 'PerfomanceType' entity
        /// </summary>
        public static class PerfomanceTypeConstants
        {
            /// <summary>
            /// Name maximum lentgth constant
            /// </summary>
            public const int MaxName = 20;

            /// <summary>
            /// Name maximum lentgth constant
            /// </summary>
            public const int MinName = 4;
        }

        /// <summary>
        /// Data Constants for 'PlaceType' entity
        /// </summary>
        public static class PlaceTypeConstants
        {
            /// <summary>
            /// Name maximum lentgth constant
            /// </summary>
            public const int MaxName = 20;

            /// <summary>
            /// Name maximum lentgth constant
            /// </summary>
            public const int MinName = 4;
        }

        /// <summary>
        /// Data Constants for 'Perfomance' entity
        /// </summary>
        public static class PerfomanceConstants
        {
            /// <summary>
            /// Name maximum lentgth constant
            /// </summary>
            public const int MaxName = 250;

            /// <summary>
            /// Name maximum lentgth constant
            /// </summary>
            public const int MinName = 1;

            /// <summary>
            /// Dirrector name maximum lentgth constant
            /// </summary>
            public const int MaxDirector = 60;

            /// <summary>
            /// Dirrector name maximum lentgth constant
            /// </summary>
            public const int MinDirector = 2;

            /// <summary>
            /// Actors name maximum lentgth constant
            /// </summary>
            public const int MaxActors = 2000;

            /// <summary>
            /// Actors name maximum lentgth constant
            /// </summary>
            public const int MinActors = 2;

            /// <summary>
            /// Description maximum lentgth constant
            /// </summary>
            public const int MaxDescription = 2000;

            /// <summary>
            /// ImageUrl maximum lentgth constant
            /// </summary>
            public const int MaxImageURL = 2000;

            /// <summary>
            /// Year maximum constant
            /// </summary>
            public const int MaxYear = 2023;

            /// <summary>
            /// Year maximum constant
            /// </summary>
            public const int MinYear = 1975;
        }

        /// <summary>
        /// Data Constants for 'Location' entity
        /// </summary>
        public static class LocationConstants
        {
            /// <summary>
            /// Name maximum length constant
            /// </summary>
            public const int MaxName = 100;

            /// <summary>
            /// Name minimum length constant
            /// </summary>
            public const int MinName = 1;

            /// <summary>
            /// Address maximum lentgth constant
            /// </summary>
            public const int MaxAddress = 255;

            /// <summary>
            /// Address minimum lentgth constant
            /// </summary>
            public const int MinAddress = 500;
        }

        /// <summary>
        /// Data Constants for 'Event' entity
        /// </summary>
        public static class EventConstants
        {
            /// <summary>
            /// Seats maximum lentgth constant
            /// </summary>
            public const int MaxSeats = 1000000;

            /// <summary>
            /// Seats minimum lentgth constant
            /// </summary>
            public const int MinSeats = 0;

            /// <summary>
            /// Price maximum lentgth constant
            /// </summary>
            public const double MaxPrice = 1000000;

            /// <summary>
            /// Price minimum lentgth constant
            /// </summary>
            public const double MinPrice = 0;

            public const string RangerErrorMessage = "The range of {0} has to be between {2} and {1}";
        }
    }
}
