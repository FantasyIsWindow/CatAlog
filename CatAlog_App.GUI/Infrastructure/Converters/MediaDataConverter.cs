using CatAlog_App.GUI.Models;
using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CatAlog_App.GUI.Infrastructure.Converters
{
    public class MediaDataConverter : IValueConverter
    {
        private StringBuilder _builder;

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

        private string GetShortInfoString(VideoDataModel v)
        {
            _builder = new StringBuilder("Video " + v.Number + ":\n");
            _builder.Append(v.Note != null ? " (" + v.Note + ")\n" : "");
            _builder.Append(v.VideoQuality != null ? v.VideoQuality + " | " : "");
            _builder.Append
                (
                    v.WidthR != 0 && v.HeigthR != 0 ? v.WidthR.ToString() + 'x' + v.HeigthR.ToString() :
                    v.HeigthR != 0 && v.WidthR == 0 ? v.HeigthR.ToString() + "p " : ""
                );
            _builder.Append(v.Relation != null ? " (" + v.Relation + ") | " : "");
            _builder.Append(v.VideoFormat != null ? v.VideoFormat + " | " : "");
            _builder.Append(v.Bitrate != null ? v.Bitrate.ToString() + " kb/s | " : "");
            _builder.Append(v.FrameRate != null ? v.FrameRate.ToString() + " FPS" : "");
            return _builder.ToString();
        }

        private string GetFullInfoString(VideoDataModel v)
        {
            _builder = new StringBuilder("Video " + v.Number + ":\n");
            _builder.Append(v.Note != null ? " (" + v.Note + ")\n" : "");
            _builder.Append(v.VideoQuality != null ? "\tКачество видео: " + v.VideoQuality + '\n' : "");
            _builder.Append(v.VideoFormat != null ? "\tФормат: " + v.VideoFormat + '\n' : "");
            _builder.Append(v.Relation != null ? "\tСоотношение: " + v.Relation + '\n' : "");
            _builder.Append(v.Bitrate != null ? "\tБитрейт: " + v.Bitrate.ToString() + " kb/s\n" : "");
            _builder.Append
                (
                    v.WidthR != 0 && v.HeigthR != 0 ? "\tРазрешение: " + v.WidthR.ToString() + 'x' + v.HeigthR.ToString() + '\n' :
                    v.HeigthR != 0 && v.WidthR == 0 ? "\tРазрешение: " + v.HeigthR.ToString() + "p\n" : ""
                );
            _builder.Append(v.FrameRate != null ? "\tЧастота: " + v.FrameRate.ToString() + " FPS\n" : "");
            return _builder.ToString();
        }

        #endregion

        #region AUDIO_PROCESSOR_INFORMATION

        private string GetShortInfoString(AudioDataModel a)
        {
            _builder = new StringBuilder("Audio track " + a.Number + ":\n");
            _builder.Append(a.AudioFormat != null ? a.AudioFormat + " | " : "");
            _builder.Append(a.Frequency != 0 ? a.Frequency + " kHz | " : "");
            _builder.Append(a.Channel != null ? a.Channel + " ch | " : "");
            _builder.Append(a.Bitrate != 0 ? a.Bitrate + " kbps " : "");
            _builder.Append(a.Language != null ? "\nLanguage: " + a.Language + " " : "");
            _builder.Append
                (
                    a.Note != null && a.Author != null ? a.Note + " (" + a.Author + ")." :
                    a.Note != null ? a.Author + '.' :
                    a.Author != null ? a.Author + '.' : ""
                );
            return _builder.ToString();
        }

        private string GetFullInfoString(AudioDataModel a)
        {
            _builder = new StringBuilder("Audio track " + a.Number.ToString() + ":\n");
            _builder.Append(a.AudioFormat != null ? "\tFormat: " + a.AudioFormat + '\n' : "");
            _builder.Append(a.Channel != null ? "\tChannels: " + a.Channel + " ch\n" : "");
            _builder.Append(a.Frequency != 0 ? "\tFrequency: " + a.Frequency + " kHz\n" : "");
            _builder.Append(a.Bitrate != 0 ? "\tBitrate: " + a.Bitrate + " kbps\n" : "");
            _builder.Append(a.Language != null ? "\tLanguage: " + a.Language + '\n' : "");
            _builder.Append
                (
                    a.Author != null && a.Note != null ? "\tAuthor: " + a.Author + "\n\tType: " + a.Note :
                    a.Author != null ? "\tAuthor: " + a.Author :
                    a.Note != null ? "\tType: " + a.Note : ""
                );
            return _builder.ToString();
        }

        #endregion

        #region SUBTITLE_PROCESSOR_INFORMATION

        private string GetShortInfoString(SubtitleDataModel s)
        {
            _builder = new StringBuilder("Subtitle: " + s.Number + ":\n");
            _builder.Append(s.Language != null ? s.Language : "");
            _builder.Append(s.SubtitleFormat != null ? " | " + s.SubtitleFormat : "");
            _builder.Append(s.Author != null ? " | " + s.Author : "");
            _builder.Append(s.Note != null ? " (" + s.Note + ')' : "");
            return _builder.ToString();
        }

        private string GetFullInfoString(SubtitleDataModel s)
        {
            _builder = new StringBuilder("Subtitle: " + s.Number + ":\n");
            _builder.Append(s.Language != null ? "\tЯзык: " + s.Language + '\n' : "");
            _builder.Append(s.SubtitleFormat != null ? "\tФормат: " + s.SubtitleFormat + '\n' : "");
            _builder.Append(s.Author != null ? "\tАвтор: " + s.Author + '\n' : "");
            _builder.Append(s.Note != null ? "\tТип: " + s.Note + '\n' : "");
            return _builder.ToString();
        }

        #endregion

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}
