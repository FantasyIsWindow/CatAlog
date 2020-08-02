using CatAlog_App.GUI.Models;
using System;
using System.Globalization;
using System.Windows.Data;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class MediaDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string viewSwitch = parameter as string;
            switch (value)
            {
                case VideoDataModel video:
                    {
                        if (viewSwitch == "compact")
                        {
                            return GetShortInfoString(video);
                        }
                        else if (viewSwitch == "extended")
                        {
                            return GetFullInfoString(video);
                        }
                        break;
                    }
                case AudioDataModel audio:
                    {
                        if (viewSwitch == "compact")
                        {
                            return GetShortInfoString(audio);
                        }
                        else if (viewSwitch == "extended")
                        {
                            return GetFullInfoString(audio);
                        }
                        break;
                    }
                case SubtitleDataModel subtitle:
                    {
                        if (viewSwitch == "compact")
                        {
                            return GetShortInfoString(subtitle);
                        }
                        else if (viewSwitch == "extended")
                        {
                            return GetFullInfoString(subtitle);
                        }
                        break;
                    }
                default:
                    return null;
            }
            return null;
        }

        #region VIDEO_PROCESSOR_INFORMATION

        private string GetShortInfoString(VideoDataModel video)
        {
            string id = "Video: " + video.Number + " ";
            string note = video.Note != null ? " (" + video.Note + ")\n" : "";
            string quality = video.VideoQuality != null ? video.VideoQuality + " | " : "";
            string width = video.ResolutionWidth.ToString();
            string heigth = video.ResolutionHeigth.ToString();
            string resolution = width != null && heigth != null ? width + 'x' + heigth :
                                heigth != null && width == null ? heigth + "p " : "";
            string relation = video.Relation != null ? " (" + video.Relation + ") | " : "";
            string videoFormat = video.VideoFormat != null ? video.VideoFormat + " | " : "";
            string bitrate = video.Bitrate != null ? video.Bitrate.ToString() + " kb/s | " : "";
            string frameRate = video.FrameRate != null ? video.FrameRate.ToString() + " FPS" : "";

            return $"{id}{note}{quality}{resolution}{relation}{videoFormat}{bitrate}{frameRate}";
        }

        private string GetFullInfoString(VideoDataModel video)
        {
            string id = "Video: " + video.Number + '\n';
            string note = video.Note != null ? " (" + video.Note + ")\n" : "";
            string quality = video.VideoQuality != null ? "\tКачество видео: " + video.VideoQuality + '\n' : "";
            string videoFormat = video.VideoFormat != null ? "\tФормат: " + video.VideoFormat + '\n' : "";
            string relation = video.Relation != null ? "\tСоотношение: " + video.Relation + '\n' : "";
            string bitrate = video.Bitrate != null ? "\tБитрейт: " + video.Bitrate.ToString() + " kb/s\n" : "";

            string width = video.ResolutionWidth.ToString();
            string heigth = video.ResolutionHeigth.ToString();
            string resolution = width != null && heigth != null ? "\tРазрешение: " + width + 'x' + heigth + '\n' :
                                heigth != null && width == null ? "\tРазрешение: " + heigth + "p\n" : "";

            string frameRate = video.FrameRate != null ? "\tЧастота: " + video.FrameRate.ToString() + " FPS\n" : "";
            return $"{id}{note}{quality}{videoFormat}{bitrate}{resolution}{relation}{frameRate}";
        }

        #endregion

        #region AUDIO_PROCESSOR_INFORMATION

        private string GetShortInfoString(AudioDataModel audio)
        {
            var id = "Audio track " + audio.Number + '\n';
            var format = audio.AudioFormat != null ? audio.AudioFormat + " | " : "";
            var frequency = audio.Frequency != 0 ? audio.Frequency + " kHz | " : "";
            var channel = audio.Channel != null ? audio.Channel + " ch | " : "";
            var bitrate = audio.Bitrate != 0 ? audio.Bitrate + " kbps " : "";
            var language = audio.Language != null ? "\nLanguage: " + audio.Language + " " : "";

            var translation = audio.Note != null && audio.Author != null ? audio.Note + " (" + audio.Author + ")." :
                              audio.Note != null ? audio.Author + '.' :
                              audio.Author != null ? audio.Author + '.' : "";
            return $"{id}{format}{frequency}{channel}{bitrate}{language}{translation}";
        }

        private string GetFullInfoString(AudioDataModel audio)
        {
            var id = "Audio track " + audio.Number.ToString() + ":\n";
            var format = audio.AudioFormat != null ? "\tFormat: " + audio.AudioFormat + '\n' : "";
            var channel = audio.Channel != null ? "\tChannels: " + audio.Channel + " ch\n" : "";
            var frequency = audio.Frequency != 0 ? "\tFrequency: " + audio.Frequency + " kHz\n" : "";
            var bitrate = audio.Bitrate != 0 ? "\tBitrate: " + audio.Bitrate + " kbps\n" : "";
            var language = audio.Language != null ? "\tLanguage: " + audio.Language + '\n' : "";

            var translation = audio.Author != null && audio.Note != null ? "\tAuthor: " + audio.Author + "\n\tType: " + audio.Note :
                              audio.Author != null ? "\tAuthor: " + audio.Author :
                              audio.Note != null ? "\tType: " + audio.Note : "";
            return $"{id}{format}{channel}{frequency}{bitrate}{language}{translation}";
        }

        #endregion

        #region SUBTITLE_PROCESSOR_INFORMATION

        private string GetShortInfoString(SubtitleDataModel subtitle)
        {
            string id = "Subtitle: " + subtitle.Number + '\n';
            string language = subtitle.Language != null ? subtitle.Language : "";
            string format = subtitle.SubtitleFormat != null ? " | " + subtitle.SubtitleFormat : "";
            string author = subtitle.Author != null ? " | " + subtitle.Author : "";
            string note = subtitle.Note != null ? '(' + subtitle.Note + ')' : "";

            return $"{id}{language}{format}{author}{note}";
        }

        private string GetFullInfoString(SubtitleDataModel subtitle)
        {
            string id = "Subtitle: " + subtitle.Number + '\n';
            string language = subtitle.Language != null ? "\tЯзык: " + subtitle.Language + '\n' : "";
            string format = subtitle.SubtitleFormat != null ? "\tФормат: " + subtitle.SubtitleFormat + '\n' : "";
            string author = subtitle.Author != null ? "\tАвтор: " + subtitle.Author + '\n' : "";
            string note = subtitle.Note != null ? "\tТип: " + subtitle.Note + '\n' : "";

            return $"{id}{language}{format}{author}{note}";
        }

        #endregion

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
