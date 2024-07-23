using CollectionViewPerformanceXamarin.Enums;
using CollectionViewPerformanceXamarin.Helpers;
using CollectionViewPerformanceXamarin.Resources.Fonts;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CollectionViewPerformanceXamarin.Models
{
    public sealed class Data
    {
        public Template Template { get; set; }

        public string RestaurantName { get; set; } = string.Empty;

        public string RestaurantDescription { get; set; } = string.Empty;

        public string RestaurantAddress { get; set; } = string.Empty;

        public string Rating { get; set; } = string.Empty;

        public string Review { get; set; } = string.Empty;

        public List<string> Reviews { get; set; } = new();

        public List<string> SocialMedia { get; set; } = new();

        public ImageSource PhotoImageSource { get; set; } = null;

        List<string> imageStrings = new() {
                "CollectionViewPerformanceXamarin.Resources.Photos.cat1.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat2.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat3.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat4.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat5.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat6.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat7.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat8.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat9.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat10.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat11.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat12.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat13.jpg",
                "CollectionViewPerformanceXamarin.Resources.Photos.cat14.jpg",
            };

        public Data()
        {
            var random = new Random();

            this.Template = Template.CardWithTheLot;
            this.RestaurantName = RandomContentHelper.GenerateRandomRestaurantName();
            this.RestaurantDescription = RandomContentHelper.GenerateRandomSentence(5);
            this.RestaurantAddress = RandomContentHelper.GenerateRandomAddress();

            this.Rating = RandomContentHelper.GenerateRandomRating();

            this.Review = RandomContentHelper.GenerateRandomSentence(random.Next(6, 12));
            this.Reviews = new List<string>()
            {
                RandomContentHelper.GenerateRandomSentence(random.Next(6, 12)),
                RandomContentHelper.GenerateRandomSentence(random.Next(6, 12)),
                RandomContentHelper.GenerateRandomSentence(random.Next(6, 12))
            };

            this.SocialMedia = new List<string>()
            {
                FontAwesome.Instagram,
                FontAwesome.Facebook,
                FontAwesome.Tiktok,
            };
            this.PhotoImageSource = ImageSource.FromResource(imageStrings[new Random().Next(0,imageStrings.Count)]);

            // random.Next(0, 2) == 1; // 50/50 chance
        }
    }
}
