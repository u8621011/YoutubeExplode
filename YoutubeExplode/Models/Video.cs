using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using YoutubeExplode.Internal;
using YoutubeExplode.Models.ClosedCaptions;

namespace YoutubeExplode.Models
{
    /// <summary>
    /// Information about a YouTube video.
    /// </summary>
    public class Video {
        /// <summary>
        /// ID of this video.
        /// </summary>
        [NotNull]
        public string Id { get; }

        /// <summary>
        /// Author of this video.
        /// </summary>
        [NotNull]
        public string Author { get; }

        /// <summary>
        /// ID of the channel this Video belongs to.
        /// It seems would be possible be null if this Video object is retrieved with playlist retrieve function
        /// </summary>
        public string ChannelId { get; }

        /// <summary>
        /// Upload date of this video.
        /// </summary>
        public DateTimeOffset UploadDate { get; }

        /// <summary>
        /// Title of this video.
        /// </summary>
        [NotNull]
        public string Title { get; }

        /// <summary>
        /// Description of this video.
        /// </summary>
        [NotNull]
        public string Description { get; }

        /// <summary>
        /// Thumbnails of this video.
        /// </summary>
        [NotNull]
        public ThumbnailSet Thumbnails { get; }

        /// <summary>
        /// Duration of this video.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Search keywords of this video.
        /// </summary>
        [NotNull, ItemNotNull]
        public IReadOnlyList<string> Keywords { get; }

        /// <summary>
        /// Statistics of this video.
        /// </summary>
        [NotNull]
        public Statistics Statistics { get; }

        public IReadOnlyList<ClosedCaptionTrackInfo> CaptionTrackInfos { get; }

        /// <summary>
        /// Initializes an instance of <see cref="Video"/>.
        /// </summary>
        public Video(string id, string channelId, string author, DateTimeOffset uploadDate, string title, string description,
            ThumbnailSet thumbnails, TimeSpan duration, IReadOnlyList<string> keywords, Statistics statistics,
            IReadOnlyList<ClosedCaptionTrackInfo> trackInfos)
        {
            Id = id.GuardNotNull(nameof(id));
            ChannelId = channelId.GuardNotNull(nameof(channelId));
            Author = author.GuardNotNull(nameof(author));
            UploadDate = uploadDate;
            Title = title.GuardNotNull(nameof(title));
            Description = description.GuardNotNull(nameof(description));
            Thumbnails = thumbnails.GuardNotNull(nameof(thumbnails));
            Duration = duration.GuardNotNegative(nameof(duration));
            Keywords = keywords.GuardNotNull(nameof(keywords));
            Statistics = statistics.GuardNotNull(nameof(statistics));
            CaptionTrackInfos = trackInfos;
        }

        /// <inheritdoc />
        public override string ToString() => Title;
    }
}