﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            /// Description name maximum lentgth constant
            /// </summary>
            public const int MaxDescription = 2000;
        }

        /// <summary>
        /// Data Constants for 'Location' entity
        /// </summary>
        public static class LocationConstants
        {
            /// <summary>
            /// Address maximum lentgth constant
            /// </summary>
            public const int MaxAddress= 255;

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
            /// Seats and price maximum lentgth constant
            /// </summary>
            public const int MaxSeats = 1000000;

            /// <summary>
            /// Seats and price minimum lentgth constant
            /// </summary>
            public const int MinSeats = 0;

            public const string RangerErrorMessage = "The range of {0} has to be between {2} and {1}";
        }
    }
}
