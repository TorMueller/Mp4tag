using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Knuckleball
{
    /// <summary>
    /// Specifies the value for the (HD) Video Quality of an MP4 file.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32", Justification = "ContentRating is a byte in the external API.")]
    public enum HDVideo : byte
    {
        /// <summary>
        /// Indicates that the value is not set in the file.
        /// </summary>
        NotSet = byte.MaxValue,

        /// <summary>
        /// Indicates a value of "SD" (Standard Definition) has been set for the quality of this file.
        /// </summary>
        SD = 0,

        /// <summary>
        /// Indicates a value of "HD720" (High Definition 720p) has been set for the quality of this file.
        /// </summary>
        HD720 = 1,

        /// <summary>
        /// Indicates a value of "HD1080" (High Definition 1080p) has been set for the quality of this file.
        /// </summary>
        HD1080 = 2
    }

}
