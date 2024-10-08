﻿namespace Demo.Clip01
{
    public class Video : IEquatable<Video>
    {
        public string Title { get; }
        public string Handle { get; }

        public Video(string title, string handle)
        {
            this.Title = title;
            this.Handle = handle;
        }

        public bool Equals(Video other) =>
            other.GetType() == typeof(Video) &&
            other.Title.Equals(this.Title);

        public override bool Equals(object obj) =>
            obj is Video video && this.Equals(video);

        public override int GetHashCode() =>
            this.Title?.GetHashCode() ?? 0;

        public override string ToString() =>
            this.Title;
    }
}
